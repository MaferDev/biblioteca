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
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Xobject;

namespace ManejoArchivos.BE
{
    public class Archivo
    {
        public static string rutaFinal = @"D:\ManejoArchivos-Prueba\Archivos\";
        public static bool CopiarArchivo()
        {
            string rutaInicial = @"\\192.168.0.15\adicionales\2016\10\000331016\000331016-20161123-1.pdf";
            rutaFinal = rutaFinal+@"Copia\";

            if (!Directory.Exists(rutaFinal))
            {
                Directory.CreateDirectory(@"D:\Carpeta Temporal");
            }

            if (File.Exists(rutaInicial))
            {
                File.Copy(rutaInicial, rutaFinal+ "000331016-20161123-1-Copia.pdf", true);
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


        public static string FirmarArchivo(string strInforme, eFacturacion objFact, out string mensaje, int pagina, int x, int y)
        {
            string strInformeCopia = strInforme.Split('.')[0] + "_Firmado" + Variables.Archivo.ExtPdf;
            string strInformeCopia2 = strInforme.Split('.')[0] + "2" + Variables.Archivo.ExtPdf;
            int numPageNew = 0;
            int numSustentos = 0;
            string strSustento = string.Empty;
            string nameFile = "";
            try
            {
                File.Copy(strInforme, strInformeCopia, true);
                File.Copy(strInforme, strInformeCopia2, true);

                PdfDocument pdfDocument = new PdfDocument(new PdfReader(strInformeCopia2), new PdfWriter(strInformeCopia));

                //+160 nutricional
                //Poner estructura de firma y huella
                PdfCanvas canvas = new PdfCanvas(pdfDocument.GetPage(pagina));
                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFontFamilies.HELVETICA), 8)
                    .MoveText(50+x, 59+y).ShowText("___________________").EndText();

                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFontFamilies.HELVETICA), 8)
                    .MoveText(59+x, 49+y).ShowText("Firma del Paciente").EndText();
                if (objFact.huella.Length > 0)
                {
                    canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFontFamilies.HELVETICA), 8)
                    .MoveText(152+x, 49+y).ShowText("Huella").EndText();
                }

                if (objFact.adjunto1.Length > 0)
                    numSustentos++;

                if (objFact.adjunto2.Length > 0)
                    numSustentos++;

                numPageNew = pdfDocument.GetNumberOfPages();

                using (Document document = new Document(pdfDocument))
                {
                    // Cargamos la imagen desde la firma
                    ImageData imageDataFirma = ImageDataFactory.Create(objFact.firma);

                    // Crear objeto de imagen de diseño y proporcionar parámetros.Número de página = 1
                    Image imageFirma = new Image(imageDataFirma).ScaleAbsolute(84, 30).SetFixedPosition(pagina, 50+x, 60+y);

                    // Agregamos la firma al documento
                    document.Add(imageFirma);

                    if (objFact.huella.Length > 0)
                    {
                        ImageData imageDataBorde = ImageDataFactory.Create(AppDomain.CurrentDomain.BaseDirectory + "borde.jpg");
                        ImageData imageDataHuella = ImageDataFactory.Create(objFact.huella);

                        Image ImageBorde = new Image(imageDataBorde).ScaleAbsolute(54, 57).SetFixedPosition(pagina, 139+x, 56+y);
                        Image imageHuella = new Image(imageDataHuella).ScaleAbsolute(46, 50).SetFixedPosition(pagina, 143+x, 59+y);

                        document.Add(ImageBorde);
                        document.Add(imageHuella);
                    }

                    //Incluir Adjuntos al informe
                    for (int i = 1; i <= numSustentos; i++)
                    {
                        if (i == 1) strSustento = objFact.adjunto1;
                        else strSustento = objFact.adjunto2;

                        // Cargamos la imagen desde la firma                    
                        ImageData ImageDataSustento = ImageDataFactory.Create(strSustento);

                        // Crear objeto de imagen de diseño y proporcionar parámetros.Número de página = +1
                        Image imageSustento = new Image(ImageDataSustento).SetAutoScale(true).SetFixedPosition(numPageNew + i, 50, 220);

                        // Agregamos la imagen al documento
                        document.Add(imageSustento);

                        PdfCanvas canvas2 = new PdfCanvas(pdfDocument.GetPage(numPageNew + i));
                        canvas2.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFontFamilies.HELVETICA), 14)
                            .MoveText(230, 790).ShowText("AUTORIZACIÓN").EndText();
                    }
                }
                mensaje = "Informe Firmado";
                nameFile = "Informe_Firmado";
                File.Delete(strInformeCopia2);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message + " -- " + AppDomain.CurrentDomain.BaseDirectory + "borde.jpg";
            }

            return nameFile;
        }       

        public static bool AddImagen(string strInforme, string ImgSustento1, string ImgSustento2, out string Mensaje) 
        {
            bool state = false;            
            string strInformeFirmado = strInforme.Split('.')[0] + "_Adjunto.pdf";
            int numPageNew = 0;
            int numSustentos = 1;
            string strSustento = string.Empty;
            try
            {
                PdfDocument pdfDocument = new PdfDocument(new PdfReader(strInforme), new PdfWriter(strInformeFirmado));
                                
                if (ImgSustento2.Length > 0)
                    numSustentos++;

                numPageNew = pdfDocument.GetNumberOfPages();

                using (Document document = new Document(pdfDocument))
                {
                    for (int i = 1; i <= numSustentos; i++)
                    {
                        if (i == 1) strSustento = ImgSustento1;
                        else strSustento = ImgSustento2;

                        // Cargamos la imagen desde la firma                    
                        ImageData ImageDataSustento = ImageDataFactory.Create(strSustento);                        

                        // Crear objeto de imagen de diseño y proporcionar parámetros.Número de página = +1
                        Image imageSustento = new Image(ImageDataSustento).SetAutoScale(true).SetFixedPosition(numPageNew + i, 50,  220);

                        // Agregamos la imagen al documento
                        document.Add(imageSustento);

                        PdfCanvas canvas = new PdfCanvas(pdfDocument.GetPage(numPageNew + i));
                        canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFontFamilies.HELVETICA), 14)
                            .MoveText(230, 790).ShowText("AUTORIZACIÓN").EndText();
                    }
                }

                state = true;
                Mensaje = string.Empty;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
            return state;
        }


        public static bool GuardarPDF(byte[] pdf64, string strFile)
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
            { }
            return State;
        }
       
        public static eArchivo GenerarArchivoAgrupado(List<string> lista_PDFs, eArchivo objArchivo)
        {
            string strPath = @ConfigurationManager.AppSettings["strPath"] + "InformeFinal";
            string strFile = @"\" + objArchivo.Nombre;

            try
            {
                if (!Directory.Exists(@strPath))
                    Directory.CreateDirectory(@strPath);

                strFile = strPath + strFile;

                using (PdfDocument pdf = new PdfDocument(new PdfWriter(strFile)))
                {
                    PdfMerger merger = new PdfMerger(pdf);

                    foreach (string archivo in lista_PDFs)
                    {
                        //Agregamos las paginas del nuevo documento al documento base
                        using (PdfDocument sourcePdf = new PdfDocument(new PdfReader(@archivo)))
                        {
                            merger.Merge(sourcePdf, 1, sourcePdf.GetNumberOfPages());
                        }
                    }
                    objArchivo.strPath = strFile;

                    foreach (string archivo in lista_PDFs)
                    {
                        File.Delete(archivo);
                    }
                    File.Delete(@ConfigurationManager.AppSettings["strPath"] + Variables.Archivo.FileNameInforme + @"\" + Variables.Archivo.FileNameInforme + Variables.Archivo.ExtPdf);

                }
            }
            catch (Exception ex)
            {
                objArchivo = null;
            }

            return objArchivo;
        }
    }
}
