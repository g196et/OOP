using System;

namespace Commands {

    internal class PopCommand<T> : ICommand {
        private Application app;

        public PopCommand (Application app) {
            this.app = app;
        }

        public string Name { get { return "pop"; } }

        public string Help {
            get {
                return "Удаление последнего элемента из дека";
            }
        }

        public string[] Synonyms {
            get { return new string[] { }; }
        }

        public string Description {
            get {
                return "Возвращает первый элемент с хвоста дека " +
                       "и удаляет его (при Length = 0 выдается InvalidOperationException)";
            }
        }

        public void Execute (params string[] parameters) {
            Console.WriteLine(Humans.deque.Pop());
        }
    }
}