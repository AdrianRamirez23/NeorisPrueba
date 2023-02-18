using System;
using System.Collections.Generic;

namespace API.Neoris.Infraestructure.NeorisContext;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string Genero1 { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
