using Layer.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Layer.AccessData
{
    public class SUNAT_Data
    {

        public async Task<SUNAT_Entity> ConsultaRUC(string cDocumento)
        {
            SUNAT_Entity oEntidad = new SUNAT_Entity();

            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                HttpWebRequest request;
                HttpWebResponse response = null/* TODO Change to default(_) if this is not a reference type */;
                StreamReader reader;

                request = (HttpWebRequest)WebRequest.Create("https://api.apis.net.pe/v1/ruc?numero=" + cDocumento);
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());

                string rawresp;
                rawresp = reader.ReadToEnd();
                rawresp = "[" + rawresp + "]";

                JArray array = JArray.Parse(rawresp);


                foreach (JObject item in array)
                {
                    oEntidad.Nombres = item["nombre"] == null ? "" : item["nombre"].ToString();
                    oEntidad.TipoDocumento = item["tipoDocumento"] == null ? "" : item["tipoDocumento"].ToString();
                    oEntidad.RUC = item["numeroDocumento"] == null ? "" : item["numeroDocumento"].ToString();
                    oEntidad.Estado = item["estado"] == null ? "" : item["estado"].ToString();
                    oEntidad.CondiContribuyente = item["condicion"] == null ? "" : item["condicion"].ToString();
                    oEntidad.Direccion = item["direccion"] == null ? "" : item["direccion"].ToString();
                    oEntidad.Ubigeo = item["ubigeo"] == null ? "" : item["ubigeo"].ToString();
                    oEntidad.Departamento = item["departamento"] == null ? "" : item["departamento"].ToString();
                    oEntidad.Provincia = item["provincia"] == null ? "" : item["provincia"].ToString();
                    oEntidad.Distrito = item["distrito"] == null ? "" : item["distrito"].ToString();
                }
            }
            catch (Exception ex)
            {
                return null/* TODO Change to default(_) if this is not a reference type */;
            }

            return oEntidad;
        }

        public async Task<SUNAT_Entity> ConsultaDNI(string cDocumento)
        {
            SUNAT_Entity oEntidad = new SUNAT_Entity();

            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                HttpWebRequest request;
                HttpWebResponse response = null/* TODO Change to default(_) if this is not a reference type */;
                StreamReader reader;

                request = (HttpWebRequest)WebRequest.Create("https://api.apis.net.pe/v1/dni?numero=" + cDocumento);
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());

                string rawresp;
                rawresp = reader.ReadToEnd();
                rawresp = "[" + rawresp + "]";

                JArray array = JArray.Parse(rawresp);


                foreach (JObject item in array)
                {
                    oEntidad.Nombres = item["nombre"] == null ? "" : item["nombre"].ToString();
                    oEntidad.TipoDocumento = item["tipoDocumento"] == null ? "" : item["tipoDocumento"].ToString();
                    oEntidad.RUC = item["numeroDocumento"] == null ? "" : item["numeroDocumento"].ToString();
                    oEntidad.Estado = item["estado"] == null ? "" : item["estado"].ToString();
                    oEntidad.CondiContribuyente = item["condicion"] == null ? "" : item["condicion"].ToString();
                    oEntidad.Direccion = item["direccion"] == null ? "" : item["direccion"].ToString();
                    oEntidad.Ubigeo = item["ubigeo"] == null ? "" : item["ubigeo"].ToString();
                    oEntidad.Departamento = item["departamento"] == null ? "" : item["departamento"].ToString();
                    oEntidad.Provincia = item["provincia"] == null ? "" : item["provincia"].ToString();
                    oEntidad.Distrito = item["distrito"] == null ? "" : item["distrito"].ToString();
                }
            }
            catch (Exception)
            {
                return null/* TODO Change to default(_) if this is not a reference type */;
            }

            return oEntidad;
        }

        public static Double NE(object Valor)
        {
            if (Valor == null || Valor == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(Valor);
            }
        }

        public static DateTime FE(object Valor)
        {
            if (Valor == null || Valor == "")
            {
                return Convert.ToDateTime("01/01/1900");
            }
            else if (Convert.ToDateTime(Valor).Year <= 1900)
            {
                return Convert.ToDateTime("01/01/1900");
            }
            else
            {
                return Convert.ToDateTime(Valor);
            }
        }

        public async Task<DIA_Entity> ConsultaTC(string cFecha)
        {
            DIA_Entity oDia = new DIA_Entity();

            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                HttpWebRequest request;
                HttpWebResponse response = null/* TODO Change to default(_) if this is not a reference type */;
                StreamReader reader;

                request = (HttpWebRequest)WebRequest.Create("https://api.apis.net.pe/v1/tipo-cambio-sunat?fecha=" + cFecha);
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream());

                string rawresp;
                rawresp = reader.ReadToEnd();
                rawresp = "[" + rawresp + "]";

                JArray array = JArray.Parse(rawresp);


                foreach (JObject item in array)
                {
                    oDia.Compra = NE(item["compra"]);
                    oDia.Venta = NE(item["venta"]);
                    oDia.Fecha = FE(item["fecha"]);
                }
            }

            catch (Exception ex)
            {
                return null/* TODO Change to default(_) if this is not a reference type */;
            }

            return oDia;
        }

    }
}
