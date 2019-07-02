namespace ppedv.SOLID_Taschenrechner.Domain.Interfaces
{
    public interface IParser
    {
        Formel Parse(string input);
    }
}
