using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class CustomDictionary<TKey, TValue> where TKey : struct
                                        where TValue : IDisposable
    {
        public CustomDictionary() : this(4,true) { }
        public CustomDictionary(int capacity, bool throwExceptionIfKeyExists = true)
        {
            this.throwExceptionIfKeyExists = throwExceptionIfKeyExists;
            keys = new TKey[capacity];
            values = new TValue[capacity];
            position = 0;
        }

        private readonly bool throwExceptionIfKeyExists;
        private TKey[] keys;
        private TValue[] values;
        private int position;


        public bool Add(TKey Key, TValue Value)
        {
            // Key darf nicht doppelt vorkommen !
            if (keys.Contains(Key))
            {
                if (throwExceptionIfKeyExists)
                    throw new ArgumentException("Key bereits vorhanden !");
                else
                    return false; // hat nicht funtkioniert
            }

            if (position == keys.Length)
            {
                TKey[] newKeys = new TKey[keys.Length * 2];
                TValue[] newValues = new TValue[values.Length * 2];

                Array.Copy(keys, newKeys, keys.Length);
                Array.Copy(values, newValues, values.Length);

                keys = newKeys;
                values = newValues;
            }

            keys[position] = Key;
            values[position] = Value;

            position++;
            return true; // hat funtkioniert
        }

        public TValue this[TKey key]
        {
            get
            {
                if (! keys.Contains(key))
                    throw new KeyNotFoundException("Key ist leider nicht vorhanden !");

                int keyPosition = Array.IndexOf(keys, key);
                return values[keyPosition];
            }
            set
            {
                if (! keys.Contains(key))
                    throw new KeyNotFoundException("Der Key ist leider nicht vorhanden");
                else
                {
                    int keyPosition = Array.IndexOf(keys, key);
                    values[keyPosition] = value;
                }
            }
        }

        // indexer

    }
}
