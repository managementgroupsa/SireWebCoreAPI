using System;
using System.Collections.Generic;
using Layer.Entity;
using Layer.AccessData;
using System.Threading.Tasks;

namespace Layer.Domain
{
    public class SUNAT_Domain
    {

        public async Task<SUNAT_Entity> ConsultaRUC(string cDocumento)
        {
            SUNAT_Data oDominio = new SUNAT_Data();
            return await oDominio.ConsultaRUC(cDocumento);
        }

        public async Task<SUNAT_Entity> ConsultaDNI(string cDocumento)
        {
            SUNAT_Data oDominio = new SUNAT_Data();
            return await oDominio.ConsultaDNI(cDocumento);
        }

        public async Task<DIA_Entity> ConsultaTC(string cFecha)
        {
            SUNAT_Data oDominio = new SUNAT_Data();
            return await oDominio.ConsultaTC(cFecha);
        }

    }
}
