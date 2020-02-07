using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[] { 1, 2, 3, 4 };

            //IList<int> interfaceL = new LList1<int>(arr);
            //IList<int> interfaceA = new AList0(arr);

            //interfaceL.Add(0, 12);
            //interfaceA.Add(0, 12);

            //interfaceL.Show();
            //interfaceA.Show();
            int[] arr1 = new int[] { -1, 2, 324, 23, 12, 2, -32, 236, -10, 10, 20, 3, -4 };
            int[] arr2 = new int[] {-33, -22, -11, -9, -5, -4, -1, 3, 10, 20, 33, 43, 54, 56, 77 };
            int[] arr3 = new int[] { 20, 10, 3, - 1, -4 };

            //LList1<int> list1 = new LList1<int>(arr1);
            //var watch1 = System.Diagnostics.Stopwatch.StartNew();
            //list1.DoInsertSort();
            //watch1.Stop();
            //Console.WriteLine("1) INSERT SORT : " + watch1.ElapsedMilliseconds);

            //var watch11 = System.Diagnostics.Stopwatch.StartNew();
            //list1.DoBubbleSort();
            //watch11.Stop();
            //Console.WriteLine("1) BUBLE SORT : " + watch11.ElapsedMilliseconds);

            //LList1<int> list2 = new LList1<int>(arr2);
            //var watch2 = System.Diagnostics.Stopwatch.StartNew();
            //list2.DoInsertSort();
            //watch2.Stop();
            //Console.WriteLine("2) INSERT SORT : " + watch2.ElapsedMilliseconds);
            
            //var watch22 = System.Diagnostics.Stopwatch.StartNew();
            //list2.DoBubbleSort();
            //watch22.Stop();
            //Console.WriteLine("2) BUBLE SORT : " + watch22.ElapsedMilliseconds);
            
            LList1<int> list3 = new LList1<int>(arr3);
            var watch3 = System.Diagnostics.Stopwatch.StartNew();
            list3.DoInsertSort();
            watch3.Stop();
            Console.WriteLine("2) INSERT SORT : " + watch3.ElapsedMilliseconds);
            
            var watch33 = System.Diagnostics.Stopwatch.StartNew();
            list3.DoBubbleSort();
            watch33.Stop();
            Console.WriteLine("2) BUBLE SORT : " + watch33.ElapsedMilliseconds);
            
            
            Console.ReadKey();
        }
    }
}
