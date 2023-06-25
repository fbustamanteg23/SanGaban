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
  
    public class ListarUbicacionController : ControllerBase
    {
        private readonly ILogger<ListarUbicacionController> _logger;
        private readonly ApplicationDbContext _db;

        public ListarUbicacionController(ILogger<ListarUbicacionController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> GetListarUbicacionBy()
        {
            string StoredProc = "exec PRI_SP_LISTAR_UBICACION";


            var loginList = await _db.ListarUbicacionResultadoDto.FromSqlRaw(StoredProc).ToListAsync();
            return Ok(loginList);

        }
    }
}
