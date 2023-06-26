using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanGaban_WebAPI.Modelos.Dto
{
    public class AuditoriaDto
    {

        [Key]
        public int ID { get; set; }
        public int respuesta { get; set; }
      
    }
}
