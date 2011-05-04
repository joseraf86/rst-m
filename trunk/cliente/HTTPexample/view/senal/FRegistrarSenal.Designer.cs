using System.Drawing;
using System.Windows.Forms;

namespace RSTmobile.view
{
    partial class FRegistrarSenal
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
        /// 

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboCategorias = new System.Windows.Forms.ComboBox();
            this.comboSenales = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboEntidad = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboMunicipios = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboParroquias = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(10, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.Text = "Datos de la Señal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.Text = "Tipo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboTipo
            // 
            this.comboTipo.Location = new System.Drawing.Point(77, 92);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(140, 22);
            this.comboTipo.TabIndex = 3;
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.Text = "Categoría";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 22);
            this.label4.Text = "Señal";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboCategorias
            // 
            this.comboCategorias.Location = new System.Drawing.Point(77, 120);
            this.comboCategorias.Name = "comboCategorias";
            this.comboCategorias.Size = new System.Drawing.Size(538, 22);
            this.comboCategorias.TabIndex = 6;
            this.comboCategorias.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboSenales
            // 
            this.comboSenales.Location = new System.Drawing.Point(77, 148);
            this.comboSenales.Name = "comboSenales";
            this.comboSenales.Size = new System.Drawing.Size(538, 22);
            this.comboSenales.TabIndex = 7;
            this.comboSenales.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 21);
            this.label5.Text = "Coord Y";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 19);
            this.label6.Text = "Coord X";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.Text = "Estado";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBox6
            // 
            this.comboBox6.Items.Add("BUEN ESTADO");
            this.comboBox6.Items.Add("REGULAR");
            this.comboBox6.Items.Add("MAL ESTADO");
            this.comboBox6.Location = new System.Drawing.Point(77, 176);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(140, 22);
            this.comboBox6.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 22);
            this.label8.Text = "Estatus";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBox7
            // 
            this.comboBox7.Items.Add("ACTIVO");
            this.comboBox7.Items.Add("INACTIVO");
            this.comboBox7.Location = new System.Drawing.Point(77, 204);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(140, 22);
            this.comboBox7.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.IndianRed;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(15, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 20);
            this.label9.Text = "Datos de la Ubicación";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.PapayaWhip;
            this.label10.Location = new System.Drawing.Point(14, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 32);
            this.label10.Text = "Entidad Federal";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboEntidad
            // 
            this.comboEntidad.Location = new System.Drawing.Point(78, 262);
            this.comboEntidad.Name = "comboEntidad";
            this.comboEntidad.Size = new System.Drawing.Size(139, 22);
            this.comboEntidad.TabIndex = 18;
            this.comboEntidad.SelectedIndexChanged += new System.EventHandler(this.comboBox8_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.PapayaWhip;
            this.label12.Location = new System.Drawing.Point(15, 294);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 20);
            this.label12.Text = "Municipio";
            // 
            // comboMunicipios
            // 
            this.comboMunicipios.Location = new System.Drawing.Point(79, 292);
            this.comboMunicipios.Name = "comboMunicipios";
            this.comboMunicipios.Size = new System.Drawing.Size(138, 22);
            this.comboMunicipios.TabIndex = 21;
            this.comboMunicipios.SelectedIndexChanged += new System.EventHandler(this.comboBox9_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.PapayaWhip;
            this.label13.Location = new System.Drawing.Point(15, 320);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 22);
            this.label13.Text = "Parroquia";
            // 
            // comboParroquias
            // 
            this.comboParroquias.Location = new System.Drawing.Point(78, 320);
            this.comboParroquias.Name = "comboParroquias";
            this.comboParroquias.Size = new System.Drawing.Size(139, 22);
            this.comboParroquias.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PapayaWhip;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(11, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 20);
            this.button1.TabIndex = 24;
            this.button1.Text = "Volver";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PapayaWhip;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(134, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 20);
            this.button2.TabIndex = 25;
            this.button2.Text = "Registrar";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBox7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.comboBox6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboSenales);
            this.panel1.Controls.Add(this.comboCategorias);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboTipo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 561);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.IndianRed;
            this.panel5.Location = new System.Drawing.Point(0, 350);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(310, 10);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.IndianRed;
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Location = new System.Drawing.Point(0, 511);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(310, 34);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.IndianRed;
            this.panel3.Location = new System.Drawing.Point(0, 234);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 23);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 24);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 389);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(242, 111);
            this.textBox3.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(10, 367);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.Text = "Observaciones";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(82, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(126, 21);
            this.textBox2.TabIndex = 35;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 21);
            this.textBox1.TabIndex = 34;
            // 
            // FRegistrarSenal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.comboParroquias);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboMunicipios);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboEntidad);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "FRegistrarSenal";
            this.Text = "RST";
            this.Load += new System.EventHandler(this.FRegistrarSenal_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboCategorias;
        private System.Windows.Forms.ComboBox comboSenales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboEntidad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboMunicipios;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboParroquias;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Panel panel1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label11;
        private TextBox textBox3;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private Panel panel5;
    }

}