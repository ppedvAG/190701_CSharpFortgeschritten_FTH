using ppedv.SOLID_Taschenrechner.Domain;
using ppedv.SOLID_Taschenrechner.Domain.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace ppedv.SOLID_Taschenrechner.Logik
{
    public class RegexParser : IParser
    {
        public Formel Parse(string input)
        {
            Regex r = new Regex(@"(\d+)\s*([+\-*/])\s*(\d+)", RegexOptions.Compiled);
            var result = r.Match(input);

            if (result.Success)
            {
                Formel formel = new Formel();

                formel.Operand1 = Convert.ToInt32(result.Groups[1].Value);
                formel.Rechenoperator = result.Groups[2].Value;
                formel.Operand2 = Convert.ToInt32(result.Groups[3].Value);

                return formel;
            }
            else
                throw new FormatException("Ungültiges Formelformat");
        }
    }
}
