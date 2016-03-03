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
    class LoadCommand<T>:ICommand
    {
        Application app;
        public LoadCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "load"; } }
        public string Help
        {
            get { return "Загрузка из файла и запись в дек"; }
        }
        public string[] Synonyms
        {
            get { return new string[] { "loading","outfile" }; }
        }
        public string Description
        {
            get { return "Загрузка данных из файла и помещение их в дек"; }
        }
        public void Execute(params string[] parameters)
        {
          
            while (parameters.Length == 0)
            {

                Console.WriteLine("Введите имя файла");
                parameters = Console.ReadLine().Split(new char[] { ' ' }, 1, StringSplitOptions.RemoveEmptyEntries);
            }
            FileInfo file = new FileInfo(parameters[0]);
            if (!file.Exists)
            {
                var myFile = File.Create(parameters[0]);
                myFile.Close();
            }
            StreamReader reader = new StreamReader(parameters[0]);
            while(!reader.EndOfStream)
                switch (reader.ReadLine())
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
            reader.Dispose();
            reader.Close();
        }
    }
}
