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
        private List<Usuario> listaUsuarios;
        private int indexUsuarioLogueado;
        internal FrmLogin login;
        internal DataGridViewRow filaPedidoEnProceso;
        internal int contProcesos = 0;
        internal ArrayList arrayControlStock = new ArrayList();

        public FrmMenuOperario(List<Usuario> listaUsuarios, int indexUsuario, FrmLogin login)
        {
            InitializeComponent();
            this.listaUsuarios = listaUsuarios;
            indexUsuarioLogueado = indexUsuario;
            this.login = login;
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
            // Deshabilitar el botón mientras se realiza la tarea
            if (radioButtonImpresora.Checked)
            {
                radioButtonImpresora.Enabled = false;
                Visual.ModificarProgressBar(progressBarImpresora);

                labelImpresionExitosa.Visible = true;

                Visual.ControlSeleccionProduccion(this, true, false);
                Visual.InfoProcesoProduccion(this, true, false, false, listaUsuarios[indexUsuarioLogueado]);

                login.menuSupervisor.dataGridView1.Refresh();
                login.menuSupervisor.dataGridView1.Update();
            }
        }
        private void radioButtonTroqueladora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTroqueladora.Checked)
            {
                radioButtonTroqueladora.Enabled = false;
                          
                Visual.ModificarProgressBar(progressBarTroqueladora);
                labelTroqueladoExitoso.Visible = true;

                Visual.ControlSeleccionProduccion(this, false, true);
                Visual.InfoProcesoProduccion(this, true, true, false, listaUsuarios[indexUsuarioLogueado]);

                login.menuSupervisor.dataGridView1.Refresh();
                login.menuSupervisor.dataGridView1.Update();
            }
        }
        private void radioButtonEncuadernadora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEncuadernadora.Checked)
            {
                radioButtonEncuadernadora.Enabled = false;
                
                Visual.ModificarProgressBar(progressBarEncuadernadora);
                labelEncuExitosa.Visible = true;

                Visual.InfoProcesoProduccion(this, true, true, true, listaUsuarios[indexUsuarioLogueado]);

                login.menuSupervisor.dataGridView1.Refresh();
                login.menuSupervisor.dataGridView1.Update();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void nombreLogueado_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void progressBarTroqueladora_Click(object sender, EventArgs e)
        {

        }


    }
}
