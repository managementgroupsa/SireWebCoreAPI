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
    public class SIRE : ControllerBase
    {
        //[HttpPost("Periodos")]
        ////[Authorize(Roles = "Administrator,User")]
        //public  string BuscarPeriodos(EntidadSIRE entidad)
        //{
        //    SIRE_Domain oDominio = new SIRE_Domain();
        //    return  oDominio.BuscarPeriodos(entidad);
        //}



    }
}
