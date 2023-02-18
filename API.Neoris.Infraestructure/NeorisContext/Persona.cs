using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Neoris.Infraestructure.NeorisContext;

public partial class Persona
{
    [Key]
    [JsonPropertyName("personaId")]
    public int PersonaId { get; set; }

    [Required]
    [JsonPropertyName("identificacion")]
    [MaxLength(10, ErrorMessage = "El tamaño máximo en caracteres para el campo Identificación es de 10")]
    [MinLength(7, ErrorMessage = "El tamaño mínimo en caracteres para el campo Identificación es de 7")]
    public string Identificacion { get; set; }

    [Required]
    [JsonPropertyName("nombre")]
    [MaxLength(50, ErrorMessage = "El tamaño máximo en caracteres para el campo Identificación es de 50")]
    [MinLength(3, ErrorMessage = "El tamaño mínimo en caracteres para el campo Nombre es de 3")]
    public string Nombre { get; set; }

    [Required]
    [JsonPropertyName("genero")]
    [Range(1, 2, ErrorMessage = "Ingrese 1 = Masculino o 2 = Femenino")]
    public int Genero { get; set; }

    [Required]
    [JsonPropertyName("edad")]
    [Range(18, 99, ErrorMessage = "la edad permitida es desde la mayoria de edad (18 años) hasta los 99 años")]
    public int Edad { get; set; }

    [Required]
    [JsonPropertyName("direccion")]
    [MaxLength(100, ErrorMessage = "El tamaño máximo en caracteres para el campo Dirección es de 100")]
    [MinLength(15, ErrorMessage = "El tamaño mínimo en caracteres para el campo Dirección es de 15")]
    public string Direccion { get; set; }

    [Required]
    [JsonPropertyName("telefono")]
    [MaxLength(10, ErrorMessage = "El tamaño máximo en caracteres para el campo Teléfono es de 10")]
    [MinLength(9, ErrorMessage = "El tamaño mínimo en caracteres para el campo Teléfono es de 9")]
    public string Telefono { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Genero? GeneroNavigation { get; set; }
}
