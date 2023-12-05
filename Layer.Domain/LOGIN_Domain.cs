using System;
using System.Collections.Generic;
using Layer.Entity;
using Layer.AccessData;
using System.Threading.Tasks;

namespace Layer.Domain
{

    public class LOGIN_Domain
    {


        public async Task<Respuesta_Entity> ValidaIngreso(LOGIN_Entity entidad)
        {
            LOGIN_Data oData = new LOGIN_Data();
            return  await oData.ValidaIngreso("LOGIN", entidad);
        }

        public async Task<LOGIN_Entity> ValidacionUsuarioToken(LOGIN_Entity entidad)
        {
            LOGIN_Data oData = new LOGIN_Data();
            return  await oData.ValidacionUsuarioToken("SEL_ALL",entidad);
        }

        

        public async Task<List<Empresa_Entity>> BuscarYear(LOGIN_Entity entidad)
        {
            LOGIN_Data oData = new LOGIN_Data();
            return await oData.BuscarEmpresas("EMPRESA", entidad);
        }


        public async Task<List<Empresa_Entity>> BuscarEmpresas(LOGIN_Entity entidad)
        {
            LOGIN_Data oData = new LOGIN_Data();
            return await oData.BuscarEmpresas("EMPRESA", entidad);
        }

        public async Task<List<Anio_Entity>> BuscarAnios(LOGIN_Entity entidad)
        {
            LOGIN_Data oData = new LOGIN_Data();
            return await oData.BuscarAnios("ANIOS", entidad);
        }

        public async Task<List<PuntoVenta_Entity>> BuscarPuntosVenta(LOGIN_Entity entidad)
        {
            LOGIN_Data oData = new LOGIN_Data();
            return await oData.BuscarPuntosVenta("PUNTOVTA", entidad);
        }
    }
}
