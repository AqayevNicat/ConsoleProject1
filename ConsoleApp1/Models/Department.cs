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
        public int iscisayi { get; set; }
        public double OrtaSal { get; set; }

        public Employee[] Employees = new Employee[0];

        public Department(string name, int workerlimit, double salarylimit)
        {
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
        }
        public int WorkerCount()
        {
            iscisayi = Employees.Length;
            foreach (Employee item in Employees)
            {
                if (item == null)
                {
                    iscisayi--;
                }
            }
            return iscisayi;
        }
        public double CalcSalaryAverage()
        {
            double Ortasal = 0;
            foreach (Employee item in Employees)
            {
                if (item != null && item.DepartmentName == Name)
                {
                    Ortasal += item.Salary;
                }
            }
            Ortasal /= WorkerCount();
            if(WorkerCount() == 0)
            {
                Ortasal = 0;
            }
            return Ortasal;
        }

        public override string ToString()
        {
            return $"Departamentin adi : {Name}";
        }
    }
}
