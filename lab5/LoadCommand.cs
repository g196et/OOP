using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleUI;
using lab4;

namespace lab5
{
    class LoadCommand<T> : ICommand
    {
        Application app;
        public LoadCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "load"; } }
        public string Help
        {
            get { return "Загрузка из файла"; }
        }
        public string[] Synonyms
        {
            get { return new string[] { "loading" }; }
        }
        public string Description
        {
            get { return "Загрузка данных из файла и помещение их в дек"; }
        }
        public void Execute(params string[] parameters)
        {
            Deque<Human>.Load(parameters[0]);
        }
    }
}
