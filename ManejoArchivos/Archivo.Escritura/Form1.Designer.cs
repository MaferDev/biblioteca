namespace Archivo.Escritura
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
            this.lblRuta = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.gboxCrear = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRutaArchivoL = new System.Windows.Forms.TextBox();
            this.btnLeerArchivo = new System.Windows.Forms.Button();
            this.lblRutaArchivo = new System.Windows.Forms.Label();
            this.txtDatosArchivo = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCrearArchivo2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCopiarArchivo = new System.Windows.Forms.Button();
            this.gboxCrear.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(10, 22);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(30, 13);
            this.lblRuta.TabIndex = 0;
            this.lblRuta.Text = "Ruta";
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(58, 19);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(170, 20);
            this.txtRuta.TabIndex = 1;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(252, 14);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(95, 28);
            this.btnCrear.TabIndex = 2;
            this.btnCrear.Text = "Crear Archivo";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // gboxCrear
            // 
            this.gboxCrear.Controls.Add(this.txtRuta);
            this.gboxCrear.Controls.Add(this.btnCrear);
            this.gboxCrear.Controls.Add(this.lblRuta);
            this.gboxCrear.Location = new System.Drawing.Point(12, 12);
            this.gboxCrear.Name = "gboxCrear";
            this.gboxCrear.Size = new System.Drawing.Size(368, 67);
            this.gboxCrear.TabIndex = 3;
            this.gboxCrear.TabStop = false;
            this.gboxCrear.Text = "Crear Archivo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDatosArchivo);
            this.groupBox1.Controls.Add(this.txtRutaArchivoL);
            this.groupBox1.Controls.Add(this.btnLeerArchivo);
            this.groupBox1.Controls.Add(this.lblRutaArchivo);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 159);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leer Archivo";
            // 
            // txtRutaArchivoL
            // 
            this.txtRutaArchivoL.Location = new System.Drawing.Point(58, 19);
            this.txtRutaArchivoL.Name = "txtRutaArchivoL";
            this.txtRutaArchivoL.Size = new System.Drawing.Size(170, 20);
            this.txtRutaArchivoL.TabIndex = 4;
            // 
            // btnLeerArchivo
            // 
            this.btnLeerArchivo.Location = new System.Drawing.Point(252, 14);
            this.btnLeerArchivo.Name = "btnLeerArchivo";
            this.btnLeerArchivo.Size = new System.Drawing.Size(95, 28);
            this.btnLeerArchivo.TabIndex = 5;
            this.btnLeerArchivo.Text = "Leer Archivo";
            this.btnLeerArchivo.UseVisualStyleBackColor = true;
            this.btnLeerArchivo.Click += new System.EventHandler(this.btnLeerArchivo_Click);
            // 
            // lblRutaArchivo
            // 
            this.lblRutaArchivo.AutoSize = true;
            this.lblRutaArchivo.Location = new System.Drawing.Point(10, 22);
            this.lblRutaArchivo.Name = "lblRutaArchivo";
            this.lblRutaArchivo.Size = new System.Drawing.Size(30, 13);
            this.lblRutaArchivo.TabIndex = 3;
            this.lblRutaArchivo.Text = "Ruta";
            // 
            // txtDatosArchivo
            // 
            this.txtDatosArchivo.Location = new System.Drawing.Point(13, 52);
            this.txtDatosArchivo.Name = "txtDatosArchivo";
            this.txtDatosArchivo.Size = new System.Drawing.Size(334, 96);
            this.txtDatosArchivo.TabIndex = 6;
            this.txtDatosArchivo.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCrearArchivo2);
            this.groupBox2.Location = new System.Drawing.Point(12, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 67);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Verificar Existencia de archivo";
            // 
            // btnCrearArchivo2
            // 
            this.btnCrearArchivo2.Location = new System.Drawing.Point(13, 19);
            this.btnCrearArchivo2.Name = "btnCrearArchivo2";
            this.btnCrearArchivo2.Size = new System.Drawing.Size(95, 28);
            this.btnCrearArchivo2.TabIndex = 2;
            this.btnCrearArchivo2.Text = "Crear Archivo";
            this.btnCrearArchivo2.UseVisualStyleBackColor = true;
            this.btnCrearArchivo2.Click += new System.EventHandler(this.btnCrearArchivo2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCopiarArchivo);
            this.groupBox3.Location = new System.Drawing.Point(194, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(198, 67);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Crear Directorios y copiar archivos";
            // 
            // btnCopiarArchivo
            // 
            this.btnCopiarArchivo.Location = new System.Drawing.Point(13, 19);
            this.btnCopiarArchivo.Name = "btnCopiarArchivo";
            this.btnCopiarArchivo.Size = new System.Drawing.Size(125, 28);
            this.btnCopiarArchivo.TabIndex = 2;
            this.btnCopiarArchivo.Text = "Copiar Archivos";
            this.btnCopiarArchivo.UseVisualStyleBackColor = true;
            this.btnCopiarArchivo.Click += new System.EventHandler(this.btnCopiarArchivo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxCrear);
            this.Name = "Form1";
            this.Text = "Archivos TXT";
            this.gboxCrear.ResumeLayout(false);
            this.gboxCrear.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.GroupBox gboxCrear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtDatosArchivo;
        private System.Windows.Forms.TextBox txtRutaArchivoL;
        private System.Windows.Forms.Button btnLeerArchivo;
        private System.Windows.Forms.Label lblRutaArchivo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCrearArchivo2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCopiarArchivo;
    }
}

