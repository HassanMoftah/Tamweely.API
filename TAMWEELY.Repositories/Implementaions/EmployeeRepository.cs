using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAMWEELY.DataLayer;
using TAMWEELY.DataLayer.Models;
using TAMWEELY.Repositories.Interfaces;

namespace TAMWEELY.Repositories.Implementaions
{
    public class EmployeeRepository:Repository<TbEmployee>,IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<TbEmployee> GetAllEagerLoaded()
        {
            return ApplicationDbContext.Set<TbEmployee>().Include(x => x.Department).Include(x => x.Job);
        }

        public List<TbEmployee> GetBetweenTwoDates(DateTime from, DateTime to)
        {
            return ApplicationDbContext.Set<TbEmployee>().Where(x => x.BirthDate >= from.Date&&x.BirthDate<=to.Date).Include(x => x.Job)
                .Include(x => x.Department).ToList();
        }

        public List<TbEmployee> GetBySearch(string text)
        {
            return ApplicationDbContext.Set<TbEmployee>().Where(x => x.Name.Contains(text)||
            x.Email.Contains(text)||x.Address.Contains(text)||x.Phone.Contains(text)||x.Department.Name.Contains(text)||
            x.Job.Name.Contains(text)).Include(x=>x.Job).Include(x=>x.Department).ToList();
        }

        public TbEmployee GetEagerLoaded(int id)
        {
            return ApplicationDbContext.Set<TbEmployee>().Where(x=>x.Id==id).Include(x => x.Department).Include(x => x.Job).SingleOrDefault();
        }
    }
}
