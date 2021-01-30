using System;
using System.Collections.Generic;
using System.Text;

namespace TAMWEELY.Repositories.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {  
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        IJobRepository Jobs { get; }
        IUserRepository Users { get; }

        int Complete();
    }
}
