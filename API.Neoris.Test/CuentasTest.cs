using API.Neoris.Application.Interfaces;
using API.Neoris.Controllers;
using API.Neoris.Infraestructure.NeorisContext;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Neoris.Test
{
    public class CuentasTest
    {
        [Fact]
        public void CuentasCrear_EsValido()
        {
            Cuentum cuenta = new Cuentum();

            var mockCuentaApp = new Mock<ICuentaApp>();
            mockCuentaApp.Setup(u => u.CrearCuenta(cuenta)).Returns(cuenta);
            mockCuentaApp.SetupGet(x => x.CrearCuenta( cuenta)).Returns(new Cuentum
            {
               IdCliente = 1,
               NumeroCuenta = Guid.NewGuid().ToString(),
               TipoCuenta = 1,
               SaldoInicial = 10000,
               Estado = true
            });

            CuentasController controller = new CuentasController(mockCuentaApp.Object);

            var resultado = controller.CrearCuenta(cuenta);

            Assert.NotNull(resultado);
        }

        [Fact]
        public void CuentasCrear_NoEsValido()
        {
            Cuentum cuenta = new Cuentum();
            Cuentum cuentaResult = null;

            var mockCuentaApp = new Mock<ICuentaApp>();
            mockCuentaApp.Setup(u => u.CrearCuenta(cuenta)).Returns(cuenta);
            mockCuentaApp.SetupGet(x => x.CrearCuenta(cuenta)).Returns(cuentaResult);

            CuentasController controller = new CuentasController(mockCuentaApp.Object);

            var resultado = controller.CrearCuenta(cuenta);

            Assert.Null(resultado);
        }
    }
}
