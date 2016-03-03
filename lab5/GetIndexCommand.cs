using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deque;
using Humans;

namespace Commands
{
    class GetIndexCommand<T> : ICommand
        where T : Human, new()
    {
        Application app;
        public GetIndexCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "getindex"; } }
        public string Help
        {
            get
            {
                return"Вывод элемент с заданным индексом";
            }
        }
        public string[] Synonyms
        {
            get { return new string[] { "1" }; }
        }
        public string Description
        {
            get { return "Вывод элемента с заданным индексом из деки"; }
        }
        public void Execute(params string[] parameters)
        {
            while (parameters.Length == 0)
            {

                Console.WriteLine("Введите индекс элемента");
                parameters = Console.ReadLine().Split(new char[] { ' ' }, 1, StringSplitOptions.RemoveEmptyEntries);
            }
            try
            {
                if (parameters[0] != null)
                    Class1.deque[int.Parse(parameters[0])].Print();
            }

            catch
            {
                Console.WriteLine("Некоректный ввод. Попробуйте еще раз");
            }
            
        }
    }
}
