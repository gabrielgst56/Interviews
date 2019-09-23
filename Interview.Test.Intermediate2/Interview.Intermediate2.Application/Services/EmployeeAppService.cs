using AutoMapper;
using AutoMapper.QueryableExtensions;
using Interview.Intermediate2.Application.Interfaces;
using Interview.Intermediate2.Application.ViewModels;
using Interview.Intermediate2.Domain.Core.Bus;
using Interview.Intermediate2.Domain.Core.Notifications;
using Interview.Intermediate2.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;

namespace Interview.Intermediate2.Application.Services
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        public EmployeeAppService(IMapper mapper,
                                  IEmployeeRepository employeeRepository,
                                  INotificationHandler<DomainNotification> notifications,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
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
            try
            {
                var employee = GetById(id);

                if (employee == null)
                    _mediator.RaiseEvent(new DomainNotification("0", "Funcionário não reconhecido."));

                if (employee.BirthDate.Day != DateTime.Now.Day
                    || employee.BirthDate.Month != DateTime.Now.Month)
                    _mediator.RaiseEvent(new DomainNotification("0", "Impossível sacar, dia atual não corresponde ao aniversário."));

                var balance = employee.Balance;
                var value = 0.00;

                if (balance < 500)
                    value = 0 + balance * 0.5;

                if (balance > 500 && balance < 1000)
                    value = 50 + balance * 0.4;

                if (balance > 1000.01 && balance < 5000)
                    value = 150 + balance * 0.3;

                if (balance > 5000.01 && balance < 10000)
                    value = 650 + balance * 0.2;

                if (balance > 10000.01 && balance < 15000)
                    value = 1150 + balance * 0.15;

                if (balance > 15000.01 && balance < 20000)
                    value = 1900 + balance * 0.1;

                if (balance > 20000.01)
                    value = 2900 + balance * 0.05;

                employee.Balance = balance - value;



                return $"Saque realizado, valor: {value}";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public void Register(EmployeeViewModel employeeViewModel)
        {
            _employeeRepository.Add(employeeViewModel);
        }

        public void Update(EmployeeViewModel employeeViewModel)
        {
            _employeeRepository.Add(employeeViewModel);
        }

        public void Remove(Guid id)
        {
            _employeeRepository.Add(employeeViewModel);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
