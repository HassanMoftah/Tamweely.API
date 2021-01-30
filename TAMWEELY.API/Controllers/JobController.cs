using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAMWEELY.API.ActionFilters;
using TAMWEELY.DataLayer.Models;
using TAMWEELY.Repositories.Interfaces;
using TAMWEELY.ViewModels.viewmodels;

namespace TAMWEELY.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public JobController(IUnitOfWork _unitOfwork, IMapper _mapper)
        {
            unitOfWork = _unitOfwork;
            mapper = _mapper;
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetAll()
        {
            List<TbJob> jobs = unitOfWork.Jobs.GetAll().ToList();
            List<VMJob> vmjobs = mapper.Map<List<TbJob>, List<VMJob>>(jobs);
            return Ok(vmjobs);
        }
        [Authorize]
        [ValidModel]
        [HttpPost]
        public ActionResult Add(VMJob vmjob)
        {
            TbJob job = mapper.Map<VMJob, TbJob>(vmjob);
            unitOfWork.Jobs.Add(job);
            unitOfWork.Complete();
            vmjob.Id = job.Id;
            return Ok(vmjob);
        }
        [Authorize]
        [ValidModel]
        [HttpPost]
        public ActionResult Update(VMJob vmjob)
        {
             TbJob job = unitOfWork.Jobs.Get(vmjob.Id);
            job.Name = vmjob.Name;
            unitOfWork.Complete();
            return Ok(vmjob);
        }
        [Authorize]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            TbJob job = unitOfWork.Jobs.Get(id);
            if (job == null) { return NotFound(); }
            unitOfWork.Jobs.Remove(job);
            unitOfWork.Complete();
            return Ok();
        }
    }
}