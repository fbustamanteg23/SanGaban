using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanGaban_WebAPI.Modelos
{
    public class ExportarBitacoraDto

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String UBICACION { get; set; }

        public String EQUIPO { get; set; }
        public String TIPO { get; set; }
        
        public DateTime? FECHA_HORA_INICIO { get; set; }
        public DateTime? FECHA_HORA_FIN { get; set; }
        public String? DESCRIPCION { get; set; }
        public Boolean ELIMINACION { get; set; }
        public String? CAUSA_DESCONEXION { get; set; }
        public String? CAUSA_ELIMINACION { get; set; }
       
    }
}
