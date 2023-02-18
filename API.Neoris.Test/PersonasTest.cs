using API.Neoris.Application.Interfaces;
using API.Neoris.Controllers;
using API.Neoris.Infraestructure.NeorisContext;
using Moq;

namespace API.Neoris.Test
{
    public class PersonasTest
    {
        [Fact]
        public void CuentasCrear_EsValido()
        {
            Persona persona = new Persona();

            var mockPersonaApp = new Mock<IUsuarioApp>();
            mockPersonaApp.Setup(u => u.CrearUsuario(persona)).Returns(persona);
            mockPersonaApp.SetupGet(x => x.CrearUsuario(persona)).Returns( new Persona 
            { PersonaId= 1 , 
              Nombre = "Nombre Prueba",
              Identificacion = "111111111",
              Genero = 1,
              Edad = 18,
              Direccion = "Dirección Prueba",
              Telefono = "000000000"
            });

            UsuariosController controller = new UsuariosController(mockPersonaApp.Object);

            var resultado = controller.CrearUsuarios(persona);

            Assert.NotNull(resultado);
        }

        [Fact]
        public void CuentasCrear_NoEsValido()
        {
            Persona persona = new Persona();
            Persona personaResult = null;

            var mockPersonaApp = new Mock<IUsuarioApp>();
            mockPersonaApp.Setup(u => u.CrearUsuario(persona)).Returns(persona);
            mockPersonaApp.SetupGet(x => x.CrearUsuario(persona)).Returns(personaResult);

            UsuariosController controller = new UsuariosController(mockPersonaApp.Object);

            var resultado = controller.CrearUsuarios(persona);

            Assert.Null(resultado);
        }
    }
}