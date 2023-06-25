using System.ComponentModel.DataAnnotations;

namespace SanGaban_WebAPI.Modelos.Dto
{
    public class LoginDto
    {
        public String usuario { get; set; }
     
        public String clave { get; set; }
       
    }
}
