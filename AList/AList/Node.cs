using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class Node<T>
    {
        public Node<T> Next;

        public T Value {
            get;
            private set;
        }

        public Node(T value)
        {
            this.Value = value;
            Next = null;
        }
    }
}
