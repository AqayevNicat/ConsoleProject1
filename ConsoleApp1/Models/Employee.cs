using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Employee
    {
        public static int Count = 1000;
        public string No { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string DepartmentName;

        public Employee(string fullname, string position, double salary, string departmentName)
        {
            FullName = fullname;
            DepartmentName = departmentName;
            Position = position;
            Salary = salary;
            Count++;
            No = DepartmentName.Substring(0, 2).ToUpper() + Count;
        }
        public override string ToString()
        {
            return $"Nomresi : {No}\n" +
                $"FullName : {FullName}\n" +
                $"Position : {Position}\n" +
                $"Salary : {Salary}\n" +
                $"Department : {DepartmentName}\n-----------------";
        }
    }
}
