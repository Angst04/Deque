using System;
using System.Xml.Linq;
using System.Diagnostics;

namespace Deque;
public class Program
{
    public static void Main(string[] args)
    {
        Sort sort = new Sort();

        Random random = new Random();

        var timer = new Stopwatch();

        int size = 5000;

        for (int i = 1; i <= 10; i++)
        {
            Deque deque = new Deque();

            for (int j = 0; j < size * i; j++)
            {
                int randomValue = random.Next(1, 10001);
                deque.PushRight(randomValue);
            }

            timer.Restart();
            sort.SortBubble(deque);
            timer.Stop();

            Console.WriteLine($"Размер данных: {deque.Count()}, Время выполнения: {timer.Elapsed}");
        }


        //deque.PushLeft(1);
        //deque.PushRight(2);
        //deque.PushLeft(3);
        //deque.PushRight(4);

        //Console.WriteLine("Длина дека: " + deque.Count());

        //deque.Print();
        //sort.SortBubble(deque);
        //deque.Print();

        //Console.WriteLine(deque.PopLeft());    // Output: 3
        //Console.WriteLine(deque.PopRight());    // Output: 4
        //Console.WriteLine(deque.PopLeft());    // Output: 1
        //Console.WriteLine(deque.PopLeft());    // Output: 2
    }
}