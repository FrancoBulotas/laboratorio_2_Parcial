namespace Frms
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            botonSalir = new Button();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            USUARIO = new DataGridViewTextBoxColumn();
            CONTRASEÑA = new DataGridViewTextBoxColumn();
            TIPO = new DataGridViewTextBoxColumn();
            Trabajos = new DataGridViewTextBoxColumn();
            nombreLogueado = new Label();
            label15 = new Label();
            botonMenuOperarios = new Button();
            label1 = new Label();
            buttonComprar = new Button();
            textBoxPapel = new TextBox();
            textBoxTinta = new TextBox();
            textBoxTroquel = new TextBox();
            textBoxEncuadernacion = new TextBox();
            labelPrecioPapel = new Label();
            labelPrecioTinta = new Label();
            labelPrecioTroquel = new Label();
            labelPrecioEncuadernacion = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label16 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            dataGridView2 = new DataGridView();
            Material = new DataGridViewTextBoxColumn();
            Cantidad2 = new DataGridViewTextBoxColumn();
            buttonEditarUsr = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, USUARIO, CONTRASEÑA, TIPO, Trabajos });
            dataGridView1.GridColor = Color.Black;
            dataGridView1.Location = new Point(7, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(328, 307);
            dataGridView1.TabIndex = 9;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ID.FillWeight = 105.329971F;
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.Width = 30;
            // 
            // USUARIO
            // 
            USUARIO.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            USUARIO.FillWeight = 92.724205F;
            USUARIO.HeaderText = "USUARIO";
            USUARIO.Name = "USUARIO";
            USUARIO.ReadOnly = true;
            USUARIO.SortMode = DataGridViewColumnSortMode.Programmatic;
            USUARIO.Width = 81;
            // 
            // CONTRASEÑA
            // 
            CONTRASEÑA.FillWeight = 119.714211F;
            CONTRASEÑA.HeaderText = "CONTRASEÑA";
            CONTRASEÑA.Name = "CONTRASEÑA";
            CONTRASEÑA.ReadOnly = true;
            // 
            // TIPO
            // 
            TIPO.FillWeight = 91.11583F;
            TIPO.HeaderText = "TIPO";
            TIPO.Name = "TIPO";
            TIPO.ReadOnly = true;
            // 
            // Trabajos
            // 
            Trabajos.FillWeight = 91.11583F;
            Trabajos.HeaderText = "TRABAJOS HECHOS";
            Trabajos.Name = "Trabajos";
            // 
            // nombreLogueado
            // 
            nombreLogueado.AutoSize = true;
            nombreLogueado.BackColor = Color.Transparent;
            nombreLogueado.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            nombreLogueado.Location = new Point(94, 9);
            nombreLogueado.Name = "nombreLogueado";
            nombreLogueado.Size = new Size(0, 12);
            nombreLogueado.TabIndex = 23;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(341, 29);
            label1.Name = "label1";
            label1.Size = new Size(104, 37);
            label1.TabIndex = 33;
            label1.Text = "STOCK ";
            // 
            // buttonComprar
            // 
            buttonComprar.BackColor = SystemColors.ScrollBar;
            buttonComprar.ForeColor = SystemColors.ControlText;
            buttonComprar.Location = new Point(393, 373);
            buttonComprar.Name = "buttonComprar";
            buttonComprar.Size = new Size(71, 32);
            buttonComprar.TabIndex = 34;
            buttonComprar.Text = "Agregar";
            buttonComprar.UseVisualStyleBackColor = false;
            buttonComprar.Click += buttonComprar_Click;
            // 
            // textBoxPapel
            // 
            textBoxPapel.BorderStyle = BorderStyle.None;
            textBoxPapel.Location = new Point(544, 239);
            textBoxPapel.Name = "textBoxPapel";
            textBoxPapel.PlaceholderText = "Cantidad";
            textBoxPapel.Size = new Size(43, 16);
            textBoxPapel.TabIndex = 37;
            textBoxPapel.Text = "0";
            textBoxPapel.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxTinta
            // 
            textBoxTinta.BorderStyle = BorderStyle.None;
            textBoxTinta.Location = new Point(544, 272);
            textBoxTinta.Name = "textBoxTinta";
            textBoxTinta.PlaceholderText = "Cantidad";
            textBoxTinta.Size = new Size(43, 16);
            textBoxTinta.TabIndex = 38;
            textBoxTinta.Text = "0";
            textBoxTinta.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxTroquel
            // 
            textBoxTroquel.BorderStyle = BorderStyle.None;
            textBoxTroquel.Location = new Point(544, 305);
            textBoxTroquel.Name = "textBoxTroquel";
            textBoxTroquel.PlaceholderText = "Cantidad";
            textBoxTroquel.Size = new Size(43, 16);
            textBoxTroquel.TabIndex = 39;
            textBoxTroquel.Text = "0";
            textBoxTroquel.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxEncuadernacion
            // 
            textBoxEncuadernacion.BorderStyle = BorderStyle.None;
            textBoxEncuadernacion.Location = new Point(544, 337);
            textBoxEncuadernacion.Name = "textBoxEncuadernacion";
            textBoxEncuadernacion.PlaceholderText = "Cantidad";
            textBoxEncuadernacion.Size = new Size(43, 16);
            textBoxEncuadernacion.TabIndex = 40;
            textBoxEncuadernacion.Text = "0";
            textBoxEncuadernacion.TextAlign = HorizontalAlignment.Center;
            // 
            // labelPrecioPapel
            // 
            labelPrecioPapel.AutoSize = true;
            labelPrecioPapel.BackColor = Color.Transparent;
            labelPrecioPapel.Location = new Point(429, 239);
            labelPrecioPapel.Name = "labelPrecioPapel";
            labelPrecioPapel.Size = new Size(0, 15);
            labelPrecioPapel.TabIndex = 43;
            // 
            // labelPrecioTinta
            // 
            labelPrecioTinta.AutoSize = true;
            labelPrecioTinta.BackColor = Color.Transparent;
            labelPrecioTinta.Location = new Point(429, 273);
            labelPrecioTinta.Name = "labelPrecioTinta";
            labelPrecioTinta.Size = new Size(0, 15);
            labelPrecioTinta.TabIndex = 44;
            // 
            // labelPrecioTroquel
            // 
            labelPrecioTroquel.AutoSize = true;
            labelPrecioTroquel.BackColor = Color.Transparent;
            labelPrecioTroquel.Location = new Point(429, 306);
            labelPrecioTroquel.Name = "labelPrecioTroquel";
            labelPrecioTroquel.Size = new Size(0, 15);
            labelPrecioTroquel.TabIndex = 45;
            // 
            // labelPrecioEncuadernacion
            // 
            labelPrecioEncuadernacion.AutoSize = true;
            labelPrecioEncuadernacion.BackColor = Color.Transparent;
            labelPrecioEncuadernacion.Location = new Point(429, 337);
            labelPrecioEncuadernacion.Name = "labelPrecioEncuadernacion";
            labelPrecioEncuadernacion.Size = new Size(0, 15);
            labelPrecioEncuadernacion.TabIndex = 46;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(341, 178);
            label11.Name = "label11";
            label11.Size = new Size(144, 37);
            label11.TabIndex = 48;
            label11.Text = "MERCADO";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Location = new Point(593, 239);
            label12.Name = "label12";
            label12.Size = new Size(36, 15);
            label12.TabIndex = 49;
            label12.Text = "/ Uni.";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Location = new Point(593, 338);
            label13.Name = "label13";
            label13.Size = new Size(36, 15);
            label13.TabIndex = 50;
            label13.Text = "/ Uni.";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Location = new Point(593, 306);
            label14.Name = "label14";
            label14.Size = new Size(36, 15);
            label14.TabIndex = 51;
            label14.Text = "/ Uni.";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Location = new Point(593, 273);
            label16.Name = "label16";
            label16.Size = new Size(24, 15);
            label16.TabIndex = 52;
            label16.Text = "/ L.";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InfoText;
            panel1.Location = new Point(1, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(750, 2);
            panel1.TabIndex = 56;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InfoText;
            panel2.Location = new Point(341, 178);
            panel2.Name = "panel2";
            panel2.Size = new Size(420, 2);
            panel2.TabIndex = 57;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Location = new Point(393, 239);
            label17.Name = "label17";
            label17.Size = new Size(36, 15);
            label17.TabIndex = 58;
            label17.Text = "Papel";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Transparent;
            label18.Location = new Point(393, 272);
            label18.Name = "label18";
            label18.Size = new Size(33, 15);
            label18.TabIndex = 59;
            label18.Text = "Tinta";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.Transparent;
            label19.Location = new Point(393, 304);
            label19.Name = "label19";
            label19.Size = new Size(46, 15);
            label19.TabIndex = 60;
            label19.Text = "Troquel";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.Transparent;
            label20.Location = new Point(393, 338);
            label20.Name = "label20";
            label20.Size = new Size(92, 15);
            label20.TabIndex = 61;
            label20.Text = "Encuadernacion";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView2.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Material, Cantidad2 });
            dataGridView2.Location = new Point(451, 32);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(252, 129);
            dataGridView2.TabIndex = 62;
            // 
            // Material
            // 
            Material.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Material.HeaderText = "MATERIAL";
            Material.Name = "Material";
            // 
            // Cantidad2
            // 
            Cantidad2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Cantidad2.HeaderText = "CANTIDAD";
            Cantidad2.Name = "Cantidad2";
            Cantidad2.ReadOnly = true;
            Cantidad2.Resizable = DataGridViewTriState.False;
            Cantidad2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // buttonEditarUsr
            // 
            buttonEditarUsr.BackColor = SystemColors.ScrollBar;
            buttonEditarUsr.Location = new Point(7, 373);
            buttonEditarUsr.Name = "buttonEditarUsr";
            buttonEditarUsr.Size = new Size(100, 32);
            buttonEditarUsr.TabIndex = 63;
            buttonEditarUsr.Text = "Editar Usuarios";
            buttonEditarUsr.UseVisualStyleBackColor = false;
            buttonEditarUsr.Click += buttonEditarUsr_Click;
            // 
            // FrmMenuSupervisor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 414);
            Controls.Add(buttonEditarUsr);
            Controls.Add(dataGridView2);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label16);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(labelPrecioEncuadernacion);
            Controls.Add(labelPrecioTroquel);
            Controls.Add(labelPrecioTinta);
            Controls.Add(labelPrecioPapel);
            Controls.Add(textBoxEncuadernacion);
            Controls.Add(textBoxTroquel);
            Controls.Add(textBoxTinta);
            Controls.Add(textBoxPapel);
            Controls.Add(buttonComprar);
            Controls.Add(label1);
            Controls.Add(botonMenuOperarios);
            Controls.Add(nombreLogueado);
            Controls.Add(label15);
            Controls.Add(dataGridView1);
            Controls.Add(botonSalir);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMenuSupervisor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sispro";
            FormClosing += FrmMenuSupervisor_FormClosing;
            Load += FrmMenu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button botonSalir;
        internal DataGridView dataGridView1;
        internal Label nombreLogueado;
        private Label label15;
        private Button botonMenuOperarios;
        private Label label1;
        private Button buttonComprar;
        internal TextBox textBoxPapel;
        internal TextBox textBoxTinta;
        internal TextBox textBoxTroquel;
        internal TextBox textBoxEncuadernacion;
        private Label labelPrecioPapel;
        private Label labelPrecioTinta;
        private Label labelPrecioTroquel;
        private Label labelPrecioEncuadernacion;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label16;
        private Panel panel1;
        private Panel panel2;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        internal DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Material;
        private DataGridViewTextBoxColumn Cantidad2;
        private Button buttonEditarUsr;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn USUARIO;
        private DataGridViewTextBoxColumn CONTRASEÑA;
        private DataGridViewTextBoxColumn TIPO;
        private DataGridViewTextBoxColumn Trabajos;
    }
}