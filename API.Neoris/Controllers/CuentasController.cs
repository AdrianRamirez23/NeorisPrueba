using API.Neoris.Application.Interfaces;
using API.Neoris.Infraestructure.NeorisContext;
using API.Neoris.Models.DTO;
using API.Neoris.Models.Globals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Neoris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaApp _cuenta;
        public CuentasController(ICuentaApp cuenta) 
        {
            _cuenta = cuenta;
        }

        /// <summary>
        /// Crea una lista de cuentas para clientes existentes
        /// </summary>
        /// <param name="cuentas"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearCuentas")]
        public async Task<IActionResult> CrearCuentas(List<Cuentum> cuentas) 
        {
            if(ModelState.IsValid) 
            {
                var result = _cuenta.CrearCuentas(cuentas);
                if (result != null)
                {
                    var response = new ResultDto
                    {
                        Estado = true,
                        Mensaje = Constants.ListaCuentasCreada,
                        Result = result
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(Constants.ListaCuentasNoCreada);
                }
            }
            else
            {
                return BadRequest(Constants.BadRequestMessage);
            }
        }


        /// <summary>
        /// Crea una cuenta para un cliente existente
        /// </summary>
        /// <param name="cuenta"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CrearCuenta")]
        public async Task<IActionResult> CrearCuenta(Cuentum cuenta)
        {
            if (ModelState.IsValid)
            {
                var result = _cuenta.CrearCuenta(cuenta);
                if (result != null)
                {
                    var response = new ResultDto
                    {
                        Estado = true,
                        Mensaje = Constants.CuentaCreada,
                        Result = result
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(Constants.CuentaNoCreada);
                }
            }
            else
            {
                return BadRequest(Constants.BadRequestMessage);
            }
        }

    }
}
