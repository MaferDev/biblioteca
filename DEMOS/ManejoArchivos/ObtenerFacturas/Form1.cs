using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ObtenerFacturas
{
    public partial class Form1 : Form
    {
        private static WSResultadosDigitales.UsuarioCia objDriveUser = null;
        public static WSResultadosDigitales.UsuarioCia DataDriveUser
        {
            get { return objDriveUser; }
            set { objDriveUser = value; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            ObtenerInformePreventivo();
            //ObtenerFactura();

        }

        public void ObtenerInformePreventivo()
        {
            string sMsje = string.Empty;
            string ticket = txtCodigo.Text;
            string docSalida = @ConfigurationManager.AppSettings["strRaiz"] + "Informe.pdf";
            try
            {
                WSResultadosDigitales.wsSuizaDriveSoapClient ws = new WSResultadosDigitales.wsSuizaDriveSoapClient();
                byte[] pdf64 = ws.GetInfPreventivoPac(ticket,out sMsje);

                if (GuardarPDF(pdf64, docSalida))
                {
                    MessageBox.Show("Se guardo el Informe "+ sMsje, "Correcto",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("No se guardo el informe","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ObtenerFactura()
        {
            string docSalida = @ConfigurationManager.AppSettings["strRaiz"] + "Factura.pdf";
            byte[] pdf64 = null;
            string Ruc = "20330025213";
            string Serie = "FMF1";
            string Correlativo = "0059848";
            string TipoDocumento = "01";
            string Fecha = "02/10/2019";
            string MontoTotal = "156.99";
            //String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(parametros[3]))
                       
            try
            {   
                WSConsultaComprobantesOnLine.consultService ws = new WSConsultaComprobantesOnLine.consultService();
                string docPDF = ws.getDocumentoPDF(Ruc, TipoDocumento, Serie, Correlativo, Fecha, MontoTotal);
                pdf64 = Convert.FromBase64String(docPDF);
                if (GuardarPDF(pdf64, docSalida))
                {
                    MessageBox.Show("Se guardo La factura", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("No se guardo la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                //throw;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool GuardarPDF(byte[] pdf64,string pathDoc)
        {

            try
            {
                using (FileStream stream = new FileStream(@pathDoc, FileMode.Create, FileAccess.Write))
                {
                    stream.Seek(0, SeekOrigin.Begin);

                    long Size = stream.Length + pdf64.Length;
                    for (int i = 0; i < pdf64.Length; i++)
                    {
                        stream.WriteByte(pdf64[i]);
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
