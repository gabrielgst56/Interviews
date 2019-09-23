using AutoMapper;
using Interview.Intermediate2.Application.ViewModels;
using Interview.Intermediate2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Intermediate2.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        private readonly Mapper _mapper;

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>()
                .ConstructUsing(c => new Employee(c.Id, c.Name, c.Email, c.Balance, c.Company, c.BirthDate));
        }
    }
}
