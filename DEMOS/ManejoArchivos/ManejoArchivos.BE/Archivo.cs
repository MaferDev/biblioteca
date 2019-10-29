using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Layout;
using iText.IO.Image;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Font;
using iText.IO.Font;
using iText.Kernel.Colors;

namespace ManejoArchivos.BE
{
    public class Archivo
    {
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

        public static bool MoverArchivo()
        {

            string rutaInicial = @"D:\Biopsia.jpg";
            string rutaFinal = @"\\192.168.0.15\biopsias3\Biopsia.jpg";

            if (!Directory.Exists(@"\\192.168.0.15\biopsias3"))
            {
                Directory.CreateDirectory(@"\\192.168.0.15\biopsias3");
            }

            if (File.Exists(rutaInicial))
            {
                File.Move(rutaInicial, rutaFinal);
                return true;
            }
            else
            {
                return false;
            }

        }


        public static bool GenerarArchivoAgrupado(List<string> Lista_PDFs, string docSalida, out string strMensaje)
        {
            bool state = false;
            try
            {
                using (PdfDocument pdf = new PdfDocument(new PdfWriter(docSalida)))
                {
                    PdfMerger merger = new PdfMerger(pdf);

                    foreach (string archivo in Lista_PDFs)
                    {
                        //Agregamos las paginas del nuevo documento al documento base
                        using (PdfDocument sourcePdf = new PdfDocument(new PdfReader(@archivo)))
                        {
                            merger.Merge(sourcePdf, 1, sourcePdf.GetNumberOfPages());
                        }
                    }
                }
                state = true;
                strMensaje = "Documento Creado";
            }
            catch (Exception ex)
            {
                strMensaje = ex.Message;
            }

            return state;
        }

        public static bool FirmarArchivo(string strInforme, string strFirma,string strHuella, out string strMensaje)
        {
            bool state = false;

            string strInformeFirmado = strInforme.Split('.')[0] + "_firmado.pdf";
            try
            {
                PdfDocument pdfDocument = new PdfDocument(new PdfReader(strInforme), new PdfWriter(strInformeFirmado));

                /*Poner estructura de firma y huella*/
                PdfCanvas canvas = new PdfCanvas(pdfDocument.GetPage(1));
                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(FontConstants.HELVETICA), 8)
                    .MoveText(50, 89).ShowText("___________________").EndText();

                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(FontConstants.HELVETICA), 8)
                    .MoveText(59, 79).ShowText("Firma del Paciente").EndText();

//                canvas.Rectangle(140, 89, 48, 52);
  //              canvas.Stroke();

                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(FontConstants.HELVETICA), 8)
                    .MoveText(152, 79).ShowText("Huella").EndText();


                using (Document document = new Document(pdfDocument))
                {
                    // Cargamos la imagen desde la firma
                    ImageData imageDataFirma = ImageDataFactory.Create(strFirma);
                    ImageData imageDataBorde= ImageDataFactory.Create(ConfigurationManager.AppSettings["strRaiz"]+ "borde.jpg");
                    ImageData imageDataHuella = ImageDataFactory.Create(strHuella);

                    // Crear objeto de imagen de diseño y proporcionar parámetros.Número de página = 1
                    Image imageFirma = new Image(imageDataFirma).ScaleAbsolute(84, 30).SetFixedPosition(1, 50, 90);
                    Image ImageBorde = new Image(imageDataBorde).ScaleAbsolute(53, 57).SetFixedPosition(1, 139, 86);
                    Image imageHuella = new Image(imageDataHuella).ScaleAbsolute(46, 50).SetFixedPosition(1, 143, 89);

                    // Agregamos la firma al documento
                    document.Add(imageFirma);
                    document.Add(ImageBorde);
                    document.Add(imageHuella);
                }
                state = true;

                strMensaje = string.Empty;
            }
            catch (Exception ex)
            {
                strMensaje = ex.Message;
            }
            return state;
        }


    }
}
