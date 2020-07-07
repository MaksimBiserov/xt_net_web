using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArrayLibrary
{
    public class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        private const int defaultSize = 8;
        private T[] array;

        public int SizeCount { get; private set; }
        public int Length // 8
        {
            get
            {
                return SizeCount;
            }
        }
        public int Capacity // 9
        {
            get
            {
                return array.Length;
            }
            set // 2*
            {
                if (array == null)
                {
                    array = new T[value];
                }

                else if (array.Length <= value)
                {
                    throw new ArgumentOutOfRangeException("Capacity can't be more than size of array");
                }

                else
                {
                    T[] newArray = array;
                    array = new T[value];
                    newArray.CopyTo(array, 0);
                }
            }
        }

        public DynamicArray() : this(defaultSize) // 1
        {

        }

        public DynamicArray(int size) // 2
        {
            if (size >= 0)
            {
                SizeCount = 0;
                array = new T[size];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Size of array can't be < 0");
            }
        }

        public DynamicArray(IEnumerable<T> items) // 3
        {
            array = new T[(items as ICollection).Count];
            (items as ICollection).CopyTo(array, 0);
        }

        private void Resize(int newSize) // method for resizing an array
        {
            T[] newArray = new T[newSize];
            array.CopyTo(newArray, 0);
            array = newArray;
        }

        public void Add(T element) // 4
        {
            if (SizeCount + 1 > Capacity)
            {
                Resize(SizeCount * 2);
            }

            array[SizeCount] = element;
            SizeCount++;
        }

        public void AddRange(IEnumerable<T> elements) // 5
        {
            int newSize = 0;

            foreach (var item in elements)
            {
                newSize++;
            }

            if ((SizeCount + newSize) > Capacity)
            {
                Resize(SizeCount + newSize);
            }

            foreach (var value in elements)
            {
                array[SizeCount] = value;
                SizeCount++;
            }
        }

        public bool Remove(T element) // 6
        {
            for (int i = 0; i < SizeCount; i++)
            {
                if (array[i].Equals(element) && (i + 1) < SizeCount)
                {
                    Array.Copy(array, (i + 1), array, i, SizeCount - (i + 1));
                    SizeCount--;
                    return true;
                }
            }
            return false;
        }

        public bool Insert(int index, T element) // 7
        {
            if (index > 0 || index < SizeCount)
            {
                Add(element);
                Array.Copy(array, index, array, index + 1, SizeCount - index);
                array[index] = element;
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index must be more than 0 and can't be more than size of array");
            }
        }

        public T[] ToArray() // 4*
        {
            T[] newArray = new T[SizeCount];

            for (int i = 0; i < SizeCount; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        public IEnumerator<T> GetEnumerator() // 10
        {
            for (int i = 0; i < SizeCount; i++)
            {
                yield return array[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() // 10
        {
            return GetEnumerator();
        }

        public object Clone() // 3*
        {
            T[] newArray = new T[Capacity];

            for (int i = 0; i < SizeCount; i++)
            {
                newArray[i] = this[i];
            }

            return new DynamicArray<T>(newArray);
        }

        public T this[int index] // 11
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    throw new IndexOutOfRangeException("Index can't be < 0 and can't go beyond the array");
                }
                array[index] = value;
            }
        }
    }
}