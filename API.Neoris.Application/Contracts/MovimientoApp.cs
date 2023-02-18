using API.Neoris.Application.Interfaces;
using API.Neoris.Infraestructure.NeorisContext;
using API.Neoris.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Neoris.Application.Contracts
{
    public class MovimientoApp: IMovimientoApp
    {
        private readonly IMovimientoSrvs _movimientoSrvs;
        public MovimientoApp(IMovimientoSrvs movimiento) 
        {
            _movimientoSrvs = movimiento;
        }
        public List<Movimiento> CrearMovimientos(List<Movimiento> movimientos) 
        {
            return _movimientoSrvs.CrearMovimientos(movimientos);
        }

        public Movimiento CrearMovimiento(Movimiento movimiento)
        {
            return _movimientoSrvs.CrearMovimiento(movimiento);
        }
        public dynamic ListadoMovimientosByCliente(int id) 
        {
            return _movimientoSrvs.ListadoMovimientosByCliente(id);
        }
    }
}
