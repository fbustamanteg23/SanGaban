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
    public class TipoRegistroController : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private readonly ApplicationDbContext _db;

        public TipoRegistroController(ILogger<RolController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        //Listar Todos Los TipoRegistro
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TipoRegistroDto>> GetTipoRegistro()
        {

            {
                _logger.LogInformation("Listar los TipoRegistro");
                return Ok(_db.TipoRegistro.ToList());


            };
        }


        //Listar Todos Los TipoRegistro pero bajo un id
        [HttpGet("id:int", Name = "GetTipoRegistro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<TipoRegistroDto>> GetTipoRegistros(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer TipoRegistro con Id " + id);
                return BadRequest();
            }

            var TipoRegistro = _db.TipoRegistro.FirstOrDefault(v => v.ID_TIPO_REGISTRO == id);
            if (TipoRegistro == null)
            {
                return NotFound();
            }
            return Ok(TipoRegistro);

        }


        //Insertar en la tabla TipoRegistro
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipoRegistroDto> CrearTipoRegistro([FromBody] TipoRegistroDto tiporegistroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (tiporegistroDto == null)
            {
                return BadRequest(tiporegistroDto);
            }
            if (tiporegistroDto.ID_TIPO_REGISTRO > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            TipoRegistro modelo = new()
            {
                ID_TIPO_REGISTRO = tiporegistroDto.ID_TIPO_REGISTRO,
                TIPO_REGISTRO = tiporegistroDto.TIPO_REGISTRO,
                DESCRIPCION = tiporegistroDto.DESCRIPCION,
                ID_UBICACION = tiporegistroDto.ID_UBICACION

            };
            _db.TipoRegistro.Add(modelo);
            _db.SaveChanges();
            return CreatedAtRoute("GetTipoRegistro", new { id = tiporegistroDto.ID_TIPO_REGISTRO }, tiporegistroDto);
        }

        //eliminar registros en la tabla TipoRegistro
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTipoRegistro(int id)
        {
            if (id==0) { return BadRequest(); }
            var tiporegistro = _db.TipoRegistro.FirstOrDefault(v=>v.ID_TIPO_REGISTRO==id);
            if (tiporegistro == null) { return NotFound(); }
            _db.TipoRegistro.Remove(tiporegistro);
            _db.SaveChanges();
            return NoContent();
    
        }
        //Actualizar registros en la tabla tiporegistro
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateTipoRegistro(int id, [FromBody] TipoRegistroDto tiporegistroDto) {
            if (tiporegistroDto == null || id != tiporegistroDto.ID_TIPO_REGISTRO)
            {
                return BadRequest();    
            }

            TipoRegistro modelo = new()
            {
                ID_TIPO_REGISTRO = tiporegistroDto.ID_TIPO_REGISTRO,
                TIPO_REGISTRO = tiporegistroDto.TIPO_REGISTRO,
                DESCRIPCION = tiporegistroDto.DESCRIPCION,
                ID_UBICACION = tiporegistroDto.ID_UBICACION
            };
            _db.TipoRegistro.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }
       
        
        //Actualizar registros en la tabla TipoRegistro-patch
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialTipoRegistro(int id, JsonPatchDocument<TipoRegistroDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var tiporegistro=_db.TipoRegistro.FirstOrDefault(v=>v.ID_TIPO_REGISTRO==id);

            TipoRegistroDto tiporegistroDto = new()
            {

                ID_TIPO_REGISTRO = tiporegistro.ID_TIPO_REGISTRO,
                TIPO_REGISTRO = tiporegistro.TIPO_REGISTRO,
                DESCRIPCION = tiporegistro.DESCRIPCION,
                ID_UBICACION = tiporegistro.ID_UBICACION
               
            };

            if(tiporegistro == null) return BadRequest();
            patchDto.ApplyTo(tiporegistroDto, ModelState);
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            TipoRegistro modelo = new()
            {
                ID_TIPO_REGISTRO = tiporegistroDto.ID_TIPO_REGISTRO,
                TIPO_REGISTRO = tiporegistroDto.TIPO_REGISTRO,
                DESCRIPCION = tiporegistroDto.DESCRIPCION,
                ID_UBICACION = tiporegistroDto.ID_UBICACION
                 
            };
            _db.TipoRegistro.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }

    }
}
