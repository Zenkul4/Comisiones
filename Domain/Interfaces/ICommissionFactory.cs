namespace Comisiones.Domain.Interfaces;

public interface ICommissionFactory
{
    ICommissionStrategy ObtenerEstrategia(string codigoPais);
}