using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SanGaban_WebAPI.Datos;
using SanGaban_WebAPI.Modelos;
using SanGaban_WebAPI.Modelos.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SanGaban_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private readonly ApplicationDbContext _db;

        public UsuarioController(ILogger<RolController> logger, ApplicationDbContext db)
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
        [HttpGet("id:int", Name = "GetRol")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<RolDto>> GetRols(int id)
        {
            if (id == 0)
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


        //Insertar en la tabla Rol
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RolDto> CrearRol([FromBody] RolDto rolDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (rolDto == null)
            {
                return BadRequest(rolDto);
            }
            if (rolDto.IdRol > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Rol modelo = new()
            {
                IdRol = rolDto.IdRol,
                Nombre = rolDto.Nombre,
                fechaRegistro = rolDto.fechaRegistro
            };
            _db.Rol.Add(modelo);
            _db.SaveChanges();
            return CreatedAtRoute("GetRol", new { id = rolDto.IdRol }, rolDto);
        }

        //eliminar registros en la tabla Rol
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteRol(int id)
        {
            if (id == 0) { return BadRequest(); }
            var rol = _db.Rol.FirstOrDefault(v => v.IdRol == id);
            if (rol == null) { return NotFound(); }
            _db.Rol.Remove(rol);
            _db.SaveChanges();
            return NoContent();

        }
        //Actualizar registros en la tabla Rol
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateRol(int id, [FromBody] RolDto rolDto)
        {
            if (rolDto == null || id != rolDto.IdRol)
            {
                return BadRequest();
            }

            Rol modelo = new()
            {
                IdRol = rolDto.IdRol,
                Nombre = rolDto.Nombre,
                fechaRegistro = rolDto.fechaRegistro
            };
            _db.Rol.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }


        //Actualizar registros en la tabla Rol-patch
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialRol(int id, JsonPatchDocument<RolDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var rol = _db.Rol.FirstOrDefault(v => v.IdRol == id);

            RolDto rolDto = new()
            {
                IdRol = rol.IdRol,
                Nombre = rol.Nombre,
                fechaRegistro = rol.fechaRegistro
            };

            if (rol == null) return BadRequest();
            patchDto.ApplyTo(rolDto, ModelState);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            Rol modelo = new()
            {
                IdRol = rolDto.IdRol,
                Nombre = rolDto.Nombre,
                fechaRegistro = rolDto.fechaRegistro
            };
            _db.Rol.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
