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
        internal Administracion administracion;
        //private List<Usuario> listaUsuarios;
        internal FrmLogin login;
        internal int indexUsuarioLogueado;
        internal ArrayList arrayControlStock = new ArrayList();
        internal Dictionary<string, int> materialesComprados = new Dictionary<string, int>();
        private FrmMenuSupervisorCRUD menuCRUD;

        public FrmMenuSupervisor(Administracion administracion, int indexUsuario, FrmLogin login)
        {
            InitializeComponent();
            this.administracion = administracion;
            //this.listaUsuarios = listaUsuarios;
            indexUsuarioLogueado = indexUsuario;
            this.login = login;
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Visual.CargarFondo(false);
            this.Icon = Visual.CargarIcono();

            this.nombreLogueado.Text = administracion.ListaUsuarios[indexUsuarioLogueado].NombreUsuario;

            Visual.CargarUsuariosDataGrid(dataGridView1, administracion);
            Visual.CargarMaterialesDataGridView(dataGridView2, login.stock);
            Visual.CargarStockDg(dataGridView2, login.stock);

        }

        private void FrmMenuSupervisor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            administracion.ListaUsuarios = UsuarioDAO.LeerTodo();
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

        private void buttonEditarUsr_Click(object sender, EventArgs e)
        {
            menuCRUD = new FrmMenuSupervisorCRUD(administracion, this);
            menuCRUD.Show();
        }
    }
}

