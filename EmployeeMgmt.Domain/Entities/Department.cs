namespace EmployeeMgmt.Domain.Entities
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; } = [];

        public Department() { }

        public Department(string departmentName, string description)
        {
            DepartmentId = Guid.NewGuid();
            DepartmentName = departmentName;
            Description = description;
        }
    }
}
