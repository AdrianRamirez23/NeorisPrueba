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
    public class UsuariosApp: IUsuarioApp
    {
        private readonly IUsuarioSrvs _usuariosSrv;
        public UsuariosApp(IUsuarioSrvs usuariosSrv)
        {
            _usuariosSrv = usuariosSrv;
        }

        public Persona UsuarioById(string id)
        {
            return _usuariosSrv.UsuarioById(id);
        }
        public List<Persona> ListarUsuarios() 
        {
            return _usuariosSrv.ListarUsuarios();
        }
        public Persona CrearUsuario(Persona persona) 
        {
            return _usuariosSrv.CrearUsuario(persona);
        }
        public List<Persona> CrearListaUsuario(List<Persona> personas)
        {
            return _usuariosSrv.CrearListaUsuario(personas);
        }
        public Persona EditarUsuario(Persona persona)
        {
            return _usuariosSrv.EditarUsuario(persona);
        }
    }
}
