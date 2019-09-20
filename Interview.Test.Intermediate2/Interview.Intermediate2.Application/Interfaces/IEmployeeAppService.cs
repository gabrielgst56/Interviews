using Interview.Intermediate2.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Intermediate2.Application.Interfaces
{
    public interface IEmployeeAppService : IDisposable
    {
        void Register(EmployeeViewModel employeeViewModel);
        IEnumerable<EmployeeViewModel> GetAll();
        EmployeeViewModel GetById(Guid id);
        void Update(EmployeeViewModel employeeViewModel);
        void Remove(Guid id);
        string WithdrawFromBalanceById(Guid id);
    }
}
