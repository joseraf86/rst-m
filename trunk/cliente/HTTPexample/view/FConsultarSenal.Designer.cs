﻿namespace RSTmobile.view
{
    partial class FConsultarSenal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FConsultarSenal));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.botonReset = new System.Windows.Forms.PictureBox();
            this.boVolver = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboParroquia = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboMunicipio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboEntidad = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboSenal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboCategoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titulo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.comboParroquia);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboMunicipio);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboEntidad);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboSenal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboCategoria);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboTipo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.titulo);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 268);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.botonReset);
            this.panel2.Controls.Add(this.boVolver);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(1, 227);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 34);
            // 
            // botonReset
            // 
            this.botonReset.Image = ((System.Drawing.Image)(resources.GetObject("botonReset.Image")));
            this.botonReset.Location = new System.Drawing.Point(47, 2);
            this.botonReset.Name = "botonReset";
            this.botonReset.Size = new System.Drawing.Size(31, 30);
            this.botonReset.Click += new System.EventHandler(this.botonReset_Click);
            // 
            // boVolver
            // 
            this.boVolver.Image = ((System.Drawing.Image)(resources.GetObject("boVolver.Image")));
            this.boVolver.Location = new System.Drawing.Point(8, 2);
            this.boVolver.Name = "boVolver";
            this.boVolver.Size = new System.Drawing.Size(20, 30);
            this.boVolver.Click += new System.EventHandler(this.boVolver_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PapayaWhip;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(150, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 30);
            this.button1.TabIndex = 13;
            this.button1.Text = "Consultar";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboParroquia
            // 
            this.comboParroquia.Items.Add("TODOS");
            this.comboParroquia.Location = new System.Drawing.Point(72, 194);
            this.comboParroquia.Name = "comboParroquia";
            this.comboParroquia.Size = new System.Drawing.Size(165, 22);
            this.comboParroquia.TabIndex = 12;
            this.comboParroquia.SelectedIndexChanged += new System.EventHandler(this.comboParroquia_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(5, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.Text = "Parroquia";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboMunicipio
            // 
            this.comboMunicipio.Items.Add("TODOS");
            this.comboMunicipio.Location = new System.Drawing.Point(72, 167);
            this.comboMunicipio.Name = "comboMunicipio";
            this.comboMunicipio.Size = new System.Drawing.Size(165, 22);
            this.comboMunicipio.TabIndex = 10;
            this.comboMunicipio.SelectedIndexChanged += new System.EventHandler(this.comboMunicipio_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(3, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 22);
            this.label5.Text = "Municipio";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboEntidad
            // 
            this.comboEntidad.Items.Add("TODOS");
            this.comboEntidad.Location = new System.Drawing.Point(72, 140);
            this.comboEntidad.Name = "comboEntidad";
            this.comboEntidad.Size = new System.Drawing.Size(165, 22);
            this.comboEntidad.TabIndex = 8;
            this.comboEntidad.SelectedIndexChanged += new System.EventHandler(this.comboEstado_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(4, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.Text = "Estado";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label4.ParentChanged += new System.EventHandler(this.label4_ParentChanged);
            // 
            // comboSenal
            // 
            this.comboSenal.Items.Add("TODOS");
            this.comboSenal.Location = new System.Drawing.Point(72, 104);
            this.comboSenal.Name = "comboSenal";
            this.comboSenal.Size = new System.Drawing.Size(165, 22);
            this.comboSenal.TabIndex = 6;
            this.comboSenal.SelectedIndexChanged += new System.EventHandler(this.comboSenal_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(5, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.Text = "Señal";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboCategoria
            // 
            this.comboCategoria.Items.Add("TODOS");
            this.comboCategoria.Location = new System.Drawing.Point(72, 76);
            this.comboCategoria.Name = "comboCategoria";
            this.comboCategoria.Size = new System.Drawing.Size(165, 22);
            this.comboCategoria.TabIndex = 4;
            this.comboCategoria.SelectedIndexChanged += new System.EventHandler(this.comboCategoria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 22);
            this.label2.Text = "Categoría";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboTipo
            // 
            this.comboTipo.Items.Add("TODOS");
            this.comboTipo.Location = new System.Drawing.Point(72, 49);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(164, 22);
            this.comboTipo.TabIndex = 2;
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.comboTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.Text = "Tipo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // titulo
            // 
            this.titulo.BackColor = System.Drawing.Color.IndianRed;
            this.titulo.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.titulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.titulo.Location = new System.Drawing.Point(0, 14);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(240, 20);
            this.titulo.Text = "Consultar Señal";
            this.titulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.IndianRed;
            this.panel3.Location = new System.Drawing.Point(0, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 34);
            // 
            // FConsultarSenal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "FConsultarSenal";
            this.Text = "RST";
            this.Load += new System.EventHandler(this.FConsultarSenal_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.ComboBox comboCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboMunicipio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboEntidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboSenal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboParroquia;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox boVolver;
        private System.Windows.Forms.PictureBox botonReset;
        private System.Windows.Forms.Panel panel3;

    }
}