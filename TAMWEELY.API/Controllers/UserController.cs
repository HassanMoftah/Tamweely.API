using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TAMWEELY.API.TokenHandler;
using TAMWEELY.DataLayer.Models;
using TAMWEELY.Repositories.Interfaces;
using TAMWEELY.ViewModels.viewmodels;

namespace TAMWEELY.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
      
        public UserController(IUnitOfWork _unitOfwork,IConfiguration _config)
        {
            configuration = _config;
            unitOfWork = _unitOfwork;
        
        }

        public ActionResult Login(VMUser credential)
        {
            TbUser user = unitOfWork.Users.GetByUserName(credential.UserName);
            if (user == null) { return NotFound("user not found"); }
            else if (user.Password != credential.Password) { return Unauthorized("wrong password"); }
            VMUser vmuser = new VMUser();
            var tokenhandler = new TokenManager(configuration);
            vmuser.Token = tokenhandler.GenerateToken(user.Id);
            return Ok(vmuser);
        }


    }
}