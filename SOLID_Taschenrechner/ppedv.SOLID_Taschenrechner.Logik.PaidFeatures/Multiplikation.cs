using ppedv.SOLID_Taschenrechner.Domain;
using ppedv.SOLID_Taschenrechner.Domain.Interfaces;
using System.Linq;

namespace ppedv.SOLID_Taschenrechner.Logik.PaidFeatures
{
    public class Multiplikation : IRechenart
    {
        public string Rechenoperator => "*";

        public int Berechne(params int[] operanden) => operanden.Aggregate((a, b) => a * b);
    }
}
