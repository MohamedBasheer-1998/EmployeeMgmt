using AutoMapper;
using EmployeeMgmt.Application.DTOs;
using EmployeeMgmt.Application.Interfaces;
using EmployeeMgmt.Domain.Entities;
using EmployeeMgmt.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeMgmt.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int departmentId)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(departmentId);
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            var createdDepartment = await _departmentRepository.CreateDepartmentAsync(department);
            return _mapper.Map<DepartmentDto>(createdDepartment);
        }

        public async Task UpdateDepartmentAsync(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            await _departmentRepository.UpdateDepartmentAsync(department);
        }

        public async Task DeleteDepartmentAsync(int departmentId)
        {
            await _departmentRepository.DeleteDepartmentAsync(departmentId);
        }
    }
}
