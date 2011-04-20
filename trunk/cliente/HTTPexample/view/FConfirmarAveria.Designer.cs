namespace RSTmobile.controller
{
    partial class FConfirmarAveria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSenal = new System.Windows.Forms.Label();
            this.labelMotivo = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelObservaciones = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel1.Controls.Add(this.labelObservaciones);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.labelFecha);
            this.panel1.Controls.Add(this.labelMotivo);
            this.panel1.Controls.Add(this.labelSenal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 268);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 40);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 20);
            this.label1.Text = "Confirmar Avería";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.Text = "Motivo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.Text = "Fecha";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.Text = "Señal";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelSenal
            // 
            this.labelSenal.Location = new System.Drawing.Point(99, 62);
            this.labelSenal.Name = "labelSenal";
            this.labelSenal.Size = new System.Drawing.Size(100, 20);
            // 
            // labelMotivo
            // 
            this.labelMotivo.Location = new System.Drawing.Point(99, 87);
            this.labelMotivo.Name = "labelMotivo";
            this.labelMotivo.Size = new System.Drawing.Size(100, 20);
            // 
            // labelFecha
            // 
            this.labelFecha.Location = new System.Drawing.Point(99, 112);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(100, 20);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.IndianRed;
            this.panel3.Controls.Add(this.buttonEnviar);
            this.panel3.Controls.Add(this.buttonCancelar);
            this.panel3.Location = new System.Drawing.Point(2, 212);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 40);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(15, 11);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(72, 20);
            this.buttonCancelar.TabIndex = 0;
            this.buttonCancelar.Text = "Cancelar";
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(152, 11);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(72, 20);
            this.buttonEnviar.TabIndex = 1;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "Observaciones";
            // 
            // labelObservaciones
            // 
            this.labelObservaciones.Location = new System.Drawing.Point(17, 180);
            this.labelObservaciones.Name = "labelObservaciones";
            this.labelObservaciones.Size = new System.Drawing.Size(100, 20);
            // 
            // FConfirmarAveria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "FConfirmarAveria";
            this.Text = "RST";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelMotivo;
        private System.Windows.Forms.Label labelSenal;
        private System.Windows.Forms.Label labelObservaciones;
        private System.Windows.Forms.Label label5;
    }
}