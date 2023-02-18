using API.Neoris.Application.Interfaces;
using API.Neoris.Controllers;
using API.Neoris.Infraestructure.NeorisContext;
using Moq;

namespace API.Neoris.Test
{
    public class MovimientoTest
    {
        [Fact]
        public void MovimientoCrear_EsValido()
        {
            Movimiento movimiento = new Movimiento();

            var mockMovimioentopApp = new Mock<IMovimientoApp>();
            mockMovimioentopApp.Setup(u => u.CrearMovimiento(movimiento)).Returns(movimiento);
            mockMovimioentopApp.SetupGet(x => x.CrearMovimiento(movimiento)).Returns(new Movimiento
            {
               IdMovimiento = Guid.NewGuid().ToString(),
               Fecha = DateTime.Now,
               Valor = 50000,
               Saldo = 150000,
               Descripcion = "Nuevo movimiento",
               TipoMovimiento = 2,
               NumeroCuenta = Guid.NewGuid().ToString()
            });

            MovimientosController controller = new MovimientosController(mockMovimioentopApp.Object);

            var resultado = controller.CrearMovimiento(movimiento);

            Assert.NotNull(resultado);
        }

        [Fact]
        public void MovimientoCrear_NoEsValido()
        {
            Movimiento movimiento = new Movimiento();
            Movimiento movimientoResultado = null;

            var mockMovimioentopApp = new Mock<IMovimientoApp>();
            mockMovimioentopApp.Setup(u => u.CrearMovimiento(movimiento)).Returns(movimiento);
            mockMovimioentopApp.SetupGet(x => x.CrearMovimiento(movimiento)).Returns(movimientoResultado);

            MovimientosController controller = new MovimientosController(mockMovimioentopApp.Object);

            var resultado = controller.CrearMovimiento(movimiento);

            Assert.Null(resultado);
        }
    }
}
