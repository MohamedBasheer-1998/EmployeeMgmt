using EmployeeMgmt.Domain.Entities;
using EmployeeMgmt.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using EmployeeMgmt.Infrastructure.EmpDBContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeMgmt.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeMgmtDbContext _context;

        public EmployeeRepository(EmployeeMgmtDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() => await _context.Employees.ToListAsync();

        public async Task<Employee> GetByIdAsync(Guid id) => await _context.Employees.FindAsync(id);

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await GetByIdAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
