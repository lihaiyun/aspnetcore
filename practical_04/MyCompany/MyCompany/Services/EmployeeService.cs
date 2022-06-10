﻿using MyCompany.Models;

namespace MyCompany.Services
{
    public class EmployeeService
    {
        private MyDbContext _context;

        public EmployeeService(MyDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.OrderBy(m => m.Name).ToList();
        }

        public Employee? GetEmployeeById(string id)
        {
            Employee? employee = _context.Employees.FirstOrDefault(x => x.EmployeeId.Equals(id));
            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
    }
}
