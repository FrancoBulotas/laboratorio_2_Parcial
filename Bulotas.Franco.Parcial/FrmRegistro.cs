﻿using Biblioteca;
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
        //private List<Usuario> listaUsuarios;
        public FrmLogin login;
        private Administracion administracion;
        private Dictionary<string, string> dictResultadoRegistro = new Dictionary<string, string>();


        //public FrmRegistro(List<Usuario> listaUsuarios, FrmLogin login, Administracion rrhh)
        public FrmRegistro(FrmLogin login, Administracion administracion)
        {
            InitializeComponent();

            this.administracion = administracion;
            //this.listaUsuarios = listaUsuarios;
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
            }
            else
            {
                labelErrorRegistro.Visible = false;
                this.Hide();
                login.Show();
                MessageBox.Show($"Registrado Correctamente \nUsuario: {nombre} \nContraseña: {contra} \nTipo Usuario: {tipoUsuario}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dictResultadoRegistro["Error"] = "";

            //if (nombre != String.Empty)
            //{
            //    if (contra != String.Empty && contra == repContra)
            //    {
            //        if (checkBoxOperario.Checked && checkBoxSupervisor.Checked == false)
            //        {
            //            tipoUsuario = checkBoxOperario.Text.ToLower();
            //        }
            //        else if (checkBoxOperario.Checked == false && checkBoxSupervisor.Checked)
            //        {
            //            tipoUsuario = checkBoxSupervisor.Text.ToLower();
            //        }

            //        //Usuario user = new Usuario(nombre, contra, tipoUsuario);
            //        //if (administracion.AgregarUsuario(this.listaUsuarios, user, tipoUsuario))

            //        if (UsuarioDAO.Guardar(nombre, contra, tipoUsuario))
            //        {
            //            administracion.ListaUsuarios = UsuarioDAO.LeerTodo();
            //            this.Hide();
            //            login.Show();
            //            MessageBox.Show($"Registrado Correctamente \nUsuario: {nombre} \nContraseña: {contra} \nTipo Usuario: {tipoUsuario}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            if (tipoUsuario == string.Empty)
            //            {
            //                this.labelErrorRegistro.Text = "Error. Seleccionar un tipo de usuario.";
            //            }
            //            else
            //            {
            //                this.labelErrorRegistro.Text = "Error al registrar usuario.";
            //            }
            //            this.labelErrorRegistro.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        if (contra != repContra)
            //        {
            //            this.labelErrorRegistro.Text = "Error. Las contraseñas no coinciden.";
            //        }
            //        else
            //        {
            //            this.labelErrorRegistro.Text = "Error. Contraseña vacia.";
            //        }
            //        this.labelErrorRegistro.Visible = true;
            //    }
            //}
            //else
            //{
            //    this.labelErrorRegistro.Text = "Error. Nombre de usuario vacio.";
            //    this.labelErrorRegistro.Visible = true;
            //}
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
