using System;

namespace Commands {

    public class HelpCommand : ICommand {
        private Application app;
        public string Name { get { return "help"; } }
        public string Help { get { return "Описание всех команд"; } }

        public string[] Synonyms {
            get { return new string[] { "?" }; }
        }

        public string Description {
            get { return "Выводит список команд с кратким описанием"; }
        }

        public HelpCommand (Application app) {
            this.app = app;
        }

        public void Execute (params string[] parameters) {
            Console.WriteLine(line);
            foreach (ICommand cmd in app.Commands) {
                Console.WriteLine("{0, -15} {1:N1}", cmd.Name, cmd.Help);
            }
            Console.WriteLine(line);
        }

        private const string line = "===============================================================================";

        public static implicit operator HelpCommand (int v) {
            throw new NotImplementedException();
        }
    }
}