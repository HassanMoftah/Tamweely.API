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
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public DepartmentController(IUnitOfWork _unitOfwork, IMapper _mapper)
        {
            unitOfWork = _unitOfwork;
            mapper = _mapper;
        }
        [Authorize]
        [HttpGet]
        public ActionResult GetAll()
        {
            List<TbDepartment> departments = unitOfWork.Departments.GetAll().ToList();
            List<VMDepartment> vmdepartments = mapper.Map<List<TbDepartment>, List<VMDepartment>>(departments);
            return Ok(vmdepartments);
        }
        [Authorize]
        [ValidModel]
        [HttpPost]
        public ActionResult Add(VMDepartment vmdepartment)
        {
            TbDepartment department = mapper.Map<VMDepartment, TbDepartment>(vmdepartment);
            unitOfWork.Departments.Add(department);
            unitOfWork.Complete();
            vmdepartment.Id = department.Id;
            return Ok(vmdepartment);
        }
        [Authorize]
        [ValidModel]
        [HttpPost]
        public ActionResult Update(VMDepartment vmdepartment)
        {
            TbDepartment department = unitOfWork.Departments.Get(vmdepartment.Id);
            department.Name = vmdepartment.Name;
            unitOfWork.Complete();
            return Ok(vmdepartment);
        }
        [Authorize]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            TbDepartment department = unitOfWork.Departments .Get(id);
            if (department == null) { return NotFound(); }
            unitOfWork.Departments.Remove(department);
            unitOfWork.Complete();
            return Ok();
        }
    }
}