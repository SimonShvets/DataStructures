using NUnit.Framework;
using DataStructures.LL;
using System;

namespace DataStructures.Test
{
    public class LinkedListTests
    {
        [TestCase(1, 2, new int[] { 1, 2 })]
        [TestCase(0, 0, new int[] { 0, 0 })]
        [TestCase(10, 99, new int[] { 10, 99 })]
        public void AddTest(int value, int value2, int[] expectedArray)
        {
            LinkedList actual = new LinkedList();
            LinkedList expected = new LinkedList(expectedArray);

            actual.Add(value);
            actual.Add(value2);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2 }, new int[] { 0, 0, 0, 1, 2 })]
        [TestCase(new int[] { }, new int[] { 0, 0, 0 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0 })]
        public void AddTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(new int[] { 0, 0, 0 });
            LinkedList expected = new LinkedList(expectedArray);

            actual.Add(array);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1 }, 2, new int[] { 2, 1 })]
        [TestCase(new int[] { 1, 2 , 3 }, 0, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { }, 99, new int[] { 99 })]
        public void AddToBeginningTest(int []actualArray,int value, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddToBeginning(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 0, 0, 0, })]
        [TestCase(new int[] { }, new int[] { 0, 0, 0 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0 })]
        public void AddToBeginningTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(new int[] { 0, 0, 0 });
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddToBeginning(array);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]
        public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expArray);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 0, 1, 2, 2, 3, 0, 0, 0 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 1, 2, 3, 0, 0, 0, 0 })]
        [TestCase(new int[] { 1, 2, 3 }, 99, new int[] { 0, 0, 0, 0, 1, 2, 3 })]
        public void AddByIndexTest(int[] array, int index, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(new int[] { 0,0,0,0 });
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddByIndex(index, array);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3 }, -1, 2)]
        public void AddByIndexTestNegative(int[] actualArray, int index, int value)
        {
            LinkedList actual = new LinkedList(actualArray);


            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));
        }
        [TestCase(new int[] { 1, 2, 3 }, -1, new int[] { 0 })]
        public void AddByIndexTestNegative(int[] actualArray, int index, int[] array)
        {
            LinkedList actual = new LinkedList(actualArray);


            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, array));
        }
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 0, 1 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 3, 3 }, new int[] { 1, 3 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 0, 1 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 3, 3 }, new int[] { 1, 3 })]
        public void DeleteFromEndOfLinkedListTest(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteFromEndOfLinkedList();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { })]
        public void DeleteFromEndOfLinkedListTestNegative(int[] actualArray)
        {
            LinkedList actual = new LinkedList(actualArray);


            Assert.Throws<Exception>(() => actual.DeleteFromEndOfLinkedList());
        }
        [TestCase(new int[] { 0 }, 0, new int[] { 0 })]
        [TestCase(new int[] { 0, 1 }, 2, new int[] { })]
        [TestCase(new int[] { 1, 3, 3 }, 1, new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 3, 3, 4, 5, 6 }, 2, new int[] { 1, 3, 3, 4 })]
        public void DeleteFromEndOfLinkedListTest(int[] actualArray, int value, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteFromEndOfLinkedList(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { }, -1)]
        public void DeleteFromEndOfLinkedListTestNegative(int[] actualArray, int value)
        {
            LinkedList actual = new LinkedList(actualArray);


            Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteFromEndOfLinkedList(value));
        }
    }
}
