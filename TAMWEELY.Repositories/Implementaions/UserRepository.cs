using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAMWEELY.DataLayer;
using TAMWEELY.DataLayer.Models;
using TAMWEELY.Repositories.Interfaces;

namespace TAMWEELY.Repositories.Implementaions
{
    public class UserRepository :Repository<TbUser>,IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public TbUser GetByUserName(string username)
        {
           return  ApplicationDbContext.Set<TbUser>().Where(x => x.UserName == username).SingleOrDefault();
        }
    }
}
