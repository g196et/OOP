using Humans;
using System;

namespace Commands {

    internal class UnshiftCommand<T> : ICommand
        where T : Human, new() {
        private Application app;

        public UnshiftCommand (Application app) {
            this.app = app;
        }

        public string Name { get { return "unshift"; } }

        public string Help {
            get {
                return "Удаление первого элемента из дека";
            }
        }

        public string[] Synonyms {
            get { return new string[] { }; }
        }

        public string Description {
            get {
                return "Возвращает первый элемент с головы дека " +
                       "и удаляет его (при Length = 0 выдается InvalidOperationException)";
            }
        }

        public void Execute (params string[] parameters) {
            Console.WriteLine(Humans.deque.Unshift());
        }
    }
}