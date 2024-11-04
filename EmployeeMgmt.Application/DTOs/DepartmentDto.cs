﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeMgmt.Application.DTOs
{
    public class DepartmentDto
    {
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}