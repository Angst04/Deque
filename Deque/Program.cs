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

        int size = 100;

        for (int i = 1; i <= 10; i++)
        {
            Deque deque = new Deque();

            for (int j = 0; j < size * i; j++)
            {
                int randomValue = random.Next(1, 10001);
                deque.PushRight(randomValue);
            }

            int N = deque.Count();

            timer.Restart();
            //sort.SortBubble(deque);
            Sort.SortBubbleNew(deque, N);
            timer.Stop();

            Console.WriteLine($"Размер данных: {deque.Count()}, Время выполнения: {timer.Elapsed}");
        }
    }
}