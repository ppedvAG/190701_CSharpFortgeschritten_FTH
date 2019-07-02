using ppedv.SOLID_Taschenrechner.Domain;
using ppedv.SOLID_Taschenrechner.Domain.Interfaces;
using System;

namespace ppedv.SOLID_Taschenrechner.Logik
{
    public class SimplerRechner : IRechner
    {
        public int Berechne(Formel formel)
        {
            if (formel.Rechenoperator == "+")
                return formel.Operand1 + formel.Operand2;
            else if (formel.Rechenoperator == "-")
                return formel.Operand1 - formel.Operand2;
            else
                throw new InvalidOperationException("Der Rechenoperator ist unbekannt");
        }
    }
}
