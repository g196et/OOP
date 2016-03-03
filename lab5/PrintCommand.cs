using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Deque;
using Humans;

namespace Commands
{
    class PrintCommand<T> : ICommand
    {
        Application app;
        public PrintCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "print"; } }
        public string Help { get { return "Печатает содержимое дека"; } }
        public string[] Synonyms
        {
            get { return new string[] {  }; }
        }
        public string Description
        {
            get { return "Печатает содержимое дека "; }
        }
        public void Execute(params string[] parameters)
        {
            if (parameters.Length == 0)
            {
                Class1.deque.Print("");
            }
            else
            {
                FileInfo file = new FileInfo(parameters[0]);
                if (!file.Exists)
                {
                    var myFile = File.Create(parameters[0]);
                    myFile.Close();
                }
                StreamWriter writer = new StreamWriter(parameters[0]);
                for (int i = 0; i < Class1.deque.Length; i++)
                {
                    switch (Class1.deque[i].GetType().ToString())
                    {
                        case "lab4.Human":
                            writer.WriteLine("Human");
                            break;
                        case "lab4.Student":
                            writer.WriteLine("Student");
                            break;
                        case "lab4.Worker":
                            writer.WriteLine("Worker");
                            break;
                    }
                    Class1.deque[i].InFile(writer);
                }
                writer.Dispose();
            }
        
        }
    }
}
