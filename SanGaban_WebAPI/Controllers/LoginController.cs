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
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ApplicationDbContext _db;

        public LoginController(ILogger<LoginController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet("{usuario},{clave}")]
        public async Task<IActionResult> GetLoginById(string usuario,string clave)
        {
            string StoredProc = "exec sp_validar_login " +
            "@usuario='" + usuario + "'," +
            "@clave='" + clave + "'";
            

            var loginList = await _db.LoginResultadoDto.FromSqlRaw(StoredProc).ToListAsync();
            return Ok(loginList);

        }
    }
}
