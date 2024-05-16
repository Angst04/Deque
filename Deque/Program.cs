using System;
using System.Xml.Linq;

public class Deque
{
    public class Item
    {
        public int Value;
        public Item Prev;
        public Item Next;

        public Item(int value)
        {
            Value = value;
        }
    }

    private Item _head;
    private Item _tail;

    public bool IsEmpty()
    {
        return _head == null;
    }

    public void PushLeft(int value)
    {
        Item newItem = new Item(value);
        if (IsEmpty())
        {
            _tail = newItem;
        }
        else
        {
            newItem.Next = _head;
            _head.Prev = newItem;
        }
        _head = newItem;
    }

    public void PushRight(int value)
    {
        Item newElement = new Item(value);
        if (IsEmpty())
        {
            _head = newElement;
        }
        else
        {
            newElement.Prev = _tail;
            _tail.Next = newElement;
        }
        _tail = newElement;
    }

    public int PopLeft()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }

        int value = _head.Value;
        _head = _head.Next;
        if (_head != null)
        {
            _head.Prev = null;
        }
        else
        {
            _tail = null;
        }
        return value;
    }

    public int PopRight()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Deque is empty");
        }

        int value = _tail.Value;
        _tail = _tail.Prev;
        if (_tail != null)
        {
            _tail.Next = null;
        }
        else
        {
            _head = null;
        }
        return value;
    }

    public void Print()
    {
        Console.Write("Дек: ");
        Item current = _head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public int Count()
    {
        Item current = _head;
        int count = 0;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }


    public Item GetHead()
    {
        return _head;
    }

}

public class Sort : Deque
{
    public void SortBubble(Deque deque)
    {
        int N = deque.Count();

        bool flag = false;
        for (int i = 0; i < N; i++)
        {
            flag = false;
            Deque.Item current = deque.GetHead();
            for (int j = 0; j < N - 1 - i; j++)
            {
                if (current.Value > current.Next.Value)
                {
                    int tmp = current.Value;
                    current.Value = current.Next.Value;
                    current.Next.Value = tmp;
                    flag = true;
                }
                current = current.Next;
            }

            if (!flag) break;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Sort sort = new Sort();

        Deque deque = new Deque();

        deque.PushLeft(1);
        deque.PushRight(2);
        deque.PushLeft(3);
        deque.PushRight(4);

        //Console.WriteLine("Длина дека: " + deque.Count());

        deque.Print();
        sort.SortBubble(deque);
        deque.Print();

        //Console.WriteLine(deque.PopLeft()); // Output: 3
        //Console.WriteLine(deque.PopRight()); // Output: 4
        //Console.WriteLine(deque.PopLeft()); // Output: 1
        //Console.WriteLine(deque.PopLeft()); // Output: 2
    }
}