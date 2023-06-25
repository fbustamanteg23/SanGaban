using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SanGaban_WebAPI.Datos;
using SanGaban_WebAPI.Modelos;
using SanGaban_WebAPI.Modelos.Dto;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SanGaban_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListarUbicacion_x_TipoRegistroController : ControllerBase
    {
        private readonly ILogger<ListarUbicacion_x_TipoRegistroController> _logger;
        private readonly ApplicationDbContext _db;

        public ListarUbicacion_x_TipoRegistroController(ILogger<ListarUbicacion_x_TipoRegistroController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet("{id_ubicacion}")]
        public async Task<IActionResult> GetListarUbicacion_x_TipoRegistroById(int id_ubicacion)
        {
            string StoredProc = "exec PRI_SP_LISTAR_UBICACION_X_TIPO_REGISTRO " +
            "@ID_UBICACION='" + id_ubicacion + "'";
            

            var loginList = await _db.ListarUbicacion_x_TipoRegistroResultadoDto.FromSqlRaw(StoredProc).ToListAsync();
            return Ok(loginList);

        }
    }
}
