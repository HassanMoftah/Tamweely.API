using System;
using System.Collections.Generic;
using System.Text;
using TAMWEELY.DataLayer.Models;

namespace TAMWEELY.Repositories.Interfaces
{
    public interface IEmployeeRepository:IRepository<TbEmployee>
    {
        IEnumerable<TbEmployee> GetAllEagerLoaded();
        TbEmployee GetEagerLoaded(int id);
        List<TbEmployee> GetBetweenTwoDates(DateTime from, DateTime to);
        List<TbEmployee> GetBySearch(string text);
    }
}
