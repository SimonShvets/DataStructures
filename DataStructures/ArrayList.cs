using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DataStructures
{
    public class ArrayList
    {
        public int Length { get; private set; }
        private int[] _array;
        private int _TrueLenght
        {
            get
            {
                return _array.Length;
            }
        }
        public ArrayList()
        {
            _array = new int[3];
            Length = 0;
        }
        public ArrayList(int[] array)
        {
            Length = array.Length;
            _array = new int[Length];
            Array.Copy(array, _array, Length);
        }
        public ArrayList(int[] array, int value)
        {
            Length = array.Length;
            _array = new int[Length];
            Array.Copy(array, _array, Length);
            AddToBeginningOfArray(value);
        }
        public int this[int index]
        {
            get
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }

        }
        public void Add(int value)
        {
            if (_TrueLenght <= Length)
            {
                IncreaseLenght();
            }
            _array[Length] = value;
            Length++;
        }
        public void Add(int[] array)
        {
            if (_TrueLenght <= Length + array.Length)
            {
                IncreaseLenght(array.Length);
            }
            for (int i = 0; i < array.Length; i++)
            {
                _array[Length] = array[i];
                Length++;
            }
        }
        public void AddToBeginningOfArray(int value)
        {
            if (_TrueLenght <= Length)
            {
                IncreaseLenght();
            }
            for (int i = Length - 1; i >= 0; i--)
            {
                _array[i + 1] = _array[i];
            }
            _array[0] = value;
            Length++;
        }
        public void AddToBeginningOfArray(int[] array)
        {
            if (_TrueLenght <= Length + array.Length)
            {
                IncreaseLenght(array.Length);
            }
            for (int i = 0; i < array.Length; i++)
            {
                _array[i + array.Length] = _array[i];
                Length++;
            }
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
        }
        public void AddByIndex(int index, int value)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index > Length)
            {
                Add(value);
            }
            else
            {
                IncreaseLenght();
                for (int i = Length - 1; i >= index; i--)
                {
                    _array[i + 1] = _array[i];
                }
                _array[index] = value;
                Length++;
            }
        }
        public void AddByIndex(int index, int[] array)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index > Length)
            {
                Add(array);
            }
            else
            {
                IncreaseLenght(array.Length);
                for (int i = Length - 1; i >= index; i--)
                {
                    _array[i + array.Length] = _array[i];
                }
                for (int i = 0; i < array.Length; i++)
                {
                    _array[index] = array[i];
                    index++;
                    Length++;
                }
            }
        }
        public void DeleteFromEndOfArrayList()
        {
            if (Length == 0)
            {
                throw new Exception("Lenght of ArrayList can't be negative");
            }
            if (_TrueLenght >= 2 * Length)
            {
                DecreaseLenght();
            }
            Length--;
        }
        public void DeleteFromEndOfArrayList(int value)
        {
            if (value <= Length && value >= 0)
            {
                for (int i = 0; i < value; i++)
                {
                    if (_TrueLenght >= 2 * Length)
                    {
                        DecreaseLenght();
                    }
                    Length--;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public void DeleteFromBeginningOfArrayList()
        {
            for (int i = 0; i < Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            DeleteFromEndOfArrayList();
        }
        public void DeleteFromBeginningOfArrayList(int value)
        {
            for (int i = 0; i < Length - value; i++)
            {
                _array[i] = _array[value + i];
            }
            DeleteFromEndOfArrayList(value);
        }
        public void DeleteElementOfArrayByIndex(int index)
        {

            if (0 > index || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = index; i < Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                DeleteFromEndOfArrayList();
            }
        }
        public void DeleteElementOfArrayByIndex(int index, int value)
        {

            if (0 > index || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = index; i < Length - value; i++)
                {
                    _array[i] = _array[value + i];
                }
                DeleteFromEndOfArrayList(value);
            }
        }
        public int[] GetIndexByValue(int value)
        {
            int[] array = new int[Length];
            int count = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    array[count] = i;
                    count++;
                }
            }
            int[] indices = new int[count];
            Array.Copy(array, indices, count);
            return indices;
        }
        public void ReverseArrayList()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int b = 0;
                b = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = b;
            }
        }
        public int MaxElementOfArrayList()
        {
            int maxValue = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > maxValue)
                {
                    maxValue = _array[i];
                }
            }
            return maxValue;
        }
        public int MinElementOfArrayList()
        {
            int minValue = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < minValue)
                {
                    minValue = _array[i];
                }
            }
            return minValue;
        }
        public int IndexOfMaxElementOfArrayList()
        {
            int maxValue = _array[0];
            int indexOfMaxValue = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > maxValue)
                {
                    maxValue = _array[i];
                    indexOfMaxValue = i;
                }
            }
            return indexOfMaxValue;
        }
        public int IndexOfMinElementOfArrayList()
        {
            int minValue = _array[0];
            int indexOfMinValue = 0;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < minValue)
                {
                    minValue = _array[i];
                    indexOfMinValue = i;
                }
            }
            return indexOfMinValue;
        }
        public void AscendingSortOfArrayList()
        {
            DescendingSortOfArrayList();
            ReverseArrayList();
        }
        public void DescendingSortOfArrayList()
        {
            for (int i = 1; i < Length; i++)
            {
                int currentValue = _array[i];
                int j = i;
                while (j > 0 && currentValue > _array[j - 1])
                {
                    _array[j] = _array[j - 1];
                    j--;
                }
                _array[j] = currentValue;
            }
        }
        public void DeleteFirstElementByValue(int value)
        {
            if (GetIndexByValue(value).Length == 0)
            {
                GetIndexByValue(value);
            }
            else
            {
                DeleteElementOfArrayByIndex(GetIndexByValue(value)[0]);
            }
        }
        public void DeleteElementsByValue(int value)
        {

            int[] indices = GetIndexByValue(value);
            if (indices.Length == 0)
            {
                GetIndexByValue(value);
            }
            else
            {
                for (int i = 0; i < indices.Length; i++)
                {
                    DeleteElementOfArrayByIndex(indices[i] - i);
                }
            }
        }
        private void IncreaseLenght(int number = 1)
        {
            int newLenght = _TrueLenght;
            while (newLenght <= Length + number)
            {
                newLenght = (int)(newLenght * 1.33 + 1);
            }
            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _TrueLenght);
            _array = newArray;
        }
        private void DecreaseLenght()
        {
            int newLenght = _TrueLenght;
            while (newLenght > 2 * Length)
            {
                newLenght = newLenght * 2 / 3;
            }
            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, newLenght);
            _array = newArray;
        }
        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override string ToString()
        {
            return string.Join(";", _array.Take(Length));
        }
    }
}
