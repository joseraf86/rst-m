namespace RSTmobile.view
{
    partial class FRepararAveria
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
            this.buttonVolver = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonReparar = new System.Windows.Forms.Button();
            this.pickerFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxObservaciones = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonVolver
            // 
            this.buttonVolver.BackColor = System.Drawing.Color.PapayaWhip;
            this.buttonVolver.Location = new System.Drawing.Point(16, 8);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(72, 20);
            this.buttonVolver.TabIndex = 0;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.buttonReparar);
            this.panel1.Controls.Add(this.buttonVolver);
            this.panel1.Location = new System.Drawing.Point(0, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 34);
            // 
            // buttonReparar
            // 
            this.buttonReparar.BackColor = System.Drawing.Color.PapayaWhip;
            this.buttonReparar.Location = new System.Drawing.Point(147, 8);
            this.buttonReparar.Name = "buttonReparar";
            this.buttonReparar.Size = new System.Drawing.Size(73, 20);
            this.buttonReparar.TabIndex = 1;
            this.buttonReparar.Text = "Reparar";
            this.buttonReparar.Click += new System.EventHandler(this.buttonReparar_Click);
            // 
            // pickerFecha
            // 
            this.pickerFecha.CustomFormat = "dd/MM/yyyy";
            this.pickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pickerFecha.Location = new System.Drawing.Point(102, 65);
            this.pickerFecha.Name = "pickerFecha";
            this.pickerFecha.Size = new System.Drawing.Size(88, 22);
            this.pickerFecha.TabIndex = 1;
            this.pickerFecha.ValueChanged += new System.EventHandler(this.pickerFecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 20);
            this.label1.Text = "Reparar Avería";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(42, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.Text = "Fecha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 34);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Observaciones";
            // 
            // textBoxObservaciones
            // 
            this.textBoxObservaciones.Location = new System.Drawing.Point(16, 138);
            this.textBoxObservaciones.Multiline = true;
            this.textBoxObservaciones.Name = "textBoxObservaciones";
            this.textBoxObservaciones.Size = new System.Drawing.Size(204, 69);
            this.textBoxObservaciones.TabIndex = 6;
            this.textBoxObservaciones.TextChanged += new System.EventHandler(this.textBoxObservaciones_TextChanged);
            // 
            // FRepararAveria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.textBoxObservaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pickerFecha);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Menu = this.mainMenu1;
            this.Name = "FRepararAveria";
            this.Text = "RST";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker pickerFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxObservaciones;
        private System.Windows.Forms.Button buttonReparar;
    }
}