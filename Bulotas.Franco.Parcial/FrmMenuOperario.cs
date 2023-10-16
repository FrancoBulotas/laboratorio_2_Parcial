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
        public FrmLogin login;
        private Stock stock;

        public FrmMenuOperario(List<Usuario> listaUsuarios, int indexUsuario, FrmLogin login, Stock stock)
        {
            InitializeComponent();
            this.listaUsuarios = listaUsuarios;
            indexUsuarioLogueado = indexUsuario;
            this.login = login;
            this.stock = stock;
            this.BackgroundImage = Image.FromFile("C:\\Users\\Franco\\Desktop\\UTN FRA\\Tecnicatura Superior en Programacion\\2do Cuatrimestre\\Laboratorio II\\PRIMER-PARCIAL\\posible-fondo-app-2.jpg");
        }

        private void FrmPruebaMenu_Load(object sender, EventArgs e)
        {
            this.nombreLogueado.Text = listaUsuarios[indexUsuarioLogueado].nombreUsuario;
            stock.CargarStock(this);
            CargarDataGridView();
        }

        private void CargarDataGridView()
        {
            string[] pedido1 = { "Libros de matematica", "10000", "5000", "1500", "1250", "0", "$100000" };
            string[] pedido2 = { "Boletas", "50000", "7500", "1200", "0", "0", "$170000" };
            string[] pedido3 = { "Cuadernillos", "6000", "5000 ", "1500", "800", "2000", "$130000" };
            string[] pedido4 = { "LIbros de literatura", "3000", "2200", "700", "0", "280", "$60000" };

            dataGridView1.Rows.Add(pedido1);
            dataGridView1.Rows.Add(pedido2);
            dataGridView1.Rows.Add(pedido3);
            dataGridView1.Rows.Add(pedido4);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Calculos.ManejoDataGrid(this, stock, e);
        }

        private void botonVolverSup_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.menuSupervisor.Show();
            stock.CargarStock(login.menuSupervisor);
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();
        }

        private void radioButtonImpresora_CheckedChanged(object sender, EventArgs e)
        {
            // Deshabilitar el botón mientras se realiza la tarea
            if (radioButtonImpresora.Checked)
            {
                radioButtonImpresora.Enabled = false;
                RealizarTarea(true, false, false);
            }
        }
        private void radioButtonTroqueladora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTroqueladora.Checked)
            {
                radioButtonTroqueladora.Enabled = false;
                RealizarTarea(false, true, false);
            }
        }
        private void radioButtonEncuadernadora_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEncuadernadora.Checked)
            {
                radioButtonEncuadernadora.Enabled = false;
                RealizarTarea(false, false, true);
            }
        }


        private void RealizarTarea(bool impresora, bool troqueladora, bool encuadernadora) // REPLICAR CON LOS DEMAS
        {
            if (impresora)
            {
                for (int i = 0; i <= 100; i++)
                {
                    progressBarImpresora.Value = i;
                    progressBarImpresora.Refresh();
                    Thread.Sleep(30);
                }
                progressBarImpresora.Value = progressBarImpresora.Maximum;
            }
            else if (troqueladora)
            {
                for (int i = 0; i <= 100; i++)
                {
                    progressBarTroqueladora.Value = i;
                    progressBarTroqueladora.Refresh();
                    Thread.Sleep(30);
                }
                progressBarTroqueladora.Value = progressBarTroqueladora.Maximum;
            }
            else if (encuadernadora)
            {
                for (int i = 0; i <= 100; i++)
                {
                    progressBarEncuadernadora.Value = i;
                    progressBarEncuadernadora.Refresh();
                    Thread.Sleep(30);
                }
                progressBarEncuadernadora.Value = progressBarEncuadernadora.Maximum;
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
