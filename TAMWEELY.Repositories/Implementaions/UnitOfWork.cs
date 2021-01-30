using System;
using System.Collections.Generic;
using System.Text;
using TAMWEELY.DataLayer;
using TAMWEELY.Repositories.Interfaces;

namespace TAMWEELY.Repositories.Implementaions
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
            Departments = new DepartmentRepository(_context);
            Jobs = new JobRepository(_context);
            Users = new UserRepository(_context);
          
        }

        public IEmployeeRepository Employees { get; private set; }

        public IDepartmentRepository Departments { get; private set; }

        public IJobRepository Jobs { get; private set; }

        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
