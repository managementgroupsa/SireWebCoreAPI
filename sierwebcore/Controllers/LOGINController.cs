using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Layer.Entity;
using Layer.Domain;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace CodesicorpCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LOGINController : ControllerBase
    {
        #region JWT



        private IConfiguration _config;

        public LOGINController(IConfiguration config)
        {
            _config = config;
        }

        

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LOGIN_Entity userLogin)
        {
            var user = await Authenticate(userLogin);

            if ( !String.IsNullOrEmpty( user.usu_cRole ))
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("Credenciales incorrectas");
        }

        private string Generate(LOGIN_Entity user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.usu_cCodUsuario),
                new Claim(ClaimTypes.Email, user.usu_cCorreo),
                new Claim(ClaimTypes.GivenName, user.usu_cNombre),
                new Claim(ClaimTypes.Surname, user.usu_cApellido),
                new Claim(ClaimTypes.Role, user.usu_cRole)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.UtcNow.AddMinutes(65),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private async Task<LOGIN_Entity> Authenticate(LOGIN_Entity oEntidad)
        {

            LOGIN_Domain oDomain = new LOGIN_Domain();

            var currentUser = await oDomain.ValidacionUsuarioToken(oEntidad);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;



        }


        private LOGIN_Entity GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new LOGIN_Entity
                {
                    usu_cCodUsuario = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    usu_cCorreo = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    usu_cNombre = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    usu_cApellido = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    usu_cRole = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }

        #endregion

        #region Login



        [HttpPost("ValidaIngreso")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<Respuesta_Entity> ValidaIngreso(LOGIN_Entity entidad)
        {
            LOGIN_Domain oDominio = new LOGIN_Domain();
            return await oDominio.ValidaIngreso(entidad);
        }

        [HttpPost("BuscarAnios")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<Anio_Entity>> BuscarAnios(LOGIN_Entity entidad)
        {
            LOGIN_Domain oDominio = new LOGIN_Domain();
            return await oDominio.BuscarAnios(entidad);
        }


        [HttpPost("BuscarEmpresas")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<Empresa_Entity>> BuscarEmpresas(LOGIN_Entity entidad)
        {
            LOGIN_Domain oDominio = new LOGIN_Domain();
            return await oDominio.BuscarEmpresas(entidad);
        }

        [HttpPost("BuscarPuntosVenta")]
        [Authorize(Roles = "Administrator,User")]
        public async Task<List<PuntoVenta_Entity>> BuscarPuntosVenta(LOGIN_Entity entidad)
        {
            LOGIN_Domain oDominio = new LOGIN_Domain();
            return await oDominio.BuscarPuntosVenta(entidad);
        }

        #endregion
    }
}
