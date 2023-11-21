﻿namespace Frms
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
            labelRegistro = new Label();
            tbNombreUsuario = new TextBox();
            tbContraseña = new TextBox();
            tbRepContraseña = new TextBox();
            botonRegistrar = new Button();
            labelErrorRegistro = new Label();
            linkLabelVaciar = new LinkLabel();
            checkBoxOperario = new CheckBox();
            linkLabelRandom = new LinkLabel();
            checkBoxSupervisor = new CheckBox();
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
            // labelRegistro
            // 
            labelRegistro.AutoSize = true;
            labelRegistro.BackColor = Color.Transparent;
            labelRegistro.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            labelRegistro.Location = new Point(12, 9);
            labelRegistro.Name = "labelRegistro";
            labelRegistro.Size = new Size(171, 46);
            labelRegistro.TabIndex = 1;
            labelRegistro.Text = "REGISTRO";
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
            labelErrorRegistro.BackColor = Color.Transparent;
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
            linkLabelVaciar.BackColor = Color.Transparent;
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
            checkBoxOperario.BackColor = Color.Transparent;
            checkBoxOperario.Location = new Point(16, 204);
            checkBoxOperario.Name = "checkBoxOperario";
            checkBoxOperario.Size = new Size(72, 19);
            checkBoxOperario.TabIndex = 8;
            checkBoxOperario.Text = "Operario";
            checkBoxOperario.UseVisualStyleBackColor = false;
            // 
            // linkLabelRandom
            // 
            linkLabelRandom.AutoSize = true;
            linkLabelRandom.BackColor = Color.Transparent;
            linkLabelRandom.LinkColor = Color.Black;
            linkLabelRandom.Location = new Point(16, 312);
            linkLabelRandom.Name = "linkLabelRandom";
            linkLabelRandom.Size = new Size(85, 15);
            linkLabelRandom.TabIndex = 10;
            linkLabelRandom.TabStop = true;
            linkLabelRandom.Text = "Datos Random";
            linkLabelRandom.LinkClicked += linkLabelRandom_LinkClicked;
            // 
            // checkBoxSupervisor
            // 
            checkBoxSupervisor.AutoSize = true;
            checkBoxSupervisor.BackColor = Color.Transparent;
            checkBoxSupervisor.Location = new Point(101, 204);
            checkBoxSupervisor.Name = "checkBoxSupervisor";
            checkBoxSupervisor.Size = new Size(81, 19);
            checkBoxSupervisor.TabIndex = 9;
            checkBoxSupervisor.Text = "Supervisor";
            checkBoxSupervisor.UseVisualStyleBackColor = false;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
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
            Controls.Add(labelRegistro);
            Controls.Add(botonCancelar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmRegistro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sispro - Registro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button botonCancelar;
        private Label labelRegistro;
        private TextBox tbNombreUsuario;
        private TextBox tbContraseña;
        private TextBox tbRepContraseña;
        private Button botonRegistrar;
        private Label labelErrorRegistro;
        private LinkLabel linkLabelVaciar;
        private CheckBox checkBoxOperario;
        private LinkLabel linkLabelRandom;
        private CheckBox checkBoxSupervisor;
    }
}