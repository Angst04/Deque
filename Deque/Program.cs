using System;
using System.Xml.Linq;
using System.Diagnostics;

public class Deque
{
    public class Item
    {
        public int Value;    // 1
        public Item Prev;    // 1
        public Item Next;    // 1

        public Item(int value)    // 1
        {
            Value = value;    // 1
        }
    }

    private Item _head;    // 1
    private Item _tail;    // 1

    public bool IsEmpty()    // => 2
    {
        return _head == null;    // 1 + 1
    }

    public void PushLeft(int value) // => 7
    {
        Item newItem = new Item(value);    // 2

        // => 4>2 => 4
        if (IsEmpty())    // 2 + 1
        {
            _tail = newItem;    // 1
        }
        else
        {
            newItem.Next = _head;    // 1
            _head.Prev = newItem;    // 1
        }
        _head = newItem;    // 1
    }

    public void PushRight(int value)    // => 7
    {
        Item newElement = new Item(value);    // 2

        // => 4>2 => 4
        if (IsEmpty())    // 3
        {
            _head = newElement;    // 1
        }
        else
        {
            newElement.Prev = _tail;    // 1
            _tail.Next = newElement;    // 1
        }
        _tail = newElement;    // 1    
    }

    public int PopLeft()    // => 9
    {
        // => 3
        if (IsEmpty())    // 2
        {
            throw new InvalidOperationException("Deque is empty");  // 1
        }

        int value = _head.Value;    // 1
        _head = _head.Next;    // 1

        // => 3 > 1 => 3
        if (_head != null)  // 2
        {
            _head.Prev = null;  // 1
        }
        else
        {
            _tail = null;   // 1
        }
        return value;   // 1
    }

    public int PopRight() // => 9
    {
        // => 3
        if (IsEmpty())  // 2
        {
            throw new InvalidOperationException("Deque is empty"); // 1
        }

        int value = _tail.Value;    // 1
        _tail = _tail.Prev; // 1

        // => 3>1 => 3
        if (_tail != null)  // 2
        {
            _tail.Next = null;  // 1
        }
        else
        {
            _head = null;   // 1
        }
        return value;   // 1
    }

    public void Print() // => !!!!
    {
        Console.Write("Дек: "); // 1
        Item current = _head;   // 1
        while (current != null) // !!!!!
        {
            Console.Write(current.Value + " "); // 1
            current = current.Next; // 1
        }
        // Console.WriteLine();
    }

    public int Count()
    {
        Item current = _head;   // 1
        int count = 0;  // 1
        while (current != null) // Сигма(i=1, n)
        {
            count++;    // 1
            current = current.Next; // 1
        }
        return count;   // 1
    }


    public Item GetHead()   // => 1
    {
        return _head;   // 1
    }

}

public class Sort : Deque
{
    public void SortBubble(Deque deque)
    {
        int N = deque.Count();  // Сигма(i=1, n)

        bool flag = false;  // 1
        for (int i = 0; i < N; i++) // 1 + 1 + Сигма(i=1, n)
        {
            flag = false;   // 1
            Deque.Item current = deque.GetHead();   // 2
            for (int j = 0; j < N - 1 - i; j++) //Сигма(j = 1, n - 1 - i)
            {
                if (current.Value > current.Next.Value) // 2
                {
                    int tmp = current.Value;    // 1
                    current.Value = current.Next.Value; // 1
                    current.Next.Value = tmp;   // 1
                    flag = true;    // 1
                }
                current = current.Next; // 1
            }

            if (!flag) break;   // 1
        }
    }
}

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