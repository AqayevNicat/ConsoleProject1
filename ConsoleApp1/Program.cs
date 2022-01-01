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
                Console.WriteLine($"-------------------------------__ *  DEPARTMENT *  __--------------------------------");
                Console.WriteLine($"Etmek istediyiniz emeliyyati secin :\n");
                Console.WriteLine("1 - Movcud olan departamentlerin siyahisinin gosterilmesi .");
                Console.WriteLine("2 - Yeni departamentin elave olunmasi .");
                Console.WriteLine("3 - Movcud olan departamentler uzerinde deyisiklik edilmesi .");
                Console.WriteLine("4 ---> Isciler uzerinde prosesler .");
                Console.WriteLine($"5 - Sistmden cixis .\n");
                Console.Write("DAXIL EDIN : ");
                string choose = Console.ReadLine().Trim();
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
                        Console.WriteLine($"--**  Duzgun reqem daxil edin...  **--\n");
                        break;
                }
            } while (true);
        }
        static void EmployeeOperation(ref HumanResourceManager humanResourceManager)
        {
            Console.Clear();
            do
            {
                Console.WriteLine("-------------------------------__ *  EMPLOYEE  *  __--------------------------------");
                Console.WriteLine("Etmek istediyiniz emeliyyati secin :\n");
                Console.WriteLine("1 - Movcud olan iscilerin siyahisinin gosterilmesi . ");
                Console.WriteLine("2 - Departamentlere gore iscilerin siyahisinin gosterilmesi .");
                Console.WriteLine("3 - Yeni iscinin elave edilmesi .");
                Console.WriteLine("4 - Movcud olan isciler uzerinde deyisiklik edilmesi .");
                Console.WriteLine("5 - Departamentden iscilerin silinmesi .");
                Console.WriteLine("6 - <--- Evvelki menyuya qayitmaq .\n");
                Console.Write("DAXIL EDIN : ");
                string choose = Console.ReadLine().Trim();
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
                        EditEmploye(ref humanResourceManager);
                        break;
                    case 5:
                        Console.Clear();
                        RemoveEmployee(ref humanResourceManager);
                        break;
                    case 6:
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("--**  Duzgun reqem daxil edin...  **--\n");
                        break;
                }
            } while (true);
        }

        #region Department
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Elave etmek istediyniz departmentin adini daxil edin : ");
        CheckName:
            string department = Console.ReadLine().Trim();
            foreach (Department item in humanResourceManager.Departments)
            {
                if(department.ToLower() == item.Name.ToLower())
                {
                    Console.WriteLine("*** Daxil etdiyniz adda departament movcudur.Duzgun daxil edin : ***");
                    goto CheckName;
                }
            }
            while (department.Length < 2)
            {
                Console.WriteLine("*** Departamentin adinin uzunlugu 2-den az ola bilmez.Duzgun daxil edin : ***");
                department = Console.ReadLine().Trim();
            }
            Console.WriteLine("Maksimum ola bilecek isci sayini daxil edin : ");
            string workerlimitName = Console.ReadLine().Trim();
            int workerlimit;
            while (!int.TryParse(workerlimitName, out workerlimit) || workerlimit < 1)
            {
                Console.WriteLine("*** Maksimum isci sayi 1-den az ola bilmez.Duzgun daxil edin : ***");
                workerlimitName = Console.ReadLine().Trim();
            }

            Console.WriteLine("Maksimum ola bilecek maas miqdarini daxil edin : ");
            string salarylimitName = Console.ReadLine().Trim();
            int salarylimit;
            while (!int.TryParse(salarylimitName, out salarylimit) || salarylimit < 250)
            {
                Console.WriteLine("*** Maksimum maas miqdari 250-den az ola bilmez.Duzgun daxil edin : ***");
                salarylimitName = Console.ReadLine().Trim();
            }
            Console.WriteLine($"\n**** \"{department.ToUpper()}\" adli departament elave edildi. ****\n");

            humanResourceManager.AddDepartment(department, workerlimit, salarylimit);
        }
        static void GetDepartments(ref HumanResourceManager humanResourceManager)
        {
            Department[] departments =  humanResourceManager.GetDepartments(); 
            if (departments.Length == 0)
            {
                Console.WriteLine("*** Departament elave olunmayib.Ilk once departament elave edin ***\n");
                return;
            }
            Console.WriteLine("Movcud olan departamentlerin siyahisi :\n\n----------Departments-----------|");
            for (int i = 0; i < departments.Length; i++)
            {
                Console.WriteLine($"{i+1}. {departments[i]}\n" +
                    $"Iscilerin sayi: { departments[i].WorkerCount()}/{ departments[i].WorkerLimit}\n" +
                    $"Ortalama maas : {departments[i].CalcSalaryAverage()}\n" +
                    $"Iscilerin umumi maasi : {departments[i].CalcSalaryAverage()* departments[i].WorkerCount()}/{departments[i].SalaryLimit}\n--------------------------------|");
            }
        }
        static void EditDepartaments(ref HumanResourceManager humanResourceManager)
        {
            Department[] departments = humanResourceManager.GetDepartments();
            if (departments.Length == 0)
            {
                Console.WriteLine("*** Departament elave olunmayib.Ilk once departament elave edin ***\n");
                return;
            }
            else
            {
                Console.WriteLine("Movcud olan departamentler : ");
            }
            for (int i = 0; i < departments.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {departments[i].Name}");
            }
            Console.WriteLine("Deyisdirmek istediyiniz departamentin adini daxil edin :");
            string oldName = Console.ReadLine().Trim();
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
                    Console.WriteLine($"*** Daxil etdiyniz adda departament movcud deyil...\n");
                    return;
                }
                else
                {
                    checkName = false;
                }

                count = 0;
            }
            
            Console.WriteLine("Departmentin yeni adini daxil edin :");
        CheckName:
            string newName = Console.ReadLine().Trim();
            foreach (Department item in humanResourceManager.Departments)
            {
                if (newName.ToLower() == item.Name.ToLower())
                {
                    Console.WriteLine("*** Daxil etdiyniz adda departament movcudur.Duzgun daxil edin : ***");
                    goto CheckName;
                }
            }
            while (newName.Length < 2)
            {
                Console.WriteLine("*** Departamentin adinin uzunlugu 2-den az ola bilmez.Duzgun daxil edin : ***\n");
                newName = Console.ReadLine().Trim();
            }
            Console.WriteLine($"\n*** \"{oldName.ToUpper()}\" departamentinin adi \"{newName.ToUpper()}\" adi ile evez edildi ***\n");
            humanResourceManager.EditDepartaments(oldName,newName);
        }
        #endregion

        #region Employee
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length == 0)
            {
                Console.WriteLine("***Hec bir departament elave olunmayib.Ilk once departament elave edin...\n");
                return;
            }
            Console.WriteLine("Elave etmek istediyiniz iscinin butov adini daxil edin : ");
        CheckName:
            string fullname = Console.ReadLine().Trim();
            int count1 = 0;
            for (int i = 0; i < fullname.Length; i++)
            {
                if(fullname[i] != ' ')
                {
                    count1++;
                }
            }
            if(count1 == fullname.Length)
            {
                Console.WriteLine("*** Minimum 2 soz daxil edilmelidir.Duzgun daxil edin : ***\n");
                goto CheckName;
            }


            Console.WriteLine("Elave etmek istediyiniz iscinin vezifesini daxil edin : ");
            string position = Console.ReadLine().Trim();
            while (position.Length < 2)
            {
                Console.WriteLine("*** Vezifenin adinin uzunlugu 2den az ola bilmez.");
                Console.Write("*** Vezifenin adini yeniden daxil edin : ");
                position = Console.ReadLine().Trim();
            }

            Console.WriteLine("Movcud olan departamentler : ");
            foreach (Department item in humanResourceManager.Departments)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Iscini elave etmek istediyiniz departamentin adini daxil edin : ");

            string department = Console.ReadLine().Trim();
            bool checkName = true;
            int count = 0;
            
            while (checkName)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (department.ToLower() == item.Name.ToLower())
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine($"\n*** Daxil etdiyiniz adda departament yoxdur... ***\n");
                    return;
                }
                else
                {
                    checkName = false;
                }
                count = 0;
            }

            double salary = 0;
            foreach (Department item in humanResourceManager.Departments)
            {
                if(department.ToLower() == item.Name.ToLower())
                {
                    if (item.WorkerCount() + 1 > item.WorkerLimit)
                    {
                        Console.WriteLine("Departatment temamile dolududr.Isci elave ede bilmezsiniz");
                        return;
                    }
                    if (item.SalaryLimit - item.CalcSalaryAverage()*item.WorkerCount() < 250)
                    {
                        Console.WriteLine("Maas limitine gore isci elave etmek olmur");
                        return;
                    }
                    Console.WriteLine("Iscinin maasini daxil edin : ");
                    string salaryName = Console.ReadLine().Trim();
                    while (!double.TryParse(salaryName, out salary) || salary < 250 || item.CalcSalaryAverage() * item.WorkerCount() + salary > item.SalaryLimit)
                    {
                        Console.WriteLine($"*** Iscinin maasi 250-den az {item.SalaryLimit - (item.CalcSalaryAverage() * item.WorkerCount())}-dan cox ola bilmez... ***");
                        Console.Write("*** Iscinin maasini duzgun daxil edin : ");
                        salaryName = Console.ReadLine().Trim();
                    }
                }
                    
            }
            Console.WriteLine($"\n*** \"{fullname.ToUpper()}\" adli isci elave edildi ***\n");
            humanResourceManager.AddEmployee(fullname, position, salary, department);
        }
        static void GetEmployees(ref HumanResourceManager humanResourceManager)
        {

            Employee[] employees = humanResourceManager.GetEmployees();
            if (employees.Length <= 0)
            {
                Console.WriteLine($"*** Hec bir isci elave edilmeyib.Ilk once isci elave edin. ***\n");
                return;
            }
            Console.WriteLine("Movcud olan iscilerin siyahisi :\n\n-----------Employees-----------|");
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"{i+1}. {employees[i]}");
            }
        }
        static void GetEmployeesByDepartment(ref HumanResourceManager humanResourceManager)
        {
            if (humanResourceManager.Departments.Length == 0)
            {
                Console.WriteLine($"*** Hec bir departament elave edilmeyib.Ilk once departament elave edin ... ***\n");
                return;
            }
            else
            {
                for (int i = 0; i < humanResourceManager.Departments.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {humanResourceManager.Departments[i].Name}\n");
                }
            }
            Console.WriteLine("Iscilerini gormek istediyiniz departmentin adini daxil edin :");
            string departmentName = Console.ReadLine().Trim();
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
                    Console.Write("Duzgun Ad Daxil Et: \n");
                    departmentName = Console.ReadLine().Trim();
                }
                else
                {
                    checkName = false;
                }
                count = 0;
            }

            Employee[] employees = humanResourceManager.GetEmployeesByDepartment(departmentName);
            if(employees.Length == 0)
            {
                Console.WriteLine($"*** \"{departmentName}\" departamentine hec bir isci elave edilmeyib.Ilk once isci elave edin... ***\n");
                return;
            }
            Console.WriteLine("-------------------------------|");
            foreach (Employee item in employees)
            {
                Console.WriteLine(item);
            }
        }
        static void RemoveEmployee(ref HumanResourceManager humanResourceManager)
        {
            Employee[] employees = humanResourceManager.GetEmployees();
            if (employees.Length <= 0)
            {
                Console.WriteLine($"*** Hec bir isci elave edilmeyib.Ilk once isci elave edin... ***\n");
                return;
            }
            foreach (Employee item in employees)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Silmek istediyiniz iscinin nomresini daxil edin : ");
            string no = Console.ReadLine().Trim();
            bool checkNo = true;
            int count = 0;

            while (checkNo)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee item2 in item.Employees)
                    {
                        if (item2 != null && item2.No.ToLower() == no.ToLower())
                        {
                            count++;
                        }
                    }
                }

                if (count <= 0)
                {
                    Console.WriteLine($"\n*** Daxil etdiyniz nomreli isci movcud deyil...***\n");
                    return;
                }
                else
                {
                    checkNo = false;
                }

                count = 0;
            }
            Console.WriteLine("Silmek istediyiniz iscinin departamentini daxil edin : ");
        CheckDep:
            string depart = Console.ReadLine().Trim();
            foreach (Department item in humanResourceManager.Departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if(item2 != null && no.ToLower() == item2.No.ToLower() && item2.DepartmentName.ToLower() != depart.ToLower())
                    {
                        Console.WriteLine("*** Daxil etdiyiniz departament adi silmek istediyiniz isciye uygun deyil.Yeniden daxil edin :***");
                        goto CheckDep;
                    }
                }
            }
            Console.WriteLine($"*** \"{no.ToUpper()}\" nomreli isci deparatmanetden silindi ... ***");
            humanResourceManager.RemoveEmployee(no,depart);
        }
        static void EditEmploye(ref HumanResourceManager humanResourceManager)
        {
            Employee[] employees = humanResourceManager.GetEmployees();
            if (employees.Length <= 0)
            {
                Console.WriteLine("*** Hec bir isci elave edilmeyib.Ilk once isci elave edin ... ***\n");
                return;
            }
            foreach (Employee item in employees)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Deyisdirmek istediyiniz iscinin nomrensini daxil edin : ");
            string no = Console.ReadLine().Trim();
            int count = 0;
            foreach (Employee item in employees)
            {
                if(item.No.ToLower() != no.ToLower())
                {
                    count++;
                }
            }
            if(count >= employees.Length)
            {
                Console.WriteLine($"\n*** Daxil etdiyiniz nomre yalnisidir ***\n");
                return;
            }

            Console.WriteLine("Iscinin yeni vezifesini daxil edin : ");
            string position = Console.ReadLine().Trim();
            while (position.Length < 2)
            {
                Console.WriteLine("*** Vezifenin adinin uzunlugu 2den az ola bilmez.Vezifenin adini yeniden daxil edin : ***");
                position = Console.ReadLine().Trim();
            }

            Console.WriteLine("Iscinin yeni maasini daxil edin : ");
            string salaryName = Console.ReadLine().Trim();
            double salary = 0;
            foreach (Department item in humanResourceManager.Departments)
            {
                foreach (Employee item2 in item.Employees)
                {
                    if (item2 != null && no.ToLower() == item2.No.ToLower())
                    {
                        while (!double.TryParse(salaryName, out salary) || salary < 250 || salary + item.CalcSalaryAverage() * item.WorkerCount() - item2.Salary > item.SalaryLimit)
                        {
                            Console.WriteLine($"*** Iscinin maasi 250-den az {item.SalaryLimit - item.CalcSalaryAverage() * item.WorkerCount() + item2.Salary }-dan cox ola bilmez.Iscinin maasini duzgun daxil edin : ***");
                            salaryName = Console.ReadLine();
                        }
                    }
                }
            }
            Console.WriteLine($"*** \"{no.ToUpper()}\" nomreli isci uzerinde deyisiklik edildi ***");
            humanResourceManager.EditEmploye(no, position, salary);
        }
        #endregion
    }
}