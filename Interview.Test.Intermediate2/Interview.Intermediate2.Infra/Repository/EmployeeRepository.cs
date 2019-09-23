using Interview.Intermediate2.Domain.Entities;
using Interview.Intermediate2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Intermediate2.Infra.Repository
{
    public class EmployeeRepository : IRepository<Employee>, IEmployeeRepository
    {
        protected static readonly List<Employee> DbSet = new List<Employee>();

        public EmployeeRepository()
        {
            DbSet.Add(new Employee(Guid.NewGuid(), "Gabriel", "gabrielgst56@hotmail.com",
                1050.0, "Lincros", new DateTime(1999, 07, 14)));
        }

        public virtual void Add(Employee obj)
        {
            DbSet.Add(obj);
        }

        public virtual Employee GetById(Guid id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public virtual IQueryable<Employee> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public virtual void Update(Employee obj)
        {
            DbSet.Remove(DbSet.FirstOrDefault(x => x.Id == obj.Id));

            DbSet.Add(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.FirstOrDefault(x => x.Id == id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
