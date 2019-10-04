using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

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

            if (Archivo.GenerarArchivoAgrupado(lista_PDFs, docSalida, out strMensaje))
            {
                return Json(new { Success = true , Msg= strMensaje });
            }
            else
            {
                return Json(new { Success = false, Msg = strMensaje });
            }

        }

        [HttpPost]
        public JsonResult FirmarArchivo()
        {
            string docInicial = @"D:\Temps Test\formato.pdf";
            string nombreDocInicial = "SitedAutorización";
            string rutaFirma = @"D:\Temps Test\FDIG.bmp";
            string strMensaje = string.Empty;

            if (Archivo.FirmarArchivo(docInicial, nombreDocInicial, rutaFirma, out strMensaje))
            {
                return Json(new { Success = true, Msg = strMensaje });
            }
            else
            {
                return Json(new { Success = false, Msg = strMensaje });
            }
        }

    }
}