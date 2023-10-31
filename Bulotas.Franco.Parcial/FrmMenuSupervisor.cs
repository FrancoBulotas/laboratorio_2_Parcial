using Biblioteca;
using System;
using System.Collections;
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
        internal FrmLogin login;
        internal int indexUsuarioLogueado;
        internal ArrayList arrayControlStock = new ArrayList();
        internal Dictionary<string, int> materialesComprados = new Dictionary<string, int>();


        public FrmMenuSupervisor(List<Usuario> listaUsuarios, int indexUsuario, FrmLogin login)
        {
            InitializeComponent();
            this.listaUsuarios = listaUsuarios;
            indexUsuarioLogueado = indexUsuario;
            this.login = login;
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

            Visual.CargarMaterialesDataGridView(dataGridView2, login.stock);
            Visual.CargarStockDg(dataGridView2, login.stock);

        }

        private void FrmMenuSupervisor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
            Visual.CargarStockDg(login.menuOperario.dataGridView2, login.stock);
            Visual.ControlDataGridStock(login.stock, login.menuOperario.dataGridView2, false);
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            materialesComprados = login.stock.BotonComprarStock(textBoxPapel.Text, textBoxTinta.Text, textBoxTroquel.Text, textBoxEncuadernacion.Text, login.stock);

            Visual.MostrarStockComprado(this, materialesComprados);
            Visual.CargarStockDg(dataGridView2, login.stock);
            Visual.ControlDataGridStock(login.stock, dataGridView2, false);
        }
    }
}

