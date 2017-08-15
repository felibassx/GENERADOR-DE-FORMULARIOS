using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace dal
{
    public class Instancia
    {
        private static SqlConnection instancia = null;
        private static readonly object padlock = new object();
        static string _str = ConfigurationManager.ConnectionStrings["db_connect"].ConnectionString;
        private Instancia()
        {}

        public static SqlConnection GetConnection
        {
            get
            {
                lock (padlock)
                {
                    if (instancia == null)
                    {
                        instancia = new SqlConnection();
                        instancia.ConnectionString = _str;
                    }
                    return instancia;
                }
            }
        }

        public static void Open()
        {
            if (instancia != null)
                instancia.Open();
        }

        public static void Close()
        {
            if (instancia != null)
                instancia.Close();
        }


    }
}


