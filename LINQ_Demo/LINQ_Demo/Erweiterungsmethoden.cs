using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    // Anforderung 1: static class
    internal static class Erweiterungsmethoden
    {
        // Anforderung 2: this - Schlüsselwort
        public static string Umdrehen(this string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }
            return sb.ToString();
        }

        public static int Verdoppeln(this int zahl)
        {
            return zahl * 2;
        }
    }
}
