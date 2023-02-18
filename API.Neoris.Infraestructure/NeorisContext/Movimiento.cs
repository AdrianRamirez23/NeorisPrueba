using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Neoris.Infraestructure.NeorisContext;

public partial class Movimiento
{
    [Key]

    [JsonPropertyName("idMovimiento")]
    public string IdMovimiento { get; set; } = null!;

    
    [JsonPropertyName("fechaMovimiento")]
    [DataType(DataType.DateTime)]
    public DateTime Fecha { get; set; }

    [JsonPropertyName("tipoMovimiento")]
    [Range(1, 2, ErrorMessage = "Ingrese 1 = Débito o 2 = Crédito")]
    public int TipoMovimiento { get; set; }

    [Required]
    [JsonPropertyName("valor")]
    [Range(100000, 10000000000, ErrorMessage = "El rango para crear un movimiento es de $ 100.000 hasta $ 10.000.000.000")]
    public double Valor { get; set; }


    [JsonPropertyName("saldo")]
    public double? Saldo { get; set; }

    [Required]
    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; }

    [Required]
    [JsonPropertyName("numeroCuenta")]
    public string NumeroCuenta { get; set; }

    public virtual Cuentum? NumeroCuentaNavigation { get; set; } 

    public virtual TiposMovimiento? TipoMovimientoNavigation { get; set; }
}
