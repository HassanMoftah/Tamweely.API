using System;
using System.Collections.Generic;
using System.Text;
using TAMWEELY.DataLayer;
using TAMWEELY.DataLayer.Models;
using TAMWEELY.Repositories.Interfaces;

namespace TAMWEELY.Repositories.Implementaions
{
    public class DepartmentRepository:Repository<TbDepartment>,IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context){  }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
