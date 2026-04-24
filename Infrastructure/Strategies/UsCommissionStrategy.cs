using Comisiones.Domain.Interfaces;

namespace Infrastructure.Strategies;

public class UsCommissionStrategy : ICommissionStrategy
{
    public decimal CalcularComision(decimal ventasTotales, decimal descuentos)
    {
        return (ventasTotales - descuentos) * 0.15m;
    }
}