using System.Linq;
using ppedv.SOLID_Taschenrechner.Domain.Interfaces;

namespace ppedv.SOLID_Taschenrechner.Logik.FreeFeatures
{
    public class Addition : IRechenart
    {
        public string Rechenoperator => "+";

        public int Berechne(params int[] operanden) => operanden.Sum();
    }
}
