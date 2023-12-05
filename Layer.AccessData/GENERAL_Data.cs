using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Layer.Entity;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Layer.AccessData
{
    public static class AttributesExtensions
    {
        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).First();
        }
    }

    public class GENERAL_Data
    {
        #region Funciones-API
        private SqlDbType TipoDato(string oTipo)
        {
            switch (oTipo)
            {
                case "String":
                    return SqlDbType.VarChar;
                case "Int":
                    return SqlDbType.Int;
                case "Int32":
                    return SqlDbType.Int;
                case "Float":
                    return SqlDbType.Float;
                case "Single":
                    return SqlDbType.Float;
                case "Decimal":
                    return SqlDbType.Decimal;
                case "DateTime":
                    return SqlDbType.DateTime;
                default:
                    return SqlDbType.VarChar;
            }
        }

        private Object RetornaTipoclase(string cTipo)
        {
            object oEntidad = new object();

            if (cTipo == "CNT_TIPO_CAMBIO_Entity")
            {
                var oEnt = new CNT_TIPO_CAMBIO_Entity(); oEntidad = oEnt;
            }
            if (cTipo == "TABLA_Entity")
            {
                var oEnt = new TABLA_Entity(); oEntidad = oEnt;
            }
            if (cTipo == "SUNAT_Entity")
            {
                var oEnt = new SUNAT_Entity(); oEntidad = oEnt;
            }
            if (cTipo == "CNT_PERIODO_Entity")
            {
                var oEnt = new CNT_PERIODO_Entity(); oEntidad = oEnt;
            }

            if (cTipo == "MENSAJE_Entity")
            {
                var oEnt = new MENSAJE_Entity(); oEntidad = oEnt;
            }


            #region CLASE GENERAL

            if (cTipo == "CNT_TIPO_MONEDA_Entity")
            {
                var oEnt = new CNT_TIPO_MONEDA_Entity(); oEntidad = oEnt;
            }
            if (cTipo == "CNT_TIPODOC_Entity")
            {
                var oEnt = new CNT_TIPODOC_Entity(); oEntidad = oEnt;
            }
            if (cTipo == "CFG_PARAMETROS_Entity")
            {
                var oEnt = new CFG_PARAMETROS_Entity(); oEntidad = oEnt;
            }
            if (cTipo == "EMPRESA_Entity")
            {
                var oEnt = new EMPRESA_Entity(); oEntidad = oEnt;
            }


            #endregion

            #region CLASE LOGIN

            if (cTipo == "LOGIN_Entity")
            {
                var oEnt = new LOGIN_Entity(); oEntidad = oEnt;
            }
            if (cTipo == "Respuesta_Entity")
            {
                var oEnt = new Respuesta_Entity(); oEntidad = oEnt;
            }
            if (cTipo == "Empresa_Entity")
            {
                var oEnt = new Empresa_Entity(); oEntidad = oEnt;
            }
            if (cTipo == "PuntoVenta_Entity")
            {
                var oEnt = new PuntoVenta_Entity(); oEntidad = oEnt;
            }
            if (cTipo == "Anio_Entity")
            {
                var oEnt = new Anio_Entity(); oEntidad = oEnt;
            }



            #endregion

            return oEntidad;



        }

        #endregion

        #region Funciones-Datos

        public async Task<List<object>> Meses(CNT_PERIODO_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.SeleccionarTodos("spCNT_PERIODO", "BUSCARTODOS", "Layer.Entity", "CNT_PERIODO_Entity", entidad);
        }


        public async Task<List<object>> TipoDocumento(CNT_TIPODOC_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.SeleccionarTodos("spCn_GrabaTipoDocumento", "SEL_VENTA", "Layer.Entity", "CNT_TIPODOC_Entity", entidad);
        }


        public async Task<List<object>> TipoMoneda(CNT_TIPO_MONEDA_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.SeleccionarTodos("spCn_GrabaTipoMoneda", "SEL_ALL", "Layer.Entity", "CNT_TIPO_MONEDA_Entity", entidad);
        }


        public async Task<List<object>> IncluyeIGV(CFG_PARAMETROS_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.SeleccionarTodos("spCFG_PARAMETROS", "BUSCAR_INCLUYEIGV", "Layer.Entity", "CFG_PARAMETROS_Entity", entidad);
        }

        public async Task<List<object>> BuscaTokenNubefact(EMPRESA_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.SeleccionarTodos("spEMPRESA", "SEL_TOKEN_NUBEF", "Layer.Entity", "EMPRESA_Entity", entidad);
        }

        public async Task<List<object>> DatosDetraccion(EMPRESA_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.SeleccionarTodos("spEMPRESA", "BUSCAR_DETRA", "Layer.Entity", "EMPRESA_Entity", entidad);
        }

        public async Task<List<object>> DastosRetencion(EMPRESA_Entity entidad)
        {
            GENERAL_Data oData = new GENERAL_Data();
            return await oData.SeleccionarTodos("spEMPRESA", "BUSCAR_RETEN", "Layer.Entity", "EMPRESA_Entity", entidad);
        }

  



        #endregion


        #region Funciones-Genericas

        public bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
        private Double NE(object Valor)
        {
            if (Valor == null || Valor == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(Valor);
            }
        }

        private string CE(object Valor)
        {
            if (Valor == null)
            {
                return "";
            }
            else
            {
                return Convert.ToString(Valor);
            }
        }

        private DateTime FE(object Valor)
        {
            if (Valor == null || Valor == "")
            {
                return Convert.ToDateTime("01/01/1900");
            }
            else if (Convert.ToDateTime(Valor).Year <= 1900)
            {
                return Convert.ToDateTime("01/01/1900");
            }
            else
            {
                return Convert.ToDateTime(Valor);
            }
        }

        #endregion

        #region Funciones-CRUD

        private static bool FieldExist(IDataRecord myDataRecord, string field)
        {
            int fieldNumber = 0;
            do
            {
                if (myDataRecord.GetName(fieldNumber).ToString().ToLower() == field.ToString().ToLower())
                {
                    return true;
                }
                fieldNumber++;
            }
            while (fieldNumber < myDataRecord.FieldCount);
            return false;
        }

        private static string ConnectionString()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            var cadenaConexion = config["ConnectionStrings:ConnectionString"];

            return cadenaConexion;
        }

        public async Task<List<object>> SeleccionarTodos(string sp, String Accion, string capa, string clase, object entidad)
        {
            string NombreAtributo;
            var tipo = "";
            int decimales;
            int Longitud;

            //------------------------------

            string typeName = capa + "." + clase; // Type.FullName
            string assemblyName = capa; // MyAssembly.FullName or MyAssembly.GetName().Name
            string assemblyQualifiedName = Assembly.CreateQualifiedName(assemblyName, typeName);
            Type myType = Type.GetType(assemblyQualifiedName);

            var lista = new List<object>();


            if (myType != null)
            {
                PropertyInfo[] properties = myType.GetProperties();




                using (SqlConnection conexion = new SqlConnection(ConnectionString()))
                {
                    try
                    {
                        await conexion.OpenAsync();

                        SqlCommand cmd = new SqlCommand(sp, conexion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (PropertyInfo property in properties)
                        {
                            NombreAtributo = property.Name;


                            PropertyInfo myPropInfo = myType.GetProperty(NombreAtributo);

                            //-------------------------------------------------------------------------------------

                            string displayName = string.Empty;
                            CustomAttributeData displayAttribute = myPropInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "DisplayAttribute");

                            if (displayAttribute != null)
                            {
                                displayName = displayAttribute.NamedArguments.FirstOrDefault().TypedValue.Value.ToString();
                            }

                            //-------------------------------------------------------------------------------------


                            if (displayName != "NoParameter")
                            {
                                tipo = myPropInfo.PropertyType.Name;


                                if (tipo == "String")
                                {
                                    var Valor = property.GetValue(entidad);
                                    string ValorPropiedad = "";

                                    ValorPropiedad = CE(Valor);

                                    Longitud = entidad.GetAttributeFrom<MaxLengthAttribute>(NombreAtributo).Length;
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo), Longitud)).Value = ValorPropiedad;
                                }
                                else if (tipo == "DateTime")
                                {
                                    var Valor = property.GetValue(entidad);

                                    DateTime? ValorPropiedad;

                                    ValorPropiedad = FE(Valor);

                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = ValorPropiedad;
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = property.GetValue(entidad);
                                }

                            }
                        }

                        cmd.Connection = conexion;


                        //entidad = null;

                        using (var drlector = cmd.ExecuteReader())
                        {
                            while (drlector.Read())
                            {

                                object oEntidad = RetornaTipoclase(clase);

                                foreach (PropertyInfo property in properties)
                                {
                                    NombreAtributo = property.Name;



                                    PropertyInfo myPropInfo = myType.GetProperty(NombreAtributo);

                                    tipo = myPropInfo.PropertyType.Name;


                                    //-------------------------------------------------------------------------------------

                                    string description = string.Empty;
                                    CustomAttributeData displayAttribute = myPropInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "DisplayAttribute");

                                    decimales = 2;

                                    if (displayAttribute != null)
                                    {
                                        description = displayAttribute.NamedArguments.Last().TypedValue.Value.ToString();

                                        if (IsNumeric(description))
                                        {
                                            decimales = int.Parse(description);
                                        }
                                    }

                                    //-------------------------------------------------------------------------------------



                                    if (FieldExist(drlector, NombreAtributo))
                                    {


                                        var Valor = drlector[NombreAtributo];

                                        if (tipo == "Int" || tipo == "Int16")
                                        {
                                            property.SetValue(oEntidad, Convert.ToInt16(NE(Valor.ToString())));
                                        }
                                        else if (tipo == "Int32")
                                        {
                                            property.SetValue(oEntidad, Convert.ToInt32(NE(Valor.ToString())));
                                        }
                                        else if (tipo == "Float" || tipo == "Single")
                                        {
                                            property.SetValue(oEntidad, Convert.ToSingle(NE(Valor.ToString())));
                                        }
                                        else if (tipo == "Decimal")
                                        {
                                            property.SetValue(oEntidad, Math.Round( Convert.ToDecimal(Valor.ToString()),decimales));
                                        }

                                        else if (tipo == "DateTime")
                                        {
                                            property.SetValue(oEntidad, Convert.ToDateTime(FE(Valor.ToString())));
                                        }
                                        else if (tipo == "String")
                                        {
                                            property.SetValue(oEntidad, Valor.ToString().Trim());
                                        }
                                        else
                                        {
                                        }

                                    }


                                }

                                lista.Add(oEntidad);
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }

                }




            }

            return lista;
        }

        public async Task<object> SeleccionarRegistro(string sp, String Accion, string capa, string clase, object entidad)
        {
            string NombreAtributo;
            var tipo = "";
            int Longitud;

            //------------------------------

            string typeName = capa + "." + clase; // Type.FullName
            string assemblyName = capa; // MyAssembly.FullName or MyAssembly.GetName().Name
            string assemblyQualifiedName = Assembly.CreateQualifiedName(assemblyName, typeName);
            Type myType = Type.GetType(assemblyQualifiedName);



            if (myType != null)
            {
                PropertyInfo[] properties = myType.GetProperties();




                using (SqlConnection conexion = new SqlConnection(ConnectionString()))
                {
                    try
                    {
                        await conexion.OpenAsync();

                        SqlCommand cmd = new SqlCommand(sp, conexion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (PropertyInfo property in properties)
                        {
                            NombreAtributo = property.Name;


                            PropertyInfo myPropInfo = myType.GetProperty(NombreAtributo);

                            //-------------------------------------------------------------------------------------

                            string displayName = string.Empty;
                            CustomAttributeData displayAttribute = myPropInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "DisplayAttribute");

                            if (displayAttribute != null)
                            {
                                displayName = displayAttribute.NamedArguments.FirstOrDefault().TypedValue.Value.ToString();
                            }

                            //-------------------------------------------------------------------------------------


                            if (displayName != "NoParameter")
                            {
                                tipo = myPropInfo.PropertyType.Name;


                                if (tipo == "String")
                                {
                                    var Valor = property.GetValue(entidad);
                                    string ValorPropiedad = "";

                                    ValorPropiedad = CE(Valor);

                                    Longitud = entidad.GetAttributeFrom<MaxLengthAttribute>(NombreAtributo).Length;
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo), Longitud)).Value = ValorPropiedad;
                                }
                                else if (tipo == "DateTime")
                                {
                                    var Valor = property.GetValue(entidad);

                                    DateTime? ValorPropiedad;

                                    ValorPropiedad = FE(Valor);

                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = ValorPropiedad;
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = property.GetValue(entidad);
                                }
                            }
                        }

                        cmd.Connection = conexion;

                        using (var drlector = cmd.ExecuteReader())
                        {
                            while (drlector.Read())
                            {
                                object oEntidad = RetornaTipoclase(clase);

                                foreach (PropertyInfo property in properties)
                                {
                                    NombreAtributo = property.Name;




                                    PropertyInfo myPropInfo = myType.GetProperty(NombreAtributo);

                                    tipo = myPropInfo.PropertyType.Name;

                                    if (FieldExist(drlector, NombreAtributo))
                                    {
                                        var Valor = drlector[NombreAtributo];

                                        if (tipo == "Int" || tipo == "Int16")
                                        {
                                            property.SetValue(oEntidad, Convert.ToInt16(NE(Valor.ToString())));
                                        }
                                        else if (tipo == "Int32")
                                        {
                                            property.SetValue(oEntidad, Convert.ToInt32(NE(Valor.ToString())));
                                        }
                                        else if (tipo == "Float" || tipo == "Single")
                                        {
                                            property.SetValue(oEntidad, Convert.ToSingle(NE(Valor.ToString())));
                                        }
                                        else if (tipo == "Decimal")
                                        {
                                            property.SetValue(oEntidad, Convert.ToDecimal(NE(Valor.ToString())));
                                        }

                                        else if (tipo == "DateTime")
                                        {
                                            property.SetValue(oEntidad, Convert.ToDateTime(FE(Valor.ToString())));
                                        }
                                        else
                                        {
                                            property.SetValue(oEntidad, Valor.ToString().Trim());
                                        }

                                    }


                                }

                                entidad = oEntidad;
                            }


                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }

                }




            }

            return entidad;
        }

        public async Task<MENSAJE_Entity> EliminarRegistro(string sp, String Accion, string capa, string clase, object entidad)
        {
            MENSAJE_Entity oResultado = new MENSAJE_Entity();
            Int32 recordsAffected = 0;

            string NombreAtributo;
            var tipo = "";
            int Longitud;

            //------------------------------

            string typeName = capa + "." + clase; // Type.FullName
            string assemblyName = capa; // MyAssembly.FullName or MyAssembly.GetName().Name
            string assemblyQualifiedName = Assembly.CreateQualifiedName(assemblyName, typeName);
            Type myType = Type.GetType(assemblyQualifiedName);



            if (myType != null)
            {
                PropertyInfo[] properties = myType.GetProperties();

                using (SqlConnection conexion = new SqlConnection(ConnectionString()))
                {
                    try
                    {
                        await conexion.OpenAsync();

                        SqlCommand cmd = new SqlCommand(sp, conexion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (PropertyInfo property in properties)
                        {
                            NombreAtributo = property.Name;


                            PropertyInfo myPropInfo = myType.GetProperty(NombreAtributo);

                            //-------------------------------------------------------------------------------------

                            string displayName = string.Empty;
                            CustomAttributeData displayAttribute = myPropInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "DisplayAttribute");

                            if (displayAttribute != null)
                            {
                                displayName = displayAttribute.NamedArguments.FirstOrDefault().TypedValue.Value.ToString();
                            }

                            //-------------------------------------------------------------------------------------
                            if (displayName != "NoParameter")
                            {
                                tipo = myPropInfo.PropertyType.Name;


                                if (tipo == "String")
                                {
                                    var Valor = property.GetValue(entidad);
                                    string ValorPropiedad = "";

                                    ValorPropiedad = CE(Valor);

                                    Longitud = entidad.GetAttributeFrom<MaxLengthAttribute>(NombreAtributo).Length;
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo), Longitud)).Value = ValorPropiedad;
                                }
                                else if (tipo == "DateTime")
                                {
                                    var Valor = property.GetValue(entidad);

                                    DateTime? ValorPropiedad;

                                    ValorPropiedad = FE(Valor);

                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = ValorPropiedad;
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = property.GetValue(entidad);
                                }
                            }
                        }

                        cmd.Connection = conexion;
                        recordsAffected = cmd.ExecuteNonQuery();

                        oResultado.Codigo = "";
                        oResultado.Mensaje = "";
                        oResultado.Resultado = "OK";
                        oResultado.FilasAfectadas = recordsAffected;
                    }
                    catch (SqlException e)
                    {
                        oResultado.Codigo = e.ErrorCode.ToString();
                        oResultado.Mensaje = e.Message;
                        oResultado.Resultado = "ERROR";
                        oResultado.FilasAfectadas = recordsAffected;
                    }
                    catch (Exception e)
                    {
                        oResultado.Codigo = e.Source;
                        oResultado.Mensaje = e.Message;
                        oResultado.Resultado = "ERROR";
                        oResultado.FilasAfectadas = recordsAffected;
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }

            return oResultado;
        }

        public async Task<MENSAJE_Entity> AnularRegistro(string sp, String Accion, string capa, string clase, object entidad)
        {
            MENSAJE_Entity oResultado = new MENSAJE_Entity();
            Int32 recordsAffected = 0;

            string NombreAtributo;
            var tipo = "";
            int Longitud;

            //------------------------------

            string typeName = capa + "." + clase; // Type.FullName
            string assemblyName = capa; // MyAssembly.FullName or MyAssembly.GetName().Name
            string assemblyQualifiedName = Assembly.CreateQualifiedName(assemblyName, typeName);
            Type myType = Type.GetType(assemblyQualifiedName);



            if (myType != null)
            {
                PropertyInfo[] properties = myType.GetProperties();

                using (SqlConnection conexion = new SqlConnection(ConnectionString()))
                {
                    try
                    {
                        await conexion.OpenAsync();

                        SqlCommand cmd = new SqlCommand(sp, conexion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (PropertyInfo property in properties)
                        {
                            NombreAtributo = property.Name;


                            PropertyInfo myPropInfo = myType.GetProperty(NombreAtributo);

                            //-------------------------------------------------------------------------------------

                            string displayName = string.Empty;
                            CustomAttributeData displayAttribute = myPropInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "DisplayAttribute");

                            if (displayAttribute != null)
                            {
                                displayName = displayAttribute.NamedArguments.FirstOrDefault().TypedValue.Value.ToString();
                            }

                            //-------------------------------------------------------------------------------------
                            if (displayName != "NoParameter")
                            {
                                tipo = myPropInfo.PropertyType.Name;


                                if (tipo == "String")
                                {
                                    var Valor = property.GetValue(entidad);
                                    string ValorPropiedad = "";

                                    ValorPropiedad = CE(Valor);

                                    Longitud = entidad.GetAttributeFrom<MaxLengthAttribute>(NombreAtributo).Length;
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo), Longitud)).Value = ValorPropiedad;
                                }
                                else if (tipo == "DateTime")
                                {
                                    var Valor = property.GetValue(entidad);

                                    DateTime? ValorPropiedad;

                                    ValorPropiedad = FE(Valor);

                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = ValorPropiedad;
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = property.GetValue(entidad);
                                }
                            }
                        }

                        cmd.Connection = conexion;
                        recordsAffected = cmd.ExecuteNonQuery();

                        oResultado.Codigo = "";
                        oResultado.Mensaje = "";
                        oResultado.Resultado = "OK";
                        oResultado.FilasAfectadas = recordsAffected;
                    }
                    catch (SqlException e)
                    {
                        oResultado.Codigo = e.ErrorCode.ToString();
                        oResultado.Mensaje = e.Message;
                        oResultado.Resultado = "ERROR";
                        oResultado.FilasAfectadas = recordsAffected;
                    }
                    catch (Exception e)
                    {
                        oResultado.Codigo = e.Source;
                        oResultado.Mensaje = e.Message;
                        oResultado.Resultado = "ERROR";
                        oResultado.FilasAfectadas = recordsAffected;
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }

            return oResultado;
        }
        public async Task<MENSAJE_Entity> InsertarRegistro(string sp, String Accion, string capa, string clase, object entidad)
        {
            MENSAJE_Entity oResultado = new MENSAJE_Entity();
            Int32 recordsAffected = 0;
            Int32 recordsResult = 0;
            SqlTransaction tran;

            string NombreAtributo;
            var tipo = "";
            int Longitud;

            //------------------------------

            string typeName = capa + "." + clase; // Type.FullName
            string assemblyName = capa; // MyAssembly.FullName or MyAssembly.GetName().Name
            string assemblyQualifiedName = Assembly.CreateQualifiedName(assemblyName, typeName);
            Type myType = Type.GetType(assemblyQualifiedName);



            if (myType != null)
            {
                PropertyInfo[] properties = myType.GetProperties();

                using (SqlConnection conexion = new SqlConnection(ConnectionString()))
                {

                    await conexion.OpenAsync();
                    tran = conexion.BeginTransaction();

                    try
                    {

                        SqlCommand cmd = new SqlCommand(sp, conexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tran;

                        foreach (PropertyInfo property in properties)
                        {
                            NombreAtributo = property.Name;


                            PropertyInfo myPropInfo = myType.GetProperty(NombreAtributo);


                            //-------------------------------------------------------------------------------------

                            string displayName = string.Empty;
                            CustomAttributeData displayAttribute = myPropInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "DisplayAttribute");

                            if (displayAttribute != null)
                            {
                                displayName = displayAttribute.NamedArguments.FirstOrDefault().TypedValue.Value.ToString();
                            }

                            //-------------------------------------------------------------------------------------

                            if (displayName != "NoParameter")
                            {
                                tipo = myPropInfo.PropertyType.Name;


                                if (tipo == "String")
                                {
                                    var Valor = property.GetValue(entidad);
                                    string ValorPropiedad = "";

                                    ValorPropiedad = CE(Valor);

                                    Longitud = entidad.GetAttributeFrom<MaxLengthAttribute>(NombreAtributo).Length;
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo), Longitud)).Value = ValorPropiedad;
                                }
                                else if (tipo == "DateTime")
                                {
                                    var Valor = property.GetValue(entidad);

                                    DateTime? ValorPropiedad;

                                    ValorPropiedad = FE(Valor);

                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = ValorPropiedad;
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = property.GetValue(entidad);
                                }
                            }
                        }

                        cmd.Connection = conexion;

                        recordsResult = cmd.ExecuteNonQuery();

                        if (recordsResult > 0)
                        {
                            recordsAffected = recordsAffected + recordsResult;
                        }

                        tran.Commit();

                        oResultado.Codigo = "";
                        oResultado.Mensaje = "";
                        oResultado.Resultado = "OK";
                        oResultado.FilasAfectadas = recordsAffected;

                    }
                    catch (SqlException e)
                    {
                        oResultado.Codigo = e.ErrorCode.ToString();
                        oResultado.Mensaje = e.Message;
                        oResultado.Resultado = "ERROR";
                        oResultado.FilasAfectadas = recordsAffected;
                    }
                    catch (Exception e)
                    {
                        oResultado.Codigo = e.Source;
                        oResultado.Mensaje = e.Message;
                        oResultado.Resultado = "ERROR";
                        oResultado.FilasAfectadas = recordsAffected;
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            return oResultado;
        }

        public async Task<MENSAJE_Entity> EditarRegistro(string sp, String Accion, string capa, string clase, object entidad)
        {
            MENSAJE_Entity oResultado = new MENSAJE_Entity();
            Int32 recordsAffected = 0;
            Int32 recordsResult = 0;
            SqlTransaction tran;

            string NombreAtributo;
            var tipo = "";
            int Longitud;

            //------------------------------

            string typeName = capa + "." + clase; // Type.FullName
            string assemblyName = capa; // MyAssembly.FullName or MyAssembly.GetName().Name
            string assemblyQualifiedName = Assembly.CreateQualifiedName(assemblyName, typeName);
            Type myType = Type.GetType(assemblyQualifiedName);



            if (myType != null)
            {
                PropertyInfo[] properties = myType.GetProperties();

                using (SqlConnection conexion = new SqlConnection(ConnectionString()))
                {

                    await conexion.OpenAsync();
                    tran = conexion.BeginTransaction();

                    try
                    {

                        SqlCommand cmd = new SqlCommand(sp, conexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = tran;

                        foreach (PropertyInfo property in properties)
                        {
                            NombreAtributo = property.Name;


                            PropertyInfo myPropInfo = myType.GetProperty(NombreAtributo);

                            //-------------------------------------------------------------------------------------

                            string displayName = string.Empty;
                            CustomAttributeData displayAttribute = myPropInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "DisplayAttribute");

                            if (displayAttribute != null)
                            {
                                displayName = displayAttribute.NamedArguments.FirstOrDefault().TypedValue.Value.ToString();
                            }

                            //-------------------------------------------------------------------------------------


                            tipo = myPropInfo.PropertyType.Name;

                            if (displayName != "NoParameter")
                            {
                                if (tipo == "String")
                                {
                                    var Valor = property.GetValue(entidad);
                                    string ValorPropiedad = "";

                                    ValorPropiedad = CE(Valor);

                                    Longitud = entidad.GetAttributeFrom<MaxLengthAttribute>(NombreAtributo).Length;
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo), Longitud)).Value = ValorPropiedad;
                                }
                                else if (tipo == "DateTime")
                                {
                                    var Valor = property.GetValue(entidad);

                                    DateTime? ValorPropiedad;

                                    ValorPropiedad = FE(Valor);

                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = ValorPropiedad;
                                }
                                else
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + NombreAtributo, TipoDato(tipo))).Value = property.GetValue(entidad);
                                }
                            }
                        }

                        cmd.Connection = conexion;

                        recordsResult = cmd.ExecuteNonQuery();

                        if (recordsResult > 0)
                        {
                            recordsAffected = recordsAffected + recordsResult;
                        }

                        tran.Commit();

                        oResultado.Codigo = "";
                        oResultado.Mensaje = "";
                        oResultado.Resultado = "OK";
                        oResultado.FilasAfectadas = recordsAffected;

                    }
                    catch (SqlException e)
                    {
                        oResultado.Codigo = e.ErrorCode.ToString();
                        oResultado.Mensaje = e.Message;
                        oResultado.Resultado = "ERROR";
                        oResultado.FilasAfectadas = recordsAffected;
                    }
                    catch (Exception e)
                    {
                        oResultado.Codigo = e.Source;
                        oResultado.Mensaje = e.Message;
                        oResultado.Resultado = "ERROR";
                        oResultado.FilasAfectadas = recordsAffected;
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            return oResultado;
        }

        #endregion

    }
}
