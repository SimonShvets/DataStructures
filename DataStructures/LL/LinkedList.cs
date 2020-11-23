using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LL
{
    public class LinkedList
    {
        public int Length { get; set; }

        private Node _root;
        private Node _tail;

        private Node GetNode(int index)
        {
            if (index >= Length && index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
            Node current = _root;
            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }
            return current;
            }
        }

        public int this[int index]
        {
            get
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
            _tail = _root;
            Length = 1;
        }

        public LinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }
                _tail = tmp;
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
                _tail = null; 
            }
        }

        public void Add(int value)
        {
            if (Length == 0)
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                Node tmp = _tail;
                _tail = new Node(value);
                tmp.Next = _tail;
            }
            Length++;
        }
        public void Add(int [] array)
        {
            if (Length == 0)
            {
                _root = new Node(array[0]);
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Add(array[i]);
                }
            }
        }
        public void AddToBeginning(int value)
        {
            if (Length == 0)
            {
                _root = new Node(value);
            }
            else
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
            }
            Length++;
        }
        public void AddToBeginning(int []array)
        {
            if (Length == 0)
            {
                _root = new Node(array[0]);
            }
            else
            {
                for(int i = 0; i < array.Length; i++)
                {
                    AddToBeginning(array[array.Length - 1 - i]);
                }
            }
        }
        public void AddByIndex(int index, int value)
        {
            if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;

            }
            else
            {
                Node current = _root;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                Node tmp = current.Next;
                current.Next = new Node(value);
                current.Next.Next = tmp;
            }
            Length++;
        }
        public void AddByIndex(int index, int [] array)
        {
            if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(array[0]);
                _root.Next = tmp;

            }
            else
            {
                //Node current = GetNode(index);
                Node tmp = GetNode(index).Next;
                GetNode(index).Next = new Node(array[0]);
                GetNode(index).Next.Next = tmp;
            }
            Length++;
        }
        public void DeleteFromEndOfLinkedList()
        {
            if (Length == 0)
            {
                throw new Exception("Lenght of ArrayList can't be negative");
            }
            else
            {
                Node tmp = _root;
                for (int i = 1; i < Length-1; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                Length--;
            }
        }
        public void DeleteFromEndOfLinkedList(int value)
        {
            if (value <= Length && value >= 0)
            {
                Node tmp = _root;
                for (int i = 1; i < Length - value; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                Length -= value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        //public void DeleteFromBeginningOfArrayList()
        //{
        //    for (int i = 0; i < Length - 1; i++)
        //    {
        //        _array[i] = _array[i + 1];
        //    }
        //    DeleteFromEndOfArrayList();
        //}
        //public void DeleteFromBeginningOfArrayList(int value)
        //{
        //    for (int i = 0; i < Length - value; i++)
        //    {
        //        _array[i] = _array[value + i];
        //    }
        //    DeleteFromEndOfArrayList(value);
        //}
        //public void DeleteElementOfArrayByIndex(int index)
        //{

        //    if (0 > index || index >= Length)
        //    {
        //        throw new IndexOutOfRangeException();
        //    }
        //    else
        //    {
        //        for (int i = index; i < Length - 1; i++)
        //        {
        //            _array[i] = _array[i + 1];
        //        }
        //        DeleteFromEndOfArrayList();
        //    }
        //}
        //public void DeleteElementOfArrayByIndex(int index, int value)
        //{

        //    if (0 > index || index >= Length)
        //    {
        //        throw new IndexOutOfRangeException();
        //    }
        //    else
        //    {
        //        for (int i = index; i < Length - value; i++)
        //        {
        //            _array[i] = _array[value + i];
        //        }
        //        DeleteFromEndOfArrayList(value);
        //    }
        //}
        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            //for (int i = 0; i < Length; i++)
            //{
            //    if(this[i]!=linkedList[i])
            //    {
            //        return false;
            //    }
            //}

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                Node tmp = _root;

                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
            }
            return s;
        }
    }
}
