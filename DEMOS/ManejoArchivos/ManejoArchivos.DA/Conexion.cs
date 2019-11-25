using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ManejoArchivos.DA
{
    public class Conexion
    {
        public static OracleConnection ObtenerConexion()
        {
            string CandenaConexion = ConfigurationManager.ConnectionStrings["ConexionOracle"].ConnectionString;
            //string CandenaConexion = "User ID=SIGESER; Password=T1AG0YD1EG0; Data Source=BDSUIZA;";
            OracleConnection connection = new OracleConnection(CandenaConexion);
            connection.Open();
            return connection;
        }
        public static string GetPackage()
        {
            string Pkg = "PKG_FACTURACION_RIMAC_PREV.";

            return Pkg;
        }
    }
}

