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
        internal Stock stock;
        internal int indexUsuarioLogueado;
        internal int cantidadPapelAComprar;
        internal int cantidadTintaAComprar;
        internal int cantidadTroquelAComprar;
        internal int cantidadEncuadernacionAComprar;
        internal int cantidadTotalAComprar;

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
            string directorioEjecutable = AppDomain.CurrentDomain.BaseDirectory;
            string rutaImagenFondo = Path.Combine(directorioEjecutable, "fondo-app.jpg");
            string rutaIcono = Path.Combine(directorioEjecutable, "icono-sistema.ico");
            this.BackgroundImage = Image.FromFile(rutaImagenFondo);
            this.Icon = new Icon(rutaIcono);

            this.nombreLogueado.Text = listaUsuarios[indexUsuarioLogueado].NombreUsuario;

            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (listaUsuarios != null)
                {
                    string[] usuario = { listaUsuarios[i].NombreUsuario, listaUsuarios[i].Contrasenia, listaUsuarios[i].TipoUsuario, listaUsuarios[i].TrabajosRealizados.ToString() };
                    this.dataGridView1.Rows.Add(usuario);
                }
            }

            this.labelPrecioPapel.Text = "$ " + stock.PrecioPapelUni.ToString();
            this.labelPrecioTinta.Text = "$ " + stock.PrecioTintaUni.ToString();
            this.labelPrecioTroquel.Text = "$ " + stock.PrecioTroquelUni.ToString();
            this.labelPrecioEncuadernacion.Text = "$ " + stock.PrecioEncuadernacionUni.ToString();

            Operacion.CargarMaterialesDataGridView(this);
            stock.CargarStock(this);

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
            stock.CargarStock(login.menuOperario);
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            Operacion.BotonComprarStock(this, stock);
            stock.CargarStock(this);
        }

        private void labelPrecioTinta_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

