using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Layer.Entity;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Configuration;


namespace Layer.AccessData
{
    public class LOGIN_Data
    {
        private static string ConnectionString()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            var cadenaConexion = config["ConnectionStrings:ConnectionString"];

            return cadenaConexion;
        }

        public async Task<List<PuntoVenta_Entity>> BuscarPuntosVenta(String Accion, LOGIN_Entity entidad)
        {
            var lista = new List<PuntoVenta_Entity>();

            using (SqlConnection conexion = new SqlConnection(ConnectionString()))
            {
                try
                {
                    await conexion.OpenAsync();

                    SqlCommand cmd = new SqlCommand("sp_WS_LOGIN", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = Accion;
                    cmd.Parameters.Add(new SqlParameter("@usu_cCodUsuario", SqlDbType.VarChar, 50)).Value = entidad.usu_cCodUsuario;
                    cmd.Parameters.Add(new SqlParameter("@Emp_cCodigo", SqlDbType.VarChar, 3)).Value = entidad.Emp_cCodigo;

                    cmd.Connection = conexion;

                    using (var drlector = cmd.ExecuteReader())
                    {
                        while (drlector.Read())
                        {
                            PuntoVenta_Entity oEntidad = new PuntoVenta_Entity();
                            oEntidad.Pvt_cCodigo = drlector["Pvt_cCodigo"].ToString().Trim();
                            oEntidad.Pvt_cDescripcion = drlector["Pvt_cDescripcion"].ToString().Trim();
                            lista.Add(oEntidad);
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }

                finally
                {
                    conexion.Close();
                }
                return lista;
            }
        }

        public async Task<List<Anio_Entity>> BuscarAnios(String Accion, LOGIN_Entity entidad)
        {
            var lista = new List<Anio_Entity>();

            using (SqlConnection conexion = new SqlConnection(ConnectionString()))
            {
                try
                {
                    await conexion.OpenAsync();

                    SqlCommand cmd = new SqlCommand("sp_WS_LOGIN", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = Accion;
                    cmd.Parameters.Add(new SqlParameter("@usu_cCodUsuario", SqlDbType.VarChar, 50)).Value = entidad.usu_cCodUsuario;
                    cmd.Parameters.Add(new SqlParameter("@usu_cClave", SqlDbType.VarChar, 30)).Value = entidad.usu_cClave;
                    cmd.Parameters.Add(new SqlParameter("@Emp_cCodigo", SqlDbType.VarChar, 3)).Value = entidad.Emp_cCodigo;
                    cmd.Parameters.Add(new SqlParameter("@soft_cCodSoft", SqlDbType.VarChar, 3)).Value = entidad.soft_cCodSoft;

                    cmd.Connection = conexion;



                    using (var drlector = cmd.ExecuteReader())
                    {
                        while (drlector.Read())
                        {
                            Anio_Entity oEntidad = new Anio_Entity();
                            oEntidad.Pan_cAnio = drlector["Pan_cAnio"].ToString().Trim();
                            oEntidad.Pan_cEstado = drlector["Pan_cEstado"].ToString().Trim();
                            lista.Add(oEntidad);
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }

                finally
                {
                    conexion.Close();
                }
                return lista;
            }
        }

        public async Task<List<Empresa_Entity>> BuscarEmpresas(String Accion, LOGIN_Entity entidad)
        {
            var lista = new List<Empresa_Entity>();

            using (SqlConnection conexion = new SqlConnection(ConnectionString()))
            {
                try
                {
                    await conexion.OpenAsync();

                    SqlCommand cmd = new SqlCommand("sp_WS_LOGIN", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = Accion;
                    cmd.Parameters.Add(new SqlParameter("@usu_cCodUsuario", SqlDbType.VarChar, 50)).Value = entidad.usu_cCodUsuario;
                    cmd.Parameters.Add(new SqlParameter("@usu_cClave", SqlDbType.VarChar, 30)).Value = entidad.usu_cClave;
                    cmd.Parameters.Add(new SqlParameter("@Emp_cCodigo", SqlDbType.VarChar, 3)).Value = entidad.Emp_cCodigo;
                    cmd.Parameters.Add(new SqlParameter("@soft_cCodSoft", SqlDbType.VarChar, 3)).Value = entidad.soft_cCodSoft;

                    cmd.Connection = conexion;



                    using (var drlector = cmd.ExecuteReader())
                    {
                        while (drlector.Read())
                        {
                            Empresa_Entity oEntidad = new Empresa_Entity();
                            oEntidad.Emp_cCodigo = drlector["Emp_CCodigo"].ToString().Trim();
                            oEntidad.Emp_cNombreLargo = drlector["Emp_cNombreLargo"].ToString().Trim();
                            lista.Add(oEntidad);
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }

                finally
                {
                    conexion.Close();
                }
                return lista;
            }
        }

        public async Task<Respuesta_Entity> ValidaIngreso(String Accion, LOGIN_Entity entidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString()))
            {
                LOGIN_Entity oEntidad = new LOGIN_Entity();
                Respuesta_Entity oRespuesta = new Respuesta_Entity();

                try
                {
                      await conexion.OpenAsync();

                    SqlCommand cmd = new SqlCommand("sp_WS_LOGIN", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = Accion;
                    cmd.Parameters.Add(new SqlParameter("@usu_cCodUsuario", SqlDbType.VarChar, 50)).Value = entidad.usu_cCodUsuario;
                    cmd.Parameters.Add(new SqlParameter("@usu_cClave", SqlDbType.VarChar, 30)).Value = entidad.usu_cClave;
                    cmd.Parameters.Add(new SqlParameter("@Emp_cCodigo", SqlDbType.VarChar, 3)).Value = entidad.Emp_cCodigo;
                    cmd.Parameters.Add(new SqlParameter("@soft_cCodSoft", SqlDbType.VarChar, 3)).Value = entidad.soft_cCodSoft;

                    cmd.Connection = conexion;

                    using (var drlector = cmd.ExecuteReader())
                    {
                        while (drlector.Read())
                        {
                            oRespuesta.Respuesta = drlector["Respuesta"].ToString().Trim();
                            oRespuesta.Nombres = drlector["Nombres"].ToString().Trim();
                            oRespuesta.Role= drlector["Role"].ToString().Trim();
                            oRespuesta.Usuario = entidad.usu_cCodUsuario;
                            oRespuesta.Clave = entidad.usu_cClave;
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }

                finally
                {
                    conexion.Close();
                }

                return oRespuesta;
            }

        }

        public async Task<LOGIN_Entity> ValidacionUsuarioToken(String Accion, LOGIN_Entity entidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConnectionString()))
            {

                LOGIN_Entity oRespuestaUser = new LOGIN_Entity();

                try
                {
                     await conexion.OpenAsync();

                    SqlCommand cmd = new SqlCommand("sp_WS_LOGIN", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Accion", SqlDbType.VarChar, 50)).Value = Accion;
                    cmd.Parameters.Add(new SqlParameter("@usu_cCodUsuario", SqlDbType.VarChar, 50)).Value = entidad.usu_cCodUsuario;
                    cmd.Parameters.Add(new SqlParameter("@usu_cClave", SqlDbType.VarChar, 30)).Value = entidad.usu_cClave;

                    cmd.Connection = conexion;

                    using (var drlector = cmd.ExecuteReader())
                    {
                        while (drlector.Read())
                        {
                            

                            oRespuestaUser.usu_cRole = drlector["usu_cRole"].ToString().Trim();
                            oRespuestaUser.usu_cApellido = drlector["usu_cNombre"].ToString().Trim();
                            oRespuestaUser.usu_cNombre= drlector["usu_cApellido"].ToString().Trim();
                            oRespuestaUser.usu_cCorreo = drlector["usu_cCorreo"].ToString().Trim();
                            oRespuestaUser.usu_cCodUsuario = drlector["Usu_cCodUsuario"].ToString().Trim();
                            oRespuestaUser.usu_cClave = drlector["usu_cClave"].ToString().Trim();

                            
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }

                finally
                {
                    conexion.Close();
                }

                return oRespuestaUser;
            }

        }
    }
}
