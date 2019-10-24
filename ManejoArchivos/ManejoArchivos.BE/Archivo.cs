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

        public static bool FirmarArchivo(string docInicial, string nombreDocInicial, string rutaFirma ,out string strMensaje)
        {
            bool state = false;
            string dirTempSited = ConfigurationManager.AppSettings["pathTempSiteds"];
            string pathTempSited = @dirTempSited +@"\"+ nombreDocInicial + ".pdf";
            strMensaje = string.Empty;
            try
            {
                if (!Directory.Exists(@dirTempSited))                
                    Directory.CreateDirectory(@dirTempSited);  

                PdfDocument pdfDocument = new PdfDocument(new PdfReader(docInicial), new PdfWriter(pathTempSited));

                PdfCanvas canvas = new PdfCanvas(pdfDocument.GetPage(2));
                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(FontConstants.HELVETICA), 8)
                    .MoveText(50, 99).ShowText("___________________").EndText();

                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(FontConstants.HELVETICA), 8)
                    .MoveText(59, 89).ShowText("Firma del Paciente").EndText();

                using (Document document = new Document(pdfDocument))
                {
                    // Cargamos la imagen desde la ruta
                    ImageData imageData = ImageDataFactory.Create(rutaFirma);

                    // Crear objeto de imagen de diseño y proporcionar parámetros.Número de página = 1
                    Image image = new Image(imageData).ScaleAbsolute(84, 30).SetFixedPosition(2, 50, 100);

                    // Agregamos la imagen al documento
                    document.Add(image);
                }
                strMensaje = "Documento firmado";
                state = true;
            }
            catch (Exception ex)
            {
                strMensaje = ex.Message;
            }
            return state;
        }
    }
}
