using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.SOLID_Taschenrechner.Domain
{
    public struct Formel
    {
        public Formel(int operand1, int operand2, string rechenoperator)
        {
            Operand1 = operand1;
            Operand2 = operand2;
            Rechenoperator = rechenoperator;
        }

        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Rechenoperator { get; set; }
    }
}
