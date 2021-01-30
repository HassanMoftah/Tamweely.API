using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAMWEELY.DataLayer.Models;
using TAMWEELY.ViewModels.viewmodels;

namespace TAMWEELY.API.MappingProfiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<TbDepartment, VMDepartment>();
            CreateMap<VMDepartment, TbDepartment>();
        }

    }
}
