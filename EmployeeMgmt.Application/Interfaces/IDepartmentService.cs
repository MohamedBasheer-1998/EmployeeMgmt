using EmployeeMgmt.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeMgmt.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentDto> GetDepartmentByIdAsync(int departmentId);
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto> CreateDepartmentAsync(DepartmentDto departmentDto);
        Task UpdateDepartmentAsync(DepartmentDto departmentDto);
        Task DeleteDepartmentAsync(int departmentId);
    }
}
