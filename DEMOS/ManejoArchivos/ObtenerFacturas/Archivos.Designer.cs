namespace ObtenerFacturas
{
    partial class Archivos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFirmaH = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFirmaH
            // 
            this.btnFirmaH.Location = new System.Drawing.Point(36, 23);
            this.btnFirmaH.Name = "btnFirmaH";
            this.btnFirmaH.Size = new System.Drawing.Size(163, 23);
            this.btnFirmaH.TabIndex = 0;
            this.btnFirmaH.Text = "Firma y huella";
            this.btnFirmaH.UseVisualStyleBackColor = true;
            this.btnFirmaH.Click += new System.EventHandler(this.btnFirmaH_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(228, 23);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(163, 23);
            this.btnGenerar.TabIndex = 1;
            this.btnGenerar.Text = "Obtener informe y firmar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(415, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(63, 74);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(32, 13);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Inicio";
            // 
            // Archivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 233);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnFirmaH);
            this.Name = "Archivos";
            this.Text = "Archivos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFirmaH;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblEstado;
    }
}