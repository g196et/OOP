using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deque;
using Humans;

namespace Commands
{
    class PopCommand<T> : ICommand
    {
        Application app;
        public PopCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "pop"; } }
        public string Help { get { return "Возвращает первый элемент с хвоста последовательности"+
            "и удаляет его"; } }
        public string[] Synonyms
        {
            get { return new string[] {  }; }
        }
        public string Description
        {
            get { return "Печатает содержимое дека "; }
        }
        public void Execute(params string[] parameters)
        {
            Console.WriteLine(Class1.deque.Pop());
        }
    }
}
