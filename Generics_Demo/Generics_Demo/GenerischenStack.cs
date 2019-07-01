using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class GenerischerStack<T>
    {
        public GenerischerStack() : this(4) { }
        public GenerischerStack(int capacity)
        {
            data = new T[capacity];
            position = 0;
        }

        private int position;
        private T[] data;


        public void Push(T item)
        {
            if (data.Length == position)
            {
                T[] newData = new T[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }

            data[position++] = item;
            //position++;
        }

        public T Pop()
        {
            if (position == 0)
                throw new InvalidOperationException("Stack ist leer");

            // position--;
            T result = data[--position];
            data[position] = default; // referenz löschen
            return result;
        }

        // Push -> speichern
        // Pop -> herausnehmen

        // optional: Find
    }
}
