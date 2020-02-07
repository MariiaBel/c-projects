using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using List;

namespace LListTest
{
    [TestFixture]
    class LList1Test
    {
        [TestCase(12, ExpectedResult = 12)]
        public int initializeNode(int value)
        {
            LList1<int> newNode = new LList1<int>(value);
            return newNode.Root.Value;
        }

        [TestCase("Hi", ExpectedResult = "Hi")]
        public string initializeNode(string value)
        {
            LList1<string> newNode = new LList1<string>(value);
            return newNode.Root.Value;
        }

        [TestCase(new int[] { 12, 11, 10, 9 }, ExpectedResult = new int[] { 12, 11, 10, 9 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        public int[] initializeNode(int[] value)
        {
            LList1<int> newNode = new LList1<int>(value);
            return newNode.CopyToArr(new int[newNode.Count]);
        }

        //[TestCase(new string[] { "Hi", "Everyone" }, ExpectedResult = new string[] { "Hi", "Everyone" })]
        //public string[] initializeNode(string[] value)
        //{
        //    LList1<string> newNode = new LList1<string>(value);
        //    return newNode.CopyToArr(new string[newNode.Count]);
        //}
        [Test]
        public void initializeNodeString()
        {
            string[] arr = new string[] { "Hi", "Everyone" };
            LList1<string> newNode = new LList1<string>(arr);
            Assert.AreEqual(arr, newNode.CopyToArr(new string[newNode.Count]));
        }

        [TestCase(null)]
        public void initializeNodeExceptions(int? value)
        {
            Assert.Throws<ArgumentNullException>(() => new LList1<int?>(value));
        }

        //[TestCase(new int[] { })]
        //public void initializeNodeExceptions(int[] value)
        //{
        //    Assert.Throws<ArgumentNullException>(() => new LList1<int[]>(value));
        //}

        [TestCase(new int[] { 12, 11, 10, 9 }, 34, ExpectedResult = new int[] { 34, 12, 11, 10, 9 })]
        [TestCase(new int[] { 12, 11, 10, 9 }, 1, 2, 3, ExpectedResult = new int[] { 1, 2, 3, 12, 11, 10, 9 })]
        [TestCase(new int[] { 12, 11, 10, 9 }, new int[] { 3, 3, 5}, ExpectedResult = new int[] { 3, 3, 5, 12, 11, 10, 9 })]
        [TestCase(new int[] {  }, new int[] { 3, 3, 5}, ExpectedResult = new int[] { 3, 3, 5 })]
        [TestCase(new int[] { }, 34, ExpectedResult = new int[] { 34 })]
        public int[] AddFirstTest(int[] arr, params int[] value)
        {
            LList1<int> list = new LList1<int>(arr);
            list.AddFirst(value);

            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { 12, 11, 10, 9 }, 34, ExpectedResult = new int[] { 12, 11, 10, 9, 34 })]
        [TestCase(new int[] { }, 34, ExpectedResult = new int[] { 34 })]
        public int[] AddLastTest(int[] arr, int value)
        {
            LList1<int> list = new LList1<int>(arr);
            list.Add(value);
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { 12, 11, 10, 9 }, 34, ExpectedResult = new int[] { 12, 11, 10, 9, 34 })]
        [TestCase(new int[] { }, 34, ExpectedResult = new int[] { 34 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] {  }, ExpectedResult = new int[] {  })]
        public int[] AddToEndTest(int[] arr, params int[] value)
        {
            LList1<int> list = new LList1<int>(arr);
            list.AddToEnd(value);
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { 12, 11, 10, 9 }, 2, 34, ExpectedResult = new int[] { 12, 11, 10, 34, 9 })]
        [TestCase(new int[] { }, 1, 34, ExpectedResult = new int[] { 34 })]
        public int[] AddTest(int[] arr, int value, int after)
        {
            LList1<int> list = new LList1<int>(arr);
            list.Add(value, after);
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { }, 0, 34, ExpectedResult = new int[] { 34 })]
        [TestCase(new int[] { }, 2, 34, ExpectedResult = new int[] { 34 })]
        public int[] AddTestExpended(int[] arr, int value, int after)
        {
            LList1<int> list = new LList1<int>(arr);
            list.Add(value, after);
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 2, ExpectedResult = 2)]
        public int GetNodeByIndexTest(int[] arr, int index)
        {
            LList1<int> list = new LList1<int>(arr);
            return list.GetNodeByIndex(index).Value;
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 6)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, -6)]
        public void GetNodeByIndexTestExceptions(int[] arr, int index)
        {
            LList1<int> list = new LList1<int>(arr);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.GetNodeByIndex(index));
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, ExpectedResult = 5)]
        public int GetLastNodeTest(int[] arr)
        {
            LList1<int> list = new LList1<int>(arr);
            return list.GetLastNode().Value;
        }

        [TestCase(new int[] { })]
        public void GetLastNodeExceptions(int[] arr)
        {
            LList1<int> list = new LList1<int>(arr);
            Assert.Throws<ArgumentNullException>(() => list.GetLastNode());
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 1, ExpectedResult = new int[] { 0, 2, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 0, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 4, ExpectedResult = new int[] { 0, 1, 2, 3 })]
        public int[] RemoveByIndexTest(int[] arr, int index)
        {
            LList1<int> list = new LList1<int>(arr);
            list.RemoveByIndex(index);
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4 }, -1)]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 5)]
        public void RemoveByIndexTestExceptions(int[] arr, int index)
        {
            LList1<int> list = new LList1<int>(arr);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveByIndex(index));
        }


        [TestCase(new int[] { -1, 10, 20, 3, 4 }, 20, ExpectedResult = new int[] { -1, 10, 3, 4 })]
        [TestCase(new int[] { 12, 34, 21 }, 12, ExpectedResult = new int[] { 34, 21 })]
        [TestCase(new int[] { 12, 34, 21 }, 21, ExpectedResult = new int[] { 12, 34 })]
        [TestCase(new int[] { 12, 34, 21 }, 34, ExpectedResult = new int[] { 12, 21 })]
        public int[] RemoveByValueTest(int[] arr, int value)
        {
            LList1<int> list = new LList1<int>(arr);
            list.RemoveByValue(value);
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = -4)]
        [TestCase(new int[] { 12, 34, 21 }, ExpectedResult = 12)]
        [TestCase(new int[] { 22 }, ExpectedResult = 22)]
        public int FindMinTest(int[] arr)
        {
            LList1<int> list = new LList1<int>(arr);
            return list.FindMin();
        }

        [Test]
        public void FindMinTestExseptions()
        {
            string[] arr = new string[] { "1", "2", "3", "4" };

            LList1<string> list = new LList1<string>(arr);
            Assert.Throws<TypeAccessException>(() => list.FindMin());
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = 20)]
        [TestCase(new int[] { 12, 34, 21 }, ExpectedResult = 34)]
        [TestCase(new int[] { 22 }, ExpectedResult = 22)]
        public int FindMaxTest(int[] arr)
        {
            LList1<int> list = new LList1<int>(arr);
            return list.FindMax();
        }

        [Test]
        public void FindMaxTestExseptions()
        {
            string[] arr = new string[] { "1", "2", "3", "4" };

            LList1<string> list = new LList1<string>(arr);
            Assert.Throws<TypeAccessException>(() => list.FindMax());
        }

        [TestCase(new int[] { -1, 10, 20, 3, 22 }, 4, ExpectedResult = 22)]
        [TestCase(new int[] { -1, 10, 20, 3, -4 }, 0, ExpectedResult = -4)]
        [TestCase(new int[] { 12, 21, 34 }, 1, ExpectedResult = 21)]
        [TestCase(new int[] { 22, -1, 34, -12, 2 }, 2, ExpectedResult = -12)]
        public int FindMinNodeFromIndexTest(int[] arr, int index)
        {
            LList1<int> list = new LList1<int>(arr);
            int minIndex = 0;
            Node<int> foundNode = list.FindMinNodeFromIndex(ref minIndex, index);
            return foundNode.Value;
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = new int[] { 20, 10, 3, -1, -4  })]
        [TestCase(new int[] { 12, 21, 34 }, ExpectedResult = new int[] { 34, 21, 12 })]
        [TestCase(new int[] { 22 }, ExpectedResult = new int[] { 22 })]
        public int[] DoInsertSortDescendTest(int[] arr)
        {
            LList1<int> list = new LList1<int>(arr);
            list.DoInsertSort(false);
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = new int[] { -4, -1, 3, 10, 20 })]
        [TestCase(new int[] { 12, 21, 34 }, ExpectedResult = new int[] { 12, 21, 34 })]
        [TestCase(new int[] { 22 }, ExpectedResult = new int[] { 22 })]
        public int[] DoInsertSortEscendTest(int[] arr)
        {
            LList1<int> list = new LList1<int>(arr);
            list.DoInsertSort();
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = new int[] { -4, -1, 3, 10, 20 })]
        [TestCase(new int[] { 10, -1, 20, 3, -4 }, ExpectedResult = new int[] { -4, -1, 3, 10, 20 })]
        [TestCase(new int[] { 12, 21, 34 }, ExpectedResult = new int[] { 12, 21, 34 })]
        [TestCase(new int[] { 22 }, ExpectedResult = new int[] { 22 })]
        public int[] DoBubbleSortEscendTest(int[] arr)
        {
            LList1<int> list = new LList1<int>(arr);
            list.DoBubbleSort();
            return list.CopyToArr(new int[list.Count]);
        }

        [TestCase(new int[] { -1, 10, 20, 3, -4 }, ExpectedResult = new int[] { -4, 3, 20, 10, -1 })]
        [TestCase(new int[] { -1 }, ExpectedResult = new int[] { -1 })]
        public int[] ReverseTest(int[] arr)
        {
            LList1<int> list = new LList1<int>(arr);
            list.Reverse();
            return list.CopyToArr(new int[list.Count]);
        }
        [TestCase(new int[] { 12, 11, 10, 9 }, ExpectedResult = new int[] { 12, 11, 10, 9 })]        
        public int[] CopyToArrayTest(int[] arr)
        {
            LList1<int> list = new LList1<int>(arr);
            return list.CopyToArr(arr);
        }

    }
}
