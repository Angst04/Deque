using System;
namespace Deque
{
    public class Deque
    {
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
            Console.WriteLine();    // 1
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

        public int Get(int pos, Deque tmp)
        {
            if (IsEmpty())
            {
                throw new Exception("Дек пуст");
            }

            for (int i = 0; i < pos; i++)
            {
                tmp.PushLeft(PopLeft());
            }

            int result = _head.Value;

            while (!tmp.IsEmpty())
            {
                PushLeft(tmp.PopLeft());
            }

            return result;
        }

        public void Set(int pos, int newValue, Deque tmp)
        {
            if (IsEmpty())
            {
                throw new Exception("Дек пуст");
            }

            for (int i = 0; i < pos; i++)
            {
                tmp.PushLeft(PopLeft());
            }

            _head.Value = newValue;

            while (!tmp.IsEmpty())
            {
                PushLeft(tmp.PopLeft());
            }
        }

        public int this[int index]
        {
            get => Get(index, new Deque());
            set => Set(index, value, new Deque());
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
                Item current = deque.GetHead();   // 2
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

        public static void SortBubbleNew(Deque deque, int N)
        {
            bool flag = false;
            for (int i = 0; i < N; i++)
            {
                flag = false;
                for (int j = 0; j < N - 1 - i; j++)
                {
                    if (deque[j] > deque[j + 1])
                    {
                        int tmp = deque[j];
                        deque[j] = deque[j + 1];
                        deque[j + 1] = tmp;
                        flag = true;
                    }
                }

                if (!flag) break;
            }
        }

        public static void SortBubbleNew(int[] arr)
        {
            int N = arr.Length;

            bool flag = false;
            for (int i = 0; i < N; i++)
            {
                flag = false;
                for (int j = 0; j < N - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                        flag = true;
                    }
                }

                if (!flag) break;
            }
        }
    }
}