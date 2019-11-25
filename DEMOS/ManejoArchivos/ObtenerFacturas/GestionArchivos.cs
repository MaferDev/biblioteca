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
using System.Timers;
using System.Net.Mail;
using iText.Layout;
using iText.IO.Image;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Font;
using iText.IO.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;

using ManejoArchivos.BE;
using ManejoArchivos.BL;

namespace ObtenerFacturas
{
    public partial class GestionArchivos : Form
    {

        public eFacturacion objFactura = null;
        public string serfac = "MA1";
        public string numfac = string.Empty;
        public List<string> LstArchivos = new List<string>();

        
        public GestionArchivos()
        {            
            InitializeComponent();
            txtNumFac.Focus();
        }
        private void btnGetInforme_Click(object sender, EventArgs e)
        {
            numfac = txtNumFac.Text.PadLeft(7, '0');
            objFactura = new cnFacturacion().ListaOrdenFacturados(serfac, numfac);

            txtInforme.Text = this.ObtenerInformePreventivo(objFactura);
        }

        private void btnGetFactura_Click(object sender, EventArgs e)
        {
            numfac = txtNumFac.Text.PadLeft(7, '0');
            objFactura = new cnFacturacion().ListaOrdenFacturados(serfac, numfac);
            
            txtFactura.Text = this.ObtenerFactura(objFactura);
        }

        private void btnFirmar_Click(object sender, EventArgs e)
        {
            string Mensaje="";
            int pagina = 0;
            int x = 0;
            int y = 0;
            try
            {
                pagina = 1;
                if (txtX.Text.Length > 0)
                {
                    pagina = Convert.ToInt32(txtPagina.Text);
                    x = Convert.ToInt32(txtX.Text);
                    y = Convert.ToInt32(txtY.Text);
                }

                numfac = txtNumFac.Text.PadLeft(7, '0');
                objFactura = new cnFacturacion().ListaOrdenFacturados(serfac, numfac);
                if (objFactura.firma.Length > 0)
                {
                    txtInformeFirmado.Text = Archivo.FirmarArchivo(txtInforme.Text.ToString(), objFactura, out Mensaje, pagina, x, y);
                    MessageBox.Show(Mensaje, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                string archivo = txtArchivoAdjunto.Text;
                LstArchivos.Add(archivo+".pdf");
                ListaAdjuntos.Items.Add(archivo);
                txtArchivoAdjunto.Text = "";
                txtArchivoAdjunto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            try
            {
                numfac = txtNumFac.Text.PadLeft(7, '0');
                eArchivo objArchivo = new eArchivo();
                objArchivo.Nombre = Variables.ParametroFacturacion.SuizaRuc + "_22_F" + serfac + "_" + numfac + Variables.Archivo.ExtPdf;
                objArchivo = Archivo.GenerarArchivoAgrupado(LstArchivos, objArchivo);
                txtRutaAdjuntado.Text = objArchivo.strPath;
                MessageBox.Show("Se creo el archivo adjunto.!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Se obtiene el informe preventivo
        /// </summary>

        private string ObtenerInformePreventivo(eFacturacion objFacCab)
        {
            string sMsje = string.Empty;
            string strFile = string.Empty;
            string strPath = @ConfigurationManager.AppSettings["strPath"] + Variables.Archivo.FileNameInforme;

            string codticket = objFacCab.numoscab + objFacCab.peroscab + objFacCab.anooscab + objFacCab.numsuc;

            try
            {
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);

                strFile = strPath + @"\" + Variables.Archivo.FileNameInforme + Variables.Archivo.ExtPdf;

                WSResultadosDigitales.wsSuizaDriveSoapClient ws = new WSResultadosDigitales.wsSuizaDriveSoapClient();
                byte[] pdf64 = ws.GetInfPreventivoPac(codticket, out sMsje);

                if (Archivo.GuardarPDF(pdf64, strFile))
                {
                    MessageBox.Show("Se guardo el Informe", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("No se guardo el Informe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return strFile;
        }

        /// <summary>
        /// Se obtiene la factura digital
        /// </summary>
        private string ObtenerFactura(eFacturacion objFacCab)
        {
            string strFile = string.Empty;
            string strPath = @ConfigurationManager.AppSettings["strPath"] + Variables.Archivo.FileNameFactura;
            byte[] pdf64 = null;

            string Ruc = Variables.ParametroFacturacion.SuizaRuc;
            string Serie = objFacCab.serfac;
            string Correlativo = objFacCab.numfac;
            string TipoDocumento = objFacCab.numtdven;
            string Fecha = String.Format("{0:dd/MM/yyyy}", objFacCab.fecfac);
            string MontoTotal = objFacCab.totsol.ToString();
            string nameFile = "";
            try
            {
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);

                strFile = strPath + @"\" + Variables.Archivo.FileNameFactura + "_" + objFacCab.serfac + "_" + objFacCab.numfac + Variables.Archivo.ExtPdf;
                
                WSConsultaComprobantesOnLine.consultService ws = new WSConsultaComprobantesOnLine.consultService();
                string docPDF = ws.getDocumentoPDF(Ruc, TipoDocumento, Serie, Correlativo, Fecha, MontoTotal);
                pdf64 = Convert.FromBase64String(docPDF);
                if (Archivo.GuardarPDF(pdf64, strFile))
                {
                    MessageBox.Show("Se guardo La factura", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nameFile = Variables.Archivo.FileNameFactura + "_" + objFacCab.serfac + "_" + objFacCab.numfac;
                }
                else
                    MessageBox.Show("No se guardo la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nameFile;
        }

        private void cmbAdjuntos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAdjuntos.Text == "FACTURA") txtArchivoAdjunto.Text = @ConfigurationManager.AppSettings["strPath"] + Variables.Archivo.FileNameFactura + @"\" + txtFactura.Text;
            else if (cmbAdjuntos.Text == "INFORME") txtArchivoAdjunto.Text = @ConfigurationManager.AppSettings["strPath"] + Variables.Archivo.FileNameInforme + @"\" + txtInformeFirmado.Text;
            else if (cmbAdjuntos.Text == "BIOPSIA") txtArchivoAdjunto.Text = @ConfigurationManager.AppSettings["strPath"] + @"Biopsia\DataWindow";
            else {
                txtArchivoAdjunto.Clear();
                txtArchivoAdjunto.Focus(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        public void limpiarCampos() {
            txtNumFac.Focus();
            ListaAdjuntos.Items.Clear();
            LstArchivos.Clear();
            txtArchivoAdjunto.Text = "";
            txtFactura.Text = "";
            txtInforme.Text = "";
            txtInformeFirmado.Text = "";
            txtPagina.Text = "";
            txtX.Text = "";
            txtY.Text = "";
            txtNumFac.Text = "";
            txtRutaAdjuntado.Text = "";
        }
    }
}
