using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anuitex
{
    public class Company
    {
        static string error = "Ой, что-то пошло не так, это поле не может содержать иных символов, кроме букв!";
        static string necessarily = "Данная информация обязательна к заполнению!";
        public static List<Employee> list = new List<Employee>();

        public static void TestCollect() //add few employees
        {
            list.Add(new Worker("Пётр", "Петров", "Петрович", 5));
            list.Add(new Worker("Иван", "Иванов", "Иванович", 2));
            list.Add(new Worker("Степан", "Степанов", "Степанович", 3));
            list.Add(new Worker("Алексей", "Алексеенко", "Алексеевич", 6));
            list.Add(new Manager("Фёдор", "Федоров", "Фёдорович", 4));
            list.Add(new Taskmaster("Николай", "Николаев", "Николаевич", 1));
        }
        public static void ShowAll() //show all employees
        {

            Console.Clear();
            if (list.Count == 0) { Console.WriteLine("В компании ещё никто не работает"); }
            else
            {
                var result = list.OrderBy(u => u.LastName);
                Console.WriteLine("\tСотрудники\n");
                foreach (Employee u in result)
                    Console.WriteLine($"{u.FullName}\nСтаж работы: {u.WorkExp}\n___________________________________");
            }

        }
        public static void Quantity()
        {
            Console.Clear();
            Console.WriteLine("Количество сотрудников работающих сейчас в фирме - " + list.Count);
            Thread.Sleep(3000);
        }
        public static void Add() //add employee
        {
            Console.WriteLine("Добавление нового сотрудника");

        lastname:
            Console.Write("Введите фамилию нового сотрудника: ");
            string lastname = Console.ReadLine();
            if (string.IsNullOrEmpty(lastname)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(necessarily); Console.ForegroundColor = ConsoleColor.DarkYellow; goto lastname;  }
            else
            {
                foreach (var e in lastname) { if (!char.IsLetter(e)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(error); Console.ForegroundColor = ConsoleColor.DarkYellow; goto lastname; } }
            }

        firstname:
            Console.Write("Введите имя нового сотрудника: ");
            string firstname = Console.ReadLine();
            if (string.IsNullOrEmpty(firstname)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(necessarily); Console.ForegroundColor = ConsoleColor.DarkYellow; goto firstname; }
            else
            {
                foreach (var e in firstname) { if (!char.IsLetter(e)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(error); Console.ForegroundColor = ConsoleColor.DarkYellow; goto firstname; } }
            }

        middlename:
            Console.Write("Введите отчество нового сотрудника: ");
            string middlename = Console.ReadLine();
            if (string.IsNullOrEmpty(middlename)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(necessarily); Console.ForegroundColor = ConsoleColor.DarkYellow; goto middlename; }
            else
            {
                foreach (var e in middlename) { if (!char.IsLetter(e)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(error); Console.ForegroundColor = ConsoleColor.DarkYellow; goto middlename; } }
            }

        workexp:
            Console.Write("Введите стаж работы нового сотрудника: ");
            int workexp;

            if (!int.TryParse(Console.ReadLine(), out workexp)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Ой, что-то пошло не так, это поле не может содержать иных символов, кроме цифр!"); Console.ForegroundColor = ConsoleColor.DarkYellow; goto workexp; }

        position:
            Console.Write("Выберите должность нового сотрудника: рабочий - 1, менеджер - 2, бригадир - 3\n");
            int position;

            if (!int.TryParse(Console.ReadLine(), out position)) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Ой, что-то пошло не так, введите число соответствующей должности!"); Console.ForegroundColor = ConsoleColor.DarkYellow; goto position; }

            switch (position)
            {
                case 1:
                    list.Add(new Worker(firstname, lastname, middlename, workexp));
                    break;
                case 2:
                    list.Add(new Manager(firstname, lastname, middlename, workexp));
                    break;
                case 3:
                    list.Add(new Taskmaster(firstname, lastname, middlename, workexp));
                    break;
                default :
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ой, что-то пошло не так, введите число соответствующей должности!");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    goto position;
            }

        }
        public static void Delete() //delete employee
        {

            if (list.Count > 0)
            {
                Console.Clear();
                Console.WriteLine(" ID\t      Сотрудники\n");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(" " + i + " \t" + list[i].FullName);
                    Console.WriteLine("\tСтаж работы: " + list[i].WorkExp);
                    Console.WriteLine("___________________________________");
                }

                Console.WriteLine("\nВведите ID сотрудника, которого хотите уволить: ");
                
                int id;

                if (int.TryParse(Console.ReadLine(), out id))
                {
                    if (id >= 0 && id < list.Count)
                    {
                        list.RemoveAt(id);
                        Console.Clear();
                        Console.WriteLine($"Сотрудник c ID номер {id} уволен!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введен неверный ID! Пожалуйста, введите верный ID.");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Thread.Sleep(2000);
                        Delete();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введен неверный ID! Пожалуйста, введите верный ID.");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Thread.Sleep(2000);
                    Delete();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Увольнять пока некого!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }
        public static void Remove() //delete all employees
        {
            if (list.Count > 0)
            {
                list.Clear();
                Console.Clear();
                Console.WriteLine("Все сотрудники уволены!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Увольнять пока некого!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }
        public static void Work() // duties of employees
        {
            if (list.Count > 0)
            {
                int count = 0;
                var result = list.OrderBy(p => p.LastName);
                foreach (Employee p in result)
                {
                    count++;
                    Console.Write(count + ". " + p.FullName); p.Work(); Console.WriteLine("");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В фирме нет сотрудников, поэтому некому работать");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }

        }
        public static void Find(int x) // search for an employee by position
        {
            if (list.Count > 0)
            {
                int countWorker = 0;
                int countManager = 0;
                int countTM = 0;
                var result = list.OrderBy(p => p.LastName);
                if (x == 1)
                {
                    foreach (Employee p in result)
                    {
                        string s = p.GetType().ToString();
                        if (s == "Anuitex.Worker") { countWorker++; }
                    }
                    Console.WriteLine("Рабочих в фирме работает - " + countWorker);
                }
                else if (x == 2)
                {
                    foreach (Employee p in result)
                    {
                        string s = p.GetType().ToString();
                        if (s == "Anuitex.Manager") { countManager++; }
                    }
                    Console.WriteLine("Менеджеров в фирме работает - " + countManager);
                }
                else if (x == 3)
                {
                    foreach (Employee p in result)
                    {
                        string s = p.GetType().ToString();
                        if (s == "Anuitex.Taskmaster") { countTM++; }
                    }
                    Console.WriteLine("Бригадиров в фирме работает - " + countTM);
                }
                else
                {
                    Console.WriteLine("Вы неправильно ввели ввели номер должности");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("В фирме нет сотрудников!");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }       
    }
}