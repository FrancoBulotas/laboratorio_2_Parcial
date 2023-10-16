using Biblioteca;
using System;
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
            this.BackgroundImage = Image.FromFile("C:\\Users\\Franco\\Desktop\\UTN FRA\\Tecnicatura Superior en Programacion\\2do Cuatrimestre\\Laboratorio II\\PRIMER-PARCIAL\\posible-fondo-app-2.jpg");
            this.nombreLogueado.Text = listaUsuarios[indexUsuarioLogueado].nombreUsuario;
            stock.CargarStock(this);
            Operacion.CargarPedidosDataGridView(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Operacion.ManejoDataGrid(this, e);
        }

        private void botonVolverSup_Click(object sender, EventArgs e)
        {
            stock.CargarStock(login.menuSupervisor);
            stock.ControlStock(this, filaPedidoEnProceso);

            this.Hide();
            login.menuSupervisor.Show();

        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            stock.ControlStock(this, filaPedidoEnProceso);

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
