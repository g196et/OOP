using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Humans
{
    class Student : Human
    {
        static string university;
        static int course;
        static float grandPointAverage;
        FileInfo file;

        public Student()
        {
            university = "";
            course = 0;
            grandPointAverage = 0;
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
            Console.Write("ВУЗ: ");
            university = Console.ReadLine();
            Console.Write("Курс: ");
            while (!int.TryParse(Console.ReadLine(), out course))
                Console.WriteLine("heh");
            Console.Write("Ср. балл: ");
            while (!float.TryParse(Console.ReadLine(), out grandPointAverage))
                Console.WriteLine("heh");
        }
        public override void Print()
        {
            base.Print();
            Console.Write("ВУЗ: ");
            Console.WriteLine(university);
            Console.Write("Курс: ");
            Console.WriteLine(course);
            Console.Write("Ср. балл: ");
            Console.WriteLine(grandPointAverage);
        }
        public override void InFile(StreamWriter sw)
        {
            base.InFile(sw);
            sw.WriteLine(university);
            sw.WriteLine(course);
            sw.WriteLine(grandPointAverage);
        }
        public override void OutFile(StreamReader sr)///Reading null from the file
        {
            base.OutFile(sr);
            university = sr.ReadLine();
            course = int.Parse(sr.ReadLine());
            grandPointAverage = float.Parse(sr.ReadLine());
        }
    }
}
