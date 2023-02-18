using API.Neoris.Application.Interfaces;
using API.Neoris.Infraestructure.NeorisContext;
using API.Neoris.Models.DTO;
using API.Neoris.Models.Globals;

using Microsoft.AspNetCore.Mvc;

namespace API.Neoris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioApp _usuarioApp;
        public UsuariosController(IUsuarioApp usuarioApp) 
        {
            _usuarioApp = usuarioApp;
        }

        /// <summary>
        /// Lista las personas creadas en bases de datos 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ListarUsuarios")]
        public async Task<IActionResult> ListarUsuarios() 
        {
            try
            {
                var result = _usuarioApp.ListarUsuarios();
                if (result != null)
                {
                    var response = new ResultDto
                    {
                        Estado = true,
                        Mensaje = Constants.UsuariosListados,
                        Result = result
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(Constants.UsuariosNoListados);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(Constants.BadRequestMessage+": "+ex.Message );
            }
        }

        /// <summary>
        /// Lista una persona creada en bases de datos 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("UsuarioById/{id}")]
        public async Task<IActionResult> UsuarioById(string id)
        {
            try
            {
                var result = _usuarioApp.UsuarioById(id);
                if (result != null)
                {
                    var response = new ResultDto
                    {
                        Estado = true,
                        Mensaje = Constants.UsuarioListado,
                        Result = result
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(Constants.UsuarioNoListado);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(Constants.BadRequestMessage + ": " + ex.Message);
            }
        }

        /// <summary>
        /// Crea un nueva persona en la base de datos de la entidad
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<IActionResult> CrearUsuarios(Persona persona) 
        {
            if (ModelState.IsValid)
            {
                var result = _usuarioApp.CrearUsuario(persona);
                if(result != null) 
                {
                    var response = new ResultDto
                    {
                        Estado = true,
                        Mensaje = Constants.UsuarioCreado,
                        Result = result
                    };
                    return Ok(response);
                }
                else 
                {
                    return BadRequest(Constants.UsuarioNoCreado);
                }
               
            }
            else 
            {
                return BadRequest(Constants.BadRequestMessage);
            }
        }

        /// <summary>
        /// Crea una lista de personas en la base de datos de la entidad
        /// </summary>
        /// <param name="personas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearListaUsuario")]
        public async Task<IActionResult> CrearListaUsuario(List<Persona> personas)
        {
            if (ModelState.IsValid)
            {
                var result = _usuarioApp.CrearListaUsuario(personas);
                if (result != null)
                {
                    var response = new ResultDto
                    {
                        Estado = true,
                        Mensaje = Constants.ListaUsuarioCreado,
                        Result = result
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(Constants.ListaUsuarioNoCreado);
                }

            }
            else
            {
                return BadRequest(Constants.BadRequestMessage);
            }
        }

        /// <summary>
        /// Edita un nueva persona en la base de datos de la entidad
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EditarUsuario")]
        public async Task<IActionResult> EditarUsuario(Persona persona)
        {
            if (ModelState.IsValid)
            {
                var result = _usuarioApp.EditarUsuario(persona);
                if (result != null)
                {
                    var response = new ResultDto
                    {
                        Estado = true,
                        Mensaje = Constants.UsuarioEditado,
                        Result = result
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(Constants.UsuarioNoEditado);
                }

            }
            else
            {
                return BadRequest(Constants.BadRequestMessage);
            }
        }
    }
}
