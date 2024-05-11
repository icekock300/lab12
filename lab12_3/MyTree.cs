using System;
using LibraryLab10;
namespace lab12_3
{
	public class MyTree<T> where T : IInit, IComparable, new()
	{
        public Point<T>? root = null;

        int count = 0;

        public int Count => count;

        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }

        public void ShowTree()
        {
            Show(root);
        }

        //ИСД
        public Point<T>? MakeTree(int length, Point<T>? point)
        {
            T data = new T();
            data.RandomInit();
            Point<T> newItem = new Point<T>(data);

            if (length == 0)
            {
                return null;
            }

            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Right);
            return newItem;
        }

        void Show(Point<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5); // Рекурсивно вызываем сначала правое поддерево
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(point.Data);
                Show(point.Right, spaces + 5); // Затем рекурсивно вызываем левое поддерево
            }
        }

        //Дерево поиска
        public void AddPoint(T data)
        { 
            Point<T>? point = root;
            Point<T>? current = null;
            bool isExist = false;

            while (point != null && !isExist)
            {
                current = point;
                if (point.Data.CompareTo(data) == 0) { isExist = true; }
                else
                {
                    if (point.Data.CompareTo(data) < 0) { point = point.Left; }
                    else { point = point.Right; }
                }
            }

            if (isExist) { return; }

            Point<T> newPoint = new Point<T>(data);
            if (current.Data.CompareTo(data) < 0)
                current.Left = newPoint;
            else
                current.Right = newPoint;
            count++;
        }

        public void TransformToArray(Point<T>? point, T[] array, ref int current)
        {
            if (point != null)
            {
                TransformToArray(point.Left, array, ref current);
                array[current] = point.Data;
                current++;
                TransformToArray(point.Right, array, ref current);
            }
        }

        public void TransformToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);

            root = new Point<T>(array[0]);
            count = 0;
            for (int i = 1; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
        }

        public T FindMin()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Tree is empty");
            }

            Point<T>? current = root;
            while (current.Right != null)
            {
                current = current.Right;
            }

            return current.Data;
        }

        public void RemoveTree()
        {
            root = null;
            count = 0;
        }

        public void Run(Point<T>? point)
        {
            if (point != null)
            {
                Run(point.Left);
                Run(point.Right);
            }
        }

        public void RemoveByKey(Point<T>? musForRemove)
        {
            //Point<T> musForRemove = new Point<T>(data);

            if (musForRemove == root)
            {

            }

            if (root != null)
            {
                Run(root.Left);
                Run(root.Right);
            }
        }
        
    }
}

