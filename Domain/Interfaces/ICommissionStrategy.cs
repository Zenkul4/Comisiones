    namespace Comisiones.Domain.Interfaces;

public interface ICommissionStrategy
{
    decimal CalcularComision(decimal ventasTotales, decimal descuentos);
}