using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class IntegerStack
    {
        public IntegerStack() : this(4) { }
        public IntegerStack(int capacity)
        {
            data = new int[capacity];
            position = 0;
        }

        private int position;
        private int[] data;


        public void Push(int item)
        {
            if (data.Length == position)
            {
                int[] newData = new int[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }

            data[position++] = item;
            //position++;
        }

        public int Pop()
        {
            if (position == 0)
                throw new InvalidOperationException("Stack ist leer");

            // position--;
            int result = data[--position];
            data[position] = default; // referenz löschen
            return result;
        }

        // Push -> speichern
        // Pop -> herausnehmen

        // optional: Find
    }
}
