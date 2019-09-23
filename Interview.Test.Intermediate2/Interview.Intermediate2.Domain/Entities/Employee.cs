using Interview.Intermediate2.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Intermediate2.Domain.Entities
{
    public class Employee : Entity
    {
        public Employee(Guid id, string name, string email, double balance, string company, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            Balance = balance;
            Company = company;
            BirthDate = birthDate;
        }
        public Guid Id { get; protected set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public double Balance { get; private set; }

        public string Company { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
