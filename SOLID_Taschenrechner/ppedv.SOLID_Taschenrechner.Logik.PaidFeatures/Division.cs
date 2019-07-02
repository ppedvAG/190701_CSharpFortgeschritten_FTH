using ppedv.SOLID_Taschenrechner.Domain.Interfaces;
using System;
using System.Linq;

namespace ppedv.SOLID_Taschenrechner.Logik.PaidFeatures
{
    public class Division : IRechenart
    {
        public string Rechenoperator => "/";

        public int Berechne(params int[] operanden)
        {
            if (operanden.Skip(1).Any(x => x == 0))
                throw new DivideByZeroException();

            return operanden.Aggregate((a, b) => a / b);
        }
    }
}
