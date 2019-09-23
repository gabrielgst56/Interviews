using Interview.Intermediate2.Domain.Entities;
using Interview.Intermediate2.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Intermediate2.Infra.Repository
{
    public class EmployeeRepository : IRepository<Employee>, IEmployeeRepository
    {
        protected static readonly List<Employee> DbSet = GetDb();// new List<Employee>();

        public EmployeeRepository() {}

        private static List<Employee> GetDb()
        {
            var dbSet = new List<Employee>();
            dbSet.Add(new Employee(new Guid("a3c26e43-ff7a-42eb-ac8a-795159ec432a"), "Gabriel", "gabrielgst56@hotmail.com",
                1050.0, "Lincros", new DateTime(1999, 09, 23)));

            return dbSet;
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
