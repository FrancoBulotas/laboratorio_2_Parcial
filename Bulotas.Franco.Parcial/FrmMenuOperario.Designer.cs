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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
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
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            labelCantImp = new Label();
            labelCantTroq = new Label();
            labelCantEncu = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            label5.Size = new Size(33, 15);
            label5.TabIndex = 3;
            label5.Text = "Tinta";
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
            label10.Location = new Point(285, 9);
            label10.Name = "label10";
            label10.Size = new Size(299, 37);
            label10.TabIndex = 10;
            label10.Text = "TRABAJOS PENDIENTES";
            // 
            // radioButtonImpresora
            // 
            radioButtonImpresora.AutoSize = true;
            radioButtonImpresora.BackColor = Color.Transparent;
            radioButtonImpresora.Enabled = false;
            radioButtonImpresora.Location = new Point(215, 333);
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
            radioButtonTroqueladora.Location = new Point(445, 333);
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
            label14.Location = new Point(375, 268);
            label14.Name = "label14";
            label14.Size = new Size(246, 30);
            label14.TabIndex = 19;
            label14.Text = "LINEA DE PRODUCCIÓN";
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
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
            radioButtonEncuadernadora.Location = new Point(679, 333);
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
            labelPedido.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelPedido.Location = new Point(12, 206);
            labelPedido.Name = "labelPedido";
            labelPedido.Size = new Size(176, 20);
            labelPedido.TabIndex = 25;
            labelPedido.Text = "PEDIDO SELECCIONADO:";
            labelPedido.Visible = false;
            // 
            // labelPedidoSeleccionado
            // 
            labelPedidoSeleccionado.AutoSize = true;
            labelPedidoSeleccionado.BackColor = Color.Transparent;
            labelPedidoSeleccionado.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelPedidoSeleccionado.Location = new Point(197, 206);
            labelPedidoSeleccionado.Name = "labelPedidoSeleccionado";
            labelPedidoSeleccionado.Size = new Size(0, 20);
            labelPedidoSeleccionado.TabIndex = 26;
            labelPedidoSeleccionado.Visible = false;
            // 
            // labelMaquinaria
            // 
            labelMaquinaria.AutoSize = true;
            labelMaquinaria.BackColor = Color.Transparent;
            labelMaquinaria.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelMaquinaria.Location = new Point(12, 226);
            labelMaquinaria.Name = "labelMaquinaria";
            labelMaquinaria.Size = new Size(79, 20);
            labelMaquinaria.TabIndex = 27;
            labelMaquinaria.Text = "REQUIERE:";
            labelMaquinaria.Visible = false;
            // 
            // labelMaquinariaNecesaria
            // 
            labelMaquinariaNecesaria.AutoSize = true;
            labelMaquinariaNecesaria.BackColor = Color.Transparent;
            labelMaquinariaNecesaria.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelMaquinariaNecesaria.Location = new Point(117, 226);
            labelMaquinariaNecesaria.Name = "labelMaquinariaNecesaria";
            labelMaquinariaNecesaria.Size = new Size(0, 20);
            labelMaquinariaNecesaria.TabIndex = 28;
            labelMaquinariaNecesaria.Visible = false;
            // 
            // progressBarImpresora
            // 
            progressBarImpresora.Location = new Point(162, 396);
            progressBarImpresora.Name = "progressBarImpresora";
            progressBarImpresora.Size = new Size(203, 23);
            progressBarImpresora.TabIndex = 29;
            // 
            // progressBarTroqueladora
            // 
            progressBarTroqueladora.Location = new Point(385, 396);
            progressBarTroqueladora.Name = "progressBarTroqueladora";
            progressBarTroqueladora.Size = new Size(227, 23);
            progressBarTroqueladora.TabIndex = 30;
            progressBarTroqueladora.Click += progressBarTroqueladora_Click;
            // 
            // progressBarEncuadernadora
            // 
            progressBarEncuadernadora.Location = new Point(629, 396);
            progressBarEncuadernadora.Name = "progressBarEncuadernadora";
            progressBarEncuadernadora.Size = new Size(213, 23);
            progressBarEncuadernadora.TabIndex = 31;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(162, 380);
            label11.Name = "label11";
            label11.Size = new Size(60, 13);
            label11.TabIndex = 35;
            label11.Text = "Cantidad: ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(385, 380);
            label12.Name = "label12";
            label12.Size = new Size(60, 13);
            label12.TabIndex = 36;
            label12.Text = "Cantidad: ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(629, 380);
            label13.Name = "label13";
            label13.Size = new Size(60, 13);
            label13.TabIndex = 37;
            label13.Text = "Cantidad: ";
            // 
            // labelCantImp
            // 
            labelCantImp.AutoSize = true;
            labelCantImp.BackColor = Color.Transparent;
            labelCantImp.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            labelCantImp.Location = new Point(228, 380);
            labelCantImp.Name = "labelCantImp";
            labelCantImp.Size = new Size(0, 13);
            labelCantImp.TabIndex = 38;
            // 
            // labelCantTroq
            // 
            labelCantTroq.AutoSize = true;
            labelCantTroq.BackColor = Color.Transparent;
            labelCantTroq.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            labelCantTroq.Location = new Point(451, 380);
            labelCantTroq.Name = "labelCantTroq";
            labelCantTroq.Size = new Size(0, 13);
            labelCantTroq.TabIndex = 39;
            // 
            // labelCantEncu
            // 
            labelCantEncu.AutoSize = true;
            labelCantEncu.BackColor = Color.Transparent;
            labelCantEncu.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            labelCantEncu.Location = new Point(695, 380);
            labelCantEncu.Name = "labelCantEncu";
            labelCantEncu.Size = new Size(0, 13);
            labelCantEncu.TabIndex = 40;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InfoText;
            panel1.Location = new Point(0, 201);
            panel1.Name = "panel1";
            panel1.Size = new Size(1050, 2);
            panel1.TabIndex = 57;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InfoText;
            panel2.Location = new Point(263, -7);
            panel2.Name = "panel2";
            panel2.Size = new Size(2, 210);
            panel2.TabIndex = 58;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.InfoText;
            panel3.Location = new Point(0, 249);
            panel3.Name = "panel3";
            panel3.Size = new Size(1050, 2);
            panel3.TabIndex = 59;
            // 
            // FrmMenuOperario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(1012, 461);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(labelCantEncu);
            Controls.Add(labelCantTroq);
            Controls.Add(labelCantImp);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
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
        internal ProgressBar progressBarImpresora;
        internal ProgressBar progressBarTroqueladora;
        internal ProgressBar progressBarEncuadernadora;
        private Label label11;
        private Label label12;
        private Label label13;
        internal Label labelCantImp;
        internal Label labelCantTroq;
        internal Label labelCantEncu;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}