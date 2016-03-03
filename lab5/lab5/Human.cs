using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab4
{
    class Human
    {
        public string type;
        string firstName;
        string surname;
        DateTimeOffset dateOfBirth;
        bool gender;
        FileInfo file;
        public StreamWriter writer;
        public StreamReader reader;
        public Human()
        {
            type = typeof(Human).ToString();
            firstName = "";
            surname = "";
            dateOfBirth = new DateTimeOffset();
            gender = false;
        }
        public virtual void Openf(string fileName, bool regim)
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

        ///Метод закрытия файла
        public void Closef(string fileName)
        {
            if (reader != null)
                reader.Dispose();
            if (writer != null)
                writer.Dispose();
        }

        ///Метод ввода
        public virtual void Enter()///ввод
        {
            Console.WriteLine("Введите данные:");
            Console.Write("Имя: ");
            firstName = Console.ReadLine();
            Console.Write("Фамилия: ");
            surname = Console.ReadLine();
            Console.Write("Дата рождения: ");
            bool date = false;
            while (!date)
            {
                try
                {
                    dateOfBirth = DateTimeOffset.Parse(Console.ReadLine());
                    date = true;
                }
                catch
                {
                    Console.WriteLine("Дата введена некорректно(формат даты ДД/ММ/ГГГГ)\nПовторите ввод даты");
                    Console.Write("Дата рождения: ");
                }
            }
            Console.Write("Пол(male или female): ");
            string genderStr = Console.ReadLine();
            while ((genderStr != "male") && (genderStr != "female"))
            {
                Console.WriteLine("Error. Try again");
                genderStr = Console.ReadLine();
            }
            switch (genderStr)
            {
                case "male":
                    gender = true;
                    break;
                case "female":
                    gender = false;
                    break;
            }
        }

        ///Метод вывода
        public virtual void Print()
        {
            Console.WriteLine("\nИмя: " + firstName);
            Console.WriteLine("Фамилия : " + surname);
            Console.WriteLine("Дата рождения : " + dateOfBirth.Date.ToShortDateString().Replace('.', '/'));
            string genderStr;
            if (gender)
                genderStr = "male";
            else
                genderStr = "female";
            Console.WriteLine("Пол: " + genderStr);
        }

        ///Метод записи в файл
        public virtual void InFile(StreamWriter writer)
        {
            writer.WriteLine(firstName);
            writer.WriteLine(surname);
            writer.WriteLine(dateOfBirth.Date.ToShortDateString());
            if (gender)
                writer.WriteLine("male");
            else
                writer.WriteLine("female");
        }
        ///Метод считывания из файла
        public virtual void OutFile(StreamReader reader)
        {
           
            firstName = reader.ReadLine();
            surname = reader.ReadLine();
            dateOfBirth = DateTimeOffset.Parse(reader.ReadLine().Replace('.', '/'));
            if (reader.ReadLine() == "male")
                gender = true;
            else
                gender = false;
            //reader.Dispose();
        }

        public override string ToString()
        {
            this.Print();
            return "";
        }
    }
}
