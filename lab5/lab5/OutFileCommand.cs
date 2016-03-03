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
    class OutFileCommand<T>:ICommand
    {
        Application app;
        public OutFileCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "outfile"; } }
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
            StreamReader reader = new StreamReader(parameters[0]);
            switch(reader.ReadLine())
            {
                case "Human":
                    Human newH = new Human(); 
                    newH.OutFile(reader);
                    Class1.deque.Push(newH);
                    break;
                case "Student":
                    Student newS = new Student(); 
                    newS.OutFile(reader);
                    Class1.deque.Push(newS);
                    break;
                case "Worker":
                    Worker newW = new Worker(); 
                    newW.OutFile(reader);
                    Class1.deque.Push(newW);
                    break;
            }
            reader.Close();
        }
    }
}
