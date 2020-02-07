using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class LList1<T> : IList<T>
    {
        public Node<T> Root = null;

        public int Count {
            get;
            private set;
        }
        public LList1(T value)
        {
            if (value == null) throw new ArgumentNullException();

            Root = new Node<T>(value);
        }

        public LList1(T[] arr)
        {
            //if (arr.Length == 0) throw new ArgumentNullException();
            //if (arr[0] == null) throw new ArgumentNullException();

            this.AddFirst(arr);
        }
        
        public void AddFirst(params T[] value)
        {
            Node<T> tmpNode = this.Root;
            
            for (int i = value.Length - 1; i >= 0; i--)
            {
                Node<T> newNode = new Node<T>(value[i]);
                newNode.Next = tmpNode;
                tmpNode = newNode;
                Count++;
            }
            this.Root = tmpNode;
        }

        private void AddFirstNode(Node<T> newNode)
        {
            Node<T> tmpNode = Root;

            Root = newNode;
            newNode.Next = tmpNode;
            Count++;
        }

        public void AddToEnd(params T[] items)
        {
             this.Add(this.Count - 1, items);
        }

        public void AddLastNode(Node<T> newNode)
        {
            this.GetLastNode().Next = newNode;
        }

        public void Add(T value)
        {
            if (this.Count == 0) this.Root = new Node<T>(value);
            else this.GetLastNode().Next = new Node<T>(value);

            Count++;
        }

        public void Add(int after, params T[] value)
        {
            if (this.Count == 0) this.AddFirst(value);
            else
            {
                for (int i = value.Length-1; i >= 0 ; i--)
                {
                    Node<T> newNode = new Node<T>(value[i]);
                    Node<T> tmpNode;

                    if (after < 0) throw new ArgumentOutOfRangeException();
                    else tmpNode = GetNodeByIndex(after);

                    newNode.Next = tmpNode.Next;
                    tmpNode.Next = newNode;
                    this.Count++;
                    after++;
                }
                
            }
            
        }

        private void Add(int after, Node<T> newNode)
        {
            if (newNode == null) return;
            else
            {
                Node<T> tmpNode;

                if (after < 0) throw new ArgumentOutOfRangeException();
                else tmpNode = GetNodeByIndex(after);

                newNode.Next = tmpNode.Next;
                tmpNode.Next = newNode;
                this.Count++;
            }

        }

        public void RemoveLast()
        {
            RemoveByIndex(this.Count - 1);
        }

        public void RemoveByIndex(int index)
        {
            if (index < 0 || index >= this.Count) throw new ArgumentOutOfRangeException();
            else Count--;

            if (index == 0) this.Root = this.Root.Next; 
            else
            {
                Node<T> tmpNode = this.GetNodeByIndex(index - 1);
                if (index == this.Count) tmpNode.Next = null;
                else tmpNode.Next = tmpNode.Next.Next;
            }
            
        }

        public void RemoveByValue(T value)
        {
            Node<T> tmpNode = this.Root;
            for (int i = 0; i < this.Count; i++)
            {
                if(tmpNode.Value.Equals(value))
                {
                    this.RemoveByIndex(i);
                    break;
                }
                tmpNode = tmpNode.Next;
            }

        }

        public Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.Count) throw new ArgumentOutOfRangeException();

            Node<T> tmpNode = this.Root;
            for (int i = 0; i < index; i++)
            {
                tmpNode = tmpNode.Next;
            }

            return tmpNode;
        }

        public Node<T> GetLastNode()
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node<T> tmpNode = this.Root;
            for (int i = 1; i < this.Count; i++)
            {
                tmpNode = tmpNode.Next;
            }

            return tmpNode;
        }

        public Node<T> FindNodeByIndex(int index)
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node<T> tmpNode = this.Root;
            for (int i = 0; i < index; i++)
            {
                tmpNode = tmpNode.Next;
            }

            return tmpNode;
        }

        public int FindMin()
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node<T> tmpNode = this.Root;
            int min = Convert.ToInt32(tmpNode.Value);

            for (int i = 1; i < this.Count; i++)
            {
                tmpNode = tmpNode.Next;

                StringExceptions(tmpNode);
                int newValue = Convert.ToInt32(tmpNode.Value);
                if (min > newValue) min = newValue;
            }

            return min;
        }

        public int FindIndexMin()
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node<T> tmpNode = this.Root;
            int indexMin = 0;
            int min = Convert.ToInt32(tmpNode.Value);

            for (int i = 1; i < this.Count; i++)
            {
                tmpNode = tmpNode.Next;

                StringExceptions(tmpNode);
                int newValue = Convert.ToInt32(tmpNode.Value);
                if (min > newValue) indexMin = i;
            }

            return indexMin;
        }

        public Node<T> FindMinNodeFromIndex(ref int minIndex, int index = 0)
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node<T> tmpNode = this.Root;
            Node<T> tmpNodeMin = this.Root;
            minIndex = 0;
            for (int i = 0; i < index; i++)
            {
                tmpNode = tmpNode.Next;
                tmpNodeMin = tmpNode;
            }
            for (int i = index; i < this.Count; i++)
            {
                StringExceptions(tmpNode);
                int newValue = Convert.ToInt32(tmpNode.Value);
                if (Convert.ToInt32(tmpNodeMin.Value) >= newValue)
                {
                    tmpNodeMin = tmpNode;
                    minIndex = i;
                }
                tmpNode = tmpNode.Next;
            }

            return tmpNodeMin;
        }

        public Node<T> FindMaxNodeFromIndex(ref int maxIndex, int index = 0)
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node<T> tmpNode = this.Root;
            Node<T> tmpNodeMax = this.Root;
            maxIndex = 0;
            for (int i = 0; i < index; i++)
            {
                tmpNode = tmpNode.Next;
                tmpNodeMax = tmpNode;
            }
            for (int i = index; i < this.Count; i++)
            {
                StringExceptions(tmpNode);
                int newValue = Convert.ToInt32(tmpNode.Value);
                if (Convert.ToInt32(tmpNodeMax.Value) <= newValue)
                {
                    tmpNodeMax = tmpNode;
                    maxIndex = i;
                }
                tmpNode = tmpNode.Next;
            }

            return tmpNodeMax;
        }

        public int FindIndexMax()
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node<T> tmpNode = this.Root;
            int max = Convert.ToInt32(tmpNode.Value);
            int indexMax = 0;

            for (int i = 1; i < this.Count; i++)
            {
                tmpNode = tmpNode.Next;

                StringExceptions(tmpNode);
                int newValue = Convert.ToInt32(tmpNode.Value);
                if (max < newValue) indexMax = i;
            }

            return indexMax;
        }

        
        public int FindMax()
        {
            if (this.Root == null) throw new ArgumentNullException();

            Node<T> tmpNode = this.Root;
            int max = Convert.ToInt32(tmpNode.Value);

            for (int i = 1; i < this.Count; i++)
            {
                tmpNode = tmpNode.Next;

                StringExceptions(tmpNode);
                int newValue = Convert.ToInt32(tmpNode.Value);
                if (max < newValue) max = newValue;
            }

            return max;
        }

        public void Reverse()
        {
            this.Root = Reverse(this.Root);
             
            Node<T> tmpNode = this.Root;
            while (tmpNode != null)
            {
                Count++;
                tmpNode = tmpNode.Next;
            }
        }

        private Node<T> Reverse(Node<T> node)
        {
            Node<T> lastNode = this.GetLastNode();
            this.RemoveLast();
            if (this.Count != 0)
            {
                lastNode.Next = Reverse(this.Root);
            }

            return lastNode;
        }
        public void DoInsertSort(bool ascend = true)
        {
            if (this.Root == null) throw new ArgumentNullException();
            if (this.Root.Next == null) return;

            Node<T> node = this.Root;

            for (int i = 0; i < this.Count; i++)
            {
                if (ascend)
                {
                    int maxIndex = 0;
                    node = this.FindMaxNodeFromIndex(ref maxIndex, i);
                    this.RemoveByIndex(maxIndex);
                }
                else
                {
                    int minIndex = 0;
                    node = this.FindMinNodeFromIndex(ref minIndex, i);
                    this.RemoveByIndex(minIndex);                    
                }
                this.AddFirstNode(node);
            }
        }

        public void ChangeNodePositions(Node<T> prev, Node<T> firstNode, ref bool changed)
        {
            Node<T> secondNode = firstNode.Next;

            if (Convert.ToInt32(firstNode.Value) > Convert.ToInt32(secondNode.Value))
            {
                firstNode.Next = secondNode.Next;
                prev.Next = secondNode;
                secondNode.Next = firstNode;

                changed = true;
            }
        }
        
        public void DoBubbleSort()
        {
            if (this.Count <= 1) return;

            Node<T> tmpNode, prevNode;
            bool changed = true;

            while(changed)
            {
                changed = false;
                tmpNode = this.Root;

                if (Convert.ToInt32(tmpNode.Value) > Convert.ToInt32(tmpNode.Next.Value))
                {
                    this.Root = tmpNode.Next;
                    tmpNode.Next = tmpNode.Next.Next;
                    this.Root.Next = tmpNode;

                    changed = true;
                }
                for (int i = 1; i < this.Count - 1; i++)
                {
                    prevNode = this.GetNodeByIndex(i-1);
                    tmpNode = this.GetNodeByIndex(i);
                    
                    ChangeNodePositions(prevNode, tmpNode, ref changed);

                }
            }

        }

        public T[] CopyToArr(T[] array)
        {
            Node<T> tmpNode = this.Root;
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = tmpNode.Value;
                tmpNode = tmpNode.Next;
            }
            return array;
        }

        public void Show()
        {
            Node<T> tmpNode = this.Root;

            for (int i = 0; i < this.Count; i++)
            {
                Console.Write(tmpNode.Value + " ");
                tmpNode = tmpNode.Next;
            }
        }

        private void StringExceptions(Node<T> node)
        {
            if (node != null && !node.Value.GetType().Equals(typeof(int))) throw new TypeAccessException();
        }


    }
}
