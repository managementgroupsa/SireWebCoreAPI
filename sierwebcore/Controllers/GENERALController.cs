using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Layer.Entity;
using Layer.Domain;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace CodesicorpCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GENERAL : ControllerBase
    {
        [HttpPost("Meses")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<object>> Meses(CNT_PERIODO_Entity entidad)
        {
            GENERAL_Domain oDominio = new GENERAL_Domain();
            return await oDominio.Meses(entidad);
        }

        [HttpPost("BuscaTokenNubefact")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<object>> BuscaTokenNubefact(EMPRESA_Entity entidad)
        {
            GENERAL_Domain oDominio = new GENERAL_Domain();
            return await oDominio.BuscaTokenNubefact(entidad);
        }

        [HttpPost("TipoDocumento")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<object>> TipoDocumento(CNT_TIPODOC_Entity entidad)
        {
            GENERAL_Domain oDominio = new GENERAL_Domain();
            return await oDominio.TipoDocumento(entidad);
        }

        [HttpPost("TipoMoneda")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<object>> TipoMoneda(CNT_TIPO_MONEDA_Entity entidad)
        {
            GENERAL_Domain oDominio = new GENERAL_Domain();
            return await oDominio.TipoMoneda(entidad);
        }

        [HttpPost("IncluyeIGV")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<object>> IncluyeIGV(CFG_PARAMETROS_Entity entidad)
        {
            GENERAL_Domain oDominio = new GENERAL_Domain();
            return await oDominio.IncluyeIGV(entidad);
        }

        [HttpPost("DatosDetraccion")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<object>> DatosDetraccion(EMPRESA_Entity entidad)
        {
            GENERAL_Domain oDominio = new GENERAL_Domain();
            return await oDominio.DatosDetraccion(entidad);
        }

        [HttpPost("DastosRetencion")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<object>> DastosRetencion(EMPRESA_Entity entidad)
        {
            GENERAL_Domain oDominio = new GENERAL_Domain();
            return await oDominio.DastosRetencion(entidad);
        }


    }
}
