namespace Frms
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            login = new Button();
            tPass = new TextBox();
            tNombre = new TextBox();
            labelError = new Label();
            registro = new LinkLabel();
            botonSalir = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // login
            // 
            login.BackColor = SystemColors.ActiveCaption;
            login.Location = new Point(12, 203);
            login.Name = "login";
            login.Size = new Size(251, 39);
            login.TabIndex = 0;
            login.Text = "INGRESAR";
            login.UseVisualStyleBackColor = false;
            login.Click += login_Click;
            // 
            // tPass
            // 
            tPass.Location = new Point(12, 124);
            tPass.Name = "tPass";
            tPass.PasswordChar = '*';
            tPass.PlaceholderText = "Contraseña";
            tPass.Size = new Size(251, 23);
            tPass.TabIndex = 2;
            tPass.TextChanged += tPass_TextChanged;
            // 
            // tNombre
            // 
            tNombre.Location = new Point(12, 73);
            tNombre.Name = "tNombre";
            tNombre.PlaceholderText = "Nombre de usuario";
            tNombre.Size = new Size(251, 23);
            tNombre.TabIndex = 3;
            tNombre.TextChanged += tNombre_TextChanged;
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(12, 150);
            labelError.Name = "labelError";
            labelError.Size = new Size(43, 15);
            labelError.TabIndex = 4;
            labelError.Text = "ERROR";
            labelError.Visible = false;
            labelError.Click += label1_Click;
            // 
            // registro
            // 
            registro.AutoSize = true;
            registro.LinkColor = Color.Black;
            registro.Location = new Point(12, 330);
            registro.Name = "registro";
            registro.Size = new Size(77, 15);
            registro.TabIndex = 6;
            registro.TabStop = true;
            registro.Text = "REGISTRARSE";
            registro.LinkClicked += registro_LinkClicked;
            // 
            // botonSalir
            // 
            botonSalir.BackColor = SystemColors.ControlDark;
            botonSalir.Location = new Point(173, 320);
            botonSalir.Margin = new Padding(0);
            botonSalir.Name = "botonSalir";
            botonSalir.Size = new Size(90, 35);
            botonSalir.TabIndex = 7;
            botonSalir.Text = "SALIR";
            botonSalir.UseVisualStyleBackColor = false;
            botonSalir.Click += botonSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(103, 46);
            label1.TabIndex = 8;
            label1.Text = "Login";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 367);
            Controls.Add(label1);
            Controls.Add(botonSalir);
            Controls.Add(registro);
            Controls.Add(labelError);
            Controls.Add(tNombre);
            Controls.Add(tPass);
            Controls.Add(login);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button login;
        private TextBox tPass;
        private TextBox tNombre;
        private Label labelError;
        private LinkLabel registro;
        private Button botonSalir;
        private Label label1;
    }
}