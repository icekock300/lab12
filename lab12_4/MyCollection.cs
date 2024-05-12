using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryLab10;
namespace lab12_4
{
	public class MyCollection<T>: MyList<T>, IEnumerable<T> where T : IInit, ICloneable, new()
	{
		public MyCollection() : base() { }
		public MyCollection(int size) : base(size) { }
        public MyCollection(T[] collection) : base(collection) { }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
            //Point<T> current = beg;
            //while (current != null)
            //{
            //    yield return current.Data;
            //    current = current.Next;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
            //return GetEnumerator();
        }

        public void Add(T item)
        {
            AddToEnd(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                AddToEnd(item);
            }
        }

        public bool Remove(T item)
        {
            return RemoveItem(item);
        }

        public int RemoveRange(IEnumerable<T> items)
        {
            int removedCount = 0;
            foreach (T item in items)
            {
                if (RemoveItem(item))
                {
                    removedCount++;
                }
            }
            return removedCount;
        }

        public T? Find(Func<T, bool> predicate)
        {
            foreach (T item in this)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }

        public MyCollection<T> DeepCopy()
        {
            MyCollection<T> clonedCollection = new MyCollection<T>();

            // Добавляем глубокую копию первого элемента, если он есть
            if (beg != null)
            {
                T clonedFirstItem = (T)beg.Data.Clone();
                clonedCollection.AddToEnd(clonedFirstItem);
            }

            // Клонируем остальные элементы
            Point<T>? current = beg?.Next;
            while (current != null)
            {
                T clonedItem = (T)current.Data.Clone();
                clonedCollection.AddToEnd(clonedItem);
                current = current.Next;
            }

            return clonedCollection;
        }

        public MyCollection<T> ShallowCopy()
        {
            MyCollection<T> clonedCollection = new MyCollection<T>();

            // Клонируем каждый элемент коллекции с использованием метода Clone() интерфейса ICloneable
            foreach (var item in this)
            {
                T clonedItem = (T)((ICloneable)item).Clone();
                clonedCollection.AddToEnd(clonedItem);
            }

            return clonedCollection;
        }
    }

    internal class MyEnumerator<T> : IEnumerator<T> where T : IInit, ICloneable, new()
    {
        Point<T>? beg;
        Point<T>? current;

        public MyEnumerator(MyCollection<T> collection)
        {
            beg = collection.beg;
            current = beg;
        }

        public T Current => current.Data;

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (current.Next == null)
            {
                Reset();
                return false;
            }
            else
            {
                current = current.Next;
                return true;
            }
        }

        public void Reset()
        {
            current = beg;
        }
    }
}

