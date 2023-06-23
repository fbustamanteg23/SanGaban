using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanGaban_WebAPI.Datos;
using SanGaban_WebAPI.Modelos;
using SanGaban_WebAPI.Modelos.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SanGaban_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private readonly ApplicationDbContext _db;

        public RolController(ILogger<RolController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        //Listar Todos Los Roles
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<RolDto>> GetRols()
        {

            {
                _logger.LogInformation("Listar los Roles");
                return Ok(_db.Rol.ToList());


            };
        }


        //Listar Todos Los Roles pero bajo un id
        [HttpGet  ("id:int",Name ="GetRol")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<RolDto>> GetRols(int id)
        {
            if(id==0)
            {
                _logger.LogError("Error al traer Rol con Id " + id);
                return BadRequest();
            }

            var rol = _db.Rol.FirstOrDefault(v => v.IdRol == id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
            
        }

    }
}
