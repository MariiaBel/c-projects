using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class Node2<T>
    {
        public Node2<T> Next;
        public Node2<T> Prev;

        public T Value
        {
            get;
            private set;
        }

        public Node2(T value)
        {
            this.Value = value;
            Next = null;
            Prev = null;
            //Prev = PrevNode;
        }
    }
}
