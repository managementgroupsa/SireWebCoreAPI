using System;
using System.Collections.Generic;
using Layer.Entity;
using Layer.AccessData;
using System.Threading.Tasks;

namespace Layer.Domain
{
    public class CNT_TIPO_CAMBIO_Domain
    {
        public async Task<List<object>> SeleccionarTodos(CNT_TIPO_CAMBIO_Entity entidad)
        {
            CNT_TIPO_CAMBIO_Data oData = new CNT_TIPO_CAMBIO_Data();
            return await oData.SeleccionarTodos(entidad);
        }

        public async Task<object> SeleccionarRegistro(CNT_TIPO_CAMBIO_Entity entidad)
        {
            CNT_TIPO_CAMBIO_Data oData = new CNT_TIPO_CAMBIO_Data();
            return await oData.SeleccionarRegistro(entidad);
        }

        public async Task<MENSAJE_Entity> EliminarRegistro(CNT_TIPO_CAMBIO_Entity entidad)
        {
            CNT_TIPO_CAMBIO_Data oData = new CNT_TIPO_CAMBIO_Data();
            return await oData.EliminarRegistro(entidad);
        }

        public async Task<MENSAJE_Entity> InsertarRegistro(CNT_TIPO_CAMBIO_Entity entidad)
        {
            CNT_TIPO_CAMBIO_Data oData = new CNT_TIPO_CAMBIO_Data();
            return await oData.InsertarRegistro(entidad);
        }

        public async Task<MENSAJE_Entity> EditarRegistro(CNT_TIPO_CAMBIO_Entity entidad)
        {
            CNT_TIPO_CAMBIO_Data oData = new CNT_TIPO_CAMBIO_Data();
            return await oData.EditarRegistro(entidad);
        }

    }
}
