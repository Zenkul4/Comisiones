using Comisiones.Domain.Interfaces;
using Comisiones.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommissionController : ControllerBase
{
    private readonly ICommissionFactory _factory;

    public CommissionController(ICommissionFactory factory)
    {
        _factory = factory;
    }

    [HttpPost("calcular")]
    public IActionResult Calcular([FromBody] CalculateRequest request)
    {
        try
        {
            var estrategia = _factory.ObtenerEstrategia(request.CodigoPais);

            var comision = estrategia.CalcularComision(request.VentasTotales, request.Descuentos);

            return Ok(new { comisionCalculada = comision });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}