using Biblioteca;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frms
{
    public partial class FrmRegistro : Form
    {
        internal FrmLogin login;
        private Administracion administracion;
        private Dictionary<string, string> dictResultadoRegistro = new Dictionary<string, string>();
        private string msjError;

        public FrmRegistro(FrmLogin login, Administracion administracion)
        {
            InitializeComponent();

            this.administracion = administracion;
            this.login = login;
            login.Hide();

            this.BackgroundImage = Visual.CargarFondo(true);
            this.Icon = Visual.CargarIcono();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();
        }

        private void botonRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = this.tbNombreUsuario.Text;
            string contra = this.tbContraseña.Text;
            string repContra = this.tbRepContraseña.Text;
            string tipoUsuario = "";

            if (checkBoxOperario.Checked && checkBoxSupervisor.Checked == false)
            {
                tipoUsuario = checkBoxOperario.Text.ToLower();
            }
            else if (checkBoxOperario.Checked == false && checkBoxSupervisor.Checked)
            {
                tipoUsuario = checkBoxSupervisor.Text.ToLower();
            }

            dictResultadoRegistro = administracion.ValidarUsuarioRegistro(nombre, contra, repContra, tipoUsuario);

            if (dictResultadoRegistro["Error"].Length > 0)
            {
                labelErrorRegistro.Text = dictResultadoRegistro["Error"];
                labelErrorRegistro.Visible = true;

                msjError = $"{DateTime.Now} | Registro: {dictResultadoRegistro["Error"]}";
                administracion.CargarErrorLog(msjError);
            }
            else
            {
                labelErrorRegistro.Visible = false;
                this.Hide();
                login.Show();
                MessageBox.Show($"Registrado Correctamente \nUsuario: {nombre} \nContraseña: {contra} \nTipo Usuario: {tipoUsuario}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dictResultadoRegistro["Error"] = "";
        }

        private void linkLabelVaciar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tbNombreUsuario.Text = string.Empty;
            this.tbContraseña.Text = string.Empty;
            this.tbRepContraseña.Text = string.Empty;
            this.checkBoxOperario.Checked = false;
            this.checkBoxSupervisor.Checked = false;
        }

        private void tbRepContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabelRandom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tbNombreUsuario.Text = administracion.ValorRandomUsuario(false, true);
            string contra = administracion.ValorRandomUsuario(false, false);
            this.tbContraseña.Text = contra;
            this.tbRepContraseña.Text = contra;

            if (administracion.ValorRandomUsuario(true, false) == "operario")
            {
                this.checkBoxOperario.Checked = true;
                this.checkBoxSupervisor.Checked = false;
            }
            else
            {
                this.checkBoxOperario.Checked = false;
                this.checkBoxSupervisor.Checked = true;
            }
        }
    }
}
