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

namespace Archivo.Escritura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // true, se agrega las lineas si existe el archivo
            // false, se sobreescribe
            using (StreamWriter sw = new StreamWriter(@txtRuta.Text + @"\temporal.txt", false))
            {
                sw.WriteLine("Esta es la 1 linea en el archivo.");
                sw.WriteLine("Esta es la 2 linea en el archivo.");
                sw.WriteLine("Esta es la 3 linea en el archivo.");
                txtRutaArchivoL.Text = @txtRuta.Text + @"\temporal.txt";
            }
        }

        private void btnLeerArchivo_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(@txtRutaArchivoL.Text))
            {
                string linea;
                txtDatosArchivo.Text = "";
                while ((linea = sr.ReadLine()) != null)
                {
                    txtDatosArchivo.AppendText(linea+"\n");
                }
            }
        }

        private void btnCrearArchivo2_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "temporal.txt";
            string rutaArchivo = @"D:\" + @NombreArchivo;
            if (File.Exists(rutaArchivo))
            {
                //Guid te crea caracteres únicos
                NombreArchivo = "temporal" + Guid.NewGuid().ToString()+".txt";
            }
            
            using (StreamWriter sw = new StreamWriter(@"D:\" + @NombreArchivo, false))
            {
                sw.WriteLine("Esta es la 1 linea en el archivo.");
            }
        }

        private void btnCopiarArchivo_Click(object sender, EventArgs e)
        {
            string rutaInicial = @"\\192.168.0.15\adicionales\2016\10\000331016\000331016-20161123-1.pdf";
            string rutaFinal = @"D:\Carpeta Temporal\000331016-20161123-1.pdf";

            if(!Directory.Exists(@"D:\Carpeta Temporal"))
            {
                Directory.CreateDirectory(@"D:\Carpeta Temporal");
            }

            if (File.Exists(rutaInicial))
            {
                File.Copy(rutaInicial, rutaFinal, true);
                MessageBox.Show("Copiado", "Okey");
            }
            else
            {
                MessageBox.Show("No existe el archivo", "Error");
            }
        }
    }
}
