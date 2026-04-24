using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using Comisiones.Domain.Interfaces;
using Infrastructure.Strategies;

namespace Comisiones.Infrastructure.Factories;

public class CommissionFactory : ICommissionFactory
{
    private readonly FrozenDictionary<string, ICommissionStrategy> _estrategias;

    public CommissionFactory()
    {
        var diccionario = new Dictionary<string, ICommissionStrategy>(StringComparer.OrdinalIgnoreCase)
        {
            { "IN", new IndiaCommissionStrategy() },
            { "US", new UsCommissionStrategy() },
            { "UK", new UkCommissionStrategy() }
        };

        _estrategias = diccionario.ToFrozenDictionary();
    }

    public ICommissionStrategy ObtenerEstrategia(string codigoPais)
    {
        if (_estrategias.TryGetValue(codigoPais, out var estrategia))
        {
            return estrategia;
        }
        throw new ArgumentException($"La estrategia para el país '{codigoPais}' no está soportada.");
    }
}