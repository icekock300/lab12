using LibraryLab10;
using System;
using lab12_2;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.CodeAnalysis;

namespace lab12_2
{
	public class MyHashTable<T> where T : IInit, ICloneable, new()
	{
		Point<T>?[] table;
		public int Capacity => table.Length;

		public MyHashTable(int length = 10)
		{
			table = new Point<T>[length];
		}

        [ExcludeFromCodeCoverage]
        public void PrintTable()
		{
			for (int i = 0; i < table.Length; i++)
			{
                Console.WriteLine($"{i}:");
				if (table[i] != null)
				{
					Console.WriteLine(table[i].Data);
					if (table[i].Next != null)
					{
						Point<T>? current = table[i].Next;
						while (current != null)
						{
							Console.WriteLine(current.Data);
							current = current.Next;
						}
					}
				}
            }
		}

		public void AddPoint(T data)
		{
			int index = GetIndex(data);

			if (table[index] == null)
			{
				table[index] = new Point<T>(data);
				table[index].Data = data;
			}
			else
			{
				Point<T>? current = table[index];

				while (current.Next != null)
				{
					if (current.Equals(data))
						return;
					current = current.Next;
				}
				current.Next = new Point<T>(data);
				current.Next.Prev = current;
			}
		}

		public bool Contains(T data)
		{
			int index = GetIndex(data);
			if (table == null)
				throw new Exception("empty table");
			if (table[index] == null)
				return false;
			if (table[index].Data.Equals(data))
				return true;
			else
			{
				Point<T>? current = table[index];
				while (current != null)
				{
					if (current.Data.Equals(data))
						return true;
					current = current.Next;
				}
			}
			return false;
		}

		[ExcludeFromCodeCoverage]
		public bool RemoveData(T data)
		{
			Point<T>? current;
			int index = GetIndex(data);
			if (table[index] == null)
				return false;
			if (table[index].Data.Equals(data))
			{
				if (table[index].Next == null)
					table[index] = null;
				else
				{
                    table[index] = table[index].Next;
					table[index].Prev = null;
                }
				return true;
			}
			else
			{
				current = table[index];
				while (current != null)
				{
					if (current.Data.Equals(data))
					{
						Point<T>? prev = current.Prev;
						Point<T>? next = current.Next;
						prev.Next = next;
						current.Prev = null;
						if (next != null)
							next.Prev = prev;
						return true;
					}
					current = current.Next;
				}
			}
			return false;
		}

		public int GetIndex(T data)
		{
			return Math.Abs(data.GetHashCode()) % Capacity;
		}

        public bool RemoveByKey(T data)
        {
            int index = GetIndex(data);

            if (table[index] == null)
            {
                return false; // Элемент не найден по данному ключу
            }
            else if (table[index].Data.Equals(data))
            {
                // Элемент найден в начале цепочки
                table[index] = table[index].Next;
                return true;
            }
            else
            {
                // Элемент найден в середине или в конце цепочки
                Point<T>? current = table[index];
                while (current.Next != null)
                {
                    if (current.Next.Data.Equals(data))
                    {
                        current.Next = current.Next.Next; // Удаление элемента из цепочки
                        return true;
                    }
                    current = current.Next;
                }
                return false; // Элемент не найден по данному ключу
            }
        }

        public bool ContainsKey(T data)
        {
            int index = GetIndex(data);

            if (table[index] == null)
            {
                return false; // Элемент не найден по данному ключу
            }
            else
            {
                // Проверяем цепочку на наличие элемента с данными
                Point<T>? current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        return true; // Элемент найден
                    }
                    current = current.Next;
                }
                return false; // Элемент не найден по данному ключу
            }
        }
    }
}

