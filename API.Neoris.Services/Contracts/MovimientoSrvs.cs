using API.Neoris.Infraestructure.NeorisContext;
using API.Neoris.Models.Globals;
using API.Neoris.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Neoris.Services.Contracts
{
    public class MovimientoSrvs: IMovimientoSrvs
    {
        protected NeorisContext Context { get; set; }
        public MovimientoSrvs(NeorisContext context)
        {
            Context = context;
        }
        public List<Movimiento> CrearMovimientos(List<Movimiento> movimientos)
        {
            try
            {
                List<Movimiento> result = null;

                if (movimientos != null) result = new List<Movimiento>();


                foreach (var movimiento in movimientos)
                {
                    var cuentasData = Context.Cuenta.ToList();
                    if (!cuentasData.Exists(a => a.NumeroCuenta == movimiento.NumeroCuenta))
                    {
                        var cuenta = cuentasData.Where(a => a.NumeroCuenta == movimiento.NumeroCuenta).FirstOrDefault();
                        if (movimiento.TipoMovimiento.Equals(TipoCuentaEnum.Debito))
                        {
                            movimiento.Saldo = cuenta.SaldoInicial - (double)movimiento.Valor;
                        }
                        if (movimiento.TipoMovimiento.Equals(TipoCuentaEnum.Credito))
                        {
                            movimiento.Saldo = cuenta.SaldoInicial + (double)movimiento.Valor;
                        }
                        movimiento.Fecha = DateTime.Now;
                        movimiento.IdMovimiento = Guid.NewGuid().ToString();
                        Context.Movimientos.Add(movimiento);
                        Context.SaveChanges();
                        var movimientoCreado = Context.Movimientos.FirstOrDefault(a => a.NumeroCuenta == movimiento.NumeroCuenta && a.Valor == a.Valor);
                        
                        result.Add(movimiento);
                    }
                }


                return result;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public Movimiento CrearMovimiento(Movimiento movimiento)
        {
            try
            {
                var cuentasData = Context.Cuenta.ToList();
                if (!cuentasData.Exists(a => a.NumeroCuenta == movimiento.NumeroCuenta))
                {
                    var cuenta = cuentasData.Where(a => a.NumeroCuenta == movimiento.NumeroCuenta).FirstOrDefault();
                    if (movimiento.TipoMovimiento.Equals(TipoCuentaEnum.Debito)) 
                    {
                        movimiento.Saldo = cuenta.SaldoInicial - (double)movimiento.Valor;
                    }
                    if (movimiento.TipoMovimiento.Equals(TipoCuentaEnum.Credito))
                    {
                        movimiento.Saldo = cuenta.SaldoInicial + (double)movimiento.Valor;
                    }
                    movimiento.Fecha = DateTime.Now;
                    movimiento.IdMovimiento = Guid.NewGuid().ToString();
                    Context.Movimientos.Add(movimiento);
                    Context.SaveChanges();
                    var movimientoCreado = Context.Movimientos.FirstOrDefault(a => a.NumeroCuenta == movimiento.NumeroCuenta && a.Valor == a.Valor);
                     return movimientoCreado;
                }


                return null;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public dynamic ListadoMovimientosByCliente(int id)
        {
            try
            {
                var result = (from Movimiento in Context.Movimientos
                              join cuenta in Context.Cuenta on Movimiento.NumeroCuenta equals cuenta.NumeroCuenta
                              join cliente in Context.Personas on cuenta.IdCliente equals cliente.PersonaId
                              orderby Movimiento.Fecha where cliente.PersonaId == id
                              select new
                              {
                                  Fecha = Movimiento.Fecha,
                                  Cliente = cliente.Nombre,
                                  Tipo = Context.TiposCuentas.Where(a => a.IdTipoCuenta == cuenta.TipoCuenta).FirstOrDefault().Cuenta,
                                  SaldoInicial = cuenta.SaldoInicial,
                                  Estado = cuenta.Estado,
                                  Movimiento = Movimiento.Valor,
                                  SaldoDisponible = Movimiento.Saldo

                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
