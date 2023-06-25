using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanGaban_WebAPI.Modelos
{
    public class Ubicacion_x_EquipoDto

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_UBICACION { get; set; }

        public String UBICACION { get; set; }
        public String EQUIPO { get; set; }
        public String DESCRIPCION_EQUIPO { get; set; }

    }
}
