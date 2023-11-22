using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee employee)
        {
            this.context.Employees.Add(employee);
            this.context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = this.context.Employees.Find(id);
            if (employee != null)
            {
                this.context.Employees.Remove(employee);
                this.context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return this.context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return this.context.Employees.Find(Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = this.context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.context.SaveChanges();
            return employeeChanges;
        }
    }
}
