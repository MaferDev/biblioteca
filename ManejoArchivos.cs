//Copia todos los archivos de un directorio
public void CopiarArchivosDirectorio(){            
    try
    {
        string strRutaorigen = ConfigurationManager.AppSettings["strRutaOrigen"].ToString();
        string strRutadestino = ConfigurationManager.AppSettings["strRutaDestino"].ToString();

        DirectoryInfo di = new DirectoryInfo(strRutaorigen);
        foreach (var archivo in di.GetFiles("*", SearchOption.AllDirectories))
        {
            if (File.Exists(strRutadestino + archivo.Name))
            {
                File.SetAttributes(strRutadestino + archivo.Name, FileAttributes.Normal);
                File.Delete(strRutadestino + archivo.Name);
            }

            File.Copy(strRutaorigen + archivo.Name, strRutadestino + archivo.Name);
            File.SetAttributes(strRutadestino + archivo.Name, FileAttributes.Normal);

            if (File.Exists(strRutadestino + archivo.Name))
            {
                EventLog.WriteEntry("Se copio el archivo con exito", EventLogEntryType.Information);
                Log.WriteEventLog("Se copio el archivo con exito");
            }
            else
            {
                EventLog.WriteEntry("No se copio el archivo.", EventLogEntryType.Warning);
                Log.WriteEventLog("No se copio el archivo");
            }
        }
    }
    catch (Exception ex)
    {
        Log.WriteEventLog(" -- ERROR  --");
        Log.WriteEventLog(ex.Message);
        EventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
    }   
}

//Copia un archivo de un directorio a Otro
public static bool CopiarArchivo()
{
    string rutaInicial = @"\\192.168.0.15\adicionales\2016\10\000331016\000331016-20161123-1.pdf";
    string rutaFinal = @"D:\Carpeta Temporal\000331016-20161123-1.pdf";

    if (!Directory.Exists(@"D:\Carpeta Temporal"))
    {
        Directory.CreateDirectory(@"D:\Carpeta Temporal");
    }

    if (File.Exists(rutaInicial))
    {
        File.Copy(rutaInicial, rutaFinal, true);
        return true;
    }
    else
    {
        return false;
    }
}