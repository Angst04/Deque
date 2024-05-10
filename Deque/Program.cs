using System;
using System.Xml.Linq;

public class Deque
{
    private class Item
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
            throw new InvalidOperationException("Дек пуст");
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
            throw new InvalidOperationException("Дек пуст");
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

    // служебные
    public void ShowDeque()
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
}

public class Program
{
    public static void Main(string[] args)
    {
        Deque deque = new Deque();

        deque.PushLeft(1);
        deque.PushRight(2);
        deque.PushLeft(3);
        deque.PushRight(4);

        deque.ShowDeque();

        Console.WriteLine(deque.PopLeft()); // Output: 3
        Console.WriteLine(deque.PopRight()); // Output: 4
        Console.WriteLine(deque.PopLeft()); // Output: 1
        Console.WriteLine(deque.PopLeft()); // Output: 2
    }
}