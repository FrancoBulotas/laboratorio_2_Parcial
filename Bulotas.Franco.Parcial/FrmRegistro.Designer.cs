namespace Frms
{
    partial class FrmRegistro
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
            botonCancelar = new Button();
            label1 = new Label();
            tbNombreUsuario = new TextBox();
            tbContraseña = new TextBox();
            tbRepContraseña = new TextBox();
            botonRegistrar = new Button();
            labelErrorRegistro = new Label();
            linkLabelVaciar = new LinkLabel();
            checkBoxOperario = new CheckBox();
            checkBoxSupervisor = new CheckBox();
            linkLabelRandom = new LinkLabel();
            SuspendLayout();
            // 
            // botonCancelar
            // 
            botonCancelar.BackColor = SystemColors.ControlDark;
            botonCancelar.Location = new Point(181, 313);
            botonCancelar.Name = "botonCancelar";
            botonCancelar.Size = new Size(86, 33);
            botonCancelar.TabIndex = 0;
            botonCancelar.Text = "SALIR";
            botonCancelar.UseVisualStyleBackColor = false;
            botonCancelar.Click += botonCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(143, 46);
            label1.TabIndex = 1;
            label1.Text = "Registro";
            // 
            // tbNombreUsuario
            // 
            tbNombreUsuario.Location = new Point(12, 86);
            tbNombreUsuario.Name = "tbNombreUsuario";
            tbNombreUsuario.PlaceholderText = "Nombre de usuario";
            tbNombreUsuario.Size = new Size(255, 23);
            tbNombreUsuario.TabIndex = 2;
            // 
            // tbContraseña
            // 
            tbContraseña.Location = new Point(12, 125);
            tbContraseña.Name = "tbContraseña";
            tbContraseña.PasswordChar = '*';
            tbContraseña.PlaceholderText = "Contraseña";
            tbContraseña.Size = new Size(255, 23);
            tbContraseña.TabIndex = 3;
            // 
            // tbRepContraseña
            // 
            tbRepContraseña.Location = new Point(12, 164);
            tbRepContraseña.Name = "tbRepContraseña";
            tbRepContraseña.PasswordChar = '*';
            tbRepContraseña.PlaceholderText = "Repetir contraseña";
            tbRepContraseña.Size = new Size(255, 23);
            tbRepContraseña.TabIndex = 4;
            tbRepContraseña.TextChanged += tbRepContraseña_TextChanged;
            // 
            // botonRegistrar
            // 
            botonRegistrar.BackColor = SystemColors.InactiveCaption;
            botonRegistrar.Location = new Point(12, 253);
            botonRegistrar.Name = "botonRegistrar";
            botonRegistrar.Size = new Size(255, 40);
            botonRegistrar.TabIndex = 5;
            botonRegistrar.Text = "REGISTRAR";
            botonRegistrar.UseVisualStyleBackColor = false;
            botonRegistrar.Click += botonRegistrar_Click;
            // 
            // labelErrorRegistro
            // 
            labelErrorRegistro.AutoSize = true;
            labelErrorRegistro.ForeColor = Color.Red;
            labelErrorRegistro.Location = new Point(12, 226);
            labelErrorRegistro.Name = "labelErrorRegistro";
            labelErrorRegistro.Size = new Size(43, 15);
            labelErrorRegistro.TabIndex = 6;
            labelErrorRegistro.Text = "ERROR";
            labelErrorRegistro.Visible = false;
            // 
            // linkLabelVaciar
            // 
            linkLabelVaciar.AutoSize = true;
            linkLabelVaciar.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabelVaciar.LinkColor = Color.Black;
            linkLabelVaciar.Location = new Point(16, 327);
            linkLabelVaciar.Name = "linkLabelVaciar";
            linkLabelVaciar.Size = new Size(78, 13);
            linkLabelVaciar.TabIndex = 7;
            linkLabelVaciar.TabStop = true;
            linkLabelVaciar.Text = "Vaciar Casillas";
            linkLabelVaciar.VisitedLinkColor = Color.Blue;
            linkLabelVaciar.LinkClicked += linkLabelVaciar_LinkClicked;
            // 
            // checkBoxOperario
            // 
            checkBoxOperario.AutoSize = true;
            checkBoxOperario.Location = new Point(16, 204);
            checkBoxOperario.Name = "checkBoxOperario";
            checkBoxOperario.Size = new Size(72, 19);
            checkBoxOperario.TabIndex = 8;
            checkBoxOperario.Text = "Operario";
            checkBoxOperario.UseVisualStyleBackColor = true;
            // 
            // checkBoxSupervisor
            // 
            checkBoxSupervisor.AutoSize = true;
            checkBoxSupervisor.Location = new Point(101, 204);
            checkBoxSupervisor.Name = "checkBoxSupervisor";
            checkBoxSupervisor.Size = new Size(81, 19);
            checkBoxSupervisor.TabIndex = 9;
            checkBoxSupervisor.Text = "Supervisor";
            checkBoxSupervisor.UseVisualStyleBackColor = true;
            // 
            // linkLabelRandom
            // 
            linkLabelRandom.AutoSize = true;
            linkLabelRandom.LinkColor = Color.Black;
            linkLabelRandom.Location = new Point(16, 312);
            linkLabelRandom.Name = "linkLabelRandom";
            linkLabelRandom.Size = new Size(85, 15);
            linkLabelRandom.TabIndex = 10;
            linkLabelRandom.TabStop = true;
            linkLabelRandom.Text = "Datos Random";
            linkLabelRandom.LinkClicked += linkLabelRandom_LinkClicked;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 358);
            Controls.Add(linkLabelRandom);
            Controls.Add(checkBoxSupervisor);
            Controls.Add(checkBoxOperario);
            Controls.Add(linkLabelVaciar);
            Controls.Add(labelErrorRegistro);
            Controls.Add(botonRegistrar);
            Controls.Add(tbRepContraseña);
            Controls.Add(tbContraseña);
            Controls.Add(tbNombreUsuario);
            Controls.Add(label1);
            Controls.Add(botonCancelar);
            Name = "FrmRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button botonCancelar;
        private Label label1;
        private TextBox tbNombreUsuario;
        private TextBox tbContraseña;
        private TextBox tbRepContraseña;
        private Button botonRegistrar;
        private Label labelErrorRegistro;
        private LinkLabel linkLabelVaciar;
        private CheckBox checkBoxOperario;
        private CheckBox checkBoxSupervisor;
        private LinkLabel linkLabelRandom;
    }
}