using System;
using System.Collections.Generic;

namespace API.Neoris.Infraestructure.NeorisContext;

public partial class TiposMovimiento
{
    public int IdTipoMovimiento { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public virtual ICollection<Movimiento> Movimientos { get; } = new List<Movimiento>();
}
