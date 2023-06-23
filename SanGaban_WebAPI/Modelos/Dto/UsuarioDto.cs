using System.ComponentModel.DataAnnotations;

namespace SanGaban_WebAPI.Modelos.Dto
{
    public class UsuarioDto
    {
        

        public int IdUsuario { get; set; }
        public String registro { get; set; }

        [Required]
        public String nombreCompleto { get; set; }
        public String apellido_paterno { get; set; }
        public String apellido_materno { get; set; }
        public String correo { get; set; }
        public int IdRol { get; set; }
        public String clave { get; set; }
        public Boolean esActivo { get; set; }

        public DateTime fechaRegistro { get; set; }
    }
}

