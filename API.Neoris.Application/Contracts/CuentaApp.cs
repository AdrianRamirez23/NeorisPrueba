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
    public class CuentaApp: ICuentaApp
    {
        private readonly ICuentaSrvs _cuenta;
        public CuentaApp(ICuentaSrvs cuenta)
        {
            _cuenta = cuenta;
        }

        public List<Cuentum> CrearCuentas(List<Cuentum> cuentas) 
        {
            return _cuenta.CrearCuentas(cuentas);
        }

        public Cuentum CrearCuenta(Cuentum cuenta)
        {
            return _cuenta.CrearCuenta(cuenta);
        }
    }

}
