using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
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


        //Listar Todos Los Usuarios
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UsuarioDto>> GetUsuarios()
        {

            {
                _logger.LogInformation("Listar los Usuarios");
                return Ok(_db.Usuario.ToList());


            };
        }


        //Listar Todos Los Roles pero bajo un id
        [HttpGet("id:int", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UsuarioDto>> GetUsuarios(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer Usuarios con Id " + id);
                return BadRequest();
            }

            var usuario = _db.Usuario.FirstOrDefault(v => v.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);

        }


        //Insertar en la tabla Usuario
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioDto> CrearUsuario([FromBody] UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (usuarioDto == null)
            {
                return BadRequest(usuarioDto);
            }
            if (usuarioDto.IdUsuario > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Usuario modelo = new()
            {
                IdUsuario = usuarioDto.IdUsuario,
                registro=usuarioDto.registro,
                nombreCompleto=usuarioDto.nombreCompleto,
                apellido_paterno= usuarioDto.apellido_paterno,
                apellido_materno=usuarioDto.apellido_materno,
                correo= usuarioDto.correo,
                IdRol = usuarioDto.IdRol,
                clave= usuarioDto.clave,
                esActivo= usuarioDto.esActivo,
                fechaRegistro= usuarioDto.fechaRegistro

            };
            _db.Usuario.Add(modelo);
            _db.SaveChanges();
            return CreatedAtRoute("GetUsuario", new { id = usuarioDto.IdUsuario }, usuarioDto);
        }

        //eliminar registros en la tabla Usuario
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUsuario(int id)
        {
            if (id == 0) { return BadRequest(); }
            var usuario = _db.Usuario.FirstOrDefault(v => v.IdUsuario == id);
            if (usuario == null) { return NotFound(); }
            _db.Usuario.Remove(usuario);
            _db.SaveChanges();
            return NoContent();

        }
        //Actualizar registros en la tabla Usuario
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUsuario(int id, [FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null || id != usuarioDto.IdUsuario)
            {
                return BadRequest();
            }

            Usuario modelo = new()
            {
                IdUsuario = usuarioDto.IdUsuario,
                registro = usuarioDto.registro,
                nombreCompleto = usuarioDto.nombreCompleto,
                apellido_paterno = usuarioDto.apellido_paterno,
                apellido_materno = usuarioDto.apellido_materno,
                correo = usuarioDto.correo,
                IdRol = usuarioDto.IdRol,
                clave = usuarioDto.clave,
                esActivo = usuarioDto.esActivo,
                fechaRegistro = usuarioDto.fechaRegistro
            };
            _db.Usuario.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }


        //Actualizar registros en la tabla Rol-patch
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialUsuario(int id, JsonPatchDocument<UsuarioDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var usuario = _db.Usuario.FirstOrDefault(v => v.IdUsuario == id);


            UsuarioDto usuarioDto = new()
            {
                IdUsuario = usuario.IdUsuario,
                registro = usuario.registro,
                nombreCompleto = usuario.nombreCompleto,
                apellido_paterno = usuario.apellido_paterno,
                apellido_materno = usuario.apellido_materno,
                correo = usuario.correo,
                IdRol = usuario.IdRol,
                clave = usuario.clave,
                esActivo = usuario.esActivo,
                fechaRegistro = usuario.fechaRegistro

            };

            if (usuario == null) return BadRequest();
            patchDto.ApplyTo(usuarioDto, ModelState);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            Usuario modelo = new()
            {
                IdUsuario = usuarioDto.IdUsuario,
                registro = usuarioDto.registro,
                nombreCompleto = usuarioDto.nombreCompleto,
                apellido_paterno = usuarioDto.apellido_paterno,
                apellido_materno = usuarioDto.apellido_materno,
                correo = usuarioDto.correo,
                IdRol = usuarioDto.IdRol,
                clave = usuarioDto.clave,
                esActivo = usuarioDto.esActivo,
                fechaRegistro = usuarioDto.fechaRegistro
            };
            _db.Usuario.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
