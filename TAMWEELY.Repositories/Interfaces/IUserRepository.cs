using System;
using System.Collections.Generic;
using System.Text;
using TAMWEELY.DataLayer.Models;

namespace TAMWEELY.Repositories.Interfaces
{
    public interface IUserRepository :IRepository<TbUser>
    {
        TbUser GetByUserName(string username);
    }
}
