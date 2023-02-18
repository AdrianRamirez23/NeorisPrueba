using API.Neoris.Infraestructure.NeorisContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Neoris.Application.Interfaces
{
    public interface IUsuarioApp
    {
        Persona UsuarioById(string id);
        List<Persona> ListarUsuarios();
        Persona CrearUsuario(Persona persona);
        List<Persona> CrearListaUsuario(List<Persona> personas);
        Persona EditarUsuario(Persona persona);
    }
}
