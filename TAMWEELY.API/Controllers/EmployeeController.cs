using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAMWEELY.API.ActionFilters;
using TAMWEELY.API.ImageHandler;
using TAMWEELY.DataLayer.Models;
using TAMWEELY.Repositories.Interfaces;
using TAMWEELY.ViewModels.viewmodels;

namespace TAMWEELY.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IImageUpload imageUpload;
        public EmployeeController(IUnitOfWork _unitOfwork, IMapper _mapper,IImageUpload _imageUpload)
        {
            unitOfWork = _unitOfwork;
            mapper = _mapper;
            imageUpload = _imageUpload;
        }
        [Authorize]
        [HttpGet]
        public ActionResult GetAll()
        {
            List<TbEmployee> employees = unitOfWork.Employees.GetAllEagerLoaded().ToList();
            List<VMEmployee> vmemployees = mapper.Map<List<TbEmployee>, List<VMEmployee>>(employees);
            return Ok(vmemployees);
        }
        [Authorize]
        [ValidModel]
        [HttpPost]
        public ActionResult Add(VMEmployee vmemployee)
        {
            TbEmployee employee = mapper.Map<VMEmployee, TbEmployee>(vmemployee);
            DateTime zeroTime = new DateTime(1, 1, 1);
            employee.Age = (zeroTime + (DateTime.Now.Date - employee.BirthDate)).Year;
            unitOfWork.Employees.Add(employee);
            unitOfWork.Complete();
            vmemployee.Id = employee.Id;
            return Ok(vmemployee);
        }
        [Authorize]
        [ValidModel]
        [HttpPost]
        public ActionResult Update(VMEmployee vmemployee)
        {
            TbEmployee employee = unitOfWork.Employees.Get(vmemployee.Id);
            DateTime zeroTime = new DateTime(1, 1, 1);
            employee.Age = (zeroTime + (DateTime.Now.Date - vmemployee.BirthDate)).Year ;
            employee.Name = vmemployee.Name;
            employee.BirthDate = vmemployee.BirthDate;
            employee.Email = vmemployee.Email;
            employee.Phone = vmemployee.Phone;
            employee.JobId = vmemployee.JobId;
            employee.DepartmentId = vmemployee.DepartmentId;
            employee.Address = vmemployee.Address;
            employee.ImagePath = vmemployee.ImagePath;
            unitOfWork.Complete();
            return Ok(vmemployee);
        }
        [Authorize]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            TbEmployee employee = unitOfWork.Employees.Get(id);
            if (employee == null) { return NotFound(); }
            unitOfWork.Employees.Remove(employee);
            unitOfWork.Complete();
            imageUpload.RemoveImage(employee.ImagePath);
            return Ok();
        }
       [HttpGet]
       [Authorize]
       public ActionResult Get(int id)
       {
            TbEmployee employee = unitOfWork.Employees.GetEagerLoaded(id);
            if (employee == null) { return NotFound(); }
            VMEmployee vmemployee = mapper.Map<TbEmployee, VMEmployee>(employee);
            return Ok(vmemployee);
       }
      [HttpPost]
      [Authorize]
      public ActionResult UploadImage(int id)
      {
            TbEmployee employee = unitOfWork.Employees.Get(id);
            if (employee == null) { return NotFound("employee not found"); }
            if(imageUpload.AddImage(HttpContext.Request, id))
            {
                employee.ImagePath = id.ToString() + imageUpload.GetFileExtention(HttpContext.Request);
                unitOfWork.Complete();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
       }
        [HttpGet]
        [Authorize]
        public ActionResult GetBetweenTwoDates(DateTime from, DateTime to)
        {

            List<TbEmployee> employees = unitOfWork.Employees.GetBetweenTwoDates(from, to);
            List<VMEmployee> vmemployees = mapper.Map<List<TbEmployee>, List<VMEmployee>>(employees);
            return Ok(vmemployees);
        }
        [HttpGet]
        [Authorize]
        public ActionResult GetBySearch(string text)
        {

            List<TbEmployee> employees = unitOfWork.Employees.GetBySearch(text);
            List<VMEmployee> vmemployees = mapper.Map<List<TbEmployee>, List<VMEmployee>>(employees);
            return Ok(vmemployees);
        }

    }
   
}