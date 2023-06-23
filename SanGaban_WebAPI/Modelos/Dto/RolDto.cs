using System.ComponentModel.DataAnnotations;

namespace SanGaban_WebAPI.Modelos.Dto
{
    public class RolDto
    {
        public int IdRol { get; set; }
        [Required]
        [MaxLength(200)]
        public String Nombre { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
