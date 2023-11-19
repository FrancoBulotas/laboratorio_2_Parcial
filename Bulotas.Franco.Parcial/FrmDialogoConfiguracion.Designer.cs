namespace Frms
{
    partial class FrmDialogoConfiguracion
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
            btnOpSup = new Button();
            btnLogReg = new Button();
            SuspendLayout();
            // 
            // btnOpSup
            // 
            btnOpSup.BackColor = SystemColors.ControlDark;
            btnOpSup.Location = new Point(9, 29);
            btnOpSup.Margin = new Padding(0);
            btnOpSup.Name = "btnOpSup";
            btnOpSup.Size = new Size(159, 29);
            btnOpSup.TabIndex = 29;
            btnOpSup.Text = "OPERARIO / SUPERVISOR";
            btnOpSup.UseVisualStyleBackColor = false;
            btnOpSup.Click += btnOpSup_Click;
            // 
            // btnLogReg
            // 
            btnLogReg.BackColor = SystemColors.ControlDark;
            btnLogReg.Location = new Point(192, 29);
            btnLogReg.Margin = new Padding(0);
            btnLogReg.Name = "btnLogReg";
            btnLogReg.Size = new Size(119, 29);
            btnLogReg.TabIndex = 30;
            btnLogReg.Text = "LOGIN / REGISTRO";
            btnLogReg.UseVisualStyleBackColor = false;
            btnLogReg.Click += btnLogReg_Click;
            // 
            // FrmDialogoConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 87);
            Controls.Add(btnLogReg);
            Controls.Add(btnOpSup);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmDialogoConfiguracion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sispro - Configuracion";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpSup;
        private Button btnLogReg;
    }
}