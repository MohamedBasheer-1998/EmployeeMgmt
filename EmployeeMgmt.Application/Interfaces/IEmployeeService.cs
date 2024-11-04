using EmployeeMgmt.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeMgmt.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto);
        Task<bool> UpdateEmployeeAsync(Guid id, EmployeeDto employeeDto);
        Task<bool> DeleteEmployeeAsync(Guid id);
    }
}
