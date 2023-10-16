namespace Frms
{
    partial class FrmMenuOperario
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            botonSalir = new Button();
            label10 = new Label();
            radioButtonImpresora = new RadioButton();
            radioButtonTroqueladora = new RadioButton();
            label14 = new Label();
            label15 = new Label();
            nombreLogueado = new Label();
            dataGridView1 = new DataGridView();
            Pedido = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Papel = new DataGridViewTextBoxColumn();
            Tinta = new DataGridViewTextBoxColumn();
            Troquel = new DataGridViewTextBoxColumn();
            Encuadernacion = new DataGridViewTextBoxColumn();
            Ganancia = new DataGridViewTextBoxColumn();
            Seleccion = new DataGridViewCheckBoxColumn();
            botonVolverSup = new Button();
            radioButtonEncuadernadora = new RadioButton();
            labelPedido = new Label();
            labelPedidoSeleccionado = new Label();
            labelMaquinaria = new Label();
            labelMaquinariaNecesaria = new Label();
            progressBarImpresora = new ProgressBar();
            progressBarTroqueladora = new ProgressBar();
            progressBarEncuadernadora = new ProgressBar();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 26);
            label1.Name = "label1";
            label1.Size = new Size(97, 37);
            label1.TabIndex = 0;
            label1.Text = "STOCK";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(12, 68);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Papel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(54, 68);
            label3.Name = "label3";
            label3.Size = new Size(13, 15);
            label3.TabIndex = 2;
            label3.Text = "0";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(54, 99);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 4;
            label4.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(12, 99);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 3;
            label5.Text = "Tintas";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(64, 132);
            label6.Name = "label6";
            label6.Size = new Size(13, 15);
            label6.TabIndex = 6;
            label6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(12, 132);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 5;
            label7.Text = "Troquel";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(183, 164);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 8;
            label8.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Location = new Point(12, 164);
            label9.Name = "label9";
            label9.Size = new Size(165, 15);
            label9.TabIndex = 7;
            label9.Text = "Materiales de encuadernación";
            // 
            // botonSalir
            // 
            botonSalir.BackColor = SystemColors.ControlDark;
            botonSalir.Location = new Point(913, 423);
            botonSalir.Margin = new Padding(0);
            botonSalir.Name = "botonSalir";
            botonSalir.Size = new Size(90, 29);
            botonSalir.TabIndex = 9;
            botonSalir.Text = "SALIR";
            botonSalir.UseVisualStyleBackColor = false;
            botonSalir.Click += botonSalir_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(287, 9);
            label10.Name = "label10";
            label10.Size = new Size(252, 37);
            label10.TabIndex = 10;
            label10.Text = "Trabajos Pendientes";
            // 
            // radioButtonImpresora
            // 
            radioButtonImpresora.AutoSize = true;
            radioButtonImpresora.BackColor = Color.Transparent;
            radioButtonImpresora.Enabled = false;
            radioButtonImpresora.Location = new Point(217, 304);
            radioButtonImpresora.Name = "radioButtonImpresora";
            radioButtonImpresora.Size = new Size(81, 19);
            radioButtonImpresora.TabIndex = 15;
            radioButtonImpresora.TabStop = true;
            radioButtonImpresora.Text = "Impresora ";
            radioButtonImpresora.UseVisualStyleBackColor = false;
            radioButtonImpresora.CheckedChanged += radioButtonImpresora_CheckedChanged;
            // 
            // radioButtonTroqueladora
            // 
            radioButtonTroqueladora.AutoSize = true;
            radioButtonTroqueladora.BackColor = Color.Transparent;
            radioButtonTroqueladora.Enabled = false;
            radioButtonTroqueladora.Location = new Point(458, 304);
            radioButtonTroqueladora.Name = "radioButtonTroqueladora";
            radioButtonTroqueladora.Size = new Size(94, 19);
            radioButtonTroqueladora.TabIndex = 16;
            radioButtonTroqueladora.TabStop = true;
            radioButtonTroqueladora.Text = "Troqueladora";
            radioButtonTroqueladora.UseVisualStyleBackColor = false;
            radioButtonTroqueladora.CheckedChanged += radioButtonTroqueladora_CheckedChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(401, 242);
            label14.Name = "label14";
            label14.Size = new Size(203, 30);
            label14.TabIndex = 19;
            label14.Text = "Linea de Produccón";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(8, 9);
            label15.Name = "label15";
            label15.Size = new Size(81, 12);
            label15.TabIndex = 20;
            label15.Text = "Logueado como:";
            label15.Click += label15_Click_1;
            // 
            // nombreLogueado
            // 
            nombreLogueado.AutoSize = true;
            nombreLogueado.BackColor = Color.Transparent;
            nombreLogueado.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            nombreLogueado.Location = new Point(90, 9);
            nombreLogueado.Name = "nombreLogueado";
            nombreLogueado.Size = new Size(0, 12);
            nombreLogueado.TabIndex = 21;
            nombreLogueado.Click += nombreLogueado_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Pedido, Cantidad, Papel, Tinta, Troquel, Encuadernacion, Ganancia, Seleccion });
            dataGridView1.Location = new Point(287, 49);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(713, 136);
            dataGridView1.TabIndex = 22;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Pedido
            // 
            Pedido.HeaderText = "PEDIDO";
            Pedido.Name = "Pedido";
            Pedido.ReadOnly = true;
            Pedido.Resizable = DataGridViewTriState.False;
            Pedido.SortMode = DataGridViewColumnSortMode.NotSortable;
            Pedido.Width = 200;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "CANTIDAD";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Resizable = DataGridViewTriState.False;
            Cantidad.SortMode = DataGridViewColumnSortMode.NotSortable;
            Cantidad.Width = 70;
            // 
            // Papel
            // 
            Papel.HeaderText = "PAPEL";
            Papel.Name = "Papel";
            Papel.Resizable = DataGridViewTriState.False;
            Papel.Width = 70;
            // 
            // Tinta
            // 
            Tinta.HeaderText = "TINTA";
            Tinta.Name = "Tinta";
            Tinta.Resizable = DataGridViewTriState.False;
            Tinta.Width = 70;
            // 
            // Troquel
            // 
            Troquel.HeaderText = "TROQUEL";
            Troquel.Name = "Troquel";
            Troquel.Resizable = DataGridViewTriState.False;
            Troquel.Width = 70;
            // 
            // Encuadernacion
            // 
            Encuadernacion.HeaderText = "ENCUADERNACION";
            Encuadernacion.Name = "Encuadernacion";
            Encuadernacion.Resizable = DataGridViewTriState.False;
            Encuadernacion.Width = 120;
            // 
            // Ganancia
            // 
            Ganancia.HeaderText = "GANANCIA";
            Ganancia.Name = "Ganancia";
            Ganancia.Resizable = DataGridViewTriState.False;
            Ganancia.Width = 71;
            // 
            // Seleccion
            // 
            Seleccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Seleccion.HeaderText = "";
            Seleccion.Name = "Seleccion";
            Seleccion.Resizable = DataGridViewTriState.False;
            Seleccion.TrueValue = "";
            // 
            // botonVolverSup
            // 
            botonVolverSup.BackColor = SystemColors.ControlDark;
            botonVolverSup.Location = new Point(913, 397);
            botonVolverSup.Margin = new Padding(0);
            botonVolverSup.Name = "botonVolverSup";
            botonVolverSup.Size = new Size(90, 26);
            botonVolverSup.TabIndex = 23;
            botonVolverSup.Text = "VOLVER";
            botonVolverSup.UseVisualStyleBackColor = false;
            botonVolverSup.Visible = false;
            botonVolverSup.Click += botonVolverSup_Click;
            // 
            // radioButtonEncuadernadora
            // 
            radioButtonEncuadernadora.AutoSize = true;
            radioButtonEncuadernadora.BackColor = Color.Transparent;
            radioButtonEncuadernadora.Enabled = false;
            radioButtonEncuadernadora.Location = new Point(681, 304);
            radioButtonEncuadernadora.Name = "radioButtonEncuadernadora";
            radioButtonEncuadernadora.Size = new Size(111, 19);
            radioButtonEncuadernadora.TabIndex = 24;
            radioButtonEncuadernadora.TabStop = true;
            radioButtonEncuadernadora.Text = "Encuadernadora";
            radioButtonEncuadernadora.UseVisualStyleBackColor = false;
            radioButtonEncuadernadora.CheckedChanged += radioButtonEncuadernadora_CheckedChanged;
            // 
            // labelPedido
            // 
            labelPedido.AutoSize = true;
            labelPedido.BackColor = Color.Transparent;
            labelPedido.Location = new Point(12, 210);
            labelPedido.Name = "labelPedido";
            labelPedido.Size = new Size(120, 15);
            labelPedido.TabIndex = 25;
            labelPedido.Text = "Pedido Seleccionado:";
            labelPedido.Visible = false;
            // 
            // labelPedidoSeleccionado
            // 
            labelPedidoSeleccionado.AutoSize = true;
            labelPedidoSeleccionado.Location = new Point(142, 210);
            labelPedidoSeleccionado.Name = "labelPedidoSeleccionado";
            labelPedidoSeleccionado.Size = new Size(0, 15);
            labelPedidoSeleccionado.TabIndex = 26;
            labelPedidoSeleccionado.Visible = false;
            // 
            // labelMaquinaria
            // 
            labelMaquinaria.AutoSize = true;
            labelMaquinaria.Location = new Point(12, 230);
            labelMaquinaria.Name = "labelMaquinaria";
            labelMaquinaria.Size = new Size(56, 15);
            labelMaquinaria.TabIndex = 27;
            labelMaquinaria.Text = "Requiere:";
            labelMaquinaria.Visible = false;
            // 
            // labelMaquinariaNecesaria
            // 
            labelMaquinariaNecesaria.AutoSize = true;
            labelMaquinariaNecesaria.Location = new Point(130, 230);
            labelMaquinariaNecesaria.Name = "labelMaquinariaNecesaria";
            labelMaquinariaNecesaria.Size = new Size(0, 15);
            labelMaquinariaNecesaria.TabIndex = 28;
            labelMaquinariaNecesaria.Visible = false;
            // 
            // progressBarImpresora
            // 
            progressBarImpresora.Location = new Point(164, 367);
            progressBarImpresora.Name = "progressBarImpresora";
            progressBarImpresora.Size = new Size(203, 23);
            progressBarImpresora.TabIndex = 29;
            // 
            // progressBarTroqueladora
            // 
            progressBarTroqueladora.Location = new Point(401, 367);
            progressBarTroqueladora.Name = "progressBarTroqueladora";
            progressBarTroqueladora.Size = new Size(213, 23);
            progressBarTroqueladora.TabIndex = 30;
            progressBarTroqueladora.Click += progressBarTroqueladora_Click;
            // 
            // progressBarEncuadernadora
            // 
            progressBarEncuadernadora.Location = new Point(631, 367);
            progressBarEncuadernadora.Name = "progressBarEncuadernadora";
            progressBarEncuadernadora.Size = new Size(213, 23);
            progressBarEncuadernadora.TabIndex = 31;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlText;
            pictureBox1.Location = new Point(-21, 193);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1049, 10);
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ControlText;
            pictureBox2.Location = new Point(271, -8);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(10, 211);
            pictureBox2.TabIndex = 33;
            pictureBox2.TabStop = false;
            // 
            // FrmMenuOperario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(1012, 461);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(progressBarEncuadernadora);
            Controls.Add(progressBarTroqueladora);
            Controls.Add(progressBarImpresora);
            Controls.Add(labelMaquinariaNecesaria);
            Controls.Add(labelMaquinaria);
            Controls.Add(labelPedidoSeleccionado);
            Controls.Add(labelPedido);
            Controls.Add(radioButtonEncuadernadora);
            Controls.Add(botonVolverSup);
            Controls.Add(dataGridView1);
            Controls.Add(nombreLogueado);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(radioButtonTroqueladora);
            Controls.Add(radioButtonImpresora);
            Controls.Add(label10);
            Controls.Add(botonSalir);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(1028, 658);
            MinimizeBox = false;
            MinimumSize = new Size(400, 400);
            Name = "FrmMenuOperario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sispro";
            Load += FrmPruebaMenu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        internal Label label3;
        internal Label label4;
        private Label label5;
        internal Label label6;
        private Label label7;
        internal Label label8;
        private Label label9;
        private Button botonSalir;
        private Label label10;
        internal RadioButton radioButtonImpresora;
        internal RadioButton radioButtonTroqueladora;
        private Label label14;
        private Label label15;
        private Label nombreLogueado;
        internal DataGridView dataGridView1;
        internal Button botonVolverSup;
        internal RadioButton radioButtonEncuadernadora;
        internal Label labelPedido;
        internal Label labelPedidoSeleccionado;
        internal Label labelMaquinaria;
        internal Label labelMaquinariaNecesaria;
        private DataGridViewTextBoxColumn Pedido;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Papel;
        private DataGridViewTextBoxColumn Tinta;
        private DataGridViewTextBoxColumn Troquel;
        private DataGridViewTextBoxColumn Encuadernacion;
        private DataGridViewTextBoxColumn Ganancia;
        private DataGridViewCheckBoxColumn Seleccion;
        private ProgressBar progressBarImpresora;
        private ProgressBar progressBarTroqueladora;
        private ProgressBar progressBarEncuadernadora;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}