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
            progressBar1 = new ProgressBar();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            button1 = new Button();
            button2 = new Button();
            label14 = new Label();
            label15 = new Label();
            nombreLogueado = new Label();
            dataGridView1 = new DataGridView();
            botonVolverSup = new Button();
            radioButton3 = new RadioButton();
            Pedido = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Papel = new DataGridViewTextBoxColumn();
            Tinta = new DataGridViewTextBoxColumn();
            Troquel = new DataGridViewTextBoxColumn();
            Encuadernacion = new DataGridViewTextBoxColumn();
            Ganancia = new DataGridViewTextBoxColumn();
            Seleccion = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
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
            label2.Location = new Point(12, 68);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Papel";
            // 
            // label3
            // 
            label3.AutoSize = true;
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
            label4.Location = new Point(54, 99);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 4;
            label4.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 99);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 3;
            label5.Text = "Tintas";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(64, 132);
            label6.Name = "label6";
            label6.Size = new Size(13, 15);
            label6.TabIndex = 6;
            label6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 132);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 5;
            label7.Text = "Troquel";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(183, 164);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 8;
            label8.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 164);
            label9.Name = "label9";
            label9.Size = new Size(165, 15);
            label9.TabIndex = 7;
            label9.Text = "Materiales de encuadernación";
            // 
            // botonSalir
            // 
            botonSalir.BackColor = SystemColors.ControlDark;
            botonSalir.Location = new Point(913, 581);
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
            label10.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(304, 9);
            label10.Name = "label10";
            label10.Size = new Size(252, 37);
            label10.TabIndex = 10;
            label10.Text = "Trabajos Pendientes";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(9, 581);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(824, 29);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 14;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(18, 250);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(81, 19);
            radioButton1.TabIndex = 15;
            radioButton1.TabStop = true;
            radioButton1.Text = "Impresora ";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(118, 250);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(94, 19);
            radioButton2.TabIndex = 16;
            radioButton2.TabStop = true;
            radioButton2.Text = "Troqueladora";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(-4, 191);
            button1.Name = "button1";
            button1.Size = new Size(1022, 12);
            button1.TabIndex = 17;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(271, -39);
            button2.Name = "button2";
            button2.Size = new Size(10, 242);
            button2.TabIndex = 18;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(16, 217);
            label14.Name = "label14";
            label14.Size = new Size(146, 21);
            label14.TabIndex = 19;
            label14.Text = "Linea de Produccón";
            // 
            // label15
            // 
            label15.AutoSize = true;
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
            // botonVolverSup
            // 
            botonVolverSup.BackColor = SystemColors.ControlDark;
            botonVolverSup.Location = new Point(913, 555);
            botonVolverSup.Margin = new Padding(0);
            botonVolverSup.Name = "botonVolverSup";
            botonVolverSup.Size = new Size(90, 26);
            botonVolverSup.TabIndex = 23;
            botonVolverSup.Text = "VOLVER";
            botonVolverSup.UseVisualStyleBackColor = false;
            botonVolverSup.Visible = false;
            botonVolverSup.Click += botonVolverSup_Click;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(218, 250);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(111, 19);
            radioButton3.TabIndex = 24;
            radioButton3.TabStop = true;
            radioButton3.Text = "Encuadernadora";
            radioButton3.UseVisualStyleBackColor = true;
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
            // 
            // FrmMenuOperario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(1012, 619);
            Controls.Add(radioButton3);
            Controls.Add(botonVolverSup);
            Controls.Add(dataGridView1);
            Controls.Add(nombreLogueado);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(progressBar1);
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
            MinimumSize = new Size(1028, 658);
            Name = "FrmMenuOperario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMenuOperario";
            Load += FrmPruebaMenu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button botonSalir;
        private Label label10;
        private ProgressBar progressBar1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button button1;
        private Button button2;
        private Label label14;
        private Label label15;
        private Label nombreLogueado;
        private DataGridView dataGridView1;
        internal Button botonVolverSup;
        private RadioButton radioButton3;
        private DataGridViewTextBoxColumn Pedido;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Papel;
        private DataGridViewTextBoxColumn Tinta;
        private DataGridViewTextBoxColumn Troquel;
        private DataGridViewTextBoxColumn Encuadernacion;
        private DataGridViewTextBoxColumn Ganancia;
        private DataGridViewCheckBoxColumn Seleccion;
    }
}