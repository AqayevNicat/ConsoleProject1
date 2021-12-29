using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Department[] Departments => _Departments;
        private Department[] _Departments;


        public HumanResourceManager()
        {
            _Departments = new Department[0];
        }
        public void AddDepartment(string name, int workerlimit, double salarylimit)
        {
            Department department = new Department(name, workerlimit, salarylimit);
            Array.Resize(ref _Departments, _Departments.Length + 1);
            _Departments[_Departments.Length - 1] = department;
        }
        public void GetDepartments() 
        {
            foreach (Department item in _Departments)
            {
                Console.WriteLine($"{item}\nOrtalama maas : {item.CalcSalaryAverage()}\n----------------------");
            }
        }
        public void EditDepartaments(string oldName, string newName)
        {
            foreach (Department item in _Departments)
            {
                if (item != null && item.Name.ToLower()==oldName)
                {
                    item.Name = newName;
                }
            }
        }
        public void AddEmployee(string fullname, string position, double salary, string departmentname)
        {
            Employee employee = new Employee(fullname, position, salary, departmentname);

            foreach (Department item in _Departments)
            {
                if (employee.DepartmentName.ToLower() == item.Name.ToLower())
                {
                    Array.Resize(ref item.Employees, item.Employees.Length + 1);
                    item.Employees[item.Employees.Length - 1] = employee;
                }
            }
        }
        public void GetEmployees()
        {
            foreach (Department item in _Departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item2 != null)
                    {
                        Console.WriteLine(item2);
                    }
                }
            }
        }
        public Employee[] GetEmployeesByDepartment(string departmentName)
        {
            Employee[] employee = new Employee[0];
            foreach (Department item in _Departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item2 != null && item.Name == departmentName)
                    {
                        Array.Resize(ref employee, employee.Length + 1);
                        employee[employee.Length - 1] = item2;
                    }
                }
            }
            return employee;


        }
        public void RemoveEmployee(string no, string departmentname)
        {
            foreach (Department item in Departments)
            {
                for (int i = 0; i < item.Employees.Length; i++)
                {
                    if (item.Employees[i] != null && item.Employees[i].No.ToLower() == no.ToLower() && item.Employees[i].DepartmentName.ToLower() == departmentname.ToLower())
                    {
                        item.Employees[i] = null;
                        return;
                    }
                }
            }
        }
        public void EditEmploye(string no, string position, double salary)
        {
            foreach (Department item in Departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item2.No.ToLower() == no.ToLower())
                    {
                        item2.Position = position;
                        item2.Salary = salary;
                    }
                }
            }
        }
    }
}
