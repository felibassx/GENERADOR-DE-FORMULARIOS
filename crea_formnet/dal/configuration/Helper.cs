using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dal
{
    public class Helper
    {
        //private static SqlConnection getConnection()
        //{

        //    //Obtiene la instacia activa de la conexion y de no existir la crea median patron singleton mejorado
        //    return GetConnection(ConfigurationManager.ConnectionStrings["db_connect"].ConnectionString);

        //}

        private static string strCnnApp
        {
            //Obtiene la cadena de conexion para la base 
            get { return ConfigurationManager.ConnectionStrings["db_connect"].ConnectionString; }

        }
        
        /// <summary>
        /// Ejecuta un procedimiento almacenado, comunmente utilizado para insert, update y delete
        /// </summary>
        /// <param name="strNombreSP">Procedimiento almacenado que se desea utilizar</param>
        /// <param name="_parametros">Diccionario con los parametros que se le entregan al metodo. Las key del dictionary deben ser las mismas que se utilizan dentro del SP para identificar el parametro</param>
        /// <returns></returns>
        public static bool executeProcedure(string strNombreSP, Dictionary<string, object> _parametros)
        {
            int contParametros = 0;
            

            try
            {

                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = strNombreSP;

                    if (_parametros != null & _parametros.Count > 0)
                    {
                        SqlParameter[] _params = new SqlParameter[_parametros.Count];
                        SqlParameter _param;
                        foreach (KeyValuePair<string, object> value in _parametros)
                        {
                            _param = new SqlParameter();
                            _param.ParameterName = value.Key;
                            _param.Value = value.Value;
                            _params[contParametros] = _param;

                            contParametros++;
                        }
                        cmd.Parameters.AddRange(_params);
                    }
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;

            }
            
        }

        /// <summary>
        /// Obtiene una lista de registro desde la base de datos
        /// </summary>
        /// <param name="strNombreSP"></param>
        /// <returns></returns>
        public static IList<Dictionary<string, object>> getObject(string strNombreSP)
        {


            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = strNombreSP;
            Dictionary<string, object> _Valor = new Dictionary<string, object>();
            IList<Dictionary<string, object>> listValores = new List<Dictionary<string, object>>();

            try
            {

                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = strNombreSP;
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _Valor = new Dictionary<string, object>();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            _Valor.Add(dr.GetName(i), dr[i]);
                        }
                        listValores.Add(_Valor);
                    }
                    dr.Close();
                    return listValores;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
           
        }

        /// <summary>
        /// Obtiene una lista de registro desde la base de datos, con parametros de entrada
        /// </summary>
        /// <param name="strNombreSP"></param>
        /// <returns></returns>
        public static IList<Dictionary<string, object>> getObject(string strNombreSP, Dictionary<string, object> _parametros)
        {

            int contParametros = 0;
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = strNombreSP;
            Dictionary<string, object> _Valor = new Dictionary<string, object>();
            IList<Dictionary<string, object>> listValores = new List<Dictionary<string, object>>();

            try
            {

                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = strNombreSP;

                    if (_parametros != null & _parametros.Count > 0)
                    {
                        SqlParameter[] _params = new SqlParameter[_parametros.Count];
                        SqlParameter _param;
                        foreach (KeyValuePair<string, object> value in _parametros)
                        {
                            _param = new SqlParameter();
                            _param.ParameterName = value.Key;
                            _param.Value = value.Value;
                            _params[contParametros] = _param;

                            contParametros++;
                        }
                        cmd.Parameters.AddRange(_params);
                    }
                    
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _Valor = new Dictionary<string, object>();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            _Valor.Add(dr.GetName(i), dr[i]);
                        }
                        listValores.Add(_Valor);
                    }
                    dr.Close();
                    return listValores;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta un select y devuelve un dictionary solo key y value solo se debe tener la precaucion que el primer campo del select debe ser ID y el Segundo Value
        /// </summary>
        /// <param name="strNombreSP"></param>
        /// <param name="_parametros"></param>
        /// <returns>Devuelve un dictionary ideal para carga de combos y listas de id y valor</returns>
        public static Dictionary<string, string> getObject_KeyValue(string strNombreSP, Dictionary<string, object> _parametros)
        {

            int contParametros = 0;
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = strNombreSP;
            Dictionary<string, string> _Valor = new Dictionary<string, string>();


            try
            {

                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = strNombreSP;

                    if (_parametros != null & _parametros.Count > 0)
                    {
                        SqlParameter[] _params = new SqlParameter[_parametros.Count];
                        SqlParameter _param;
                        foreach (KeyValuePair<string, object> value in _parametros)
                        {
                            _param = new SqlParameter();
                            _param.ParameterName = value.Key;
                            _param.Value = value.Value;
                            _params[contParametros] = _param;

                            contParametros++;
                        }
                        cmd.Parameters.AddRange(_params);
                    }
                    
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        _Valor.Add(dr[0].ToString(), dr[1].ToString());

                    }
                    dr.Close();
                    return _Valor;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta un select y devuelve un dictionary solo key y value solo se debe tener la precaucion que el primer campo del select debe ser ID y el Segundo Value
        /// </summary>
        /// <param name="strNombreSP"></param>
        /// <returns>Devuelve un dictionary ideal para carga de combos y listas de id y valor</returns>
        public static Dictionary<string, string> getObject_KeyValue(string strNombreSP)
        {


            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = strNombreSP;
            Dictionary<string, string> _Valor = new Dictionary<string, string>();


            try
            {

                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = strNombreSP;

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        _Valor.Add(dr[0].ToString(), dr[1].ToString());

                    }
                    dr.Close();
                    return _Valor;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta un SP generalmente cuando se requiere devolver solo un valor y es retornado tipo Object
        /// </summary>
        /// <param name="strNombreSP">Nombre de procedimiento almacenado</param>
        /// <param name="_parametros">Dictionary de tipo (string,object) donde se envia el nombre del parametro y el valor en el mismo orden</param>
        /// <returns>Un object con el valor solicitado</returns>
        public static object getScalar(string strNombreSP, Dictionary<string, object> _parametros)
        {

            int contParametros = 0;

            try
            {

                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = strNombreSP;

                    if (_parametros != null & _parametros.Count > 0)
                    {
                        SqlParameter[] _params = new SqlParameter[_parametros.Count];
                        SqlParameter _param;
                        foreach (KeyValuePair<string, object> value in _parametros)
                        {
                            _param = new SqlParameter();
                            _param.ParameterName = value.Key;
                            _param.Value = value.Value;
                            _params[contParametros] = _param;

                            contParametros++;
                        }
                        cmd.Parameters.AddRange(_params);
                    }
                    

                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta un SP generalmente cuando se requiere devolver solo un valor y es retornado tipo Object
        /// </summary>
        /// <param name="strNombreSP">Nombre de procedimiento almacenado</param>
        /// <returns>Un object con el valor solicitado</returns>
        public static object getScalar(string strNombreSP)
        {


            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = strNombreSP;


            try
            {
                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = strNombreSP;

                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta un Select, devuelve una lista segun el tipo enviado
        /// </summary>
        /// <typeparam name="TEntity">Entidad a la cual desea ser mapeada</typeparam>
        /// <param name="strNombreSP">Nombre del sp</param>
        /// <param name="_parametros">Parametros</param>
        /// <returns></returns>
        public static IList<TEntity> getObject<TEntity>(string strNombreSP, Dictionary<string, object> _parametros) where TEntity : class,new()
        {

            int contParametros = 0;
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = strNombreSP;
            Dictionary<string, object> _Valor = new Dictionary<string, object>();
            IList<Dictionary<string, object>> listValores = new List<Dictionary<string, object>>();

            try
            {

                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = strNombreSP;

                    if (_parametros != null & _parametros.Count > 0)
                    {
                        SqlParameter[] _params = new SqlParameter[_parametros.Count];
                        SqlParameter _param;
                        foreach (KeyValuePair<string, object> value in _parametros)
                        {
                            _param = new SqlParameter();
                            _param.ParameterName = value.Key;
                            _param.Value = value.Value;
                            _params[contParametros] = _param;

                            contParametros++;
                        }
                        cmd.Parameters.AddRange(_params);
                    }

                    //cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _Valor = new Dictionary<string, object>();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            _Valor.Add(dr.GetName(i), dr[i]);
                        }
                        listValores.Add(_Valor);
                    }
                    dr.Close();

                    Mapper<TEntity> mapper = new Mapper<TEntity>();
                    IList<TEntity> _list = mapper.Map(listValores);

                    return _list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta un Select, devuelve una lista segun el tipo enviado
        /// </summary>
        /// <typeparam name="TEntity">Entidad a la cual desea ser mapeada</typeparam>
        /// <param name="strNombreSP">Nombre del sp</param>
        /// <param name="_parametros">Parametros</param>
        /// <returns></returns>
        public static TEntity getObject<TEntity>(string strNombreSP, Dictionary<string, object> _parametros, bool isMappingSingle) where TEntity : class,new()
        {

            int contParametros = 0;
            Dictionary<string, object> _Valor = new Dictionary<string, object>();

            try
            {
                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = con;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = strNombreSP;

                    if (_parametros != null & _parametros.Count > 0)
                    {
                        foreach (KeyValuePair<string, object> value in _parametros)
                        {
                            command.Parameters.AddWithValue("@" + value.Key, value.Value);
                            contParametros++;
                        }
                    }

                    con.Open();

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        _Valor = new Dictionary<string, object>();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            _Valor.Add(dr.GetName(i), dr[i]);
                        }
                    }

                    dr.Close();

                    if (_Valor.Count > 0)
                    {
                        Mapper<TEntity> mapper = new Mapper<TEntity>();
                        TEntity _list = mapper.Map(_Valor, true);
                        return _list;
                    }
                    else
                    {
                        return null;
                    }
                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta un Select, devuelve una lista segun el tipo enviado
        /// </summary>
        /// <typeparam name="TEntity">Entidad a la cual desea ser mapeada</typeparam>
        /// <param name="strNombreSP"></param>
        /// <returns>IList TEntity </returns>
        public static IList<TEntity> getObject<TEntity>(string strNombreSP) where TEntity : class, new()
        {
            Dictionary<string, object> _Valor = new Dictionary<string, object>();
            IList<Dictionary<string, object>> listValores = new List<Dictionary<string, object>>();

            try
            {
                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    con.Open();
                   
                    using (SqlCommand command = new SqlCommand(strNombreSP, con))
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _Valor = new Dictionary<string, object>();
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                _Valor.Add(dr.GetName(i), dr[i]);
                            }
                            listValores.Add(_Valor);
                        }

                        Mapper<TEntity> mapper = new Mapper<TEntity>();
                        IList<TEntity> _list = mapper.Map(listValores);


                        return _list;
                    }
                }
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta un Select, devuelve una lista segun el tipo enviado
        /// </summary>
        /// <typeparam name="TEntity">Entidad a la cual desea ser mapeada</typeparam>
        /// <param name="strNombreSP"></param>
        /// <returns>IList TEntity </returns>
        public static TEntity getObject<TEntity>(string strNombreSP, bool isMappingSingle) where TEntity : class, new()
        {
            Dictionary<string, object> _Valor = new Dictionary<string, object>();
          
            try
            {

                using (SqlConnection con = new SqlConnection(strCnnApp))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand(strNombreSP, con))
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            _Valor = new Dictionary<string, object>();
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                _Valor.Add(dr.GetName(i), dr[i]);
                            }
                        }

                        Mapper<TEntity> mapper = new Mapper<TEntity>();
                        TEntity _list = mapper.Map(_Valor, true);


                        return _list;
                    }
                }

                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR CONFIGURACION DE LA CAPA DE DATOS, Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Detalle: " + ex.Message);
                throw ex;
            }
        }

    }

}
