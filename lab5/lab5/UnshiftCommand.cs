using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI;
using lab4;

namespace lab5
{
    class UnshiftCommand<T> : ICommand
        where T:Human,new()
    {
        Application app;
        public UnshiftCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "unshift"; } }
        public string Help { get { return "Возвращает первый элемент с головы последовательности "+
        "и удаляет его"; } }
        public string[] Synonyms
        {
            get { return new string[] {  }; }
        }
        public string Description
        {
            get { return "Возвращает первый элемент с головы последовательности "+
            "и удаляет его(при Length == 0 бросается  InvalidOperationException)";
            }
        }
        public void Execute(params string[] parameters)
        {
            Console.WriteLine(Class1.deque.Unshift());
        }
    }
}
