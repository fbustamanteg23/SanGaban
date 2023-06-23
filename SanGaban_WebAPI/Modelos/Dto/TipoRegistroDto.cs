using System.ComponentModel.DataAnnotations;

namespace SanGaban_WebAPI.Modelos.Dto
{
    public class TipoRegistroDto
    {
        public int ID_TIPO_REGISTRO { get; set; }

        [Required]
        public String TIPO_REGISTRO { get; set; }
        public String DESCRIPCION { get; set; }
        public String ID_UBICACION { get; set; }
    }
}