using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ManejoArchivos.BE;
namespace ManejoArchivos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CopiarArchivo()
        {
            if (Archivo.MoverArchivo())
            {                
                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }

        }

        [HttpPost]
        public JsonResult GenerarArchivoAgrupado()
        {
            //RucEmpresa_SUCRUSAL_SERIE_#FACTURA.PDF
            string docSalida = @"D:\Temps Test\ArchivoFinal.pdf";
            string strMensaje = string.Empty;
            List<string> lista_PDFs = new List<string>();
            //lista_PDFs.Add(@"D:\Temps Test\Documento.pdf");
            //lista_PDFs.Add(@"D:\Temps Test\Informe.pdf");
            lista_PDFs.Add(@"\\192.168.0.15\webformatoszip\25127081802\02102019172022\LAB_YANACGONZALES_02102019172045.pdf");
            lista_PDFs.Add(@"\\192.168.0.15\webformatoszip\25127081802\02102019172022\MEDICINA_YANACGONZALES_02102019172026.pdf");
            lista_PDFs.Add(@"\\192.168.0.15\webformatoszip\25127081802\02102019172022\ODONTO_YANACGONZALES_02102019172035.pdf");
            lista_PDFs.Add(@"\\192.168.0.15\webformatoszip\25127081802\02102019172022\OFTALMO_YANACGONZALES_02102019172038.pdf");

            //if (Archivo.GenerarArchivoAgrupado(lista_PDFs, docSalida, out strMensaje))
            //{
            //    return Json(new { Success = true , Msg= strMensaje });
            //}
            //else
            //{
                return Json(new { Success = false, Msg = strMensaje });
            //}

        }

        [HttpPost]
        public JsonResult FirmarArchivo()
        {
            string docInicial = @"D:\Temps Test\20330025213_02_FMA1_0000001.pdf";
            string nombreDocInicial = "20330025213_02_FMA1_0000001";
            string rutaFirma = @"D:\Temps Test\FDIG.bmp";
            string strMensaje = string.Empty;

            /* if (Archivo.FirmarArchivo(docInicial, nombreDocInicial, rutaFirma, out strMensaje))
             {
                 return Json(new { Success = true, Msg = strMensaje });
             }
             else
             {
                 return Json(new { Success = false, Msg = strMensaje });
             }*/
            return Json(new { Success = false, Msg = strMensaje });
        }

        [HttpPost]
        public JsonResult getFactura()
        {
            string docSalida = @"D:\Facutura.pdf";
            string Ruc = "20330025213";
            string Serie = "FMF1";
            string Correlativo = "0059419";
            string TipoDocumento = "01";
            string Fecha = "02/10/2019";
            //String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(parametros[3]))
            string MontoTotal = "156.99";

            string sMsje = string.Empty;
            System.Data.DataSet val  = xmlResponse(Ruc, TipoDocumento, Serie, Correlativo, Fecha, MontoTotal);




            //byte[] ls_archivo = Convert.FromBase64String(wsF.ToString());


                return Json(new { Success = true, Msg = "Lo que sea" });
            
        }

        private System.Data.DataSet xmlResponse(string Ruc, string TipoDocumento, string Serie, string Correlativo, string Fecha, string MontoTotal)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            try
            {
                string xml;
                xml = "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:ws=\"http://ws.feds/\">" +                
                       "   <soapenv:Body>" +
                       "      <ws:getDocumentoPDF>" +
                       "         <ruc>" + Ruc + "</ruc>" +
                       "         <tipo>" + TipoDocumento + "</tipo>" +
                       "         <serie>" + Serie + "</serie>" +
                       "         <correlativo>" + Correlativo + "</correlativo>" +
                       "         <fecha>" + Fecha + "</fecha>" +
                       "         <total>" + MontoTotal + "</total>" +
                       "      </ws:getDocumentoPDF>" +
                       "   </soapenv:Body>" +
                       "</soapenv:Envelope>";

                string urlconfig = "http://13.59.70.32/wsconsult/wsconsult/consultService?wsdl";

                string url = urlconfig;
                ////string responsestring = "";
                System.Net.HttpWebRequest myReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] buffer = encoding.GetBytes(xml);
                string response;
                myReq.AllowWriteStreamBuffering = false;
                myReq.Method = "POST";
                myReq.ContentType = "text/xml; charset=UTF-8";
                myReq.ContentLength = buffer.Length;
                myReq.Headers.Add("SOAPAction", "");
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender1, certificate, chain, sslPolicyErrors) => true);

                using (Stream post = myReq.GetRequestStream())
                {
                    post.Write(buffer, 0, buffer.Length);
                }

                System.Net.HttpWebResponse myResponse = (System.Net.HttpWebResponse)myReq.GetResponse();

                Stream responsedata = myResponse.GetResponseStream();
                StreamReader responsereader = new StreamReader(responsedata);
                response = responsereader.ReadToEnd();

                ds.ReadXml(new XmlTextReader(new StringReader(response)));
                myResponse.Close();
                responsereader.Close();
                responsedata.Close();
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                ds.Dispose();
            }
        }

    }
}