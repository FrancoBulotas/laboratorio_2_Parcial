using Biblioteca;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Frms
{
    public partial class FrmMenuOperario : Form
    {
        internal Administracion administracion;
        internal int indexUsuarioLogueado;
        internal FrmLogin login;
        internal DataGridViewRow filaPedidoEnProceso;
        internal int contProcesos = 0;
        internal ArrayList arrayControlStock = new ArrayList();
        internal int cantPapelAConsumir;
        internal int cantTintaAConsumir;
        internal int cantTroquelAConsumir;
        internal int cantEncuAConsumir;

        public FrmMenuOperario(Administracion administracion, int indexUsuario, FrmLogin login)
        {
            InitializeComponent();
            this.administracion = administracion;
            indexUsuarioLogueado = indexUsuario;
            this.login = login;
            cantPapelAConsumir = 0;
            cantTintaAConsumir = 0;
            cantTroquelAConsumir = 0;
            cantEncuAConsumir = 0;
            administracion.SerializarXMLStock(login.stock);
        }

        private void FrmPruebaMenu_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Visual.CargarFondo(false);
            this.Icon = Visual.CargarIcono();

            this.nombreLogueado.Text = administracion.ListaUsuarios[indexUsuarioLogueado].NombreUsuario;

            Visual.CargarMaterialesDataGridView(dataGridView2, login.stock);
            Visual.CargarStockDataGrid(dataGridView2, login.stock);
            Visual.ControlDataGridStock(login.stock, dataGridView2);
        }

        private void FrmPruebaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Visual.ManejoDataGridOperario(this, e);
        }

        private void botonVolverSup_Click(object sender, EventArgs e)
        {
            Visual.CargarStockDataGrid(login.menuSupervisor.dataGridView2, login.stock);
            Visual.ControlDataGridStock(login.stock, dataGridView2);
            Visual.ControlDataGridStock(login.stock, login.menuSupervisor.dataGridView2);

            //Visual.CargarUsuariosDataGrid(login.menuSupervisor.dataGridView1, administracion, administracion.ListaUsuarios[indexUsuarioLogueado].ID);
            login.cargaDeUsuariosDataGrid(login.menuSupervisor.dataGridView1, administracion, administracion.ListaUsuarios[indexUsuarioLogueado].ID);

            administracion.SerializarXMLStock(login.stock);

            this.Hide();
            login.menuSupervisor.Show();

        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            administracion.SerializarXMLStock(login.stock);

            Visual.ControlDataGridStock(login.stock, dataGridView2);
            this.Hide();
            login.Show();
        }

        private void radioButtonImpresora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonImpresora.Checked)
            {
                Visual.ActualizarFormAlChequear(this, radioButtonImpresora, labelImpresionExitosa, progressBarImpresora, true, false);
                Visual.InfoProcesoProduccion(this, true, false, false, administracion.ListaUsuarios[indexUsuarioLogueado]);
            }
        }

        private void radioButtonTroqueladora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTroqueladora.Checked)
            {
                Visual.ActualizarFormAlChequear(this, radioButtonTroqueladora, labelTroqueladoExitoso, progressBarTroqueladora, false, true);
                Visual.InfoProcesoProduccion(this, true, true, false, administracion.ListaUsuarios[indexUsuarioLogueado]);
            }
        }

        private void radioButtonEncuadernadora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEncuadernadora.Checked)
            {
                Visual.ActualizarFormAlChequear(this, radioButtonEncuadernadora, labelEncuExitosa, progressBarEncuadernadora, false, false);
                Visual.InfoProcesoProduccion(this, true, true, true, administracion.ListaUsuarios[indexUsuarioLogueado]);
            }
        }
    }
}
