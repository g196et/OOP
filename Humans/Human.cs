using System;
using System.IO;

namespace Humans {

    public class Human {
        public string type;
        private string firstName;
        private string surname;
        private DateTimeOffset dateOfBirth;
        private bool gender;
        private FileInfo file;
        public StreamWriter writer;
        public StreamReader reader;

        public Human () {
            type = typeof(Human).ToString();
            firstName = "";
            surname = "";
            dateOfBirth = new DateTimeOffset();
            gender = false;
        }

        public virtual void Openf (string fileName, bool mode) {
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

        // закрытие файла
        public void Closef (string fileName) {
            if (reader != null)
                reader.Dispose();
            if (writer != null)
                writer.Dispose();
        }

        // ввод данных в класс
        public virtual void Enter () {
            Console.WriteLine("Введите данные:");
            Console.Write("Имя: ");
            firstName = Console.ReadLine();
            Console.Write("Фамилия: ");
            surname = Console.ReadLine();
            Console.Write("Дата рождения: ");
            bool date = false;
            while (!date) {
                try {
                    dateOfBirth = DateTimeOffset.Parse(Console.ReadLine());
                    date = true;
                } catch {
                    Console.WriteLine("Дата введена некорректно (формат даты ДД/ММ/ГГГГ)\nПовторите ввод даты");
                    Console.Write("Дата рождения: ");
                }
            }
            Console.Write("Пол (м или ж): ");
            string genderStr = Console.ReadLine();
            while ((genderStr != "м") && (genderStr != "ж")) {
                Console.WriteLine("Некорректный ввод, попробуйте еще раз");
                genderStr = Console.ReadLine();
            }
            switch (genderStr) {
                case "м":
                    gender = true;
                    break;

                case "ж":
                    gender = false;
                    break;
            }
        }

        // вывод данных
        public virtual void Print () {
            Console.WriteLine("\nИмя: " + firstName);
            Console.WriteLine("Фамилия: " + surname);
            Console.WriteLine("Дата рождения: " + dateOfBirth.Date.ToShortDateString().Replace('.', '/'));
            string genderStr;
            if (gender)
                genderStr = "м";
            else
                genderStr = "ж";
            Console.WriteLine("Пол: " + genderStr);
        }

        // запись в файл
        public virtual void InFile (StreamWriter writer) {
            writer.WriteLine(firstName);
            writer.WriteLine(surname);
            writer.WriteLine(dateOfBirth.Date.ToShortDateString());
            if (gender)
                writer.WriteLine("м");
            else
                writer.WriteLine("ж");
        }

        // считывание из файла
        public virtual void OutFile (StreamReader reader) {
            firstName = reader.ReadLine();
            surname = reader.ReadLine();
            dateOfBirth = DateTimeOffset.Parse(reader.ReadLine().Replace('.', '/'));
            if (reader.ReadLine() == "м")
                gender = true;
            else
                gender = false;
        }

        public override string ToString () {
            this.Print();
            return "";
        }
    }
}