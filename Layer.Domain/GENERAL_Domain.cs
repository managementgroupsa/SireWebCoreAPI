using System;
using System.Collections.Generic;
using Layer.Entity;
using Layer.AccessData;
using System.Threading.Tasks;

namespace Layer.Domain
{
    public class GENERAL_Domain
    {
        public async Task<List<object>> Meses(CNT_PERIODO_Entity entidad)
        {
            GENERAL_Data oDominio = new GENERAL_Data();
            return await oDominio.Meses(entidad);
        }

        public async Task<List<object>> BuscaTokenNubefact(EMPRESA_Entity entidad)
        {
            GENERAL_Data oDominio = new GENERAL_Data();
            return await oDominio.BuscaTokenNubefact(entidad);
        }

        public async Task<List<object>> TipoDocumento(CNT_TIPODOC_Entity entidad)
        {
            GENERAL_Data oDominio = new GENERAL_Data();
            return await oDominio.TipoDocumento(entidad);
        }


        public async Task<List<object>> TipoMoneda(CNT_TIPO_MONEDA_Entity entidad)
        {
            GENERAL_Data oDominio = new GENERAL_Data();
            return await oDominio.TipoMoneda(entidad);
        }

        public async Task<List<object>> IncluyeIGV(CFG_PARAMETROS_Entity entidad)
        {
            GENERAL_Data oDominio = new GENERAL_Data();
            return await oDominio.IncluyeIGV(entidad);
        }

        public async Task<List<object>> DatosDetraccion(EMPRESA_Entity entidad)
        {
            GENERAL_Data oDominio = new GENERAL_Data();
            return await oDominio.DatosDetraccion(entidad);
        }

        public async Task<List<object>> DastosRetencion(EMPRESA_Entity entidad)
        {
            GENERAL_Data oDominio = new GENERAL_Data();
            return await oDominio.DastosRetencion(entidad);
        }






    }
}
