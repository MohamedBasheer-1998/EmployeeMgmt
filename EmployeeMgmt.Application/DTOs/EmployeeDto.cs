using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMgmt.Application.DTOs
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Code is required.")]
        public string EmployeeCode { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        public DateTimeOffset HireDate { get; set; }
        public string DepartmentName { get; set; }
    }
}
