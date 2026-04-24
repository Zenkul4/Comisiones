using Comisiones.Domain.Interfaces;

namespace Infrastructure.Strategies;

public class IndiaCommissionStrategy : ICommissionStrategy
{
    public decimal CalcularComision(decimal ventasTotales, decimal descuentos)
    {
        return (ventasTotales - descuentos) * 0.10m; 
    }
}