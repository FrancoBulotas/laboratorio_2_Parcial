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

        public FrmLogin()
        {
            listaUsuarios = administracion.ListaUsuarios;
            stock = new Stock();

            this.BackgroundImage = Image.FromFile("C:\\Users\\Franco\\Desktop\\UTN FRA\\Tecnicatura Superior en Programacion\\2do Cuatrimestre\\Laboratorio II\\PRIMER-PARCIAL\\posible-fondo-login3.jpg");

            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {   // METER TODO ESTO EN CALCULOS <----------- Y CAMBIAR NOMBRE A CALCULOS
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

        //private void linkLabelVerUsuarios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    string mensaje = "";
        //    for (int i = 0; i < listaUsuarios.Count; i++)
        //    {
        //        mensaje += string.Format("{0} | {1} | {2}\n", listaUsuarios[i].nombreUsuario, listaUsuarios[i].contrasenia, listaUsuarios[i].tipoUsuario);
        //    }
        //    MessageBox.Show(mensaje);
        //}

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