using EmployeeMgmt.Infrastructure.EmpDBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmployeeMgmt.Infrastructure.Data
{
    public class EmployeeMgmtDbContextFactory : IDesignTimeDbContextFactory<EmployeeMgmtDbContext>
    {
        public EmployeeMgmtDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeMgmtDbContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Database=EmployeeMgmtDb;Username=postgres;Password=12345");

            return new EmployeeMgmtDbContext(optionsBuilder.Options);
        }
    }
}
