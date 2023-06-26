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
    public class BitacoraController : ControllerBase
    {
        private readonly ILogger<BitacoraController> _logger;
        private readonly ApplicationDbContext _db;

        public BitacoraController(ILogger<BitacoraController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> GetBitacora(int? ID_REGISTRO, string? FECHA_HORA_INICIO,
            string? FECHA_HORA_FIN,int? ID_TIPO_REGISTRO,int? ID_EQUIPOS,int? ID_USUARIO,int? ID_UBICACION,
           int? EVENTO_ACTIVO,int? ELIMINACION)
        {

         

            string StoredProc = "exec SP_LISTAR_BITACORA " +
            "@ID_REGISTRO='" + ID_REGISTRO + "'," +
            "@FECHA_HORA_INICIO='" + FECHA_HORA_INICIO + "'," +
            "@FECHA_HORA_FIN='" + FECHA_HORA_FIN + "'," +
            "@ID_TIPO_REGISTRO='" + ID_TIPO_REGISTRO + "'," +
            "@ID_EQUIPOS='" + ID_EQUIPOS + "'," +
            "@ID_USUARIO='" + ID_USUARIO + "'," +
            "@ID_UBICACION='" + ID_UBICACION + "'," +
            "@EVENTO_ACTIVO='" + EVENTO_ACTIVO + "'," +
            "@ELIMINACION='" + ELIMINACION + "'";
            

            var loginList = await _db.BitacoraDto.FromSqlRaw(StoredProc).ToListAsync();
            return Ok(loginList);

        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> GetBuscara(int? ID)
        {



            string StoredProc = "exec SP_BUSCAR_BITACORA " +
            "@ID='" + ID + "'";


            var loginList = await _db.BitacoraDto.FromSqlRaw(StoredProc).ToListAsync();
            return Ok(loginList);

        }

        [HttpDelete("{ID},{CAUSA_ELIMINACION},{ID_USUARIO}")]
        public async Task<IActionResult> GetEliminarBitacora(int ID, string CAUSA_ELIMINACION, int ID_USUARIO)
        {
            string StoredProc = "exec SP_ELIMINAR_BITACORA " +
            "@ID='" + ID + "'," +
            "@CAUSA_ELIMINACION='" + CAUSA_ELIMINACION + "'," +
            "@ID_USUARIO_MODIFICACION='" + ID_USUARIO + "'";
            


            try
            {
                var loginList = await _db.BitacoraDto.FromSqlRaw(StoredProc).ToListAsync();
                return Ok(loginList);
            }
            catch
            {
                return Ok(1);
            }



        }

        [HttpPost("{FECHA_HORA_INICIO},{ID_TIPO_REGISTRO},{DISPONIBILIDAD},{DESCRIPCION},{ID_EQUIPOS},{ID_USUARIO}" +
            ",{ID_UBICACION},{CAUSA_DESCONEXION},{ID_USUARIO_REGISTRO},{EVENTO_ACTIVO}")]
        public async Task<IActionResult> GetInsertarBitacora
            (string FECHA_HORA_INICIO,string ID_TIPO_REGISTRO, string DISPONIBILIDAD, string DESCRIPCION
            , int ID_EQUIPOS, int ID_USUARIO, int ID_UBICACION, string CAUSA_DESCONEXION, int ID_USUARIO_REGISTRO,
            int EVENTO_ACTIVO)
        {
            string StoredProc = "exec SP_INSERTAR_BITACORA " +
            "@FECHA_HORA_INICIO='" + FECHA_HORA_INICIO + "'," +
            "@ID_TIPO_REGISTRO=" + ID_TIPO_REGISTRO + "," +
            "@DISPONIBILIDAD='" + DISPONIBILIDAD + "'," +
            "@DESCRIPCION='" + DESCRIPCION + "'," +
            "@ID_EQUIPOS=" + ID_EQUIPOS + "," +
            "@ID_USUARIO=" + ID_USUARIO + "," +
            "@ID_UBICACION=" + ID_UBICACION + "'," +
            "@CAUSA_DESCONEXION='" + CAUSA_DESCONEXION + "'," +
            "@ID_USUARIO_REGISTRO=" + ID_USUARIO_REGISTRO + "," +

            "@EVENTO_ACTIVO=" + EVENTO_ACTIVO;


            try
            {
                var loginList = await _db.BitacoraDto.FromSqlRaw(StoredProc).ToListAsync();
                return Ok(loginList);
            }
            catch
            {
                return Ok(1);
            }



        }

        [HttpPost("{FECHA_HORA_INICIO},{FECHA_HORA_FIN},{ID_TIPO_REGISTRO},{DISPONIBILIDAD},{DESCRIPCION},{ID_EQUIPOS},{ID_USUARIO}" +
           ",{ID_UBICACION},{CAUSA_DESCONEXION},{ID_USUARIO_REGISTRO},{EVENTO_ACTIVO}" +
            ",{ELIMINACION},{CAUSA_ELIMINACION},{ID_USUARIO_ELIMINACION}")]
        public async Task<IActionResult> GetActualizarBitacora
           (string FECHA_HORA_INICIO, string FECHA_HORA_FIN, string ID_TIPO_REGISTRO, string DISPONIBILIDAD, string DESCRIPCION
           , int ID_EQUIPOS, int ID_USUARIO, int ID_UBICACION, string CAUSA_DESCONEXION, int ID_USUARIO_REGISTRO,
           int EVENTO_ACTIVO, int ELIMINACION, string CAUSA_ELIMINACION, int ID_USUARIO_ELIMINACION)
        {
            string StoredProc = "exec SP_ACTUALIZAR_BITACORA " +
            "@FECHA_HORA_INICIO='" + FECHA_HORA_INICIO + "'," +
             "@FECHA_HORA_FIN='" + FECHA_HORA_FIN + "'," +
            "@ID_TIPO_REGISTRO=" + ID_TIPO_REGISTRO + "," +
            "@DISPONIBILIDAD='" + DISPONIBILIDAD + "'," +
            "@DESCRIPCION='" + DESCRIPCION + "'," +
            "@ID_EQUIPOS=" + ID_EQUIPOS + "," +
            "@ID_USUARIO=" + ID_USUARIO + "," +
            "@ID_UBICACION=" + ID_UBICACION + "'," +
            "@CAUSA_DESCONEXION='" + CAUSA_DESCONEXION + "'," +
            "@ID_USUARIO_REGISTRO=" + ID_USUARIO_REGISTRO + "," +
            "@ELIMINACION=" + ELIMINACION + "," +
            "@CAUSA_ELIMINACION='" + CAUSA_ELIMINACION + "'," +
            "@ID_USUARIO_ELIMINACION=" + ID_USUARIO_ELIMINACION + "," +
            "@EVENTO_ACTIVO=" + EVENTO_ACTIVO;


            try
            {
                var loginList = await _db.BitacoraDto.FromSqlRaw(StoredProc).ToListAsync();
                return Ok(loginList);
            }
            catch
            {
                return Ok(1);
            }
        


        }
    }
}
