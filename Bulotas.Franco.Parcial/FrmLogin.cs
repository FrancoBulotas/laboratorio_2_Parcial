using Biblioteca;
using System.Windows.Forms;

namespace Frms
{
    public partial class FrmLogin : Form
    {
        internal Administracion administracion = new();
        internal FrmMenuOperario menuOperario;
        internal FrmMenuSupervisor menuSupervisor;
        internal Stock stock;
        private Dictionary<string, string> datosUsuario = new Dictionary<string, string>();
        private Dictionary<string, string> resultadoValidez = new Dictionary<string, string>();
        private List<string> pedidos = new List<string>();

        public FrmLogin()
        {
            stock = Stock.InstanciaStock;

            this.BackgroundImage = Visual.CargarFondo(true);
            this.Icon = Visual.CargarIcono();

            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            resultadoValidez = administracion.ValidarUsuarioLogin(tNombre.Text, tPass.Text);

            if (resultadoValidez["Tipo Usuario"].Length > 0)
            {
                if (resultadoValidez["Tipo Usuario"] == "operario")
                {
                    menuOperario = new FrmMenuOperario(administracion, Convert.ToInt32(resultadoValidez["Indice"]), this);
                    menuOperario.Show();
                }
                else if (resultadoValidez["Tipo Usuario"] == "supervisor")
                {
                    menuOperario = new FrmMenuOperario(administracion, Convert.ToInt32(resultadoValidez["Indice"]), this);
                    menuSupervisor = new FrmMenuSupervisor(administracion, Convert.ToInt32(resultadoValidez["Indice"]), this);
                    menuSupervisor.Show();
                }
                tNombre.Text = "";
                tPass.Text = "";
                this.Hide();

                pedidos = administracion.GenerarPedidosDataGridView();

                Visual.CargarPedidosDataGridView(menuOperario.dataGridView1, pedidos);

                resultadoValidez["Tipo Usuario"] = "";
                resultadoValidez["Indice"] = "";
            }
            else if (resultadoValidez["Error"].Length > 0)
            {
                labelError.Text = resultadoValidez["Error"];
                labelError.Visible = true;

                resultadoValidez["Error"] = "";
            }      
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //FrmRegistro registro = new FrmRegistro(listaUsuarios, this, administracion);
            FrmRegistro registro = new FrmRegistro(this, administracion);
            tNombre.Text = string.Empty;
            tPass.Text = string.Empty;
            registro.Show();
        }

        private void linkLabelHardcodeOp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            datosUsuario = administracion.HardcodearUsuario("operario");
            
            tNombre.Text = datosUsuario["Nombre"];
            tPass.Text = datosUsuario["Contrasenia"];
        }

        private void linkLabelHardcodeSup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            datosUsuario = administracion.HardcodearUsuario("supervisor");

            tNombre.Text = datosUsuario["Nombre"];
            tPass.Text = datosUsuario["Contrasenia"];
        }
    }
}