using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Department
    {
        public string Name { get; set; }
        public static int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        public double OrtaSal;
        public Employee[] Employees = new Employee[0];

        //public double OrtaSal;



        public Department(string name, int workerlimit, double salarylimit)
        {
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;

        }
        public double CalcSalaryAverage()
        {
            foreach (Employee item in Employees)
            {
                OrtaSal += item.Salary;
            }
            return OrtaSal;
        }

        public override string ToString()
        {
            return $"Departamentin adi : {Name}\n" +
                $"Iscilerin sayi : {Employees.Length}\n" +
                $"{OrtaSal}\n---------------";
        }
    }
}
