using System;
using System.Collections.Generic;
using System.IO;

namespace Deque {

    public class Deque<T> : IDeque<T> {
        public T[] deque;
        public int Length { get { return deque.Length; } }

        public Deque () {
            deque = new T[0];
        }

        public T this[int index] {
            get {
                try {
                    if (index < 0)
                        return deque[Length + index];
                    else
                        return deque[index];
                } catch {
                    throw new IndexOutOfRangeException("Индекс выходит за границы дека");
                }
            }
            set {
                try {
                    if (index < 0)
                        this[Length + index] = value;
                    else
                        this[index] = value;
                } catch {
                    throw new IndexOutOfRangeException("Индекс выходит за границы дека");
                }
            }
        }

        // добавление в начало дека
        public void Shift (T val) {
            T[] newDeque = new T[Length + 1];
            newDeque[0] = val;
            for (int i = 1; i < newDeque.Length; i++) {
                newDeque[i] = deque[i - 1];
            }
            deque = newDeque;
        }

        // возвращает элемент из головы дека и удаляет его
        public T Unshift () {
            if (Length == 0)
                throw new InvalidOperationException("Невозможно достать элемент из пустого дека");
            T first = deque[0];
            T[] array = new T[deque.Length - 1];
            for (int i = 1; i < deque.Length; i++) {
                array[i - 1] = deque[i];
            }
            deque = array;
            return first;
        }

        // возвращает первый элемент с хвоста дека и удаляет его
        public T Pop () {
            if (Length == 0) {
                throw new InvalidOperationException("Невозможно достать элемент из пустого дека");
            }
            T last = deque[deque.Length - 1];
            T[] array = new T[deque.Length - 1];
            for (int i = 0; i < deque.Length - 1; i++) {
                array[i] = deque[i];
            }
            deque = array;
            return last;
        }

        // добавляет текущий объект в хвост контейнера
        public void Push (T val) {
            Array.Resize(ref deque, deque.Length + 1);
            deque[deque.Length - 1] = val;
        }

        // загрузка данных из файла
        public void Load (string fileName) {
            try {
                StreamReader reader = new StreamReader(fileName);
                List<T> list = new List<T>();
                while (!reader.EndOfStream) {
                    T val = default(T);
                    list.Add(val);
                }
            } catch {
                Console.WriteLine("Файл не найден");
            }
        }

        public void Clear () {
            while (Length != 0) {
                Pop();
            }
        }

        // сохраняет данные контейнера в файл, необязательный параметр — имя файла
        // в случае отсутствия параметра, распечатываем данные об объектах в контейнере на экран
        public void Print (string fileName) {
            if (fileName != "") {
                FileInfo file = new FileInfo(fileName);
                if (!file.Exists)
                    file.Create();
                StreamWriter writer = new StreamWriter(fileName);
                foreach (var dequeEl in deque) {
                    writer.WriteLine(dequeEl);
                }
            } else {
                if (deque.Length == 0) {
                    Console.WriteLine("Дек пуст");
                    return;
                }
                foreach (var dequeEl in deque) {
                    Console.Write(dequeEl + " ");
                }
                Console.WriteLine();
            }
        }
    }
}