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
    public class EquiposController : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private readonly ApplicationDbContext _db;

        public EquiposController(ILogger<RolController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        //Listar Todos Los Equipos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<EquiposDto>> GetEquipos()
        {

            {
                _logger.LogInformation("Listar los Equipos");
                return Ok(_db.Rol.ToList());


            };
        }


        //Listar Todos Los Equipos pero bajo un id
        [HttpGet("id:int", Name = "GetEquipos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<EquiposDto>> GetEquipos(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer Equipos con Id " + id);
                return BadRequest();
            }

            var equipos = _db.Equipos.FirstOrDefault(v => v.ID_EQUIPO == id);
            if (equipos == null)
            {
                return NotFound();
            }
            return Ok(equipos);

        }


        //Insertar en la tabla Equipos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EquiposDto> CrearEquipos([FromBody] EquiposDto equiposDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (equiposDto == null)
            {
                return BadRequest(equiposDto);
            }
            if (equiposDto.ID_EQUIPO > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Equipos modelo = new()
            {
                ID_EQUIPO = equiposDto.ID_EQUIPO,
                ID_UBICACION = equiposDto.ID_UBICACION,
                EQUIPO = equiposDto.EQUIPO,
                DESCRIPCION = equiposDto.DESCRIPCION,
                ELIMINACION = equiposDto.ELIMINACION

            };
            _db.Equipos.Add(modelo);
            _db.SaveChanges();
            return CreatedAtRoute("GetEquipo", new { id = equiposDto.ID_EQUIPO }, equiposDto);
        }

        //eliminar registros en la tabla Equipos
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEquipos(int id)
        {
            if (id == 0) { return BadRequest(); }
            var Equipos = _db.Equipos.FirstOrDefault(v => v.ID_EQUIPO == id);
            if (Equipos == null) { return NotFound(); }
            _db.Equipos.Remove(Equipos);
            _db.SaveChanges();
            return NoContent();

        }
        //Actualizar registros en la tabla Equipos
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEquipos(int id, [FromBody] EquiposDto equiposDto)
        {
            if (equiposDto == null || id != equiposDto.ID_EQUIPO)
            {
                return BadRequest();
            }

            Equipos modelo = new()
            {

                ID_EQUIPO = equiposDto.ID_EQUIPO,
                ID_UBICACION = equiposDto.ID_UBICACION,
                EQUIPO = equiposDto.EQUIPO,
                DESCRIPCION = equiposDto.DESCRIPCION,
                ELIMINACION = equiposDto.ELIMINACION

                
            };
            _db.Equipos.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }


        //Actualizar registros en la tabla Equipos-patch
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialEquipos(int id, JsonPatchDocument<RolDto> patchDto)
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
