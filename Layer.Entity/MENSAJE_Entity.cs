
using System.ComponentModel.DataAnnotations;

namespace Layer.Entity
{
    public class MENSAJE_Entity
    {
        [MaxLength(100)]
        public string Codigo { get; set; }
        [MaxLength(2000)]
        public string Mensaje { get; set; }
        [MaxLength(3)]
        public string Resultado { get; set; }

        public decimal FilasAfectadas { get; set; }
    }
}
