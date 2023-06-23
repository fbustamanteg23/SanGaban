using System.ComponentModel.DataAnnotations;

namespace SanGaban_WebAPI.Modelos.Dto
{
    public class EquiposDto
    {
        public int ID_EQUIPO { get; set; }

        [Required]
        public String ID_UBICACION { get; set; }
        public String EQUIPO { get; set; }
        public String DESCRIPCION { get; set; }
        public String ELIMINACION { get; set; }
    }
}
