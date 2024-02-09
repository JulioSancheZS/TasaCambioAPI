using System;
using System.Collections.Generic;

namespace TasaCambioAPI.Models;

public partial class TasaCambio
{
    public Guid IdTasaCambio { get; set; }

    public DateOnly? Fecha { get; set; }

    public double? TipoCambio { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
