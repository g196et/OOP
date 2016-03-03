using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;
using lab4;

namespace lab5
{
    class ShiftCommand<T> : ICommand
    {
        Application app;
        public ShiftCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "shift"; } }
        public string Help { get { return "Добавляет элемент в голову последовательности."+
            "Параметр - имя класса, объект которого требуется поместить в дек"; } }
        public string[] Synonyms
        {
            get { return new string[] {  }; }
        }
        public string Description
        {
            get { return "Добавляет элемент в голову последовательности"; }
        }
        public void Execute(params string[] parameters)
        {
            while (parameters.Length == 0)
            {
                Console.WriteLine("Введите параметр(human, student или worker)");
                parameters = Console.ReadLine().Split(new char[] { ' ' }, 1, StringSplitOptions.RemoveEmptyEntries);
            }
            switch (parameters[0])
            {
                case "human":
                    Human newHuman = new Human();
                    newHuman.Enter();
                    Class1.deque.Shift(newHuman);
                    break;
                case "student":
                    Student newStudent = new Student();
                    newStudent.Enter();
                    Class1.deque.Shift(newStudent);
                    break;
                case "worker":
                    Worker newWorker = new Worker();
                    newWorker.Enter();
                    Class1.deque.Shift(newWorker);
                    break;
            }
        }
    }
}
