namespace RSTmobile
{
    partial class FAveria
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
            this.observaciones = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboMotivos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fechaAveria = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.botonNotificar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.observaciones);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboMotivos);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.fechaAveria);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 265);
            // 
            // observaciones
            // 
            this.observaciones.Location = new System.Drawing.Point(14, 150);
            this.observaciones.Multiline = true;
            this.observaciones.Name = "observaciones";
            this.observaciones.Size = new System.Drawing.Size(203, 49);
            this.observaciones.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 21);
            this.label4.Text = "Observaciones";
            // 
            // comboMotivos
            // 
            this.comboMotivos.Location = new System.Drawing.Point(78, 93);
            this.comboMotivos.Name = "comboMotivos";
            this.comboMotivos.Size = new System.Drawing.Size(140, 22);
            this.comboMotivos.TabIndex = 5;
            this.comboMotivos.SelectedIndexChanged += new System.EventHandler(this.comboMotivos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 22);
            this.label3.Text = "Motivo";
            // 
            // fechaAveria
            // 
            this.fechaAveria.CustomFormat = "dd/MM/yyyy";
            this.fechaAveria.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaAveria.Location = new System.Drawing.Point(78, 64);
            this.fechaAveria.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.fechaAveria.Name = "fechaAveria";
            this.fechaAveria.Size = new System.Drawing.Size(141, 22);
            this.fechaAveria.TabIndex = 3;
            this.fechaAveria.ValueChanged += new System.EventHandler(this.fechaAveria_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 22);
            this.label2.Text = "Fecha";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.IndianRed;
            this.panel3.Controls.Add(this.botonNotificar);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(0, 210);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(239, 46);
            // 
            // botonNotificar
            // 
            this.botonNotificar.BackColor = System.Drawing.Color.PapayaWhip;
            this.botonNotificar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.botonNotificar.Location = new System.Drawing.Point(141, 13);
            this.botonNotificar.Name = "botonNotificar";
            this.botonNotificar.Size = new System.Drawing.Size(86, 20);
            this.botonNotificar.TabIndex = 1;
            this.botonNotificar.Text = "Notificar";
            this.botonNotificar.Click += new System.EventHandler(this.botonNotificar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PapayaWhip;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(9, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ir a Menú";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 37);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(22, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 24);
            this.label1.Text = "Registro de Averia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FAveria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "FAveria";
            this.Text = "RST";
            this.Load += new System.EventHandler(this.FAveria_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboMotivos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fechaAveria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botonNotificar;
        private System.Windows.Forms.TextBox observaciones;
        private System.Windows.Forms.Label label4;
    }
}