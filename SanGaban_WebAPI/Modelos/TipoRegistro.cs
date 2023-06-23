using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanGaban_WebAPI.Modelos
{
    public class TipoRegistro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_TIPO_REGISTRO { get; set; }

        [Required]
        public String TIPO_REGISTRO { get; set; }
        public String DESCRIPCION { get; set; }
        public String ID_UBICACION { get; set; }
    }
}
