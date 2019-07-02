using ppedv.SOLID_Taschenrechner.Domain;
using ppedv.SOLID_Taschenrechner.Domain.Interfaces;
using System;

namespace ppedv.SOLID_Taschenrechner.Logik
{
    public class StringSplitParser : IParser
    {
        public Formel Parse(string input)
        {
            string[] teile = input.Split();
            int zahl1 = Convert.ToInt32(teile[0]);
            string op = teile[1];
            int zahl2 = Convert.ToInt32(teile[2]);

            return new Formel(zahl1, zahl2, op);
        }
    }
}
