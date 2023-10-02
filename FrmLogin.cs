using Biblioteca;

namespace Frms
{
    public partial class FrmLogin : Form
    {
        //private Usuario[] listaUsuarios;
        private List<Usuario> listaUsuarios;
        public FrmMenuOperario menuOperario;
        public FrmMenuSupervisor menuSupervisor;
        private Stock stock;

        public FrmLogin()
        {
            //listaUsuarios = new Usuario[20];
            listaUsuarios = new List<Usuario>();
            stock = new Stock();
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string nombre = this.tNombre.Text;
            string pass = this.tPass.Text;
            

            if (listaUsuarios.Count >= 1)
            {
                for (int i = 0; i < listaUsuarios.Count; i++)
                {
                    //MessageBox.Show(listaUsuarios[0].nombreUsuario);

                    if (nombre != String.Empty)
                    {
                        if (pass != String.Empty)
                        {
                            if (listaUsuarios != null)
                            {
                                if (nombre == listaUsuarios[i].nombreUsuario && pass == listaUsuarios[i].contraseņa)
                                {
                                    menuOperario = new FrmMenuOperario(listaUsuarios, i, this, stock);
                                    menuSupervisor = new FrmMenuSupervisor(listaUsuarios, i, this, stock);

                                    if (listaUsuarios[i].tipoUsuario == "operario")
                                    {
                                        menuOperario.Show();
                                    }
                                    else
                                    {
                                        menuSupervisor.Show();
                                    }
                                    this.tNombre.Text = "";
                                    this.tPass.Text = "";
                                    this.Hide();
                                    //MessageBox.Show("Logueado Correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    this.labelError.Text = "Error. Los datos no coinciden.";
                                    this.labelError.Visible = true;
                                }
                            }
                            else
                            {
                                this.labelError.Text = "Error. No existe el usuario.";
                                this.labelError.Visible = true;
                            }
                        }
                        else
                        {
                            this.labelError.Text = "Error. Contraseņa vacia.";
                            this.labelError.Visible = true;
                        }
                    }
                    else
                    {
                        this.labelError.Text = "Error. Nombre de usuario vacio.";
                        this.labelError.Visible = true;
                    }
                }
            }
            else
            {
                this.labelError.Text = "Error. No hay usuarios creados.";
                this.labelError.Visible = true;
            }            
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistro registro = new FrmRegistro(listaUsuarios, this);
            tNombre.Text = string.Empty;
            tPass.Text = string.Empty;
            registro.Show();
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