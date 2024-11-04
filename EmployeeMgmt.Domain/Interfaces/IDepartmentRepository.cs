using EmployeeMgmt.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeMgmt.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentByIdAsync(int departmentId);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department> CreateDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int departmentId);
    }
}
