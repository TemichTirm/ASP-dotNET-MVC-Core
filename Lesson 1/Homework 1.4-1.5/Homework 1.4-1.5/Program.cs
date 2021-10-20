using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_1._4_1._5
{
    class Program
    {
        private static ThreadSafetyList<int> threadSafetyList = new ThreadSafetyList<int>();
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread thread = new Thread(() => AddItem(threadSafetyList));
                thread.Start();
            }
            for (int i = 0; i < 100; i++)
            {
                Thread thread = new Thread(() => RemoveItem(threadSafetyList));
                thread.Start();
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Метод добавления элементов в потокобезопасный список
        /// </summary>
        /// <param name="threadSafetyList">Потокобезопасный список</param>
        private static void AddItem(ThreadSafetyList<int> threadSafetyList)
        {
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                threadSafetyList.Add(rnd.Next(1000));
                Console.WriteLine($"{threadSafetyList.Last()} from {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }
        }
        /// <summary>
        /// Метод удаления элементов из потокобезопасного списка
        /// </summary>
        /// <param name="threadSafetyList">Потокобезопасный список</param>
        private static void RemoveItem(ThreadSafetyList<int> threadSafetyList)
        {
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                var item = rnd.Next(1000);
                var isRemoved = threadSafetyList.Remove(item);
                Console.WriteLine($"item: {item},\t removed {isRemoved}\t from {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(600);
            }
        }

    }
}
