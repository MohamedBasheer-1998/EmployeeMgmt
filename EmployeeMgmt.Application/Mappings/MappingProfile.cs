using AutoMapper;
using EmployeeMgmt.Application.DTOs;
using EmployeeMgmt.Domain.Entities;

namespace EmployeeMgmt.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
        }
    }
}
