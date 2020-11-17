using NUnit.Framework;
using System;

namespace DataStructures.Test
{
    public class ArrayListTests
    {
        [TestCase(1, 2, new int[] { 1, 2 })]
        [TestCase(0, 0, new int[] { 0, 0 })]
        [TestCase(10, 99, new int[] { 10, 99 })]
        public void AddTest(int value, int value2, int[] expectedArray)
        {
            ArrayList actual = new ArrayList();
            ArrayList expected = new ArrayList(expectedArray);

            actual.Add(value);
            actual.Add(value2);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2 }, new int[] { 0, 0, 0, 1, 2 })]
        [TestCase(new int[] { }, new int[] { 0, 0, 0 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0 })]
        public void AddTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(new int[] { 0, 0, 0 });
            ArrayList expected = new ArrayList(expectedArray);

            actual.Add(array);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, 2, new int[] { 2, 1 })]
        [TestCase(0, 0, new int[] { 0, 0 })]
        [TestCase(10, 99, new int[] { 99, 10 })]
        public void AddToBeginningOfArrayTest(int value, int value2, int[] expectedArray)
        {
            ArrayList actual = new ArrayList();
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddToBeginningOfArray(value);
            actual.AddToBeginningOfArray(value2);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 0, 0, 0, })]
        [TestCase(new int[] { }, new int[] { 0, 0, 0 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0 })]
        public void AddToBeginningOfArrayTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(new int[] { 0, 0, 0 });
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddToBeginningOfArray(array);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2 }, 0, new int[] { 1, 2, 0, 0, 0, })]
        [TestCase(new int[] { }, 1, new int[] { 0, 0, 0 })]
        [TestCase(new int[] { 1 }, 1, new int[] { 0, 1, 0, 0 })]
        public void AddByIndexTest(int[] array, int index, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(new int[] { 0, 0, 0 });
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddByIndex(index, array);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, 2, new int[] { 1, 2, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 0, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 10, 99, new int[] { 1, 2, 3, 99 })]
        public void AddByIndexTest(int[] actualArray, int index, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, -1, 2)]
        public void AddByIndexTestNegative(int[] actualArray, int index, int value)
        {
            ArrayList actual = new ArrayList(actualArray);


            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));
        }
        [TestCase(new int[] { 1, 2, 3 }, -1, new int[] { 0 })]
        public void AddByIndexTestNegative(int[] actualArray, int index, int[] array)
        {
            ArrayList actual = new ArrayList(actualArray);


            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, array));
        }
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 0, 1 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 3, 3 }, new int[] { 1, 3 })]
        public void DeleteFromEndOfArrayListTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteFromEndOfArrayList();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { })]
        public void DeleteFromEndOfArrayListTestNegative(int[] actualArray)
        {
            ArrayList actual = new ArrayList(actualArray);


            Assert.Throws<Exception>(() => actual.DeleteFromEndOfArrayList());
        }
        [TestCase(new int[] { 0 }, 0, new int[] { 0 })]
        [TestCase(new int[] { 0, 1 }, 2, new int[] { })]
        [TestCase(new int[] { 1, 3, 3 }, 1, new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 3, 3, 4, 5, 6 }, 2, new int[] { 1, 3, 3, 4 })]
        public void DeleteFromEndOfArrayListTest(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteFromEndOfArrayList(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, -1)]
        public void DeleteFromEndOfArrayListTestNegative(int[] actualArray, int value)
        {
            ArrayList actual = new ArrayList(actualArray);


            Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteFromEndOfArrayList(value));
        }
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 0, 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        public void DeleteFromBeginningOfArrayListTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteFromBeginningOfArrayList();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0 }, 0, new int[] { 0 })]
        [TestCase(new int[] { 0, 1 }, 2, new int[] { })]
        [TestCase(new int[] { 1, 3, 3 }, 1, new int[] { 3, 3 })]
        [TestCase(new int[] { 1, 3, 3, 4, 5, 6 }, 2, new int[] { 3, 4, 5, 6 })]
        public void DeleteFromBeginingOfArrayListTest(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteFromBeginningOfArrayList(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0 }, 0, new int[] { })]
        [TestCase(new int[] { 0, 1 }, 1, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 1, 3 })]
        public void DeleteElementOfArrayByIndexTest(int[] actualArray, int index, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteElementOfArrayByIndex(index);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0 }, 0, 0, new int[] { 0 })]
        [TestCase(new int[] { 0, 1 }, 1, 1, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, 2, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1, 4, new int[] { 1, 6, 7, 8 })]
        public void DeleteElementOfArrayByIndexTest(int[] actualArray, int index, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteElementOfArrayByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0 }, 0, 0)]
        [TestCase(new int[] { 0, 1 }, 1, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 2, 3)]
        public void IndexatorTest(int[] array, int index, int expected)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray[index];
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        public void ReverseArrayListTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.ReverseArrayList();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, 0, new int[] { })]
        [TestCase(new int[] { 0 }, 0, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3, 1 }, 1, new int[] { 0, 3 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0 }, 0, new int[] { 0, 1, 2, 3, 4, 8, 9 })]
        public void GetIndexByValueTest(int[] array, int value, int[] expected)
        {
            ArrayList actualArray = new ArrayList(array);

            int[] actual = actualArray.GetIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1, 10, 2, 3 }, 10)]

        public void MaxElementOfArrayListTest(int[] array, int expected)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.MaxElementOfArrayList();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 0, 10, -2, 3 }, -2)]
        public void MinElementOfArrayListTest(int[] array, int expected)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.MinElementOfArrayList();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 2)]
        [TestCase(new int[] { 0, 10, -2, 3 }, 1)]
        public void IndexOfMaxElementOfArrayListTest(int[] array, int expected)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.IndexOfMaxElementOfArrayList();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 0)]
        [TestCase(new int[] { 0, 10, -2, 3 }, 2)]
        public void IndexOfMinElementOfArrayListTest(int[] array, int expected)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.IndexOfMinElementOfArrayList();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 0, 10, -2, 3 }, new int[] { -2, 0, 3, 10 })]
        public void AscendingSortOfArrayListTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AscendingSortOfArrayList();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 0, 10, -2, 3 }, new int[] { 10, 3, 0, -2 })]
        public void DescendingSortOfArrayListTest(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DescendingSortOfArrayList();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, 0, new int[] { })]
        [TestCase(new int[] { 0 }, 0, new int[] { })]
        [TestCase(new int[] { 0 }, -1, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3, 1 }, 1, new int[] { 2, 3, 1 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, 0, new int[] { 0, 0, 0, 0 })]
        public void DeleteFirstElementByValueTest(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteFirstElementByValue(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, 0, new int[] { })]
        [TestCase(new int[] { 0 }, 0, new int[] { })]
        [TestCase(new int[] { 0, 1, 0 }, 0, new int[] { 1 })]
        [TestCase(new int[] { 1, 0, 1 }, 1, new int[] { 0 })]
        [TestCase(new int[] { 0 }, -1, new int[] { 0 })]
        [TestCase(new int[] { 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1 }, 1, new int[] { 0, 0, 0 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, new int[] { })]
        public void DeleteElementsByValueTest(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(actualArray);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteElementsByValue(value);

            Assert.AreEqual(expected, actual);
        }
    }
}