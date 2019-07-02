namespace ppedv.SOLID_Taschenrechner.Domain.Interfaces
{
    public interface IRechenart
    {
        string Rechenoperator { get; }
        int Berechne(params int[] operanden);
    }
}
