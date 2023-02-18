using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Neoris.Infraestructure.NeorisContext;

public partial class Cliente
{
    [Key]
    [JsonPropertyName("clienteId")]
    public int ClienteId { get; set; }

    [Required]
    [JsonPropertyName("contrasena")]
    [Range(0000, 9999, ErrorMessage = "La contraseña deben ser 4 digitos entre 0000 y 9999")]
    public int Contrasena { get; set; }

    [Required]
    [JsonPropertyName("estado")]
    public bool Estado { get; set; }

    [JsonPropertyName("personaCliente")]
    public virtual Persona? ClienteNavigation { get; set; }
    [JsonPropertyName("cuentasCliente")]
    public virtual ICollection<Cuentum> Cuenta { get; } = new List<Cuentum>();
}
