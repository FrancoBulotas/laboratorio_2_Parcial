using Biblioteca;
using Microsoft.VisualBasic.Devices;
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
        internal FrmLogin login;
        internal int indexUsuarioLogueado;
        internal ArrayList arrayControlStock = new ArrayList();
        internal Dictionary<string, int> materialesComprados = new Dictionary<string, int>();
        internal bool insumosComprados = false;
        private FrmMenuSupervisorCRUD menuCRUD;
        private FrmConfiguracion menuConfig;

        public FrmMenuSupervisor(Administracion administracion, int indexUsuario, FrmLogin login)
        {
            InitializeComponent();
            this.administracion = administracion;
            indexUsuarioLogueado = indexUsuario;
            this.login = login;
            administracion.SerializarXMLStock(login.stock);
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Visual.CargarFondo(false);
            this.Icon = Visual.CargarIcono();

            this.nombreLogueado.Text = administracion.ListaUsuarios[indexUsuarioLogueado].NombreUsuario;

            Visual.CargarUsuariosDataGrid(dataGridView1, administracion);
            Visual.CargarMaterialesDataGridView(dataGridView2, login.stock);
            Visual.CargarStockDataGrid(dataGridView2, login.stock);
            Visual.ControlDataGridStock(login.stock, dataGridView2);
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
            Visual.CargarStockDataGrid(login.menuOperario.dataGridView2, login.stock);
            Visual.ControlDataGridStock(login.stock, login.menuOperario.dataGridView2);
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            insumosComprados = login.stock.BotonComprarStock(textBoxPapel.Text, textBoxTinta.Text, textBoxTroquel.Text, textBoxEncuadernacion.Text);

            Visual.ValidarStockComprado(this, insumosComprados);
            Visual.CargarStockDataGrid(dataGridView2, login.stock);
            Visual.ControlDataGridStock(login.stock, dataGridView2);
            administracion.SerializarXMLStock(login.stock);
        }

        private void buttonEditarUsr_Click(object sender, EventArgs e)
        {
            menuCRUD = new FrmMenuSupervisorCRUD(administracion, this);
            menuCRUD.Show();
        }

        private void buttonConfiguracion_Click(object sender, EventArgs e)
        {
            menuConfig = new FrmConfiguracion(login);
            menuConfig.Show();
        }
    }
}

