using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanGaban_WebAPI.Modelos
{
    public class LoginResultadoDto

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int respuesta { get; set; }

        public String usuario_logueado { get; set; }
        public String apellidos { get; set; }
        public int id_usuario { get; set; }   

    }
}
