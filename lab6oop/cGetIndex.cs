using Humans;
using System;

namespace Commands {

    internal class GetIndexCommand<T> : ICommand
        where T : Human, new() {
        private Application app;

        public GetIndexCommand (Application app) {
            this.app = app;
        }

        public string Name { get { return "getindex"; } }

        public string Help {
            get {
                return "Вывод элемента с заданным индексом";
            }
        }

        public string[] Synonyms {
            get { return new string[] { }; }
        }

        public string Description {
            get { return "Вывод элемента с заданным индексом из деки"; }
        }

        public void Execute (params string[] parameters) {
            while (parameters.Length == 0) {
                Console.WriteLine("Введите индекс элемента");
                parameters = Console.ReadLine().Split(new char[] { ' ' }, 1, StringSplitOptions.RemoveEmptyEntries);
            }
            try {
                if (parameters[0] != null)
                    Humans.deque[int.Parse(parameters[0])].Print();
            } catch {
                Console.WriteLine("Указанного элемента не существует или произведен некоректный ввод. Попробуйте еще раз");
            }
        }
    }
}