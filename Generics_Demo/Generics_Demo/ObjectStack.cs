using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class ObjectStack
    {
        public ObjectStack() : this(4){}
        public ObjectStack(int capacity)
        {
            data = new object[capacity];
            position = 0;
        }

        private int position;
        private object[] data;


        public void Push(object item)
        {
            if(data.Length == position)
            {
                object[] newData = new object[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }

            data[position++] = item;
            //position++;
        }

        public object Pop()
        {
            if (position == 0)
                throw new InvalidOperationException("Stack ist leer");

            // position--;
            object result =  data[--position];
            data[position] = null; // referenz löschen
            return result;
        }

        // Push -> speichern
        // Pop -> herausnehmen

        // optional: Find
    }
}
