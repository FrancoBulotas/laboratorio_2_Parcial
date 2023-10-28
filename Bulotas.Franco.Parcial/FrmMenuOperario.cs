using Biblioteca;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        internal Stock stock;
        internal DataGridViewRow filaPedidoEnProceso;
        internal int contProcesos = 0;
        internal ArrayList arrayControlStock = new ArrayList();

        public FrmMenuOperario(List<Usuario> listaUsuarios, int indexUsuario, FrmLogin login, Stock stock)
        {
            InitializeComponent();
            this.listaUsuarios = listaUsuarios;
            indexUsuarioLogueado = indexUsuario;
            this.login = login;
            this.stock = stock;
        }

        private void FrmPruebaMenu_Load(object sender, EventArgs e)
        {
            string directorioEjecutable = AppDomain.CurrentDomain.BaseDirectory;
            string rutaImagenFondo = Path.Combine(directorioEjecutable, "fondo-app.jpg");
            string rutaIcono = Path.Combine(directorioEjecutable, "icono-sistema.ico");
            this.BackgroundImage = Image.FromFile(rutaImagenFondo);
            this.Icon = new Icon(rutaIcono);

            this.nombreLogueado.Text = listaUsuarios[indexUsuarioLogueado].NombreUsuario;

            Operacion.CargarMaterialesDataGridView(this);

            Visual.CargarStock(dataGridView2, stock);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Operacion.ManejoDataGrid(this, e);
        }

        private void botonVolverSup_Click(object sender, EventArgs e)
        {
            Visual.CargarStock(login.menuSupervisor.dataGridView2, stock);

            Visual.ControlStock(stock, dataGridView2, "papel");
            Visual.ControlStock(stock, dataGridView2, "tinta");
            Visual.ControlStock(stock, dataGridView2, "troquel");
            Visual.ControlStock(stock, dataGridView2, "encuadernacion");

            Visual.ControlStock(login.menuSupervisor.stock, login.menuSupervisor.dataGridView2, "papel");
            Visual.ControlStock(login.menuSupervisor.stock, login.menuSupervisor.dataGridView2, "tinta");
            Visual.ControlStock(login.menuSupervisor.stock, login.menuSupervisor.dataGridView2, "troquel");
            Visual.ControlStock(login.menuSupervisor.stock, login.menuSupervisor.dataGridView2, "encuadernacion");

            this.Hide();
            login.menuSupervisor.Show();

        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            Visual.ControlStock(stock, dataGridView2, "papel");
            Visual.ControlStock(stock, dataGridView2, "tinta");
            Visual.ControlStock(stock, dataGridView2, "troquel");
            Visual.ControlStock(stock, dataGridView2, "encuadernacion");
            this.Hide();
            login.Show();
        }

        private void radioButtonImpresora_CheckedChanged(object sender, EventArgs e)
        {
            // Deshabilitar el botón mientras se realiza la tarea
            if (radioButtonImpresora.Checked)
            {
                radioButtonImpresora.Enabled = false;
                Operacion.RealizarTarea(true, false, false, this);

                Operacion.ControlProduccion(this, true, false);
                Operacion.ControlProduccion(this, true, false, false, listaUsuarios[indexUsuarioLogueado]);

                login.menuSupervisor.dataGridView1.Refresh();
                login.menuSupervisor.dataGridView1.Update();
            }
        }
        private void radioButtonTroqueladora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTroqueladora.Checked)
            {
                radioButtonTroqueladora.Enabled = false;
                Operacion.RealizarTarea(false, true, false, this);

                Operacion.ControlProduccion(this, false, true);
                Operacion.ControlProduccion(this, true, true, false, listaUsuarios[indexUsuarioLogueado]);

                login.menuSupervisor.dataGridView1.Refresh();
                login.menuSupervisor.dataGridView1.Update();
            }
        }
        private void radioButtonEncuadernadora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEncuadernadora.Checked)
            {
                radioButtonEncuadernadora.Enabled = false;
                Operacion.RealizarTarea(false, false, true, this);

                Operacion.ControlProduccion(this, true, true, true, listaUsuarios[indexUsuarioLogueado]);

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
