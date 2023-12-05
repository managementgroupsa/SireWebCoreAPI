using System;
using System.Collections.Generic;
using Layer.Entity;
using Layer.AccessData;
using System.Threading.Tasks;

namespace Layer.Domain
{
    public class TABLA_Domain
    {

        public async Task<List<object>> SeleccionarTodos(TABLA_Entity entidad)
        {
            TABLA_Data oData = new TABLA_Data();
            return await oData.SeleccionarTodos(entidad);
        }

        public async Task<object> SeleccionarRegistro(TABLA_Entity entidad)
        {
            TABLA_Data oData = new TABLA_Data();
            return await oData.SeleccionarRegistro(entidad);
        }


    }
}
