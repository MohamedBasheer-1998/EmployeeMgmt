using EmployeeMgmt.Application.DTOs;
using EmployeeMgmt.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeMgmt.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto);
        Task<bool> UpdateEmployeeAsync(Employee employeeDto);
        Task<bool> DeleteEmployeeAsync(Guid id);
    }
}
