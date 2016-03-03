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
    class InFileCommand<T> : ICommand
    {
        Application app;
        public InFileCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "infile"; } }
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
            StreamWriter writer = new StreamWriter(parameters[0]);
            for (int i = 0; i < Deque<T>.deque.Length; i++)
               // Console.WriteLine(Deque<T>.deque[i].GetType().ToString());
                switch (Deque<T>.deque[i].GetType().ToString())
                {
                    case "lab4.Human":
                        writer.WriteLine("Human");
                        Human.InFile(writer);
                        break;
                    case "lab4.Student":
                        writer.WriteLine("Student");
                        Student.InFile(writer);
                        break;
                    case "lab4.Worker":
                        writer.WriteLine("Worker");
                        Worker.InFile(writer);
                        break;
                }
            writer.Close();
        }
    }
}
