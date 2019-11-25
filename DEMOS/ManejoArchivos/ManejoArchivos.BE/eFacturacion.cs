using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoArchivos.BE
{
    public class eFacturacion:Base
    {
        public string codticket { get; set; }
        public string ticket { get; set; }
        public string fecini { get; set; }
        public string fecfin { get; set; }
        public DateTime fecha { get; set; }
        public string numfac { get; set; }
        public string serfac { get; set; }
        public DateTime fecfac { get; set; }
        public string numcia { get; set; }
        public string ruccia { get; set; }
        public string paciente { get; set; }
        public decimal totsol { get; set; }
        public decimal totdebe { get; set; }
        public decimal totalventa { get; set; }
        public decimal debeventa { get; set; }
        public string numoscab { get; set; }
        public string peroscab { get; set; }
        public string anooscab { get; set; }
        public string numemp { get; set; }
        public string numsuc { get; set; }
        public decimal tipocambio { get; set; }
        public string numtdven { get; set; }
        public string numautoreg { get; set; }

        //public string strFile { get; set; }

        public string biopsia { get; set; }
        public string firma { get; set; }
        public string huella { get; set; }
        public string obs1 { get; set; }
        public string adjunto1 { get; set; }
        public string adjunto2 { get; set; }


        protected bool Disposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            Disposed = true;
        }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
