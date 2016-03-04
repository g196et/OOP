using System;
using System.IO;

namespace Humans {

    public class Student : Human {
        private static string university;
        private static int course;
        private static float grandPointAverage;
        private FileInfo file;

        public Student () {
            university = "";
            course = 0;
            grandPointAverage = 0;
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
            Console.Write("ВУЗ: ");
            university = Console.ReadLine();
            Console.Write("Курс: ");
            while (!int.TryParse(Console.ReadLine(), out course))
                Console.WriteLine("Некорректный ввод, курс — целое число");
            Console.Write("Средний балл: ");
            while (!float.TryParse(Console.ReadLine(), out grandPointAverage))
                Console.WriteLine("Некорректный ввод, введите число.");
        }

        public override void Print () {
            base.Print();
            Console.Write("ВУЗ: ");
            Console.WriteLine(university);
            Console.Write("Курс: ");
            Console.WriteLine(course);
            Console.Write("Средний балл: ");
            Console.WriteLine(grandPointAverage);
        }

        public override void InFile (StreamWriter sw) {
            base.InFile(sw);
            sw.WriteLine(university);
            sw.WriteLine(course);
            sw.WriteLine(grandPointAverage);
        }

        public override void OutFile (StreamReader sr) {
            base.OutFile(sr);
            university = sr.ReadLine();
            course = int.Parse(sr.ReadLine());
            grandPointAverage = float.Parse(sr.ReadLine());
        }
    }
}