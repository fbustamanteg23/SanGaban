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
using System.Data.Common;
using System.Net.Mail;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SanGaban_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        private readonly ILogger<AuditoriaController> _logger;
        private readonly ApplicationDbContext _db;

        public AuditoriaController(ILogger<AuditoriaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpPost("{CATEGORIA},{ID_USUARIO},{EVENTO},{OBSERVACION}")]
        public async Task<IActionResult> GetAuditoriaById(string CATEGORIA, int ID_USUARIO,string EVENTO,string OBSERVACION)
        {
            string StoredProc = "exec SP_INSERTAR_AUDITORIA " +
            "@CATEGORIA='" + CATEGORIA + "'," +
            "@ID_USUARIO=" + ID_USUARIO + "," +
            "@EVENTO='" + EVENTO + "'," +
            "@OBSERVACION='" + OBSERVACION + "'";

           
            try
            {
                var loginList = await _db.AuditoriaDto.FromSqlRaw(StoredProc).ToListAsync();
                return Ok(loginList);
            }
            catch
            {
                return Ok(1);
            }

          

        }
    }
}
