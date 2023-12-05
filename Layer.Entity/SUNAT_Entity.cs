using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    public class DIA_Entity
    {
        public DateTime Fecha { get; set; }
        public double Compra { get; set; }
        public double Venta{ get; set; }
    }
    public class SUNAT_Entity
    {
        private string _Nombres;
        private string _Ubigeo;
        private string _RUC;
        private string _TipoDocumento;
        private string _ApePaterno;
        private string _Direccion;
        private string _Telefono;
        private string _TipoEmpresa;
        private string _RazonSocial;
        private string _NomComercial;
        private string _Estado;
        private string _CondiContribuyente;
        private string _FechaBaja;
        private string _InicioActi;
        private string _FIncripcion;
        private string _EmiComprobante;
        private string _SisContabilidad;
        private string _ComerExterior;
        private string _ActiEconomica;
        private string _Oficio;

        private string _Departamento;
        private string _Provincia;
        private string _Distrito;

        public string Distrito
        {
            get
            {
                return _Distrito;
            }

            set
            {
                _Distrito = value;
            }
        }

        public string Provincia
        {
            get
            {
                return _Provincia;
            }

            set
            {
                _Provincia = value;
            }
        }

        public string Departamento
        {
            get
            {
                return _Departamento;
            }

            set
            {
                _Departamento = value;
            }
        }
        public string Ubigeo
        {
            get
            {
                return _Ubigeo;
            }

            set
            {
                _Ubigeo = value;
            }
        }

        public string TipoDocumento
        {
            get
            {
                return _TipoDocumento;
            }
            set
            {
                _TipoDocumento = value;
            }
        }

        public string Nombres
        {
            get
            {
                return _Nombres;
            }

            set
            {
                _Nombres = value;
            }
        }
        public string ApePaterno
        {
            get
            {
                return _ApePaterno;
            }

            set
            {
                _ApePaterno = value;
            }
        }
        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }
        public string Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }
        public string RazonSocial
        {
            get
            {
                return _RazonSocial;
            }

            set
            {
                _RazonSocial = value;
            }
        }
        public string RUC
        {
            get
            {
                return _RUC;
            }

            set
            {
                _RUC = value;
            }
        }
        public string TipoEmpresa
        {
            get
            {
                return _TipoEmpresa;
            }

            set
            {
                _TipoEmpresa = value;
            }
        }
        public string NomComercial
        {
            get
            {
                return _NomComercial;
            }

            set
            {
                _NomComercial = value;
            }
        }

        public string CondiContribuyente
        {
            get
            {
                return _CondiContribuyente;
            }


            set
            {
                _CondiContribuyente = value;
            }
        }


        public string FechaBaja
        {
            get
            {
                return _FechaBaja;
            }

            set
            {
                _FechaBaja = value;
            }
        }
        public string FInscripcion
        {
            get
            {
                return _FIncripcion;
            }

            set
            {
                _FIncripcion = value;
            }
        }
        public string InicioActiviades
        {
            get
            {
                return _InicioActi;
            }

            set
            {
                _InicioActi = value;
            }
        }
        public string EmiComprobante
        {
            get
            {
                return _EmiComprobante;
            }

            set
            {
                _EmiComprobante = value;
            }
        }

        public string SisContabilidad
        {
            get
            {
                return _SisContabilidad;
            }
            set
            {
                _SisContabilidad = value;
            }
        }

        public string ComerExterior
        {
            get
            {
                return _ComerExterior;
            }

            set
            {
                _ComerExterior = value;
            }
        }

        public string ActiEconomica
        {
            get
            {
                return _ActiEconomica;
            }

            set
            {
                _ActiEconomica = value;
            }
        }

        public string Oficio
        {
            get
            {
                return _Oficio;
            }
            set
            {
                _Oficio = value;
            }
        }
    }

}
