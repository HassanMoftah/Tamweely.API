using System;
using System.Collections.Generic;
using System.Text;
using TAMWEELY.DataLayer;
using TAMWEELY.DataLayer.Models;
using TAMWEELY.Repositories.Interfaces;

namespace TAMWEELY.Repositories.Implementaions
{
   public class JobRepository :Repository<TbJob>,IJobRepository
    {
        public JobRepository (ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
