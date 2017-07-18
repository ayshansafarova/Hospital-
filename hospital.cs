using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the password: ");
            if (Console.ReadLine() == "admin")
            {
                //"static" objects have been given in this section, departmentsList and also doctorsList
                List<Departments> departmentsList = new List<Departments>()
                {
                        new Departments("Kardiologiya"),
                        new Departments("Radyologiya"),
                        new Departments("Dermatologiya")
                };
                departmentsList[0].doctorsList = new List<Doctors>()
                {
                    new Doctors("Zulfiya","Imamaliyeva"),
                    new Doctors("Yaqub","Aliyev")
                };
                departmentsList[1].doctorsList = new List<Doctors>()
                {
                    new Doctors("Aydin","Seferov"),
                    new Doctors("Aydan","Aliyeva")
                };
                departmentsList[2].doctorsList = new List<Doctors>()
                {
                    new Doctors("Shakir","Islamov")
                };
                departmentsList.ShowList();
                while (true)
                {
                    Console.WriteLine("Choose operation: ");
                    string caseSwitch = Console.ReadLine();
                    switch (caseSwitch)
                    {
                        case "show1":
                            departmentsList.ShowList();
                            break;
                        case "ad1":
                            departmentsList.AddObject();
                            break;
                        case "rem1":
                            departmentsList.RemoveObject();
                            break;
                        case "chan1":
                            departmentsList.ChangeNameObject();
                            break;
                        case "show2":
                            Console.WriteLine("Enter an index of the department you want: ");
                            int a = Convert.ToInt32(Console.ReadLine());
                            departmentsList[a].doctorsList.ShowListt();
                            break;
                        case "ad2":
                            Console.WriteLine("Enter an index of the department you want: ");
                            int b = Convert.ToInt32(Console.ReadLine());;
                            departmentsList[b].doctorsList.AddObjectt();
                            break;
                        case "rem2":
                            Console.WriteLine("Enter an index of the department you want: ");
                            int c = Convert.ToInt32(Console.ReadLine());
                            departmentsList[c].doctorsList.RemoveObjectt();
                            break;
                        case "chan2":
                            Console.WriteLine("Enter an index of the department you want: ");
                            int d = Convert.ToInt32(Console.ReadLine());
                            departmentsList[d].doctorsList.ChangeNameSurnameObject();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong!");
            }
        }

    }

    //this class is created for adding extension methods to the lists
    //in order to make a difference, I added 1 more 't' to the names of methods which are used for only "doctors" object
    public static class ListExtensions
    {
        public static void ShowList(this List<Departments> list)
        {
            Console.WriteLine("------Departments-----");
            foreach (var departments in list)
            {
                Console.WriteLine(departments.name);
            }
        }
        public static void ShowListt(this List<Doctors> list)
        {
            Console.WriteLine("------Doctors-----");
            foreach (var doctors in list)
            {
                Console.WriteLine(doctors.name + " " + doctors.surname);
            }
        }
        public static void AddObject(this List<Departments> list)
        {
            string a = Console.ReadLine();
            list.Add(new Departments(a));
            list.ShowList();
        }
        public static void AddObjectt(this List<Doctors> list)
        {
            Console.WriteLine("enter a name: ");
            string a = Console.ReadLine();
            Console.WriteLine("enter a surname: ");
            string b = Console.ReadLine();
            list.Add(new Doctors(a,b));
            list.ShowListt();
        }
        public static void RemoveObject(this List<Departments> list)
        {
            string givenName = Console.ReadLine();
            var item = list.Find(x => x.name == givenName);
            list.Remove(item);
            list.ShowList();
        }
        public static void RemoveObjectt(this List<Doctors> list)
        {
            string givenWord = Console.ReadLine();
            var item = list.Find(x => x.name == givenWord || x.surname==givenWord || (x.name + " " + x.surname)==givenWord);
            list.Remove(item);
            list.ShowListt();
        }
        public static void ChangeNameObject(this List<Departments> list)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            var item = list.Find(x => x.name == firstName);          
            item.name=item.name.Replace(firstName, secondName);
            list.ShowList();
        }
        public static void ChangeNameSurnameObject(this List<Doctors> list)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            var item = list.Find(x => (x.name == first) || (x.surname == first));
            if (item.name == first)
            {
                item.name = item.name.Replace(first, second);
            }
            else {
                item.surname = item.surname.Replace(first, second);
            }
            list.ShowListt();
        }
    }

    //there are two classes which can create lots of objects.
    public class Departments
    {
        public string name;
        public List<Doctors> doctorsList = new List<Doctors>(); //I gived public access to append doctorsList to DepartmentsList
        public Departments(string Name)
        {
            name = Name;
        }
        
    }
    public class Doctors
    {
        public string name;
        public string surname;
        public Doctors(string Name, string Surname)
        {
            name = Name;
            surname = Surname;
        }
    }
}
