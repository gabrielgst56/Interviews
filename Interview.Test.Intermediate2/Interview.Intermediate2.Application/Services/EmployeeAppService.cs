using Interview.Intermediate2.Application.Interfaces;
using Interview.Intermediate2.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Intermediate2.Application.Services
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeAppService(IMapper mapper,
                                  IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return _employeeRepository.GetAll().ProjectTo<EmployeeViewModel>(_mapper.ConfigurationProvider);
        }

        public EmployeeViewModel GetById(Guid id)
        {
            return _mapper.Map<EmployeeViewModel>(_employeeRepository.GetById(id));
        }
        
        public string WithdrawFromBalanceById(Guid id)
        {
            return _mapper.Map<EmployeeViewModel>(_employeeRepository.WithdrawFromBalanceById(id));
        }

        public void Register(EmployeeViewModel employeeViewModel)
        {
        }

        public void Update(EmployeeViewModel employeeViewModel)
        {
        }

        public void Remove(Guid id)
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
