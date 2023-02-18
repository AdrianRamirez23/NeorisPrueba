using API.Neoris.Infraestructure.NeorisContext;
using API.Neoris.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Neoris.Services.Contracts
{
    public class CuentaSrvs: ICuentaSrvs
    {
        protected NeorisContext Context { get; set; }
        public CuentaSrvs(NeorisContext context) 
        {
            Context = context;
        }
        public List<Cuentum> CrearCuentas(List<Cuentum> cuentas)
        {
            try
            {
                List<Cuentum> result = null;

                if (cuentas != null) result = new List<Cuentum>();


                foreach (var cuenta in cuentas)
                {
                    var clientesData = Context.Clientes.ToList();
                    if (!clientesData.Exists(a => a.ClienteId == cuenta.IdCliente))
                    {
                        cuenta.NumeroCuenta = Guid.NewGuid().ToString();
                        Context.Cuenta.Add(cuenta);
                        Context.SaveChanges();
                        var cuentaCreada = Context.Cuenta.FirstOrDefault(a => a.IdCliente == cuenta.IdCliente && a.TipoCuenta == cuenta.TipoCuenta);
                        result.Add(cuentaCreada);
                    }
                }


                return result;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public Cuentum CrearCuenta(Cuentum cuenta)
        {
            try
            {

                var clientesData = Context.Clientes.ToList();
                if (!clientesData.Exists(a => a.ClienteId == cuenta.IdCliente))
                {
                    cuenta.NumeroCuenta = Guid.NewGuid().ToString();
                    Context.Cuenta.Add(cuenta);
                    Context.SaveChanges();
                    var cuentaCreada = Context.Cuenta.FirstOrDefault(a => a.IdCliente == cuenta.IdCliente && a.TipoCuenta == cuenta.TipoCuenta);
                    return cuentaCreada;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}
