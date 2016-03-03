using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using lab4;

namespace lab5
{
    ///<summary>
    /// Контейнер "Дека". Поддерживает добавление/удаление с двух сторон,
    /// а также произвольный доступ
    ///</summary>
    interface IDeque<T>
    {

        ///<summary>Количество элементов в контейнере, целое число >= 0</summary>
        int Length { get; }

        /// <summary>Возвращает элемент с номером  index</summary>
        /// <param>index</param> - индекс искомого элемента, целое число
        /// если параметр больше нуля, возвращается index-й элемент слева
        /// если параметр - отрицательное число, возвращается Length + index й
        /// элемент, т.е. если в коллекции 8 элементов, то
        /// this[-1] - восьмой элемент,
        /// this[-2] - седьмой элемент,
        /// ...,
        /// this[-8] - первый элемент
        /// в случае, если |index| <= Length бросается исключение
        /// <throws>IndexOutOfRangeException</throws>
        T this[int index] { get; set; }

        /// <summary>Возвращает первый элемент с хвоста последовательности и
        /// удаляет его</summary>
        /// При Length == 0 бросается  <throws>InvalidOperationException</throws>
        T Pop();

        /// <summary>Добавляет элемент в  хвост последовательности</summary>
        void Push(T val);

        /// <summary>Возвращает первый элемент с головы последовательности и
        /// удаляет его</summary>
        /// При Length == 0 бросается  <throws>InvalidOperationException</throws>
        T Unshift();

        /// <summary>Добавляет элемент в голову последовательности</summary>
        void Shift(T val);
    }

    class Deque<T> : IDeque<T>
    {
        public T[] deque;
        public int Length { get { return deque.Length; } }
        /// <summary>
        /// Конструктор дека
        /// </summary>
        public Deque()
        {
            deque = new T[0];
        }
        
        public T this[int index]
        {
            get
            {
                try
                {
                    if (index < 0)
                        return deque[Length + index];
                    else
                        return deque[index];
                }
                catch
                {
                    throw new IndexOutOfRangeException("Индекс выходит за границы дека");
                }
            }
            set
            {
                try
                {
                    if (index < 0)
                        this[Length + index] = value;
                    else
                        this[index] = value;
                }
                catch
                {
                    throw new IndexOutOfRangeException("Индекс выходит за границы дека");
                }
            }
        }

        /// <summary>
        /// Добавление в начало последовательности
        /// </summary>
        /// <param name="val">Добавляемый элемент</param>
        public void Shift(T val)
        {
            T[] newDeque = new T[Length+1];
            newDeque[0] = val;
            for(int i=1;i<newDeque.Length;i++)
            {
                newDeque[i] = deque[i - 1];
            }
            deque = newDeque;
        }
        /// <summary>
        /// Достать элемент из головы последовательности
        /// </summary>
        /// <returns>Элемент из головы последовательности</returns>
        public T Unshift()
        {
            if (Length == 0)
                throw new InvalidOperationException("Невозможно достать элемент из пустой последовательности");
            T first = deque[0];
            T[] array = new T[deque.Length - 1];
            for(int i=1;i<deque.Length;i++)
            {
                array[i-1] = deque[i];
            }
            deque = array;
            return first;
        }

        /// <summary>Возвращает первый элемент с хвоста последовательности и
        /// удаляет его</summary>
        /// При Length == 0 бросается  <throws>InvalidOperationException</throws>
        public T Pop()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("Невозможно достать элемент из пустой последовательности");
            }
            T last = deque[deque.Length - 1];
            T[] array = new T[deque.Length - 1];
            for (int i = 0; i < deque.Length-1; i++)
            {
                array[i] = deque[i];
            }
            deque = array;
            return last;
        }

        /// <summary>
        /// Добавляет текущий объект в "хвост" контейнера
        /// </summary>
        /// <param name="val">Добавляемый элемент</param>
        public void Push(T val)
        {
            Array.Resize(ref deque, deque.Length + 1);
            deque[deque.Length-1 ] = val;
        }

        public static void Load(string fileName)
        {

            try
            {
                StreamReader reader = new StreamReader(fileName);
                List<T> list = new List<T>();
                while (!reader.EndOfStream)
                {
                    T val = default(T);
                    //val.OutFile();
                    list.Add(val);
                }
            }
            catch
            {
                Console.WriteLine("Файл не найден");
            }
        }
            /// <summary>
        /// сохраняет данные контейнера в файл. Необязательный параметрр - имя файла. В случае отсутствия параметра, 
        /// распечатываем данные об объектах в контейнере на экран
        /// </summary>
        /// <param name="fileName">имя файла, в который производится запись</param>
        public void Print(string fileName)
        {
            if(fileName!="")
            {
                FileInfo file = new FileInfo(fileName);
                if (!file.Exists)
                    file.Create();
                StreamWriter writer = new StreamWriter(fileName);
                foreach (var dequeEl in deque)
                {
                    writer.WriteLine(dequeEl);
                }
            }
            else
            {
                if(deque.Length==0)
                {
                    Console.WriteLine("Дек пуст");
                    return;
                }
                foreach(var dequeEl in deque)
                {
                    Console.Write(dequeEl+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
