using Humans;
using System;

namespace Commands {

    internal class ShiftCommand<T> : ICommand {
        private Application app;

        public ShiftCommand (Application app) {
            this.app = app;
        }

        public string Name { get { return "shift"; } }

        public string Help {
            get {
                return "Добавление элемента в начало дека";
            }
        }

        public string[] Synonyms {
            get { return new string[] { }; }
        }

        public string Description {
            get {
                return "Добавляет элемент в начало дека. " +
                       "Параметр — имя класса, объект которого требуется поместить в дек";
            }
        }

        public void Execute (params string[] parameters) {
            while (parameters.Length == 0) {
                Console.WriteLine("Какой класс вы хотите добавить? (human, student или worker)");
                parameters = Console.ReadLine().Split(new char[] { ' ' }, 1, StringSplitOptions.RemoveEmptyEntries);
            }
            switch (parameters[0]) {
                case "human":
                    Human newHuman = new Human();
                    newHuman.Enter();
                    Humans.deque.Shift(newHuman);
                    break;

                case "student":
                    Student newStudent = new Student();
                    newStudent.Enter();
                    Humans.deque.Shift(newStudent);
                    break;

                case "worker":
                    Worker newWorker = new Worker();
                    newWorker.Enter();
                    Humans.deque.Shift(newWorker);
                    break;

                default:
                    Console.WriteLine("Некорректное имя класса, попробуйте еще раз");
                    break;
            }
        }
    }
}