using ppedv.SOLID_Taschenrechner.Domain;
using ppedv.SOLID_Taschenrechner.Domain.Interfaces;
using System;
using System.Linq;

namespace ppedv.SOLID_Taschenrechner.Logik
{
    public class ModulRechner : IRechner
    {
        public ModulRechner(params IRechenart[] rechenarten)
        {
            this.rechenarten = rechenarten;
        }
        private readonly IRechenart[] rechenarten;

        public int Berechne(Formel formel)
        {
            var rechenart = rechenarten.FirstOrDefault(x => x.Rechenoperator == formel.Rechenoperator);
            if (rechenart != null)
                return rechenart.Berechne(formel.Operand1, formel.Operand2);
            else
                throw new InvalidOperationException($"Operator '{formel.Rechenoperator}'ist leider unbekannt");
        }
    }
}
