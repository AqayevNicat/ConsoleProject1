using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    interface IHumanResourceManager
    {
        #region Departments
        Department[] Departments { get; }
        void AddDepartment(string name, int workerlimit, double salarylimit);
        Department[] GetDepartments();
        void EditDepartaments(string oldName, string newName);
        #endregion

        #region Employees
        void AddEmployee(string fullname, string position, double salary, string departmentname);
        Employee[] GetEmployees();
        Employee[] GetEmployeesByDepartment(string departmentName);
        void RemoveEmployee(string no, string departmentname);
        void EditEmploye(string no, string position, double salary);
        #endregion
    }
}
