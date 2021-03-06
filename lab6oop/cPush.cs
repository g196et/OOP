﻿using Humans;
using System;

namespace Commands {

    internal class PushCommand<T> : ICommand
        where T : Human, new() {
        private Application app;

        public PushCommand (Application app) {
            this.app = app;
        }

        public string Name { get { return "push"; } }

        public string Help {
            get {
                return "Добавление элемента в конец дека";
            }
        }

        public string[] Synonyms {
            get { return new string[] { }; }
        }

        public string Description {
            get {
                return "Добавляет элемент в конец дека. " +
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
                    Humans.deque.Push(newHuman);
                    break;

                case "student":
                    Student newStudent = new Student();
                    newStudent.Enter();
                    Humans.deque.Push(newStudent);
                    break;

                case "worker":
                    Worker newWorker = new Worker();
                    newWorker.Enter();
                    Humans.deque.Push(newWorker);
                    break;

                default:
                    Console.WriteLine("Некорректное имя класса, попробуйте еще раз");
                    break;
            }
        }
    }
}