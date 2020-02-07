using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface IList<T>
    {
        int FindMin();
        int FindMax();
        int FindIndexMin();
        int FindIndexMax();
        void Reverse();
        void AddFirst(params T[] value);
        void AddToEnd(params T[] item);
        void Add(int index, params T[] item);
        void RemoveByIndex(int index);
        void DoBubbleSort();
        void DoInsertSort(bool ascend = true);
        void Show();
        T[] CopyToArr(T[] array);
    }
}
