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

namespace Frms
{
    public partial class FrmMenuSupervisor : Form
    {
        private List<Usuario> listaUsuarios;
        private int indexUsuarioLogueado;
        public FrmLogin login;
        private Stock stock;
        private int cantidadPapelAComprar;
        private int cantidadTintaAComprar;
        private int cantidadTroquelAComprar;
        private int cantidadEncuadernacionAComprar;
        private int cantidadTotalAComprar;

        public FrmMenuSupervisor(List<Usuario> listaUsuarios, int indexUsuario, FrmLogin login, Stock stock)
        {
            InitializeComponent();
            this.listaUsuarios = listaUsuarios;
            indexUsuarioLogueado = indexUsuario;
            this.login = login;
            this.stock = stock;
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            cargarStock();

            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (listaUsuarios != null)
                {
                    string[] usuario = { listaUsuarios[i].nombreUsuario, listaUsuarios[i].contraseña, listaUsuarios[i].tipoUsuario };
                    this.dataGridView1.Rows.Add(usuario);
                }
            }

            this.labelPrecioPapel.Text = "$ " + stock.PrecioPapelUni.ToString();
            this.labelPrecioTinta.Text = "$ " + stock.PrecioTintaUni.ToString();
            this.labelPrecioTroquel.Text = "$ " + stock.PrecioTroquelUni.ToString();
            this.labelPrecioEncuadernacion.Text = "$ " + stock.PrecioEncuadernacionUni.ToString();
        }
        private void cargarStock()
        {
            this.label3.Text = stock.Papel.ToString() + " Uni.";
            this.label4.Text = stock.Tinta.ToString() + " L.";
            this.label6.Text = stock.Troquel.ToString() + " Uni.";
            this.label8.Text = stock.Encuadernacion.ToString() + " Uni.";
            this.nombreLogueado.Text = listaUsuarios[indexUsuarioLogueado].nombreUsuario;
            this.labelPresupuesto.Text = "$ " + stock.PresupuestoTotal.ToString();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void botonMenuOperarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.menuOperario.botonVolverSup.Visible = true;
            login.menuOperario.Show();
        }

        private void calcularCompra()
        {

            cantidadPapelAComprar = validarCantidadIngresada(this.textBoxPapel.Text);
            cantidadTroquelAComprar = validarCantidadIngresada(this.textBoxTroquel.Text);
            cantidadTintaAComprar = validarCantidadIngresada(this.textBoxTinta.Text);
            cantidadEncuadernacionAComprar = validarCantidadIngresada(this.textBoxEncuadernacion.Text);

            cantidadTotalAComprar = (cantidadPapelAComprar * stock.PrecioPapelUni)
                        + (cantidadTroquelAComprar * stock.PrecioTroquelUni)
                        + (cantidadTintaAComprar * stock.PrecioTintaUni)
                        + (cantidadEncuadernacionAComprar * stock.PrecioEncuadernacionUni);

            if (stock.PresupuestoTotal - cantidadTotalAComprar >= 0)
            {
                if (cantidadPapelAComprar >= 0) { stock.Papel = cantidadPapelAComprar; }
                else { this.textBoxPapel.Text = ""; }
                if (cantidadTintaAComprar >= 0) { stock.Tinta = cantidadTintaAComprar; }
                else { this.textBoxTinta.Text = ""; }
                if (cantidadTroquelAComprar >= 0) { stock.Troquel = cantidadTroquelAComprar; }
                else { this.textBoxTroquel.Text = ""; }
                if (cantidadEncuadernacionAComprar >= 0) { stock.Encuadernacion = cantidadEncuadernacionAComprar; }
                else { this.textBoxEncuadernacion.Text = ""; }

                stock.PresupuestoTotal = -cantidadTotalAComprar;
            }
            else
            {
                MessageBox.Show("Presupuesto insuficiente");
            }

        }

        private int validarCantidadIngresada(string cantidad)
        {
            try
            {
                return Convert.ToInt32(cantidad);
            }
            catch (System.FormatException)
            {
                return -1;
            }
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            if ((this.textBoxPapel.Text != string.Empty ||
                this.textBoxTinta.Text != string.Empty ||
                this.textBoxTroquel.Text != string.Empty ||
                this.textBoxEncuadernacion.Text != string.Empty) &&
                (validarCantidadIngresada(this.textBoxPapel.Text) >= 0 ||
                validarCantidadIngresada(this.textBoxTinta.Text) >= 0 ||
                validarCantidadIngresada(this.textBoxTroquel.Text) >= 0 ||
                validarCantidadIngresada(this.textBoxEncuadernacion.Text) >= 0))
            {
                calcularCompra();
            }
            login.menuOperario.cargarStock();
            cargarStock();

        }

        private void labelPrecioTinta_Click(object sender, EventArgs e)
        {

        }
    }
}

