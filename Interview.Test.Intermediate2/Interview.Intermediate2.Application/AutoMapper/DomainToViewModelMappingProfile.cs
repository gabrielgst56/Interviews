using AutoMapper;
using Interview.Intermediate2.Application.ViewModels;
using Interview.Intermediate2.Domain.Entities;

namespace Interview.Intermediate2.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
        }
    }
}
