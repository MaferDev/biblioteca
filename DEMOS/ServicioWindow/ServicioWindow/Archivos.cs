using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

using System.Timers;

namespace ServicioWindow
{
    partial class Archivos : ServiceBase
    {
        /// <summary>
        /// This event is fired whenever the scheduling criteria is met.
        /// Run your code in the handler.
        /// </summary>
        bool blBandera = false;
        private string timeString;
        private Timer stLapso = null;
        public Archivos()
        {
            Log.WriteEventLog("*****************  --Evento Iniciado--  *****************");
            Log.WriteEventLog("*********************************************************");
            stLapso = new Timer();
            stLapso.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            stLapso.Interval = 10000;
            stLapso.Enabled = true;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: agregar código aquí para iniciar el servicio.                        
            Log.WriteEventLog("*********************************************************");
            Log.WriteEventLog("******************  --Evento START--  *******************");
            Log.WriteEventLog("*********************************************************");
            
            stLapso = new Timer();
            stLapso.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            stLapso.Interval = 10000;
            stLapso.Enabled = true;
        }

        protected override void OnStop()
        {
            stLapso.Stop();
            stLapso = null;
            Log.WriteEventLog("******************  --Evento STOP--  ********************");
            Log.WriteEventLog("***********  Servicio cerrado por usuario  **************");
            Log.WriteEventLog("*********************************************************");
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.timeString = ConfigurationManager.AppSettings["timeStartService"].ToString();
            stLapso.Stop();
            SetTimer();
            
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
                        EventLog.WriteEntry("Se copio el archivo con existo", EventLogEntryType.Information);
                        Log.WriteEventLog("Se copio el archivo con existo");
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

        private void SetTimer()
        {
            DateTime t = DateTime.Parse(this.timeString);
            TimeSpan ts = new TimeSpan();

            ts = t - DateTime.Now;
            if (ts.TotalMilliseconds < 0)
            {
                ts = t.AddDays(1) - DateTime.Now;
            }            
            stLapso.Interval = ts.TotalMilliseconds;
            stLapso.Start();
        }

    }
}
