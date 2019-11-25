using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManejoArchivos.BE;
using ManejoArchivos.DA;

namespace ManejoArchivos.BL
{
    public  class cnFacturacion
    {
        public  eFacturacion ListaOrdenFacturados(string serFac, string numfac)
        {
            return new dalFacturacion().ListaOrdenFacturados(serFac, numfac);
        }
    }
}
