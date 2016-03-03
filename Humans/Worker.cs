using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Humans
{
    class Worker : Human
    {
        static string workPlace;
        static float workExperience;
        FileInfo file;

        public Worker()
        {
            workPlace="";
            workExperience=0;
        }
        public override void Openf(string fileName, bool regim)
        {
            file = new FileInfo(fileName);
            if (!file.Exists)
            {
                var myFile = File.Create(fileName);
                myFile.Close();
            }
            if (regim)
                writer = new StreamWriter(fileName);
            else
                reader = new StreamReader(fileName);
        }
        public override void Enter()
        {
            base.Enter();
            Console.Write("Место работы: ");
            workPlace = Console.ReadLine();
            Console.Write("Стаж: ");
            while (!float.TryParse(Console.ReadLine(), out workExperience))
                Console.WriteLine("heh");
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Место работы: " + workPlace);
            Console.WriteLine("Стаж: " + workExperience);
        }
        public override void InFile(StreamWriter sw)
        {
            base.InFile(sw);
            sw.WriteLine(workPlace);
            sw.WriteLine(workExperience);
        }
        public override void OutFile(StreamReader sr)
        {
            base.OutFile(sr);
            workPlace = sr.ReadLine();
            workExperience = float.Parse(sr.ReadLine());
        }
    }
}
