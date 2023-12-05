using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Layer.Entity;
using Microsoft.Extensions.Configuration;

namespace Layer.AccessData
{
    public class CNT_TIPO_CAMBIO_Data
    {
        private static string ConnectionString()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            var cadenaConexion = config["ConnectionStrings:ConnectionString"];

            return cadenaConexion;
        }

        public async Task<List<object>> SeleccionarTodos(CNT_TIPO_CAMBIO_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.SeleccionarTodos("spCn_GrabaTipoCambio", "SEL_ALL", "Layer.Entity", "CNT_TIPO_CAMBIO_Entity", entidad);
        }

        public async Task<object> SeleccionarRegistro(CNT_TIPO_CAMBIO_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.SeleccionarRegistro("spCn_GrabaTipoCambio", "SEL_REG", "Layer.Entity", "CNT_TIPO_CAMBIO_Entity", entidad);
        }


        public async Task<MENSAJE_Entity> EliminarRegistro(CNT_TIPO_CAMBIO_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.EliminarRegistro("spCn_GrabaTipoCambio", "ELIMINAR", "Layer.Entity", "CNT_TIPO_CAMBIO_Entity", entidad);
        }

        public async Task<MENSAJE_Entity> InsertarRegistro(CNT_TIPO_CAMBIO_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.InsertarRegistro("spCn_GrabaTipoCambio", "INSERTAR", "Layer.Entity", "CNT_TIPO_CAMBIO_Entity", entidad);
        }

        public async Task<MENSAJE_Entity> EditarRegistro(CNT_TIPO_CAMBIO_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.EditarRegistro("spCn_GrabaTipoCambio", "EDITAR", "Layer.Entity", "CNT_TIPO_CAMBIO_Entity", entidad);
        }


    }
}
