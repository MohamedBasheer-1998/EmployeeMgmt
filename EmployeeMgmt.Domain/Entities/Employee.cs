namespace EmployeeMgmt.Domain.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime HireDate { get; set; }

       
        public Employee() { }

        public Employee(string employeeCode, string name, string email, Guid departmentId, DateTime hireDate)
        {
            EmployeeId = Guid.NewGuid();
            EmployeeCode = employeeCode;
            Name = name;
            Email = email;
            DepartmentId = departmentId;
            HireDate = hireDate;
        }
    }
}
