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

        private DatosForms datosFormulario;

        public FrmRegistro(FrmLogin login, Administracion administracion)
        {
            InitializeComponent();

            datosFormulario = new DatosForms();

            this.administracion = administracion;
            this.login = login;
            login.Hide();
            administracion.EventoLogError += Administracion_EventoLogError;
            this.BackgroundImage = Visual.CargarFondo(true);
            this.Icon = Visual.CargarIcono();

            GuardarDatosForm();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            GuardarDatosForm();
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

                msjError = $"{DateTime.Now} | Registro: {dictResultadoRegistro["Error"]}";
                administracion.archivo.CargarErrorLog(msjError);
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

        private void Administracion_EventoLogError(object sender, string msjError)
        {
            labelErrorRegistro.Visible = true;
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

        private void GuardarDatosForm()
        {
            datosFormulario.botonCancelar = botonCancelar.Text;
            datosFormulario.labelRegistro = labelRegistro.Text;
            datosFormulario.tbNombreUsuario = tbNombreUsuario.Text;
            datosFormulario.tbContraseña = tbContraseña.Text;
            datosFormulario.tbRepContraseña = tbRepContraseña.Text;
            datosFormulario.botonRegistrar = botonRegistrar.Text;
            datosFormulario.labelErrorRegistro = labelErrorRegistro.Text;
            datosFormulario.linkLabelVaciar = linkLabelVaciar.Text;
            datosFormulario.checkBoxOperario = checkBoxOperario.Text;
            datosFormulario.linkLabelRandom = linkLabelRandom.Text;
            datosFormulario.checkBoxSupervisor = checkBoxSupervisor.Text;

            login.archivo.SerializarXML(datosFormulario, "FrmRegistro");
        }
    }
}
