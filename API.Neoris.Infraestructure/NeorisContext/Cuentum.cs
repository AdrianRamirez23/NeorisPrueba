using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Neoris.Infraestructure.NeorisContext;

public partial class Cuentum
{
    [Required]
    [JsonPropertyName("clienteId")]
    public int IdCliente { get; set; }

    [Key]
    [JsonPropertyName("numeroCuenta")]
    public string NumeroCuenta { get; set; }

    [Required]
    [JsonPropertyName("tipoCuenta")]
    [Range(1, 2, ErrorMessage = "Ingrese 1 = Cuenta Ahorros o 2 = Cuenta Corriente")]
    public int TipoCuenta { get; set; }

    [Required]
    [JsonPropertyName("saldoInicial")]
    [Range(100000, 10000000000, ErrorMessage = "El rango para crear una cuenta es de $ 100.000 hasta $ 10.000.000.000")]
    public double SaldoInicial { get; set; }
    [Required]
    [JsonPropertyName("estado")]
    public bool Estado { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } 

    public virtual ICollection<Movimiento> Movimientos { get; } = new List<Movimiento>();

    public virtual TiposCuenta TipoCuentaNavigation { get; set; }
}
