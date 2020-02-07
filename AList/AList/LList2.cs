using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LList2<T> : IList<T>
    {
        public Node2<T> Root = null;
        public Node2<T> End = null;
        
        public int Count
        {
            get;
            private set;
        }
        
        public LList2(T value)
        {
            if (value == null) throw new ArgumentNullException();

            this.Root = new Node2<T>(value);
            this.End = this.Root;
        }

        public LList2(T[] arr)
        {
            //if (arr.Length == 0) throw new ArgumentNullException();
            //if (arr[0] == null) throw new ArgumentNullException();

            this.AddFirst(arr);
        }
               
        private void SetLastNode()
        {
            if (this.Root == null) this.End = null;

            Node2<T> tmpNode = this.Root;
            for (int i = 1; i < this.Count; i++)
            {
                tmpNode = tmpNode.Next;
            }

            this.End = tmpNode;
        }

        public void AddFirst(params T[] value)
        {
            Node2<T> tmpNode = this.Root;

            for (int i = value.Length - 1; i >= 0; i--)
            {
                Node2<T> newNode = new Node2<T>(value[i]);
                newNode.Next = tmpNode;
                if(tmpNode != null) tmpNode.Prev = newNode;

                tmpNode = newNode;
                Count++;
            }
            this.Root = tmpNode;
            SetLastNode();
        }

        private void AddFirstNode(Node2<T> newNode)
        {
            Node2<T> tmpNode = this.Root;

            this.Root = newNode;
            newNode.Next = tmpNode;
            tmpNode.Prev = newNode;
            Count++;
        }

        public void AddToEnd(params T[] items)
        {
            this.Add(this.Count - 1, items);
        }

        public void Add(int index, params T[] items)
        {
            if (items.Length == 0) return;
            if (index < 0 || index >= this.Count) throw new ArgumentOutOfRangeException();
            if (this.Count == 0) this.AddFirst(items);
            else
            {
                Node2<T> tmpNode = this.Root;
                for (int i = 0; i <= index; i++)
                {
                    if (i == index)
                    {
                        Node2<T> nextNode = tmpNode.Next;
                        LList2<T> newNodes = new LList2<T>(items);

                        tmpNode.Next = newNodes.Root;
                        newNodes.Root.Prev = tmpNode;
                        newNodes.End.Next = nextNode;
                        if (nextNode != null) nextNode.Prev = newNodes.End;

                        this.Count += newNodes.Count;

                    }
                    tmpNode = tmpNode.Next;
                }
            }
        }

        public int FindIndexMax()
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node2<T> tmpNode = this.Root;
            int indexMax = 0;
            int valueMax = Convert.ToInt32(tmpNode.Value);
            for (int i = 1; i < this.Count; i++)
            {
                tmpNode = tmpNode.Next;
                StringExceptions(tmpNode);
                if (valueMax < Convert.ToInt32(tmpNode.Value))
                {
                    indexMax = i;
                    valueMax = Convert.ToInt32(tmpNode.Value);
                }
            }

            return indexMax;
        }

        public int FindIndexMin()
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node2<T> tmpNode = this.Root;
            int indexMin = 0;
            int valueMin = Convert.ToInt32(tmpNode.Value);
            for (int i = 1; i < this.Count; i++)
            {
                tmpNode = tmpNode.Next;
                StringExceptions(tmpNode);
                if (valueMin > Convert.ToInt32(tmpNode.Value))
                {
                    indexMin = i;
                    valueMin = Convert.ToInt32(tmpNode.Value);
                }
            }

            return indexMin;
        }

        public int FindMax()
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node2<T> tmpNode = this.Root;
            int valueMax = Convert.ToInt32(tmpNode.Value);
            for (int i = 1; i < this.Count; i++)
            {
                tmpNode = tmpNode.Next;
                StringExceptions(tmpNode);
                if (valueMax < Convert.ToInt32(tmpNode.Value)) valueMax = Convert.ToInt32(tmpNode.Value);
            }

            return valueMax;
        }

        public int FindMin()
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node2<T> tmpNode = this.Root;
            int valueMin = Convert.ToInt32(tmpNode.Value);
            for (int i = 1; i < this.Count; i++)
            {
                tmpNode = tmpNode.Next;
                StringExceptions(tmpNode);

                if (valueMin > Convert.ToInt32(tmpNode.Value)) valueMin = Convert.ToInt32(tmpNode.Value);
            }

            return valueMin;
        }

        public Node2<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.Count) throw new ArgumentOutOfRangeException();

            Node2<T> tmpNode = this.Root;
            for (int i = 0; i < index; i++)
            {
                tmpNode = tmpNode.Next;
            }

            return tmpNode;
        }

        public void RemoveByIndex(int index)
        {
            if (index < 0 || index >= this.Count) throw new ArgumentOutOfRangeException();
            if (index == 0)
            {
                this.Root = this.Root.Next;
                this.Root.Prev = null;
            } 
            else if(index == this.Count - 1)
            {
                this.End = this.End.Prev;
                this.End.Next = null;
            } 
            else
            {
                Node2<T> tmpNode = this.Root;
                for (int i = 0; i <= index; i++)
                {
                    if(index == i)
                    {
                        Node2<T> prevNode = tmpNode.Prev;
                        Node2<T> nextNode = tmpNode.Next;

                        prevNode.Next = nextNode;
                        nextNode.Prev = prevNode;
                    }
                    tmpNode = tmpNode.Next;
                }
            }
            Count--;
        }

        public void Reverse()
        {
            Node2<T> tmpNode = this.End;
            this.Root = this.End;
            for (int i = 0; i < this.Count; i++)
            {
                Node2<T> newPrev = tmpNode.Next;
                tmpNode.Next = tmpNode.Prev;
                tmpNode.Prev = newPrev;

                this.End = tmpNode;
                tmpNode = tmpNode.Next;
            }

        }

        public void Show()
        {
            Node2<T> tmpNode = this.Root;

            for (int i = 0; i < this.Count; i++)
            {
                Console.Write(tmpNode.Value + " ");
                tmpNode = tmpNode.Next;
            }
        }

        public void DoBubbleSort()
        {
            if (this.Count <= 1) return;

            Node2<T> tmpNode;
            bool changed = true;
            while (changed)
            {
                changed = false;
                tmpNode = this.Root;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    if (Convert.ToInt32(tmpNode.Value) > Convert.ToInt32(tmpNode.Next.Value))
                    {
                        Node2<T> tmpNodeNN = tmpNode.Next.Next;
                        Node2<T> tmpNodePrev = tmpNode.Prev;

                        tmpNode.Next.Next = tmpNode;
                        tmpNode.Next.Prev = tmpNode.Prev;

                        if (tmpNode.Prev != null) tmpNode.Prev.Next = tmpNode.Next;
                        else this.Root = tmpNode.Next;

                        tmpNode.Prev = tmpNode.Next;
                        tmpNode.Next = tmpNodeNN;
                        
                        if (tmpNodeNN != null) tmpNodeNN.Prev = tmpNode;
                        else this.End = tmpNode;

                        changed = true;
                    }
                    if(!changed) tmpNode = tmpNode.Next;
                }
            }
        }

        public void DoInsertSort(bool ascend = true)
        {
            int index;
            if (ascend) index = FindIndexMin();
            else index = FindIndexMax();
            Node2<T> findedNode = GetNodeByIndex(index);
            if (this.Count > 1)
            { 
                RemoveByIndex(index);
                DoInsertSort(ascend);
                AddFirstNode(findedNode);
            }
        }

        public T[] CopyToArr(T[] array)
        {
            Node2<T> tmpNode = this.Root;
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = tmpNode.Value;
                tmpNode = tmpNode.Next;
            }
            return array;
        }

        private void StringExceptions(Node2<T> node)
        {
            if (node != null && !node.Value.GetType().Equals(typeof(int))) throw new TypeAccessException();
        }
    }
}
