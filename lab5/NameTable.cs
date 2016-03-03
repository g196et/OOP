using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    /// <summary>
    /// Класс "таблица имен переменных" - содержит именованные значения
    /// различных типов. Позволяет извлекать типизированные значения 
    /// по имени переменной
    /// </summary>
    public class NameTable
    {
        Dictionary<string, object> vars = new Dictionary<string, object>();

        /// <summary>
        /// Установить значение переменной
        /// </summary>
        /// <param name="name">имя переменной</param>
        /// <param name="value">значение переменной</param>
        public void Set(string name, object value){
            vars[name] = value;
        }
        /// <summary>
        /// Удалить переменную
        /// </summary>
        /// <param name="name">имя переменной</param>
        public void Remove(string name)
        {
            vars.Remove(name);
        }
        /// <summary>
        /// Возвратить значение переменной типа Т для ссылочных типов
        /// </summary>
        /// <typeparam name="T">тип возвращаемого значение</typeparam>
        /// <param name="name">имя переменной</param>
        /// <returns>Значение переменной. Если нет в таблице или не совпадает по типу, возвращаем null</returns>
        public T Resolve<T>(string name)
            where T:class
        {
            if (!vars.ContainsKey(name)){
                return null;
            }
            return vars[name] as T;
        }
        /// <summary>
        /// Возвратить строковое значение переменной
        /// </summary>
        /// <param name="name">имя переменной</param>
        /// <returns>Строковое значение переменной. Если не найдена переменная, возвращает входной параметр</returns>
        public string ResolveString(string name)
        {
            string res = Resolve<string>(name);
            return res ?? name;
        }
        /// <summary>
        /// Возвращает целочисленное значение переменной или кидает исключение
        /// </summary>
        /// <trows>InvalidCastException</trows>
        /// <trows>FormatException</trows>
        /// <param name="name"></param>
        /// <returns>Целочисленное значение переменной. В случае, если переменной не нашлось, 
        /// пытается привести имя к целому числу. Если переменной не нашлось, возбуждается FormatException,  
        /// если не удалось привести к целому - FormatException</returns>
        public int ResolveInt(string name)
        {
            if (!vars.ContainsKey(name))
            {
                return int.Parse(name);
            }
            return (int)vars[name];
        }
    }
}
