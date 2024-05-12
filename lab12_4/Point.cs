﻿using LibraryLab10;
using System;
namespace lab12_4
{
    public class Point<T>
    {
        public T? Data { get; set; }
        public Point<T>? Next { get; set; }
        public Point<T>? Prev { get; set; }

        public Point()
        {
            this.Data = default(T);
            this.Prev = null;
            this.Next = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Prev = null;
            this.Next = null;
        }

        public override string? ToString()
        {
            return Data == null ? "" : Data.ToString();
        }
    }
}

