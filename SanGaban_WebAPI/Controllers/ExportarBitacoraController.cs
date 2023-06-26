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
    public class ExportarBitacoraController : ControllerBase
    {
        private readonly ILogger<ExportarBitacoraController> _logger;
        private readonly ApplicationDbContext _db;

        public ExportarBitacoraController(ILogger<ExportarBitacoraController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet("{FECHA_INICIO},{FECHA_FINAL}")]
        public async Task<IActionResult> GetExportarBitacoraById(string FECHA_INICIO, string FECHA_FINAL)
        {
            string StoredProc = "exec SP_EXPORTAR_BITACORA " +
            "@FECHA_INICIO='" + FECHA_INICIO + "'," +
            "@FECHA_FINAL='" + FECHA_FINAL + "'";
            

            var loginList = await _db.ExportarBitacoraDto.FromSqlRaw(StoredProc).ToListAsync();
            return Ok(loginList);

        }
    }
}
