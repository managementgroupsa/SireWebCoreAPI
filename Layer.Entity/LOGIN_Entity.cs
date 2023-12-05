using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Layer.Entity
{

    public class LOGIN_Entity 
    {
        public string Accion { get; set; }
        public string usu_cCodUsuario { get; set; }
        public string usu_cClave { get; set; }
        public string Emp_cCodigo { get; set; }
        public string soft_cCodSoft { get; set; }

        [Display(Name = "NoParameter")]
        public string usu_cRole { get; set; }
        [Display(Name = "NoParameter")]
        public string usu_cNombre { get; set; }
        [Display(Name = "NoParameter")]
        public string usu_cApellido { get; set; }
        [Display(Name = "NoParameter")]
        public string usu_cCorreo { get; set; }

    }

    public class Respuesta_Entity
    {
        public string Respuesta { get; set; }
        public string Nombres { get; set; }

        public string Role { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }

        public string Usuario { get; set; }
        public string Clave { get; set; }
    }

    public class Empresa_Entity
    {
        public string Emp_cCodigo { get; set; }
        public string Emp_cNombreLargo { get; set; }
    }

    public class PuntoVenta_Entity
    {
        public string Pvt_cCodigo { get; set; }
        public string Pvt_cDescripcion { get; set; }
    }

    public class Anio_Entity
    {
        public string Pan_cAnio { get; set; }
        public string Pan_cEstado { get; set; }
    }
}
