using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySystem.Entities;

namespace CompanySystem
{
    public class CompanySystemRepository : ICompanySystemRepository
    {
        private CompanySystemContext _ctx;
        public CompanySystemRepository(CompanySystemContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Company> GetAllCompanies()
        {
            return _ctx.Companies.AsQueryable();
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return _ctx.Employees.AsQueryable();
        }

        public Company GetCompany(int companyId)
        {
            return _ctx.Companies.Find(companyId);
        }

        public Employee GetEmployee(int employeeId)
        {
            return _ctx.Employees.Find(employeeId);
        }

        public bool Insert(Company company)
        {
            try
            {
                _ctx.Companies.Add(company);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Company originalCompany, Company updatedCompany)
        {
            _ctx.Entry(originalCompany).CurrentValues.SetValues(updatedCompany);
            return true;
        }

        public bool DeleteCompany(int id)
        {
            try
            {
                var entity = _ctx.Companies.Find(id);
                if (entity != null)
                {
                    _ctx.Companies.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // TODO Logging
            }

            return false;
        }

        public bool Insert(Employee employee)
        {
            try
            {
                _ctx.Employees.Add(employee);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Employee originalEmployee, Employee updatedEmployee)
        {
            _ctx.Entry(originalEmployee).CurrentValues.SetValues(updatedEmployee);
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var entity = _ctx.Employees.Find(id);
                if (entity != null)
                {
                    _ctx.Employees.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // TODO Logging
            }

            return false;
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
