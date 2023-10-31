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
        internal List<Usuario> listaUsuarios;
        internal int indexUsuarioLogueado;
        internal FrmLogin login;
        internal DataGridViewRow filaPedidoEnProceso;
        internal int contProcesos = 0;
        internal ArrayList arrayControlStock = new ArrayList();
        internal int cantPapelAConsumir;
        internal int cantTintaAConsumir;
        internal int cantTroquelAConsumir;
        internal int cantEncuAConsumir;

        public FrmMenuOperario(List<Usuario> listaUsuarios, int indexUsuario, FrmLogin login)
        {
            InitializeComponent();
            this.listaUsuarios = listaUsuarios;
            indexUsuarioLogueado = indexUsuario;
            this.login = login;
            cantPapelAConsumir = 0;
            cantTintaAConsumir = 0;
            cantTroquelAConsumir = 0;
            cantEncuAConsumir = 0;
        }

        private void FrmPruebaMenu_Load(object sender, EventArgs e)
        {
            string directorioEjecutable = AppDomain.CurrentDomain.BaseDirectory;
            string rutaImagenFondo = Path.Combine(directorioEjecutable, "fondo-app.jpg");
            string rutaIcono = Path.Combine(directorioEjecutable, "icono-sistema.ico");
            this.BackgroundImage = Image.FromFile(rutaImagenFondo);
            this.Icon = new Icon(rutaIcono);

            this.nombreLogueado.Text = listaUsuarios[indexUsuarioLogueado].NombreUsuario;

            Visual.CargarMaterialesDataGridView(dataGridView2, login.stock);

            Visual.CargarStockDg(dataGridView2, login.stock);
        }

        private void FrmPruebaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Visual.ManejoDataGrid(this, e);
        }

        private void botonVolverSup_Click(object sender, EventArgs e)
        {
            Visual.CargarStockDg(login.menuSupervisor.dataGridView2, login.stock);
            Visual.ControlDataGridStock(login.stock, dataGridView2, false);
            Visual.ControlDataGridStock(login.stock, login.menuSupervisor.dataGridView2, false);

            this.Hide();
            login.menuSupervisor.Show();

        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            Visual.ControlDataGridStock(login.stock, dataGridView2, true);
            this.Hide();
            login.Show();
        }

        private void radioButtonImpresora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonImpresora.Checked)
            {
                Visual.ActualizarFormAlChequear(this, radioButtonImpresora, labelImpresionExitosa, progressBarImpresora, true, false);
                Visual.InfoProcesoProduccion(this, true, false, false, listaUsuarios[indexUsuarioLogueado]);
            }
        }

        private void radioButtonTroqueladora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTroqueladora.Checked)
            {
                Visual.ActualizarFormAlChequear(this, radioButtonTroqueladora, labelTroqueladoExitoso, progressBarTroqueladora, false, true);
                Visual.InfoProcesoProduccion(this, true, true, false, listaUsuarios[indexUsuarioLogueado]);
            }
        }

        private void radioButtonEncuadernadora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEncuadernadora.Checked)
            {
                Visual.ActualizarFormAlChequear(this, radioButtonEncuadernadora, labelEncuExitosa, progressBarEncuadernadora, false, false);
                Visual.InfoProcesoProduccion(this, true, true, true, listaUsuarios[indexUsuarioLogueado]);
            }
        }
    }
}
