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