using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanGaban_WebAPI.Modelos.Dto
{
    public class BitacoraDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_REGISTRO { get; set; } 
        public String UBICACION { get; set; } 
        public String EQUIPO { get; set; } 
        public String TIPO_REGISTRO { get; set; } 
        public String registro { get; set; } 
        public DateTime? FECHA_HORA_INICIO { get; set; } 

        public DateTime? FECHA_HORA_FIN { get; set; }
       
        public String DESCRIPCION { get; set; }
        public String? CAUSA_DESCONEXION { get; set; } 
        public String? CAUSA_ELIMINACION { get; set; }

           

    }
}
