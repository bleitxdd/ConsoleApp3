using System;
using System.Security.AccessControl;
using System.IO;
using System.Threading;
namespace FileAccessExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Thread thread_1 = new Thread(() => {
            //    foreach (int i in arr) 
            //    {
            //        Console.WriteLine($"Thread 1:{i}");}
            //    });
            //thread_1.Start();
            //Console.WriteLine("---------------------------------------------------------------");
            //Thread thread_2 = new Thread(() => {
            //    foreach (int i in arr)
            //    {
            //        Console.WriteLine($"Thread 2:{i}");
            //    }
            //});
            //thread_2.Start();
            //Console.WriteLine("WalterVibe");
            Console.Write("Введіть початок діапазону: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Введіть кінець діапазону: ");
            int end = int.Parse(Console.ReadLine());
            if (start >= end)
            {
                Console.WriteLine("Початок діапазону повинен бути меншим за кінець.");
                return;
            }
            Console.Write("Введіть кількість потоків: ");
            int threadCount = int.Parse(Console.ReadLine());
            if (threadCount < 1)
            {
                Console.WriteLine("Кількість потоків повинна бути принаймні 1.");
                return;
            }
            int numbersPerThread = (end - start + 1) / threadCount;

            for (int i = 0; i < threadCount; i++)
            {
                int threadStart = start + i * numbersPerThread;
                int threadEnd = (i == threadCount - 1) ? end : threadStart + numbersPerThread - 1;
                Thread numberThread = new Thread(() => DisplayNumbers(threadStart, threadEnd));
                numberThread.Start();
            }
            Console.WriteLine("Очікуємо завершення потоків...");
            Console.WriteLine("Головний потік завершує роботу.");
        }
        static void DisplayNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}