using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sPassword = textcode.Text;
            string sDesencriptado = string.Empty;
            int iContador = sPassword.Length;

            int[] aux = new int[] { 3, 24, 8, 10, 34, 17, 20, 21, 21, 3, 24, 8, 10, 34, 17, 20 };

            for (int i = 0; i < iContador; i++)
            {
                sDesencriptado = sDesencriptado + Convert.ToChar(Encoding.ASCII.GetBytes(sPassword.Substring(i, 1))[0] - aux[i]).ToString();
            }

            textResult.Text= sDesencriptado;
        }

        private void textcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void textResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
