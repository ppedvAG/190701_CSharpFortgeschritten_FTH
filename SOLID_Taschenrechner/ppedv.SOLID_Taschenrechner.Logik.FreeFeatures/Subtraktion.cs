using System;
using System.Linq;
using ppedv.SOLID_Taschenrechner.Domain.Interfaces;

namespace ppedv.SOLID_Taschenrechner.Logik.FreeFeatures
{
    public class Subtraktion : IRechenart
    {
        public string Rechenoperator => "-";

        public int Berechne(params int[] operanden) => operanden[0] - operanden.Skip(1).Sum();
    }
}
