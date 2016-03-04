namespace Deque {

    ///<summary>
    /// Контейнер "Дека". Поддерживает добавление/удаление с двух сторон,
    /// а также произвольный доступ
    ///</summary>
    internal interface IDeque<T> {

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
        T Pop ();

        /// <summary>Добавляет элемент в  хвост последовательности</summary>
        void Push (T val);

        /// <summary>Возвращает первый элемент с головы последовательности и
        /// удаляет его</summary>
        /// При Length == 0 бросается  <throws>InvalidOperationException</throws>
        T Unshift ();

        /// <summary>Добавляет элемент в голову последовательности</summary>
        void Shift (T val);
    }
}