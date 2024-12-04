using EmployeeMgmt.Application.DTOs;
using EmployeeMgmt.Application.Interfaces;
using EmployeeMgmt.Application.Services;
using EmployeeMgmt.Domain.Entities;
using EmployeeMgmt.Infrastructure.EmpDBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeMgmt.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly EmployeeMgmtDbContext _context;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService, EmployeeMgmtDbContext context)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            List<EmployeeDto> employees = await (from emp in _context.Employees
                                                 join dep in _context.Departments on emp.DepartmentId equals dep.DepartmentId
                                                 select new EmployeeDto
                                                 {
                                                     EmployeeId = emp.EmployeeId,
                                                     EmployeeCode = emp.EmployeeCode,
                                                     Name = emp.Name,
                                                     Email = emp.Email,
                                                     HireDate = emp.HireDate,
                                                     DepartmentName = dep.DepartmentName,


                                                 }).ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Create()
        {
            var model = new EmployeeViewModel
            {
                Departments = await _context.Departments.ToListAsync()
            };
            return View(model); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            employeeViewModel.Employee.HireDate = employeeViewModel.Employee.HireDate.ToUniversalTime();
            _context.Employees.Add(employeeViewModel.Employee);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefaultAsync();

            if (employee == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments.ToListAsync();

            var viewModel = new EmployeeViewModel
            {
                Employee = employee,
                Departments = departments
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel viewModel)
        {

            _ = await _employeeService.UpdateEmployeeAsync(viewModel.Employee);
                return RedirectToAction(nameof(Index));
            
           
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
