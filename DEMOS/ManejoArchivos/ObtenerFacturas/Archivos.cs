using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

using ManejoArchivos.BE;

namespace ObtenerFacturas
{
    public partial class Archivos : Form
    {
        public Archivos()
        {
            InitializeComponent();
        }

        private void btnFirmaH_Click(object sender, EventArgs e)
        {
            string numoscab = "03128";
            string peroscab = "10";
            string anooscab = "19";
            string numsuc = "02";
            string serfac = "MA1";
            string numfac = "0000001";
            lblEstado.Text = "Se va obtener el informe...";
           // if (ObtenerInformePreventivo(numoscab, peroscab, anooscab, numsuc, serfac, numfac) != "")
            //{
                lblEstado.Text = "Se obtuvo el informe...";

                string docInicial = ConfigurationManager.AppSettings["strRaiz"] + @"Informes\Informe_"+serfac+"_"+numfac+".pdf";                
                string rutaFirma = @"\\192.168.0.15\files$\FHDIGITAL\prod\2019\10\25\03128101902\ATC\FDIG_03128101902.bmp";
                string rutaHuella = @"\\192.168.0.15\files$\FHDIGITAL\prod\2019\10\25\03128101902\ATC\HDIG_03128101902.bmp";
                string strMensaje = string.Empty;

                if (Archivo.FirmarArchivo(docInicial, rutaFirma, rutaHuella, out strMensaje))
                {
                    MessageBox.Show("Se firmo el Informe ", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se firmo el informe "+ strMensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            /*}
            else {
                MessageBox.Show("No se guardo el informe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
                
        }
        private string ObtenerInformePreventivo(string numoscab, string peroscab, string anooscab, string numsuc, string serfac, string numfac)
        {
            string sMsje = string.Empty;
            string strFile = string.Empty;
            string strPath = @ConfigurationManager.AppSettings["strRaiz"] + @"Informes";

            string codticket = numoscab + peroscab + anooscab + numsuc;

            try
            {
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);

                strFile = strPath + @"\Informe_" + serfac + "_" + numfac + ".pdf";

                WSResultadosDigitales.wsSuizaDriveSoapClient ws = new WSResultadosDigitales.wsSuizaDriveSoapClient();
                byte[] pdf64 = ws.GetInfPreventivoPac(codticket, out sMsje);

                if (!GuardarPDF(pdf64, strFile)) 
                    strFile = "";
            }
            catch (Exception ex)
            {                
                strFile = "";
            }

            return strFile;
        }
        private bool GuardarPDF(byte[] pdf64, string strFile)
        {
            bool State = false;
            try
            {
                using (FileStream stream = new FileStream(@strFile, FileMode.Create, FileAccess.Write))
                {
                    stream.Seek(0, SeekOrigin.Begin);

                    long Size = stream.Length + pdf64.Length;
                    for (int i = 0; i < pdf64.Length; i++)
                    {
                        stream.WriteByte(pdf64[i]);
                    }
                    stream.Close();
                    State = true;
                }
            }
            catch (Exception ex)
            {   }
            return State;
        }
        
    }
}
