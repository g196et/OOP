using System;
using System.IO;

namespace Humans {

    public class Worker : Human {
        private static string workPlace;
        private static float workExperience;
        private FileInfo file;

        public Worker () {
            workPlace = "";
            workExperience = 0;
        }

        public override void Openf (string fileName, bool mode) {
            file = new FileInfo(fileName);
            if (!file.Exists) {
                var myFile = File.Create(fileName);
                myFile.Close();
            }
            if (mode)
                writer = new StreamWriter(fileName);
            else
                reader = new StreamReader(fileName);
        }

        public override void Enter () {
            base.Enter();
            Console.Write("Место работы: ");
            workPlace = Console.ReadLine();
            Console.Write("Стаж: ");
            while (!float.TryParse(Console.ReadLine(), out workExperience))
                Console.WriteLine("Некорректный ввод, стаж — число");
        }

        public override void Print () {
            base.Print();
            Console.WriteLine("Место работы: " + workPlace);
            Console.WriteLine("Стаж: " + workExperience);
        }

        public override void InFile (StreamWriter sw) {
            base.InFile(sw);
            sw.WriteLine(workPlace);
            sw.WriteLine(workExperience);
        }

        public override void OutFile (StreamReader sr) {
            base.OutFile(sr);
            workPlace = sr.ReadLine();
            workExperience = float.Parse(sr.ReadLine());
        }
    }
}