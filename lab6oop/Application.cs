using Deque;
using System;
using System.Collections.Generic;

namespace Commands {

    public class Application {
        private NotFoundCommand notFound = new NotFoundCommand();
        private Boolean keepRunning = true;
        private List<ICommand> commands = new List<ICommand>();
        private Dictionary<string, ICommand> commandMap = new Dictionary<string, ICommand>();
        private NameTable vars = new NameTable();

        public NameTable Variables { get { return vars; } }

        public void Exit () {
            keepRunning = false;
        }

        public ICommand FindCommand (string name) {
            if (commandMap.ContainsKey(name)) {
                return commandMap[name];
            }
            notFound.Name = name;
            return notFound;
        }

        public IList<ICommand> Commands { get { return commands; } }

        public void AddCommand (ICommand cmd) {
            commands.Add(cmd);
            if (commandMap.ContainsKey(cmd.Name)) {
                throw new Exception(String.Format("Команда {0} уже добавлена", cmd.Name));
            }
            commandMap.Add(cmd.Name, cmd);
            foreach (var s in cmd.Synonyms) {
                if (commandMap.ContainsKey(s)) {
                    Console.WriteLine("ERROR: Игнорирую синоним {0} для команды {1}, поскольку имя {0}  уже использовано", s, cmd.Name);
                    continue;
                }
                commandMap.Add(s, cmd);
            }
        }

        public void Run () {
            string[] cmdline;
            string[] parameters;
            Console.WriteLine("Добро пожаловать! Для начала работы введите команду «help»\n");
            while (keepRunning) {
                Console.Write("> ");
                cmdline = Console.ReadLine().Split(
                    new char[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries
                );
                if (cmdline.Length == 0) {
                    continue;
                }

                parameters = new string[cmdline.Length - 1];
                Array.Copy(cmdline, 1, parameters, 0, cmdline.Length - 1);
                ICommand cmd = FindCommand(cmdline[0]);
                cmd.Execute(parameters);
            }
            Console.WriteLine("До скорой встречи!");
        }
    }
}