using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class AList0<T> : IList<int>
    {
        private int[] arr;

        public int[] Arr
        {
            get
            {
                return arr;
            }
        }
        
        public AList0(int[] arr)
        {
            this.arr = arr;
        }
        
        public int FindMin()
        {
            CheckArrExceptions();

            int min = this.arr[0];
            for (int i = 1; i < this.arr.Length; i++)
            {
                if (this.arr[i] < min) min = this.arr[i];
            }
            return min;
        }

        public int FindMax()
        {
            CheckArrExceptions();

            int max = this.arr[0];

            for (int i = 1; i < this.arr.Length; i++)
            {
                if (this.arr[i] > max) max = this.arr[i];
            }
            return max;
        }

        public int FindIndexMin()
        {
            CheckArrExceptions();

            int min = this.arr[0];
            int index = 0;

            for (int i = 1; i < this.arr.Length; i++)
            {
                if (this.arr[i] < min)
                {
                    index = i;
                    min = this.arr[i];
                }
            }
            return index;
        }

        public int FindIndexMax()
        {
            CheckArrExceptions();

            int max = this.arr[0];
            int index = 0;

            for (int i = 1; i < this.arr.Length; i++)
            {
                if (this.arr[i] > max)
                {
                    index = i;
                    max = this.arr[i];
                }
            }
            return index;
        }

        public int SumNumberOfUnevenIndex()
        {
            CheckArrExceptions();

            int sumUnevenInt = 0;

            for (int i = 1; i < this.arr.Length; i += 2)
            {
                sumUnevenInt += this.arr[i];
            }

            return sumUnevenInt;
        }

        public uint SumIndexOfUnevenNumber()
        {
            CheckArrExceptions();

            uint counter = 0;

            for (int i = 0; i < this.arr.Length; i++)
            {
                if (this.arr[i] % 2 != 0) counter++;
            }

            return counter;
        }

        public void Reverse()
        {
            CheckArrExceptions();

            int memory;
            for (int i = 0, j = this.arr.Length - 1; i < j; i++, j--)
            {
                memory = this.arr[i];
                this.arr[i] = this.arr[j];
                this.arr[j] = memory;
            }
        }

        public void MixArrHalf()
        {
            CheckArrExceptions();

            int secondI = this.arr.Length / 2 + this.arr.Length % 2;
            int memory;

            for (int i = 0, j = secondI; j < this.arr.Length; i++, j++)
            {
                memory = this.arr[i];
                this.arr[i] = this.arr[j];
                this.arr[j] = memory;
            }

        }

        public void MixArrRandom()
        {
            Random rand = new Random();
            int memory;
            for (int i = 0; i < this.arr.Length - 1; i++)
            {
                int randNumber = rand.Next(i+1, this.arr.Length - 1);
                //if (randNumber == i) continue;

                memory = this.arr[i];
                this.arr[i] =  this.arr[randNumber];
                this.arr[randNumber] = memory;
            }

        }

        public void DoBubbleSort()
        {
            CheckArrExceptions();

            bool changes;
            int memory;

            for (int i = 0; i < this.arr.Length; i++)
            {
                changes = false;
                for (int j = 1; j < this.arr.Length - i; j++)
                {
                    if (this.arr[j] < this.arr[j - 1])
                    {
                        memory = this.arr[j];
                        this.arr[j] = this.arr[j - 1];
                        this.arr[j - 1] = memory;
                        changes = true;
                    }
                }
                if (!changes) break;
            }
        }

        public void DoSelectSort()
        {
            CheckArrExceptions();

            int memoryJ, minN;

            for (int i = 0; i < this.arr.Length; i++)
            {
                minN = this.arr[i];
                memoryJ = i;

                for (int j = i; j < this.arr.Length; j++)
                {
                    if (this.arr[j] < minN)
                    {
                        memoryJ = j;
                        minN = this.arr[j];
                    }
                }

                this.arr[memoryJ] = this.arr[i];
                this.arr[i] = minN;
            }

        }

        public void DoInsertSort(bool ascend = true)
        {
            CheckArrExceptions();

            int memory;

            for (int i = 1; i < this.arr.Length; i++)
            {
                memory = this.arr[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (this.arr[j] > memory)
                    {
                        this.arr[j + 1] = this.arr[j];
                        if (j == 0) this.arr[j] = memory;
                    }
                    else
                    {
                        this.arr[j + 1] = memory;
                        break;
                    }
                }
            }
        }

        public void DoQuickSort()
        {
            CheckArrExceptions();

            this.arr = DoQuickSort(this.arr);
        }

        private int[] DoQuickSort(int[] arr)
        {
            int endIndex = arr.Length - 1;
            int baseNumber = arr[endIndex];
            int[] leftPart = new int[0], basePart = new int[0], rightPart = new int[0];

            for (int i = 0; i < endIndex; i++)
            {
                if (arr[i] < baseNumber) leftPart = AddToEnd(leftPart,arr[i]);
                else if (arr[i] == baseNumber) basePart = AddToEnd(basePart, arr[i]);
                else if (arr[i] > baseNumber) rightPart = AddToEnd(rightPart, arr[i]);
            }

            if (leftPart.Length > 1) leftPart = DoQuickSort(leftPart);
            if (rightPart.Length > 1) leftPart = DoQuickSort(leftPart);

            arr = leftPart;
            arr = AddToEnd(arr, baseNumber);
            arr = AddToEnd(arr, basePart);
            arr = AddToEnd(arr, rightPart);

            return arr;
        }

        public void AddFirst(params int[] item)
        {
           Add(0, item);
        }

        public void AddToEnd(params int[] item)
        {
            try
            {
                CheckArrExceptions(item);
                this.arr = AddToEnd(this.arr, item);
            }
            catch (Exception)   {}
            
        }

        private int[] AddToEnd(int[] arr, params int[] item )
        {
            int[] newArr = Add(arr, arr.Length, item);
            return newArr;
        }

        public void Add(int index, params int[] item)
        {
            this.arr = Add(this.arr, index, item);
        }

        private int[] Add(int[] arr, int index, params int[] item)
        {
            CheckArrExceptions();
            
            int[] newArr = new int[arr.Length + item.Length];
            int j = 0;
            for (int i = 0; i <= arr.Length; i++)
            {
                if (i == index)
                {
                    for (; j < item.Length; j++)
                    {
                        newArr[i + j] = item[j];
                    }
                }

                if(i != arr.Length) newArr[i + j] = arr[i];
            }

            //this.arr = newArr;
            return newArr;
        }
        
        public void RemoveByIndex(int index)
        {
            CheckArrExceptions();

            for (int i = 0, j = 0; i < this.arr.Length; i++, j++)
            {
                if (i == index)
                {
                    j--;
                    continue;
                }

                this.arr[j] = this.arr[i];
            }
            Resize(-1);
        }

        public void Show()
        {
            Console.Write("Array: ");
            for (int i = 0; i < this.arr.Length; i++)
            {
                Console.Write("{0} ", this.arr[i]);
            }
            Console.WriteLine("\n");
        }

        private void Resize(int lengthMore)
        {
            int[] newArr = new int[this.arr.Length + lengthMore];
            for (int i = 0; i < this.arr.Length + lengthMore; i++)
            {
                if (i == this.arr.Length) break;
                newArr[i] = this.arr[i];
            }
            this.arr = newArr;
        }

        private void CheckArrExceptions()
        {
            if (this.arr == null || this.arr.Length == 0) throw new ArgumentNullException("The array is not correct. The array should have more then 0 items");
        }

        private void CheckArrExceptions(int[] arr)
        {
            if (arr == null || arr.Length == 0) throw new ArgumentNullException("The array is not correct. The array should have more then 0 items");
        }

        public int[] CopyToArr(int[] arr)
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                arr[i] = this.arr[i];
            }

            return arr;
        }
    }
}
