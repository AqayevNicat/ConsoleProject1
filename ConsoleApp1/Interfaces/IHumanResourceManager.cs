using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }
        void AddDepartment(string name, int workerlimit, double salarylimit);
        Department[] GetDepartments();
        void EditDepartaments(string oldName, string newName);
        void AddEmployee(string fullname, string position, double salary, string departmentname);
        void RemoveEmployee(string no, string departmentname);
        void EditEmploye(string no, string position, double salary);
        Employee[] GetEmployees();
        Employee[] GetEmployeesByDepartment(string departmentName);
    }
}
