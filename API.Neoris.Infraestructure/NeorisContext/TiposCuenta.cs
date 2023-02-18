using System;
using System.Collections.Generic;

namespace API.Neoris.Infraestructure.NeorisContext;

public partial class TiposCuenta
{
    public int IdTipoCuenta { get; set; }

    public string TipoCuenta { get; set; } = null!;

    public virtual ICollection<Cuentum> Cuenta { get; } = new List<Cuentum>();
}
