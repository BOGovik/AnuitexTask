using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anuitex
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Добро пожаловать в консольную программу Фирма!\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            bool contin = true;
            int command;
            int id;
            while (contin)
            {
                Console.WriteLine("Ниже представлен список команд с их ID. \nВыберите нужную команду и введите её ID, после чего нажмите Enter!\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("ID   Описание команды\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1    Добавить одного сотрудника");
                Console.WriteLine("2    Добавить сотрудников в фирму");
                Console.WriteLine("3    Уволить сотрудника");
                Console.WriteLine("4    Уволить всех сотрудников");
                Console.WriteLine("5    Просмотр всех сотрудников фирмы");
                Console.WriteLine("6    Посмотреть, чем занимаются сотрудники");
                Console.WriteLine("7    Поиск сотрудников по должности");
                Console.WriteLine("8    Выход");
                Console.Write("\nВведите ID: ");

                if (int.TryParse(Console.ReadLine(), out id))
                {

                    Console.Clear();
                    switch (id)
                    {

                        case 1:
                            Company.Add();
                            Console.WriteLine("-------------------------");
                            Console.WriteLine("Готово! Сотрудник добавлен!");
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - Вернуться к списку команд \n2 - Просмотр всех сотрудников фирмы \nEnter - Выйти из программы");

                            Console.Write("Введите ID команды: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                else if (command == 2) { goto case 5; }
                                else contin = false;
                            }
                            else contin = false;
                            break;

                        case 2:
                            Company.TestCollect();
                            Console.WriteLine("-------------------------");
                            Console.WriteLine("Готово! Сотрудники добавлены!");
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - Вернуться к списку команд \n2 - Просмотр всех сотрудников фирмы \nEnter - Выйти из программы");

                            Console.Write("Введите ID команды: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                else if (command == 2) { goto case 5; }
                                else contin = false;
                            }
                            else contin = false;
                            break;

                        case 3:
                            Company.Delete();
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - Вернуться к списку команд \n2 - Добавить сотрудника \n3 - Уволить сотрудника \n4 - Уволить всех сотрудников фирмы \nEnter - Выйти из программы");

                            Console.Write("Введите ID команды: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                else if (command == 2) { goto case 1; }
                                else if (command == 3) { goto case 3; }
                                else if (command == 4) { goto case 4; }
                                else contin = false;
                            }
                            else contin = false;
                            break;

                        case 4:
                            Company.Remove();
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - Вернуться к списку команд \n2 - Добавить сотрудника \n3 - Добавить сотрудников \nEnter - Выйти из программы");

                            Console.Write("Введите ID команды: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                else if (command == 2) { goto case 1; }
                                else if (command == 3) { goto case 2; }
                                else contin = false;
                            }
                            else contin = false;
                            break;

                        case 5:
                            Company.ShowAll();
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - Вернуться к списку команд \n2 - Подсчитать количество работающих сотрудников в фирме \n3 - Добавить сотрудника \n4 - Уволить сотрудника \n5 - Уволить всех сотрудников фирмы \nEnter - Выйти из программы");

                            Console.Write("Введите ID команды: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                else if (command == 2) { Company.Quantity(); }
                                else if (command == 3) { goto case 1; }
                                else if (command == 4) { goto case 3; }
                                else if (command == 5) { goto case 4; }
                                else contin = false;
                            }
                            else contin = false;
                            break;

                        case 6:

                            Company.Work();
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("1 - Вернуться к списку команд \n2 - Что входит в обязанности менеджера \n3 - Что входит в обязанности бригадира \nEnter - Выйти из программы");

                            Console.Write("Введите ID команды: ");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Console.Clear(); continue; }
                                else if (command == 2) { Manager.Task(); Thread.Sleep(4000); Console.Clear(); }
                                else if (command == 3) { Taskmaster.Check(); Thread.Sleep(4000); Console.Clear(); }
                                else contin = false;
                            }
                            else contin = false;
                            break;

                        case 7:
                            Console.WriteLine("Введите должность сотрудника согласно его ID, чтобы начать поиск");
                            Console.WriteLine("\nID  Должность\n");
                            Console.WriteLine("1 - Рабочий \n2 - Менеджер \n3 - Бригадир \n\nEnter - Выйти из программы");
                            if (int.TryParse(Console.ReadLine(), out command))
                            {
                                if (command == 1) { Company.Find(1); Thread.Sleep(5000); Console.Clear(); continue; }
                                else if (command == 2) { Company.Find(2); Thread.Sleep(5000); Console.Clear(); continue; }
                                else if (command == 3) { Company.Find(3); Thread.Sleep(5000); Console.Clear(); continue; }
                                else contin = false;
                            }
                            contin = false;
                            break;

                        case 8:
                            contin = false;
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Введен неверный ID! Пожалуйста, введите верный ID!");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Введен неверный ID! Пожалуйста, введите верный ID!");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
            }

            Console.ReadKey();
        }
    }
}
