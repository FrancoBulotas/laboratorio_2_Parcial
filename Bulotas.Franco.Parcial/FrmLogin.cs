using Biblioteca;
using System.Windows.Forms;

namespace Frms
{
    public partial class FrmLogin : Form
    {
        internal Administracion administracion = new();
        internal List<Usuario> listaUsuarios;
        internal FrmMenuOperario menuOperario;
        internal FrmMenuSupervisor menuSupervisor;
        internal Stock stock;
        private Dictionary<string, string> datosUsuario = new Dictionary<string, string>();
        private Dictionary<string, string> resultadoValidez = new Dictionary<string, string>();
        private List<string> pedidos = new List<string>();  

        public FrmLogin()
        {
            listaUsuarios = administracion.ListaUsuarios;
            stock = Stock.InstanciaStock;

            string directorioEjecutable = AppDomain.CurrentDomain.BaseDirectory;
            string rutaImagenFondo = Path.Combine(directorioEjecutable, "fondo-login.jpg");
            string rutaIcono = Path.Combine(directorioEjecutable, "icono-sistema.ico");
            this.BackgroundImage = Image.FromFile(rutaImagenFondo);
            this.Icon = new Icon(rutaIcono);

            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            resultadoValidez = administracion.ValidarUsuario(tNombre.Text, tPass.Text);

            if (resultadoValidez["Tipo Usuario"].Length > 0)
            {
                menuOperario = new FrmMenuOperario(administracion.ListaUsuarios, Convert.ToInt32(resultadoValidez["Indice"]), this);
                menuSupervisor = new FrmMenuSupervisor(administracion.ListaUsuarios, Convert.ToInt32(resultadoValidez["Indice"]), this);

                if (resultadoValidez["Tipo Usuario"] == "operario")
                {
                    menuOperario.Show();
                }
                else if (resultadoValidez["Tipo Usuario"] == "supervisor")
                {
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
            FrmRegistro registro = new FrmRegistro(listaUsuarios, this, administracion);
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

        private void tPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void tNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}