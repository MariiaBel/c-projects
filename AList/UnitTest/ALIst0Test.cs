using System;
using NUnit.Framework;
using List;

namespace AListTest
{
    [TestFixture]
    class AList0Test
    {
        int[] myArr, newArr, newArrRemove;
        AList0<int> arrayMath, arrException;


        [SetUp]
        public void SetUpArr()
        {
            myArr = new int[] { 1, 2, 3, 4, 5, -3, 45, 21 };
            arrayMath = new AList0<int>(myArr);

            newArr = new int[] { 1, 2, 3, 4, 5, -3, 45, 21, 12 };
            newArrRemove = new int[] { 1, 2, 4, 5, -3, 45, 21 };
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, -3, 45, 21 }, ExpectedResult = -3)]
        [TestCase(new int[] { 121 }, ExpectedResult = 121)]
        public int FindMinTest(int[] arr)
        {
            arrayMath = new AList0<int>(arr);
            return arrayMath.FindMin();
        }

        [TestCase(null)]
        [TestCase(new int[] { })]
        public void FindMinTestExceptions(int[] arr)
        {
            arrException = new AList0<int>(arr);
            Assert.Throws<ArgumentNullException>(() => arrException.FindMin());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, -3, 45, 21 }, ExpectedResult = 45)]
        [TestCase(new int[] { 121 }, ExpectedResult = 121)]
        public int FindMaxTest(int[] arr)
        {
            arrayMath = new AList0<int>(arr);
            return arrayMath.FindMax();
        }

        [TestCase(null)]
        [TestCase(new int[] { })]
        public void FindMaxTestExceptions(int[] arr)
        {
            arrException = new AList0<int>(arr);
            Assert.Throws<ArgumentNullException>(() => arrException.FindMax());
        }

        [Test]
        public void FindIndexMinTest()
        {
            Assert.AreEqual(5, arrayMath.FindIndexMin());
        }

        [Test]
        public void FindIndexMaxTest()
        {
            Assert.AreEqual(6, arrayMath.FindIndexMax());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = 12)]
        [TestCase(new int[] { -1, -2, -3, -4, -5, -6 }, ExpectedResult = -12)]
        public int SumNumberOfUnevenIndexTest(int[] arr)
        {
            arrayMath = new AList0<int>(arr);
            return arrayMath.SumNumberOfUnevenIndex();
        }

        [Test]
        public void SumUnevenIndexTest()
        {
            Assert.AreEqual(6, arrayMath.SumIndexOfUnevenNumber());
        }

        [Test]
        public void ReverseArrTest()
        {
            arrayMath.Reverse();
            Assert.AreEqual(new int[] { 21, 45, -3, 5, 4, 3, 2, 1 }, arrayMath.Arr);
        }

        [Test]
        public void MixArrHalfTest()
        {
            arrayMath.MixArrHalf();
            Assert.AreEqual(new int[] { 5, -3, 45, 21, 1, 2, 3, 4 }, arrayMath.Arr);
        }

        [Test]
        public void DoBubbleSortTest()
        {
            arrayMath.DoBubbleSort();
            Assert.AreEqual(new int[] { -3, 1, 2, 3, 4, 5, 21, 45 }, arrayMath.Arr);
        }

        [Test]
        public void DoSelectSortTest()
        {
            arrayMath.DoSelectSort();
            Assert.AreEqual(new int[] { -3, 1, 2, 3, 4, 5, 21, 45 }, arrayMath.Arr);
        }

        [Test]
        public void DoInsertSortTest()
        {
            arrayMath.DoInsertSort();
            Assert.AreEqual(new int[] { -3, 1, 2, 3, 4, 5, 21, 45 }, arrayMath.Arr);
        }


        [TestCase(new int[] { 23 }, ExpectedResult = new int[] { 23 })]
        [TestCase(new int[] { 23, 1, 100 }, ExpectedResult = new int[] { 1, 23, 100 })]
        [TestCase(new int[] { 23, 1, 100, 213, -2, 3, 5 }, ExpectedResult = new int[] { -2, 1, 3, 5, 23, 100, 213 })]
        public int[] DoQuickSortTest(int[] arr)
        {
            AList0<int> arrForSortQuick = new AList0<int>(arr);

            arrForSortQuick.DoQuickSort();
            return arrForSortQuick.Arr;
        }

        [TestCase(new int[] { })]
        [TestCase(null)]
        public void DoQuickSortTestExceptions(int[] arr)
        {
            AList0<int> arrForSortQuick = new AList0<int>(arr);

            Assert.Throws<ArgumentNullException>(() => arrForSortQuick.DoQuickSort());
        }

        [TestCase(12, ExpectedResult = new int[] { 12, 1, 2, 3, 4, 5, -3, 45, 21 })]
        [TestCase(new int[] { 12, 34}, ExpectedResult = new int[] { 12, 34, 1, 2, 3, 4, 5, -3, 45, 21 })]
        public int[] AddFirstTest(params int[] item)
        {
            arrayMath.AddFirst(item);
            return arrayMath.Arr;
        }

        //HAha[TestCase(null, ExpectedResult = new int[] { 1, 2, 3, 4, 5, -3, 45, 21 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, -3, 45, 21 })]
        [TestCase(12, ExpectedResult = new int[] { 1, 2, 3, 4, 5, -3, 45, 21, 12 })]
        [TestCase(12, 0, ExpectedResult = new int[] { 1, 2, 3, 4, 5, -3, 45, 21, 12, 0 })]
        [TestCase(new int[] { 12, 23, 34 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, -3, 45, 21, 12, 23, 34 })]
        public int[] AddToEndTest(params int[] item)
        {
            arrayMath.AddToEnd(item);
            return arrayMath.Arr;
        }


        [TestCase(1, 12, 23, ExpectedResult = new int[] { 1, 12, 23, 2, 3, 4, 5, -3, 45, 21 })]
        [TestCase(0, 12, 23, ExpectedResult = new int[] { 12, 23, 1, 2, 3, 4, 5, -3, 45, 21 })]
        [TestCase(8, 12, 23, ExpectedResult = new int[] { 1, 2, 3, 4, 5, -3, 45, 21, 12, 23 })]
        [TestCase(8, new int[] { 12, 23, 123 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, -3, 45, 21, 12, 23, 123 })]
        public int[] AddTest(int index, params int[] item)
        {
            arrayMath.Add(index, item);
            return arrayMath.Arr;
        }
        [Test]
        public void RemoveByIndexTest()
        {
            arrayMath.RemoveByIndex(2);
            Assert.AreEqual(newArrRemove, arrayMath.Arr);
        }
    }
}