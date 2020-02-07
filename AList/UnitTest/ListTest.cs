using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using List;

namespace UnitTest
{
    //[TestFixture(typeof(AList0<int>))]
    //[TestFixture(typeof(LList1<int>))]
    //[TestFixture(typeof(LList2<int>))]
    //[TestFixture(1)]
    //[TestFixture(2)]
    //[TestFixture(3)]
    public class ListTest
    {
        private List.IList<int> TestList;
        int[] arr = new int[] { 1, 2, 3 };

        [SetUp]
        public void CreateList()
        {

            this.TestList = new LList2<int>(arr);
            //if (this.TestList.GetType() == typeof(AList0<int>))
            //{
            //    this.TestList = new AList0<int>(arr);
            //}
            //else if (this.TestList.GetType() == typeof(LList1<int>))
            //{
            //    this.TestList = new LList1<int>(arr);
            //}
            //else if (this.TestList.GetType() == typeof(LList2<int>))
            //{
            //    this.TestList = new LList2<int>(arr);
            //}

        }
        //public ListTest(int a)
        //{
        //    if (a == 1) TestList = new AList0<int>(new int[] { 1, 2, 3 });
        //    else if (a == 2) TestList = new LList1<int>(new int[] { 1, 2, 3 });
        //    else if (a == 3) TestList = new LList2<int>(new int[] { 1, 2, 3 });
        //}

        [TestCase(1, ExpectedResult = new int[] {1, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3}, ExpectedResult = new int[] {1, 2, 3, 1, 2, 3 })]
        [TestCase(new int[] { 1 }, ExpectedResult = new int[] {1, 1, 2, 3 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { 1, 2, 3 })]
        public int[] Add(params int[] item)
        {
            int arrLenght = item.Length + arr.Length;
            TestList.AddFirst(item);
            return TestList.CopyToArr(new int[arrLenght]);
        }

        [TestCase(1, 1, ExpectedResult = new int[] {1, 2, 1, 3 })]
        [TestCase(1, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 1, 2, 3, 3 })]
        [TestCase( 0, new int[] { 5 }, ExpectedResult = new int[] { 1, 5, 2, 3 })]
        [TestCase(0, new int[] { }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 5, 6}, ExpectedResult = new int[] { 1, 2, 3, 5, 6 })]
        public int[] AddByIndex( int index, params int[] items)
        {
            int arrLenght = items.Length + arr.Length;
            TestList.Add(index, items);
            return TestList.CopyToArr(new int[arrLenght]);
        }

        [TestCase(5, new int[] { 5, 6 })]
        [TestCase(-1, new int[] { 5, 6 })]
        public void AddByIndexExceptions(int index, params int[] items)
        {
            Assert.Throws<ArgumentOutOfRangeException> (() => TestList.Add(index, items));
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = -4)]
        [TestCase(new int[] { 12, 34, 21 }, ExpectedResult = 12)]
        [TestCase(new int[] { 22 }, ExpectedResult = 22)]
        public int FindMinTest(int[] arr)
        {
            LList2<int> list = new LList2<int>(arr);
            return list.FindMin();
        }

        [Test]
        public void FindMinTestExseptions()
        {
            string[] arr = new string[] { "1", "2", "3", "4" };

            LList2<string> list = new LList2<string>(arr);
            Assert.Throws<TypeAccessException>(() => list.FindMin());
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = 20)]
        [TestCase(new int[] { 12, 34, 21 }, ExpectedResult = 34)]
        [TestCase(new int[] { 22 }, ExpectedResult = 22)]
        public int FindMaxTest(int[] arr)
        {
            LList2<int> list = new LList2<int>(arr);
            return list.FindMax();
        }

        [Test]
        public void FindMaxTestExseptions()
        {
            string[] arr = new string[] { "1", "2", "3", "4" };

            LList2<string> list = new LList2<string>(arr);
            Assert.Throws<TypeAccessException>(() => list.FindMax());
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 1, ExpectedResult = new int[] { 0, 2, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 0, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 4, ExpectedResult = new int[] { 0, 1, 2, 3 })]
        public int[] RemoveByIndexTest(int[] arr, int index)
        {
            LList2<int> list = new LList2<int>(arr);
            list.RemoveByIndex(index);
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4 }, -1)]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 5)]
        public void RemoveByIndexTestExceptions(int[] arr, int index)
        {
            LList2<int> list = new LList2<int>(arr);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveByIndex(index));
        }


        [TestCase(ExpectedResult = new int[] { 3, 2, 1 })]
        public int[] ReverseTest()
        {
            TestList.Reverse();
            return TestList.CopyToArr(new int[arr.Length]);
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = new int[] { -4, -1, 3, 10, 20 })]
        [TestCase(new int[] { 10, -1, 20, 3, -4 }, ExpectedResult = new int[] { -4, -1, 3, 10, 20 })]
        [TestCase(new int[] { 12, 21, 34 }, ExpectedResult = new int[] { 12, 21, 34 })]
        [TestCase(new int[] { 22 }, ExpectedResult = new int[] { 22 })]
        public int[] DoBubbleSortEscendTest(int[] arr)
        {
            LList2<int> list = new LList2<int>(arr);
            list.DoBubbleSort();
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = new int[] { -4, -1, 3, 10, 20 })]
        [TestCase(new int[] { 12, 21, 34 }, ExpectedResult = new int[] { 12, 21, 34 })]
        [TestCase(new int[] { 22 }, ExpectedResult = new int[] { 22 })]
        public int[] DoInsertSortEscendTest(int[] arr)
        {
            LList2<int> list = new LList2<int>(arr);
            list.DoInsertSort();
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = new int[] { 20, 10, 3, -1, -4 })]
        [TestCase(new int[] { 12, 21, 34 }, ExpectedResult = new int[] { 34, 21, 12 })]
        [TestCase(new int[] { 22 }, ExpectedResult = new int[] { 22 })]
        public int[] DoInsertSortDescendTest(int[] arr)
        {
            LList2<int> list = new LList2<int>(arr);
            list.DoInsertSort(false);
            return list.CopyToArr(new int[list.Count]);
        }
    }
}
