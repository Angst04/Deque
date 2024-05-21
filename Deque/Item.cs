using System;
namespace Deque
{
    public class Item
    {
        public int Value;    // 1
        public Item Prev;    // 1
        public Item Next;    // 1

        public Item(int value)    // 1 + 1
        {
            Value = value;    // 1
        }
    }
}

