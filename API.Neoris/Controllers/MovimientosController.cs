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
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoApp _movimiento;

        public MovimientosController(IMovimientoApp movimiento)
        {
            _movimiento = movimiento;
        }

        [HttpPost]
        [Route("CrearMovimientos")]
        public async Task<IActionResult> CrearMovimientos(List<Movimiento> movimientos) 
        {
            if (ModelState.IsValid)
            {
                var result = _movimiento.CrearMovimientos(movimientos);
                if (result != null)
                {
                    var response = new ResultDto
                    {
                        Estado = true,
                        Mensaje = Constants.ListaMovimientoCreado,
                        Result = result
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(Constants.ListaMovimientoNoCreado);
                }
            }
            else
            {
                return BadRequest(Constants.BadRequestMessage);
            }
        }

        [HttpPost]
        [Route("CrearMovimiento")]
        public async Task<IActionResult> CrearMovimiento(Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                var result = _movimiento.CrearMovimiento(movimiento);
                if (result != null)
                {
                    var response = new ResultDto
                    {
                        Estado = true,
                        Mensaje = Constants.MovimientoCreado,
                        Result = result
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(Constants.MovimientoNoCreado);
                }
            }
            else
            {
                return BadRequest(Constants.BadRequestMessage);
            }
        }

        [HttpGet]
        [Route("ListadoMovimientosByCliente/{id}")]
        public async Task<IActionResult> ListadoMovimientosByCliente(int id) 
        {
            if(id >= 0) 
            {
                var result = _movimiento.ListadoMovimientosByCliente(id);
                    if (result != null)
                {
                    var response = new ResultDto
                    {
                        Estado = true,
                        Mensaje = Constants.ListaMovimientos,
                        Result = result
                    };
                    return Ok(response);
                }
                else
                {
                    return BadRequest(Constants.ListaNoMovimientos);
                }
            }
            else 
            {
                return BadRequest(Constants.BadRequestMessage);
            }
        }
    }
}
