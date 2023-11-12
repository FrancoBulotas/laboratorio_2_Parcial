namespace Frms
{
    partial class FrmMenuSupervisorCRUD
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
            dataGridViewUsr = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Seleccion = new DataGridViewCheckBoxColumn();
            textBoxNuevoNombre = new TextBox();
            textBoxNuevaContra = new TextBox();
            buttoneliminarUsr = new Button();
            buttonModificarUsr = new Button();
            labelNombreActual = new Label();
            labelContraActual = new Label();
            labelActual = new Label();
            labelNombre = new Label();
            labelContra = new Label();
            buttonCrearUsr = new Button();
            textBoxRepetirNuevaContra = new TextBox();
            buttonAplicarCreacion = new Button();
            buttonAplicarModificacion = new Button();
            labelTipoDeUsuario = new Label();
            textBoxTipoDeUsuario = new TextBox();
            labelErrorRegistro = new Label();
            labelTipoUsuarioActual = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsr).BeginInit();
            SuspendLayout();
            // 
            // botonSalir
            // 
            botonSalir.BackColor = SystemColors.ControlDark;
            botonSalir.Location = new Point(397, 247);
            botonSalir.Margin = new Padding(0);
            botonSalir.Name = "botonSalir";
            botonSalir.Size = new Size(90, 29);
            botonSalir.TabIndex = 9;
            botonSalir.Text = "SALIR";
            botonSalir.UseVisualStyleBackColor = false;
            botonSalir.Click += botonSalir_Click;
            // 
            // dataGridViewUsr
            // 
            dataGridViewUsr.AllowUserToAddRows = false;
            dataGridViewUsr.AllowUserToDeleteRows = false;
            dataGridViewUsr.AllowUserToResizeColumns = false;
            dataGridViewUsr.AllowUserToResizeRows = false;
            dataGridViewUsr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsr.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewUsr.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewUsr.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsr.Columns.AddRange(new DataGridViewColumn[] { ID, Nombre, Seleccion });
            dataGridViewUsr.GridColor = Color.Black;
            dataGridViewUsr.Location = new Point(12, 12);
            dataGridViewUsr.MultiSelect = false;
            dataGridViewUsr.Name = "dataGridViewUsr";
            dataGridViewUsr.RowHeadersVisible = false;
            dataGridViewUsr.RowTemplate.Height = 25;
            dataGridViewUsr.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsr.Size = new Size(155, 260);
            dataGridViewUsr.TabIndex = 10;
            dataGridViewUsr.CellContentClick += dataGridViewUsr_CellContentClick;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ID.FillWeight = 98.47717F;
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.Width = 25;
            // 
            // Nombre
            // 
            Nombre.FillWeight = 172.231735F;
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Seleccion
            // 
            Seleccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Seleccion.FillWeight = 29.2911129F;
            Seleccion.HeaderText = "";
            Seleccion.Name = "Seleccion";
            Seleccion.Resizable = DataGridViewTriState.True;
            Seleccion.SortMode = DataGridViewColumnSortMode.Automatic;
            Seleccion.Width = 25;
            // 
            // textBoxNuevoNombre
            // 
            textBoxNuevoNombre.BorderStyle = BorderStyle.FixedSingle;
            textBoxNuevoNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNuevoNombre.Location = new Point(384, 90);
            textBoxNuevoNombre.Name = "textBoxNuevoNombre";
            textBoxNuevoNombre.PlaceholderText = "Nuevo nombre";
            textBoxNuevoNombre.Size = new Size(103, 25);
            textBoxNuevoNombre.TabIndex = 38;
            textBoxNuevoNombre.Visible = false;
            // 
            // textBoxNuevaContra
            // 
            textBoxNuevaContra.BorderStyle = BorderStyle.FixedSingle;
            textBoxNuevaContra.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNuevaContra.Location = new Point(384, 134);
            textBoxNuevaContra.Name = "textBoxNuevaContra";
            textBoxNuevaContra.PlaceholderText = "Nueva contraseña";
            textBoxNuevaContra.Size = new Size(103, 25);
            textBoxNuevaContra.TabIndex = 39;
            textBoxNuevaContra.Visible = false;
            // 
            // buttoneliminarUsr
            // 
            buttoneliminarUsr.BackColor = Color.DarkGray;
            buttoneliminarUsr.Enabled = false;
            buttoneliminarUsr.Location = new Point(399, 12);
            buttoneliminarUsr.Margin = new Padding(0);
            buttoneliminarUsr.Name = "buttoneliminarUsr";
            buttoneliminarUsr.Size = new Size(90, 29);
            buttoneliminarUsr.TabIndex = 41;
            buttoneliminarUsr.Text = "ELIMINAR";
            buttoneliminarUsr.UseVisualStyleBackColor = false;
            buttoneliminarUsr.Click += buttoneliminarUsr_Click;
            // 
            // buttonModificarUsr
            // 
            buttonModificarUsr.BackColor = Color.DarkGray;
            buttonModificarUsr.Location = new Point(270, 12);
            buttonModificarUsr.Margin = new Padding(0);
            buttonModificarUsr.Name = "buttonModificarUsr";
            buttonModificarUsr.Size = new Size(90, 29);
            buttonModificarUsr.TabIndex = 42;
            buttonModificarUsr.Text = "MODIFICAR";
            buttonModificarUsr.UseVisualStyleBackColor = false;
            buttonModificarUsr.Click += buttonModificarUsr_Click;
            // 
            // labelNombreActual
            // 
            labelNombreActual.AutoSize = true;
            labelNombreActual.BackColor = Color.Transparent;
            labelNombreActual.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelNombreActual.Location = new Point(289, 92);
            labelNombreActual.Name = "labelNombreActual";
            labelNombreActual.Size = new Size(19, 19);
            labelNombreActual.TabIndex = 43;
            labelNombreActual.Text = "N";
            labelNombreActual.Visible = false;
            // 
            // labelContraActual
            // 
            labelContraActual.AutoSize = true;
            labelContraActual.BackColor = Color.Transparent;
            labelContraActual.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelContraActual.Location = new Point(289, 136);
            labelContraActual.Name = "labelContraActual";
            labelContraActual.Size = new Size(19, 19);
            labelContraActual.TabIndex = 44;
            labelContraActual.Text = "N";
            labelContraActual.Visible = false;
            // 
            // labelActual
            // 
            labelActual.AutoSize = true;
            labelActual.BackColor = Color.Transparent;
            labelActual.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelActual.Location = new Point(179, 55);
            labelActual.Name = "labelActual";
            labelActual.Size = new Size(67, 21);
            labelActual.TabIndex = 46;
            labelActual.Text = "ACTUAL";
            labelActual.Visible = false;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.BackColor = Color.Transparent;
            labelNombre.Location = new Point(179, 94);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 47;
            labelNombre.Text = "Nombre";
            labelNombre.Visible = false;
            // 
            // labelContra
            // 
            labelContra.AutoSize = true;
            labelContra.BackColor = Color.Transparent;
            labelContra.Location = new Point(179, 138);
            labelContra.Name = "labelContra";
            labelContra.Size = new Size(67, 15);
            labelContra.TabIndex = 48;
            labelContra.Text = "Contraseña";
            labelContra.Visible = false;
            // 
            // buttonCrearUsr
            // 
            buttonCrearUsr.BackColor = Color.DarkGray;
            buttonCrearUsr.Location = new Point(170, 12);
            buttonCrearUsr.Margin = new Padding(0);
            buttonCrearUsr.Name = "buttonCrearUsr";
            buttonCrearUsr.Size = new Size(90, 29);
            buttonCrearUsr.TabIndex = 50;
            buttonCrearUsr.Text = "CREAR";
            buttonCrearUsr.UseVisualStyleBackColor = false;
            buttonCrearUsr.Click += buttonCrearUsr_Click;
            // 
            // textBoxRepetirNuevaContra
            // 
            textBoxRepetirNuevaContra.BorderStyle = BorderStyle.FixedSingle;
            textBoxRepetirNuevaContra.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxRepetirNuevaContra.Location = new Point(275, 134);
            textBoxRepetirNuevaContra.Name = "textBoxRepetirNuevaContra";
            textBoxRepetirNuevaContra.PlaceholderText = "Nueva contraseña";
            textBoxRepetirNuevaContra.Size = new Size(103, 25);
            textBoxRepetirNuevaContra.TabIndex = 51;
            textBoxRepetirNuevaContra.Visible = false;
            // 
            // buttonAplicarCreacion
            // 
            buttonAplicarCreacion.BackColor = Color.DarkGray;
            buttonAplicarCreacion.Location = new Point(170, 243);
            buttonAplicarCreacion.Margin = new Padding(0);
            buttonAplicarCreacion.Name = "buttonAplicarCreacion";
            buttonAplicarCreacion.Size = new Size(90, 29);
            buttonAplicarCreacion.TabIndex = 52;
            buttonAplicarCreacion.Text = "APLICAR";
            buttonAplicarCreacion.UseVisualStyleBackColor = false;
            buttonAplicarCreacion.Visible = false;
            buttonAplicarCreacion.Click += buttonAplicarCreacion_Click;
            // 
            // buttonAplicarModificacion
            // 
            buttonAplicarModificacion.BackColor = Color.DarkGray;
            buttonAplicarModificacion.Location = new Point(170, 243);
            buttonAplicarModificacion.Margin = new Padding(0);
            buttonAplicarModificacion.Name = "buttonAplicarModificacion";
            buttonAplicarModificacion.Size = new Size(90, 29);
            buttonAplicarModificacion.TabIndex = 53;
            buttonAplicarModificacion.Text = "APLICAR";
            buttonAplicarModificacion.UseVisualStyleBackColor = false;
            buttonAplicarModificacion.Visible = false;
            buttonAplicarModificacion.Click += buttonAplicarModificacion_Click;
            // 
            // labelTipoDeUsuario
            // 
            labelTipoDeUsuario.AutoSize = true;
            labelTipoDeUsuario.BackColor = Color.Transparent;
            labelTipoDeUsuario.Location = new Point(179, 193);
            labelTipoDeUsuario.Name = "labelTipoDeUsuario";
            labelTipoDeUsuario.Size = new Size(88, 15);
            labelTipoDeUsuario.TabIndex = 54;
            labelTipoDeUsuario.Text = "Tipo de usuario";
            labelTipoDeUsuario.Visible = false;
            // 
            // textBoxTipoDeUsuario
            // 
            textBoxTipoDeUsuario.BorderStyle = BorderStyle.FixedSingle;
            textBoxTipoDeUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTipoDeUsuario.Location = new Point(383, 189);
            textBoxTipoDeUsuario.Name = "textBoxTipoDeUsuario";
            textBoxTipoDeUsuario.PlaceholderText = "Tipo de usuario";
            textBoxTipoDeUsuario.Size = new Size(103, 25);
            textBoxTipoDeUsuario.TabIndex = 55;
            textBoxTipoDeUsuario.Visible = false;
            // 
            // labelErrorRegistro
            // 
            labelErrorRegistro.AutoSize = true;
            labelErrorRegistro.BackColor = Color.Transparent;
            labelErrorRegistro.ForeColor = Color.Red;
            labelErrorRegistro.Location = new Point(174, 223);
            labelErrorRegistro.Name = "labelErrorRegistro";
            labelErrorRegistro.Size = new Size(13, 15);
            labelErrorRegistro.TabIndex = 56;
            labelErrorRegistro.Text = "E";
            labelErrorRegistro.Visible = false;
            // 
            // labelTipoUsuarioActual
            // 
            labelTipoUsuarioActual.AutoSize = true;
            labelTipoUsuarioActual.BackColor = Color.Transparent;
            labelTipoUsuarioActual.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTipoUsuarioActual.Location = new Point(289, 191);
            labelTipoUsuarioActual.Name = "labelTipoUsuarioActual";
            labelTipoUsuarioActual.Size = new Size(19, 19);
            labelTipoUsuarioActual.TabIndex = 57;
            labelTipoUsuarioActual.Text = "N";
            labelTipoUsuarioActual.Visible = false;
            // 
            // FrmMenuSupervisorCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 284);
            Controls.Add(labelTipoUsuarioActual);
            Controls.Add(labelErrorRegistro);
            Controls.Add(textBoxTipoDeUsuario);
            Controls.Add(labelTipoDeUsuario);
            Controls.Add(buttonAplicarModificacion);
            Controls.Add(buttonAplicarCreacion);
            Controls.Add(textBoxRepetirNuevaContra);
            Controls.Add(buttonCrearUsr);
            Controls.Add(labelContra);
            Controls.Add(labelNombre);
            Controls.Add(labelActual);
            Controls.Add(labelContraActual);
            Controls.Add(labelNombreActual);
            Controls.Add(buttonModificarUsr);
            Controls.Add(buttoneliminarUsr);
            Controls.Add(textBoxNuevaContra);
            Controls.Add(textBoxNuevoNombre);
            Controls.Add(dataGridViewUsr);
            Controls.Add(botonSalir);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMenuSupervisorCRUD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sispro";
            Load += FrmMenuSupervisorCRUD_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Button botonSalir;
        internal DataGridView dataGridViewUsr;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewCheckBoxColumn Seleccion;
        internal TextBox textBoxNuevoNombre;
        internal TextBox textBoxNuevaContra;
        internal Button buttoneliminarUsr;
        internal Button buttonModificarUsr;
        internal Label labelNombreActual;
        internal Label labelContraActual;
        internal Label labelActual;
        internal Label labelNombre;
        internal Label labelContra;
        internal Button buttonCrearUsr;
        internal TextBox textBoxRepetirNuevaContra;
        internal Button buttonAplicarCreacion;
        internal Button buttonAplicarModificacion;
        internal Label labelTipoDeUsuario;
        internal TextBox textBoxTipoDeUsuario;
        internal Label labelErrorRegistro;
        internal Label labelTipoUsuarioActual;
    }
}