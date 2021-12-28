using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            Console.Clear();
            do
            {
                Console.WriteLine("--------------------------------- Deaprtment ----------------------------------");
                Console.WriteLine("Etmek istediyiniz emeliyyati secin");
                Console.WriteLine("1 - Departameantlerin siyahisini gostermek");
                Console.WriteLine("2 - Departamenet yaratmaq");
                Console.WriteLine("3 - Departmanetde deyisiklik etmek");
                Console.WriteLine("4 - Employee uzerinde emeliyyat");
                Console.WriteLine("5 - Sistmden cix");
                Console.Write("Daxil edin : ");
                string choose = Console.ReadLine();
                int choosenum;
                int.TryParse(choose, out choosenum);
                switch (choosenum)
                {
                    case 1:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();
                        EditDepartaments(ref humanResourceManager);
                        break;
                    case 4:
                        EmployeeOperation(ref humanResourceManager);
                        break;
                    case 5:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun reqem daxil edin...");
                        break;
                }
            } while (true);
        }
        static void EmployeeOperation(ref HumanResourceManager humanResourceManager)
        {
            Console.Clear();
            do
            {
                Console.WriteLine("----------      Employee uzerinde emeliyyatlar      ----------");
                Console.WriteLine("1 - Iscilerin siyahisini gostermek ");
                Console.WriteLine("2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("3 - Isci elave etmek");
                Console.WriteLine("4 - Isci uzerinde deyisiklik etmek ");
                Console.WriteLine("5 - Departamentden isci silinmesi");
                Console.WriteLine("6 - Evvelki emnyuya qayit");
                Console.Write("Daxil edin : ");
                string choose = Console.ReadLine();
                int choosenum;
                int.TryParse(choose, out choosenum);
                switch (choosenum)
                {
                    case 1:
                        Console.Clear();
                        GetEmployees(ref humanResourceManager);
                        break;
                    case 2:
                        Console.Clear();
                        GetEmployeesByDepartment(ref humanResourceManager);
                        break;
                    case 3:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 4:
                        Console.Clear();
                        //EditEmploye(ref humanResourceManager);
                        break;
                    case 5:
                        Console.Clear();
                        //RemoveEmployee(ref humanResourceManager);
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Evvelki emnyuya qayit");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun reqem daxil edin...");
                        break;
                }
            } while (true);
        }

        #region Department
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Departmentin adini daxil edin :");
            string name = Console.ReadLine();
            Console.WriteLine("Isci limitini daxil edin :");
            int workerlimit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Maas limitini daxil edin :");
            double salarylimit = Convert.ToDouble(Console.ReadLine());

            humanResourceManager.AddDepartment(name, workerlimit, salarylimit);
        }
        static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {

            humanResourceManager.GetDepartments();
        }
        static void EditDepartaments(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Var olan Departmentler :");
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Deyisdirmek istediyiniz departmenti adini daxil edin :");
            string oldName = Console.ReadLine();
            bool checkName = true;
            int count = 0;
            while (checkName)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == oldName.ToLower())
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Adda department Movcud deyil");
                    Console.Write("Duzgun Ad Daxil Et: ");
                    oldName = Console.ReadLine();
                }
                else
                {
                    checkName = false;
                }

                count = 0;
            }
            Console.WriteLine("Departmentin yeni adini daxil edin :");
            string newName = Console.ReadLine();
            humanResourceManager.EditDepartaments(oldName,newName);
        }
        #endregion

        #region Employee
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Iscinin butov adini daxil edin : ");
            string fullname = Console.ReadLine();


            Console.WriteLine("Iscinin vezifesini daxil edin : ");
            string position = Console.ReadLine();
            while (position.Length < 2)
            {
                Console.WriteLine("Vezifenin adinin uzunlugu 2den az ola bilmez...");
                Console.Write("Vezifenin adini yeniden daxil edin : ");
                position = Console.ReadLine();
            }


            Console.WriteLine("Iscinin maasini daxil edin : ");
            string salaryName = Console.ReadLine();
            double salary;
            while (!double.TryParse(salaryName, out salary) || salary < 250)
            {
                Console.WriteLine("Iscinin maasi 250-den az ola bilmez...");
                Console.Write("Iscinin maasini duzgun daxil edin : ");
                salaryName = Console.ReadLine();
            }

            if (humanResourceManager.Departments.Length == 0)
            {
                Console.WriteLine("Hec bir department elave olunmayib...");
                Console.WriteLine("Ilk once department elave edin...");
                return;
            }
            else
            {
                Console.WriteLine("Mumkun ola bilen departmentler : ");
            }
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Iscinin departamnetini daxil edin : ");

            string department = Console.ReadLine();
            bool checkName = true;
            int count = 0;
            while (checkName)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == department.ToLower())
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("Daxil etdiyiniz adda department yoxdur...");
                    return;
                }
                else
                {
                    checkName = false;
                }

                count = 0;
            }

            foreach (Department item in humanResourceManager.Departments)
            {
                if (department.ToLower() == item.Name.ToLower() && item.Employees.Length > Department.WorkerLimit)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Departament tam doludur.Isci elave ede bilmezsiniz...");
                    return;
                }
            }
            humanResourceManager.AddEmployee(fullname, position, salary, department);
        }
        static void GetEmployees(ref HumanResourceManager humanResourceManager)
        {
            humanResourceManager.GetEmployees();
        }
        static void GetEmployeesByDepartment(ref HumanResourceManager humanResourceManager)
        {
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Iscilerini gormek istediyiniz departmentin adini daxil edin :");
            string departmentName = Console.ReadLine();

            bool checkName = true;
            int count = 0;
            while (checkName)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == departmentName.ToLower())
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Adda Department yoxdur ");
                    Console.Write("Duzgun Ad Daxil Et: ");
                    departmentName = Console.ReadLine();
                }
                else
                {
                    checkName = false;
                }

                count = 0;

                int say = 0;
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee item2 in item.Employees)
                    {
                        if (item != null && departmentName.ToLower() == item.Name.ToLower())
                        {
                            Console.WriteLine($"{item2}\n----------------");
                        }
                        else
                        {
                            say++;
                        }
                    }
                }
                if(say >= humanResourceManager.Departments.Length)
                {
                    Console.WriteLine("Daxil etdiyiniz adda department yoxdur.");
                    return;
                }

            }
            humanResourceManager.GetEmployeesByDepartment(departmentName);
        }
        #endregion
    }
}