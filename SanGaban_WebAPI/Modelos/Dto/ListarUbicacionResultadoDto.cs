using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SanGaban_WebAPI.Modelos
{
    public class ListarUbicacionResultadoDto

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_UBICACION { get; set; }

        public String DESCRIPCION { get; set; }
     
       

    }
}
