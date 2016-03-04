using System.IO;

namespace Commands {

    internal class PrintCommand<T> : ICommand {
        private Application app;

        public PrintCommand (Application app) {
            this.app = app;
        }

        public string Name { get { return "print"; } }

        public string Help { get { return "Печать содержимого дека"; } }

        public string[] Synonyms {
            get { return new string[] { }; }
        }

        public string Description {
            get { return "Печатает содержимое дека "; }
        }

        public void Execute (params string[] parameters) {
            if (parameters.Length == 0) {
                Humans.deque.Print("");
            } else {
                FileInfo file = new FileInfo(parameters[0]);
                if (!file.Exists) {
                    var myFile = File.Create(parameters[0]);
                    myFile.Close();
                }
                StreamWriter writer = new StreamWriter(parameters[0]);
                for (int i = 0; i < Humans.deque.Length; i++) {
                    switch (Humans.deque[i].GetType().ToString()) {
                        case "Humans.Human":
                            writer.WriteLine("Human");
                            break;

                        case "Humans.Student":
                            writer.WriteLine("Student");
                            break;

                        case "Humans.Worker":
                            writer.WriteLine("Worker");
                            break;
                    }
                    Humans.deque[i].InFile(writer);
                }
                writer.Dispose();
            }
        }
    }
}