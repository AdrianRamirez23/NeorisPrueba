using API.Neoris.Infraestructure.NeorisContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Neoris.Services.Interfaces
{
    public interface IMovimientoSrvs
    {
        List<Movimiento> CrearMovimientos(List<Movimiento> movimientos);
        Movimiento CrearMovimiento(Movimiento movimiento);
        dynamic ListadoMovimientosByCliente(int id);
    }
}
