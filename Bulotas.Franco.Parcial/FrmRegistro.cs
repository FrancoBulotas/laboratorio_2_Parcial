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
        private List<Usuario> listaUsuarios;
        public FrmLogin login;
        private RRHH RRHH;

        public FrmRegistro(List<Usuario> listaUsuarios, FrmLogin login, RRHH rrhh)
        {
            InitializeComponent();

            this.RRHH = rrhh;
            this.listaUsuarios = listaUsuarios;
            this.login = login;
            login.Hide();
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

            if (nombre != String.Empty)
            {
                if (contra != String.Empty && contra == repContra)
                {
                    if (checkBoxOperario.Checked && checkBoxSupervisor.Checked == false)
                    {
                        tipoUsuario = checkBoxOperario.Text.ToLower();
                    }
                    else if (checkBoxOperario.Checked == false && checkBoxSupervisor.Checked)
                    {
                        tipoUsuario = checkBoxSupervisor.Text.ToLower();
                    }

                    Usuario user = new Usuario(nombre, contra, tipoUsuario);

                    if (RRHH.AgregarUsuario(this.listaUsuarios, user, tipoUsuario))
                    {
                        this.Hide();
                        login.Show();

                        MessageBox.Show($"Registrado Correctamente \nUsuario: {nombre} \nContraseña: {contra} \nTipo Usuario: {tipoUsuario}");
                    }
                    else
                    {
                        if (tipoUsuario == string.Empty)
                        {
                            this.labelErrorRegistro.Text = "Error. Seleccionar un tipo de usuario.";
                        }
                        else
                        {
                            this.labelErrorRegistro.Text = "Error al registrar usuario.";
                        }
                        this.labelErrorRegistro.Visible = true;
                    }
                }
                else
                {
                    if (contra != repContra)
                    {
                        this.labelErrorRegistro.Text = "Error. Las contraseñas no coinciden.";
                    }
                    else
                    {
                        this.labelErrorRegistro.Text = "Error. Contraseña vacia.";
                    }
                    this.labelErrorRegistro.Visible = true;
                }
            }
            else
            {
                this.labelErrorRegistro.Text = "Error. Nombre de usuario vacio.";
                this.labelErrorRegistro.Visible = true;
            }
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
            this.tbNombreUsuario.Text = RRHH.ValorRandom(true, false);
            string contra = RRHH.ValorRandom(false, false);
            this.tbContraseña.Text = contra;
            this.tbRepContraseña.Text = contra;

            if (RRHH.ValorRandom(false, true) == "0")
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

        //public static string ValorRandom(bool nombreUsuario, bool tipoUsuario)
        //{
        //    List<string> listaNombres = new List<string>
        //    {
        //        "Franco","Pedro","Juan","Fausto","Adriana","Agustina","Joaquin","Malena"
        //    };

        //    string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        //    char[] arrayChar = new char[4];
        //    string tipo = "01";
        //    char[] arrayTipo = new char[1];
        //    Random random = new Random();

        //    if (tipoUsuario)
        //    {
        //        for (int i = 0; i < arrayTipo.Length; i++)
        //        {
        //            arrayTipo[i] = tipo[random.Next(tipo.Length)];
        //        }
        //        return new String(arrayTipo);
        //    }
        //    else
        //    {
        //        if (!nombreUsuario)
        //        {
        //            for (int i = 0; i < arrayChar.Length; i++)
        //            {
        //                arrayChar[i] = caracteres[random.Next(caracteres.Length)];
        //            }
        //            return new String(arrayChar);
        //        }
        //        else
        //        {
        //            return listaNombres[random.Next(listaNombres.Count)];
        //        }
        //    }
        //}
    }
}
