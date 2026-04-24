using System.ComponentModel.DataAnnotations;

namespace WebUI.Models;

public class CalculateRequestDto
{
    [Required(ErrorMessage = "Las ventas totales son obligatorias.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Las ventas deben ser mayores a cero.")]
    public decimal VentasTotales { get; set; }

    [Required(ErrorMessage = "Los descuentos son obligatorios.")]
    [Range(0, double.MaxValue, ErrorMessage = "Los descuentos no pueden tener un valor negativo.")]
    public decimal Descuentos { get; set; }

    [Required(ErrorMessage = "El código de país es obligatorio.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "El código de país debe tener exactamente 2 letras.")]
    public string CodigoPais { get; set; } = string.Empty;
}