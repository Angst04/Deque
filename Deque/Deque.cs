using System;
namespace Deque
{
    public class Deque
    {
        private Item _head;    // 1
        private Item _tail;    // 1

        public bool IsEmpty()    // => 2 + 1
        {
            return _head == null;    // 1 + 1
        }

        public void PushLeft(int value) // 1
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

        public void PushRight(int value)    // => 7 + 1
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

        public int PopLeft()    // => 9 + 1
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

        public int PopRight() // => 9 + 1
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

        public void Print() // => 3n + 4
        {
            Console.Write("Дек: "); // 1
            Item current = _head;   // 1
            while (current != null) // сигма(i=1, n) {2 + 1}
            {
                Console.Write(current.Value + " "); // 1
                current = current.Next; // 1
            }
            Console.WriteLine();    // 1
        }

        public int Count() // => 3n + 3
        {
            Item current = _head;   // 1
            int count = 0;  // 1
            while (current != null) // Сигма(i=1, n) {2 + 1}
            {
                count++;    // 1
                current = current.Next; // 1
            }
            return count;   // 1
        }


        public Item GetHead()   // => 1 + 1
        {
            return _head;   // 1
        }

        public int Get(int pos, Deque tmp) // => 18 * pos + 21 * j + 6 + 1
        {
            if (IsEmpty()) // 3
            {
                throw new Exception("Дек пуст"); // 1
            }

            for (int i = 0; i < pos; i++) // сигма(i=1, pos) {18}
            {
                tmp.PushLeft(PopLeft()); // 10 + 8
            }

            int result = _head.Value; // 1

            while (!tmp.IsEmpty()) // сигма(j=1, n) {3 + 18}
            {
                PushLeft(tmp.PopLeft()); // 10 + 8
            }

            return result; // 1
        }

        public void Set(int pos, int newValue, Deque tmp) // => 18 * pos + 21 * j + 4 + 1
        {
            if (IsEmpty()) // 2
            {
                throw new Exception("Дек пуст"); // 1
            }

            for (int i = 0; i < pos; i++) // сигма(i=1, pos) {18}
            {
                tmp.PushLeft(PopLeft()); // 10 + 8
            }

            _head.Value = newValue; // 1

            while (!tmp.IsEmpty()) // сигма(j=1, n) {3 + 18}
            {
                PushLeft(tmp.PopLeft()); // 10 + 8
            }
        }

        public int this[int index] // 1
        {
            get => Get(index, new Deque()); // 1
            set => Set(index, value, new Deque()); // 1
        }
    }

    public class Sort : Deque
    {
        public static void SortBubble(Deque deque, int N) // сигма(i=1, N) {сигма(i=1, N-1-i) {5}} + 1 + 1
        {
            bool flag = false; // 1
            for (int i = 0; i < N; i++) // сигма(i=1, N)
            {
                flag = false; // 1
                for (int j = 0; j < N - 1 - i; j++) // сигма(i=1, N-1-i) {5}
                {
                    if (deque[j] > deque[j + 1]) // 1
                    {
                        int tmp = deque[j]; // 1
                        deque[j] = deque[j + 1]; // 1
                        deque[j + 1] = tmp; // 1
                        flag = true; // 1
                    }
                }

                if (!flag) break; // 1
            }
        }

        public static void SortBubble(int[] arr) // сигма(i= 1, N) {сигма(i = 1, N - 1 - i) {5}} + 3 + 1
        {
            int N = arr.Length; // 2

            bool flag = false; // 1
            for (int i = 0; i < N; i++) // сигма(i=1, N) 
            {
                flag = false; // 1
                for (int j = 0; j < N - 1 - i; j++) // сигма(i = 1, N - 1 - i) { 5}
                {
                    if (arr[j] > arr[j + 1]) // 1
                    {
                        int tmp = arr[j]; // 1
                        arr[j] = arr[j + 1]; // 1
                        arr[j + 1] = tmp; // 1
                        flag = true; // 1
                    }
                }

                if (!flag) break; // 1
            }
        }
    }
}