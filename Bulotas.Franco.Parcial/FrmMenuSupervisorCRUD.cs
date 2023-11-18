using Biblioteca;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frms
{
    public partial class FrmMenuSupervisorCRUD : Form
    {
        internal bool botonModClickeado = false;
        internal int idUsuarioSeleccionado;
        internal int indiceUsuarioSeleccionado;
        internal Administracion administracion;
        internal FrmMenuSupervisor formSupervisor;
        internal Dictionary<string, string> dictResultadoRegistro = new Dictionary<string, string>();

        public FrmMenuSupervisorCRUD(Administracion administracion, FrmMenuSupervisor formSupervisor)
        {
            InitializeComponent();

            this.administracion = administracion;
            this.formSupervisor = formSupervisor;

            dictResultadoRegistro.Add("Error", "");
        }

        private void FrmMenuSupervisorCRUD_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Visual.CargarFondo(false);
            this.Icon = Visual.CargarIcono();

            //Visual.CargarUsuariosDataGrid(dataGridViewUsr, administracion, 0);
            formSupervisor.login.cargaDeUsuariosDataGrid(dataGridViewUsr, administracion, 0);
        }

        private void dataGridViewUsr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Visual.ManejoDataGridCRUD(this, e);
        }

        private void buttonModificarUsr_Click(object sender, EventArgs e)
        {
            dataGridViewUsr.Enabled = true;
            botonModClickeado = true;
            Visual.MostrarMenuModificar(this);
        }

        private void buttonAplicarModificacion_Click(object sender, EventArgs e)
        {
            Visual.EjecutarSolicitado(this, true);
        }

        private void buttonCrearUsr_Click(object sender, EventArgs e)
        {
            dataGridViewUsr.Enabled = false;
            Visual.MostrarMenuCrear(this);
        }

        private void buttonAplicarCreacion_Click(object sender, EventArgs e)
        {
            Visual.EjecutarSolicitado(this, false);

            dataGridViewUsr.Enabled = true;
        }

        private void buttoneliminarUsr_Click(object sender, EventArgs e)
        {
            UsuarioDAO.Eliminar(idUsuarioSeleccionado);
            administracion.ListaUsuarios.Remove(administracion.ListaUsuarios[indiceUsuarioSeleccionado]);

            Visual.ActualizarDataGrid(formSupervisor.dataGridView1, administracion, true);
            Visual.ActualizarDataGrid(dataGridViewUsr, administracion, false);
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
