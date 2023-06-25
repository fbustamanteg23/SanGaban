using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanGaban_WebAPI.Datos;
using SanGaban_WebAPI.Modelos;
using SanGaban_WebAPI.Modelos.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SanGaban_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ubicacion_x_EquiposController : ControllerBase
    {
        private readonly ILogger<RolController> _logger;
        private readonly ApplicationDbContext _db;

        public Ubicacion_x_EquiposController(ILogger<RolController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet("{idUbicacion}")]
        public async Task<IActionResult> GetUbicacion_x_EquiposById(int idUbicacion)
        {
            string StoredProc = "exec PRI_SP_LISTAR_UBICACION_X_EQUIPO " +
            "@ID_UBICACION='" + idUbicacion + "'";
           


            var loginList = await _db.Ubicacion_x_EquipoDto.FromSqlRaw(StoredProc).ToListAsync();
            return Ok(loginList);

        }


    }
}
