using System;
using System.Collections.Generic;
using Interview.Intermediate2.Application.Interfaces;
using Interview.Intermediate2.Application.ViewModels;
using Interview.Intermediate2.Domain.Core.Bus;
using Interview.Intermediate2.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Intermediate2.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeeController(
            IEmployeeAppService employeeAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _employeeAppService = employeeAppService;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Response(_employeeAppService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var employeeViewModel = _employeeAppService.GetById(id);

            return Response(employeeViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody]EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(employeeViewModel);
            }

            _employeeAppService.Register(employeeViewModel);

            return Response(employeeViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody]EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(employeeViewModel);
            }

            _employeeAppService.Update(employeeViewModel);

            return Response(employeeViewModel);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _employeeAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [Route("withdraw/{id}")]
        public IActionResult WithdrawFromBalanceById(Guid id)
        {
            var employeeViewModel = _employeeAppService.WithdrawFromBalanceById(id);

            return Response(employeeViewModel);
        }
    }
}