using Biblioteca;
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
    public partial class FrmMenuSupervisor : Form
    {
        private List<Usuario> listaUsuarios;
        public FrmLogin login;
        private Stock stock;
        private int indexUsuarioLogueado;
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
            CargarStock();

            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (listaUsuarios != null)
                {
                    string[] usuario = { listaUsuarios[i].nombreUsuario, listaUsuarios[i].contrasenia, listaUsuarios[i].tipoUsuario };
                    this.dataGridView1.Rows.Add(usuario);
                }
            }

            this.labelPrecioPapel.Text = "$ " + stock.PrecioPapelUni.ToString();
            this.labelPrecioTinta.Text = "$ " + stock.PrecioTintaUni.ToString();
            this.labelPrecioTroquel.Text = "$ " + stock.PrecioTroquelUni.ToString();
            this.labelPrecioEncuadernacion.Text = "$ " + stock.PrecioEncuadernacionUni.ToString();
        }
        private void CargarStock()
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

        private void botonMenuOperarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.menuOperario.botonVolverSup.Visible = true;
            login.menuOperario.Show();
        }

        private void CalcularCompra()
        {
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

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            if ((this.textBoxPapel.Text != string.Empty ||
                this.textBoxTinta.Text != string.Empty ||
                this.textBoxTroquel.Text != string.Empty ||
                this.textBoxEncuadernacion.Text != string.Empty))
            {
                int.TryParse(this.textBoxPapel.Text, out int papelIngresado);
                int.TryParse(this.textBoxTinta.Text, out int tintaIngresada);
                int.TryParse(this.textBoxTroquel.Text, out int troquelIngresado);
                int.TryParse(this.textBoxEncuadernacion.Text, out int encuIngresado);

                this.cantidadPapelAComprar = papelIngresado;
                this.cantidadTintaAComprar = tintaIngresada;
                this.cantidadTroquelAComprar = troquelIngresado;
                this.cantidadEncuadernacionAComprar = encuIngresado;
                CalcularCompra();
            }
            login.menuOperario.CargarStock();
            CargarStock();

        }

        private void labelPrecioTinta_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

