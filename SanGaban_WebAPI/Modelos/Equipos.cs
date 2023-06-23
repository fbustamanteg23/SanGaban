using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanGaban_WebAPI.Modelos
{
    public class Equipos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_EQUIPO { get; set; }

        [Required]
        public String ID_UBICACION { get; set; }
        public String EQUIPO { get; set; }
        public String DESCRIPCION { get; set; }
        public String ELIMINACION { get; set; }
    }
}
