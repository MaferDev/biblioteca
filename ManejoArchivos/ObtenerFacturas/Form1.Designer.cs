namespace ObtenerFacturas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPdf = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(156, 22);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(141, 23);
            this.btnPdf.TabIndex = 0;
            this.btnPdf.Text = "Obtener Factura";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(23, 22);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // btnSendMail
            // 
            this.btnSendMail.Location = new System.Drawing.Point(23, 88);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(274, 23);
            this.btnSendMail.TabIndex = 2;
            this.btnSendMail.Text = "Envio de Mail";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 142);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btnPdf);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnSendMail;
    }
}

