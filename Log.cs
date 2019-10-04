using System;
using System.Configuration;
using System.IO;

namespace ServicioWindow
{
    public static class Log
    {
        public static void WriteEventLog(string Message)
        {
            string strRutadestino = ConfigurationManager.AppSettings["strRutaDestino"].ToString()+@"\Log";

            string Date = System.DateTime.Now.ToString("dd-MM-yyyy");
            if (!Directory.Exists(strRutadestino))
                Directory.CreateDirectory(strRutadestino);

            using (StreamWriter sw = new StreamWriter(@strRutadestino + @"\ServicioWindows " + Date + ".txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " : " + Message);
                sw.Flush();
            }
        }
    }
}
