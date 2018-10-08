using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CompanySystem.Entities;
using CompanySystem.Mappers;
using CompanySystem;

public class CompanySystemContext : DbContext
{
    public CompanySystemContext() :
        base("companySystemConnection")
    {
        Configuration.ProxyCreationEnabled = false;
        Configuration.LazyLoadingEnabled = false;

        Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanySystemContext, CompanySystemContextMigrationConfiguration>());
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new CompanyMapper());
        modelBuilder.Configurations.Add(new EmployeeMapper());

        base.OnModelCreating(modelBuilder);
    }
}
