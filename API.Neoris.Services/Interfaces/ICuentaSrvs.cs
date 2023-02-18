using API.Neoris.Infraestructure.NeorisContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Neoris.Services.Interfaces
{
    public interface ICuentaSrvs
    {
        List<Cuentum> CrearCuentas(List<Cuentum> cuentas);

        Cuentum CrearCuenta(Cuentum cuenta);
    }
}
