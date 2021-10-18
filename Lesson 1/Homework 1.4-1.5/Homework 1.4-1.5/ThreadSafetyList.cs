using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1._4_1._5
{
    /// <summary>
    /// Класс потокобезопасного списка
    /// </summary>
    /// <typeparam name="T">Универсальный тип</typeparam>
    class ThreadSafetyList<T>
    {
        private object lockObj = new object();
        private List<T> list = new List<T>();
        /// <summary>
        /// Добавление элемента в список
        /// </summary>
        /// <param name="item">Значение</param>
        public void Add(T item)
        {
            lock (lockObj)
            {
                list.Add(item);
            }
        }
        /// <summary>
        /// Удаление значения из списка
        /// </summary>
        /// <param name="item">Значение</param>
        /// <returns>Возвращает True если значение найдено и удалено, иначе False</returns>
        public bool Remove(T item)
        {
            lock (lockObj)
            {
                return list.Remove(item);
            }
        }
        /// <summary>
        /// Удаление 'элемента из списка по его индексу
        /// </summary>
        /// <param name="index">индекс</param>
        public void RemoveAt(int index)
        {
            lock (lockObj)
            {
                list.RemoveAt(index);
            }
        }
        /// <summary>
        /// Получение значения элемента списка по индексу
        /// </summary>
        /// <param name="index">индекс</param>
        /// <returns>Значение элемента списка</returns>
        public T GetByIndex(int index)
        {
            lock (lockObj)
            {
                return list[index];
            }
        }
        /// <summary>
        /// Получение значения последнегоэлемента списка
        /// </summary>
        /// <returns>Значение элемента списка</returns>
        public T Last()
        {
            lock (lockObj)
            {
                return list.Last();
            }
        }
        /// <summary>
        /// Получение количества элементов в списке
        /// </summary>
        /// <returns> Количества элементов в списке</returns>
        public int Count()
        {
            lock (lockObj)
            {
                return list.Count();
            }
        }
    }
}
