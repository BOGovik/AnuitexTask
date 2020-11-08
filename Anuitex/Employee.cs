using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anuitex
{
    
    public class Employee
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1} {2}", LastName, FirstName, MiddleName); }
        }
        public int WorkExp { get; set; }

        public Employee(string fName, string lName, string mName, int wExp)
        {                     
            FirstName = fName;
            LastName = lName;
            MiddleName = mName;
            WorkExp = wExp;
        }

        public virtual void Work()  
        {
            Console.WriteLine("Employee.Work()");
        }


    }

    public class Worker : Employee //сотрудник типа "Рабочий"
        {
            public Worker(string fName, string lName, string mName, int wExp)
                : base(fName, lName, mName, wExp) { }

            public override void Work()
            {
                Console.Write(" - рабочий и он занимается выпуском продукции!");
            }
    }

    public class Manager : Employee //сотрудник типа "Менеджер"
        {
            public Manager(string fName, string lName, string mName, int wExp)
                : base(fName, lName, mName, wExp) { }
            public override void Work()
            {
                Console.Write(" - менеджер и он занимается сбором заказов!");
            }

            internal static void Task()
            {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Менеджер раздаёт задания рабочим и бригадиру!");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
    }

    public class Taskmaster : Employee //сотрудник типа "Бригадир"
        {
            public Taskmaster(string fName, string lName, string mName, int wExp)
                : base(fName, lName, mName, wExp) { }

            public override void Work()
            {
                Console.Write(" - бригадир и он занимается закупкой материалов!");
            }
            internal static void Check()
            {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Бригадир проверяет рабочих!");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
    }
}



