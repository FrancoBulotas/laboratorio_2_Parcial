using Biblioteca;

namespace Frms
{
    public partial class FrmLogin : Form
    {
        private Administracion administracion = new();
        internal List<Usuario> listaUsuarios;
        public FrmMenuOperario menuOperario;
        public FrmMenuSupervisor menuSupervisor;
        internal Stock stock;
        //internal int contIngresos = 0;

        public FrmLogin()
        {
            listaUsuarios = administracion.ListaUsuarios;
            stock = new Stock();

            string directorioEjecutable = AppDomain.CurrentDomain.BaseDirectory;
            string rutaImagenFondo = Path.Combine(directorioEjecutable, "fondo-login.jpg");
            string rutaIcono = Path.Combine(directorioEjecutable, "icono-sistema.ico");
            this.BackgroundImage = Image.FromFile(rutaImagenFondo);
            this.Icon = new Icon(rutaIcono);

            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            Operacion.ValidarUsuario(this);
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
            Operacion.HardcodearUsuario(this, "operario");
        }

        private void linkLabelHardcodeSup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Operacion.HardcodearUsuario(this, "supervisor");
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