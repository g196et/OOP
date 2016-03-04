using System.Collections.Generic;

namespace Deque {

    // класс "таблица имен переменных" - содержит именованные значения различных типов.
    // позволяет извлекать типизированные значения по имени переменной
    public class NameTable {
        private Dictionary<string, object> vars = new Dictionary<string, object>();

        // установить значение переменной
        public void Set (string name, object value) {
            vars[name] = value;
        }

        // удалить переменную
        public void Remove (string name) {
            vars.Remove(name);
        }

        // Возвратить значение переменной типа Т для ссылочных типов
        // eсли значения нет в таблице или не совпадает по типу, возвращаем null
        public T Resolve<T> (string name)
            where T : class {
            if (!vars.ContainsKey(name)) {
                return null;
            }
            return vars[name] as T;
        }

        // возвращает строковое значение переменной.
        // если не найдена переменная, возвращает входной параметр
        public string ResolveString (string name) {
            string res = Resolve<string>(name);
            return res ?? name;
        }

        // возвращает целочисленное значение переменной, в случае, если переменной не нашлось,
        // пытается привести имя к целому числу. если не удалось привести к целому - FormatException
        public int ResolveInt (string name) {
            if (!vars.ContainsKey(name)) {
                return int.Parse(name);
            }
            return (int)vars[name];
        }
    }
}