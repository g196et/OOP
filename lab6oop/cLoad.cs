using Humans;
using System;
using System.IO;

namespace Commands {

    internal class LoadCommand<T> : ICommand {
        private Application app;

        public LoadCommand (Application app) {
            this.app = app;
        }

        public string Name { get { return "load"; } }

        public string Help {
            get { return "Загрузка из файла и запись в дек"; }
        }

        public string[] Synonyms {
            get { return new string[] { "loading", "outfile" }; }
        }

        public string Description {
            get { return "Загрузка данных из файла и помещение их в дек"; }
        }

        public void Execute (params string[] parameters) {
            Humans.deque.Clear();
            while (parameters.Length == 0) {
                Console.WriteLine("Введите имя файла");
                parameters = Console.ReadLine().Split(new char[] { ' ' }, 1, StringSplitOptions.RemoveEmptyEntries);
            }
            FileInfo file = new FileInfo(parameters[0]);
            if (!file.Exists) {
                Console.WriteLine("Файл не найден");
            } else {
                StreamReader reader = new StreamReader(parameters[0]);
                while (!reader.EndOfStream)
                    try {
                        switch (reader.ReadLine()) {
                            case "Human":
                                Human newH = new Human();
                                newH.OutFile(reader);
                                Humans.deque.Push(newH);
                                break;

                            case "Student":
                                Student newS = new Student();
                                newS.OutFile(reader);
                                Humans.deque.Push(newS);
                                break;

                            case "Worker":
                                Worker newW = new Worker();
                                newW.OutFile(reader);
                                Humans.deque.Push(newW);
                                break;
                        }
                    } catch {
                        Console.WriteLine("Что-то пошло не так! Некоторые элементы не считались.\n" +
                                          "Проверьте корректность данных.");
                    }
                reader.Dispose();
                reader.Close();
            }
        }
    }
}