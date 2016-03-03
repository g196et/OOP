using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deque;
using Humans;

namespace Commands
{
    class PushCommand<T> : ICommand
        where T:Human,new()
    {
        Application app;
        public PushCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "push"; } }
        public string Help { get { return "Добавляет элемент в  хвост последовательности"; } }
        public string[] Synonyms
        {
            get { return new string[] {  }; }
        }
        public string Description
        {
            get { return "Добавляет элемент в  хвост последовательности "; }
        }
        public void Execute(params string[] parameters)
        {
            while (parameters.Length == 0)
            {
                Console.WriteLine("Кого вы хотите добавить(human,student или worker)?");
                parameters = Console.ReadLine().Split(new char[] { ' ' }, 1, StringSplitOptions.RemoveEmptyEntries);
            }
            switch (parameters[0])
            {
                case "human":
                    Human newHuman = new Human();
                    newHuman.Enter();
                    Class1.deque.Push(newHuman);
                    break;
                case "student":
                    Student newStudent = new Student();
                    newStudent.Enter();
                    Class1.deque.Push(newStudent);
                    break;
                case "worker":
                    Worker newWorker = new Worker();
                    newWorker.Enter();
                    Class1.deque.Push(newWorker);
                    break;
            }
        }
    }
}
