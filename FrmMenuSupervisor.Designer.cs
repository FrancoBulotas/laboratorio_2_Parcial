﻿namespace Frms
{
    partial class FrmMenuSupervisor
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
            botonSalir = new Button();
            dataGridView1 = new DataGridView();
            USUARIO = new DataGridViewTextBoxColumn();
            CONTRASEÑA = new DataGridViewTextBoxColumn();
            TIPO = new DataGridViewTextBoxColumn();
            nombreLogueado = new Label();
            label15 = new Label();
            botonMenuOperarios = new Button();
            label8 = new Label();
            label9 = new Label();
            label6 = new Label();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonComprar = new Button();
            label10 = new Label();
            labelPresupuesto = new Label();
            textBoxPapel = new TextBox();
            textBoxTinta = new TextBox();
            textBoxTroquel = new TextBox();
            textBoxEncuadernacion = new TextBox();
            button1 = new Button();
            button2 = new Button();
            labelPrecioPapel = new Label();
            labelPrecioTinta = new Label();
            labelPrecioTroquel = new Label();
            labelPrecioEncuadernacion = new Label();
            button3 = new Button();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label16 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // botonSalir
            // 
            botonSalir.BackColor = SystemColors.ControlDark;
            botonSalir.Location = new Point(613, 376);
            botonSalir.Margin = new Padding(0);
            botonSalir.Name = "botonSalir";
            botonSalir.Size = new Size(90, 29);
            botonSalir.TabIndex = 8;
            botonSalir.Text = "SALIR";
            botonSalir.UseVisualStyleBackColor = false;
            botonSalir.Click += botonSalir_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { USUARIO, CONTRASEÑA, TIPO });
            dataGridView1.GridColor = Color.Black;
            dataGridView1.Location = new Point(7, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(275, 188);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // USUARIO
            // 
            USUARIO.HeaderText = "USUARIO";
            USUARIO.Name = "USUARIO";
            USUARIO.ReadOnly = true;
            USUARIO.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // CONTRASEÑA
            // 
            CONTRASEÑA.HeaderText = "CONTRASEÑA";
            CONTRASEÑA.Name = "CONTRASEÑA";
            CONTRASEÑA.ReadOnly = true;
            // 
            // TIPO
            // 
            TIPO.HeaderText = "TIPO";
            TIPO.Name = "TIPO";
            TIPO.ReadOnly = true;
            // 
            // nombreLogueado
            // 
            nombreLogueado.AutoSize = true;
            nombreLogueado.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            nombreLogueado.Location = new Point(94, 9);
            nombreLogueado.Name = "nombreLogueado";
            nombreLogueado.Size = new Size(0, 12);
            nombreLogueado.TabIndex = 23;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(7, 9);
            label15.Name = "label15";
            label15.Size = new Size(81, 12);
            label15.TabIndex = 22;
            label15.Text = "Logueado como:";
            // 
            // botonMenuOperarios
            // 
            botonMenuOperarios.BackColor = SystemColors.ControlDark;
            botonMenuOperarios.Location = new Point(508, 376);
            botonMenuOperarios.Margin = new Padding(0);
            botonMenuOperarios.Name = "botonMenuOperarios";
            botonMenuOperarios.Size = new Size(105, 29);
            botonMenuOperarios.TabIndex = 24;
            botonMenuOperarios.Text = "Menu Operarios";
            botonMenuOperarios.UseVisualStyleBackColor = false;
            botonMenuOperarios.Click += botonMenuOperarios_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(652, 190);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 32;
            label8.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(497, 190);
            label9.Name = "label9";
            label9.Size = new Size(165, 15);
            label9.TabIndex = 31;
            label9.Text = "Materiales de encuadernación";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(549, 158);
            label6.Name = "label6";
            label6.Size = new Size(13, 15);
            label6.TabIndex = 30;
            label6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(497, 158);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 29;
            label7.Text = "Troquel";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(539, 125);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 28;
            label4.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(497, 125);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 27;
            label5.Text = "Tintas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(539, 94);
            label3.Name = "label3";
            label3.Size = new Size(13, 15);
            label3.TabIndex = 26;
            label3.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(497, 94);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 25;
            label2.Text = "Papel";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(497, -3);
            label1.Name = "label1";
            label1.Size = new Size(104, 37);
            label1.TabIndex = 33;
            label1.Text = "STOCK ";
            // 
            // buttonComprar
            // 
            buttonComprar.BackColor = SystemColors.Control;
            buttonComprar.ForeColor = SystemColors.ControlText;
            buttonComprar.Location = new Point(314, 68);
            buttonComprar.Name = "buttonComprar";
            buttonComprar.Size = new Size(65, 23);
            buttonComprar.TabIndex = 34;
            buttonComprar.Text = "Comprar";
            buttonComprar.UseVisualStyleBackColor = false;
            buttonComprar.Click += buttonComprar_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(314, 36);
            label10.Name = "label10";
            label10.Size = new Size(82, 15);
            label10.TabIndex = 35;
            label10.Text = "PRESUPUESTO";
            // 
            // labelPresupuesto
            // 
            labelPresupuesto.AutoSize = true;
            labelPresupuesto.Location = new Point(406, 36);
            labelPresupuesto.Name = "labelPresupuesto";
            labelPresupuesto.Size = new Size(0, 15);
            labelPresupuesto.TabIndex = 36;
            // 
            // textBoxPapel
            // 
            textBoxPapel.BorderStyle = BorderStyle.None;
            textBoxPapel.Location = new Point(430, 94);
            textBoxPapel.Name = "textBoxPapel";
            textBoxPapel.PlaceholderText = "Cantidad";
            textBoxPapel.Size = new Size(43, 16);
            textBoxPapel.TabIndex = 37;
            textBoxPapel.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxTinta
            // 
            textBoxTinta.BorderStyle = BorderStyle.None;
            textBoxTinta.Location = new Point(430, 127);
            textBoxTinta.Name = "textBoxTinta";
            textBoxTinta.PlaceholderText = "Cantidad";
            textBoxTinta.Size = new Size(43, 16);
            textBoxTinta.TabIndex = 38;
            textBoxTinta.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxTroquel
            // 
            textBoxTroquel.BorderStyle = BorderStyle.None;
            textBoxTroquel.Location = new Point(430, 160);
            textBoxTroquel.Name = "textBoxTroquel";
            textBoxTroquel.PlaceholderText = "Cantidad";
            textBoxTroquel.Size = new Size(43, 16);
            textBoxTroquel.TabIndex = 39;
            textBoxTroquel.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxEncuadernacion
            // 
            textBoxEncuadernacion.BorderStyle = BorderStyle.None;
            textBoxEncuadernacion.Location = new Point(430, 192);
            textBoxEncuadernacion.Name = "textBoxEncuadernacion";
            textBoxEncuadernacion.PlaceholderText = "Cantidad";
            textBoxEncuadernacion.Size = new Size(43, 16);
            textBoxEncuadernacion.TabIndex = 40;
            textBoxEncuadernacion.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.Location = new Point(-5, 227);
            button1.Name = "button1";
            button1.Size = new Size(728, 10);
            button1.TabIndex = 41;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(298, -3);
            button2.Name = "button2";
            button2.Size = new Size(10, 240);
            button2.TabIndex = 42;
            button2.UseVisualStyleBackColor = true;
            // 
            // labelPrecioPapel
            // 
            labelPrecioPapel.AutoSize = true;
            labelPrecioPapel.Location = new Point(357, 94);
            labelPrecioPapel.Name = "labelPrecioPapel";
            labelPrecioPapel.Size = new Size(0, 15);
            labelPrecioPapel.TabIndex = 43;
            // 
            // labelPrecioTinta
            // 
            labelPrecioTinta.AutoSize = true;
            labelPrecioTinta.Location = new Point(357, 128);
            labelPrecioTinta.Name = "labelPrecioTinta";
            labelPrecioTinta.Size = new Size(0, 15);
            labelPrecioTinta.TabIndex = 44;
            labelPrecioTinta.Click += labelPrecioTinta_Click;
            // 
            // labelPrecioTroquel
            // 
            labelPrecioTroquel.AutoSize = true;
            labelPrecioTroquel.Location = new Point(357, 161);
            labelPrecioTroquel.Name = "labelPrecioTroquel";
            labelPrecioTroquel.Size = new Size(0, 15);
            labelPrecioTroquel.TabIndex = 45;
            // 
            // labelPrecioEncuadernacion
            // 
            labelPrecioEncuadernacion.AutoSize = true;
            labelPrecioEncuadernacion.Location = new Point(357, 192);
            labelPrecioEncuadernacion.Name = "labelPrecioEncuadernacion";
            labelPrecioEncuadernacion.Size = new Size(0, 15);
            labelPrecioEncuadernacion.TabIndex = 46;
            // 
            // button3
            // 
            button3.Location = new Point(481, -3);
            button3.Name = "button3";
            button3.Size = new Size(10, 240);
            button3.TabIndex = 47;
            button3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(314, -3);
            label11.Name = "label11";
            label11.Size = new Size(144, 37);
            label11.TabIndex = 48;
            label11.Text = "MERCADO";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(396, 94);
            label12.Name = "label12";
            label12.Size = new Size(36, 15);
            label12.TabIndex = 49;
            label12.Text = "/ Uni.";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(396, 193);
            label13.Name = "label13";
            label13.Size = new Size(36, 15);
            label13.TabIndex = 50;
            label13.Text = "/ Uni.";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(396, 161);
            label14.Name = "label14";
            label14.Size = new Size(36, 15);
            label14.TabIndex = 51;
            label14.Text = "/ Uni.";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(396, 128);
            label16.Name = "label16";
            label16.Size = new Size(24, 15);
            label16.TabIndex = 52;
            label16.Text = "/ L.";
            // 
            // FrmMenuSupervisor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 414);
            Controls.Add(label16);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(button3);
            Controls.Add(labelPrecioEncuadernacion);
            Controls.Add(labelPrecioTroquel);
            Controls.Add(labelPrecioTinta);
            Controls.Add(labelPrecioPapel);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBoxEncuadernacion);
            Controls.Add(textBoxTroquel);
            Controls.Add(textBoxTinta);
            Controls.Add(textBoxPapel);
            Controls.Add(labelPresupuesto);
            Controls.Add(label10);
            Controls.Add(buttonComprar);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(botonMenuOperarios);
            Controls.Add(nombreLogueado);
            Controls.Add(label15);
            Controls.Add(dataGridView1);
            Controls.Add(botonSalir);
            Name = "FrmMenuSupervisor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMenu";
            Load += FrmMenu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button botonSalir;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn USUARIO;
        private DataGridViewTextBoxColumn CONTRASEÑA;
        private DataGridViewTextBoxColumn TIPO;
        private Label nombreLogueado;
        private Label label15;
        private Button botonMenuOperarios;
        private Label label8;
        private Label label9;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button buttonComprar;
        private Label label10;
        private Label labelPresupuesto;
        private TextBox textBoxPapel;
        private TextBox textBoxTinta;
        private TextBox textBoxTroquel;
        private TextBox textBoxEncuadernacion;
        private Button button1;
        private Button button2;
        private Label labelPrecioPapel;
        private Label labelPrecioTinta;
        private Label labelPrecioTroquel;
        private Label labelPrecioEncuadernacion;
        private Button button3;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label16;
    }
}