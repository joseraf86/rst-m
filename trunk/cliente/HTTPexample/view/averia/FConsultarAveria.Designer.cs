namespace RSTmobile.view
{
    partial class FConsultarAveria
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
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxObservaciones = new System.Windows.Forms.TextBox();
            this.labelMotivo = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxObservaciones);
            this.panel1.Controls.Add(this.labelMotivo);
            this.panel1.Controls.Add(this.labelFecha);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 268);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Observaciones";
            // 
            // textBoxObservaciones
            // 
            this.textBoxObservaciones.BackColor = System.Drawing.Color.PapayaWhip;
            this.textBoxObservaciones.Location = new System.Drawing.Point(15, 161);
            this.textBoxObservaciones.Multiline = true;
            this.textBoxObservaciones.Name = "textBoxObservaciones";
            this.textBoxObservaciones.ReadOnly = true;
            this.textBoxObservaciones.Size = new System.Drawing.Size(205, 40);
            this.textBoxObservaciones.TabIndex = 6;
            this.textBoxObservaciones.TextChanged += new System.EventHandler(this.textBoxObservaciones_TextChanged);
            // 
            // labelMotivo
            // 
            this.labelMotivo.Location = new System.Drawing.Point(90, 88);
            this.labelMotivo.Name = "labelMotivo";
            this.labelMotivo.Size = new System.Drawing.Size(130, 40);
            // 
            // labelFecha
            // 
            this.labelFecha.Location = new System.Drawing.Point(89, 61);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(131, 20);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.Text = "Motivo:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.Text = "Fecha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.IndianRed;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.buttonVolver);
            this.panel3.Location = new System.Drawing.Point(2, 219);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(235, 40);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PapayaWhip;
            this.button2.Location = new System.Drawing.Point(148, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 20);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reparar";
            this.button2.Click += new System.EventHandler(this.buttonReparar_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.BackColor = System.Drawing.Color.PapayaWhip;
            this.buttonVolver.Location = new System.Drawing.Point(13, 8);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(72, 20);
            this.buttonVolver.TabIndex = 0;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 34);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 26);
            this.label1.Text = "Consulta de Averia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FConsultarAveria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "FConsultarAveria";
            this.Text = "RST";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMotivo;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxObservaciones;
    }
}