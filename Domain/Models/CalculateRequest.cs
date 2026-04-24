namespace Comisiones.Domain.Models;

public record CalculateRequest(
    decimal VentasTotales,
    decimal Descuentos,
    string CodigoPais
);