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
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }

        public int iscisayi;

        public Employee[] Employees = new Employee[0];



        public Department(string name, int workerlimit, double salarylimit)
        {
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
        }
        public double CalcSalaryAverage()
        {
            double OrtaSal = 0;
            foreach (Employee item in Employees)
            {
                if (item!= null && item.DepartmentName == Name)
                {
                    OrtaSal += item.Salary;
                }
            }
            return OrtaSal;
        }

        public override string ToString()
        {
            iscisayi = Employees.Length;
            foreach (Employee item in Employees)
            {
                if (item == null)
                {
                    iscisayi--;
                }
            }
            return $"Departamentin adi : {Name}\n" +
                $"Iscilerin sayi : {iscisayi}";
        }
    }
}
