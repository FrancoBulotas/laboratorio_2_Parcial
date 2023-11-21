using Biblioteca;
using System.Windows.Forms;
using System.Xml.Serialization;

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
        private List<Administracion> pedidos = new List<Administracion>();
        internal FrmRegistro registro;
        private string msjError;
        internal Action<DataGridView, Administracion, int> cargaDeUsuariosDataGrid;

        internal Archivo archivo;
        private DatosForms datosFormulario;

        public FrmLogin()
        {
            InitializeComponent();

            archivo = new Archivo(administracion);
            datosFormulario = new DatosForms();
            registro = new FrmRegistro(this, administracion);
            stock = Stock.InstanciaStock;

            administracion.EventoLogError += Administracion_EventoLogError;

            cargaDeUsuariosDataGrid = Visual.CargarUsuariosDataGrid;

            this.BackgroundImage = Visual.CargarFondo(true);
            this.Icon = Visual.CargarIcono();

            GuardarDatosForm();
        }

        private void login_Click(object sender, EventArgs e)
        {
            resultadoValidez = administracion.ValidarUsuarioLogin(tNombre.Text, tPass.Text);

            administracion.EventoLoginUsuario += Administracion_EventoLoginUsuario;
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            GuardarDatosForm();
            this.Close();
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

        private void linkLabelRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tNombre.Text = string.Empty;
            tPass.Text = string.Empty;
            registro.Show();
            this.Hide();
        }


        private void Administracion_EventoLogError(object sender, string msjError)
        {
            labelError.Visible = true;
        }

        private void Administracion_EventoLoginUsuario(object sender, Dictionary<string, string> dictResultadoLogin)
        {
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
                msjError = $"{DateTime.Now} | Loguin: {resultadoValidez["Error"]}";
                administracion.archivo.CargarErrorLog(msjError);
                resultadoValidez["Error"] = "";
            }
        }

        private void GuardarDatosForm()
        {
            datosFormulario.login = login.Text;
            datosFormulario.tPass = tPass.Text;
            datosFormulario.tNombre = tNombre.Text;
            datosFormulario.labelError = labelError.Text;
            datosFormulario.botonSalir = botonSalir.Text;
            datosFormulario.label1 = label1.Text;
            datosFormulario.linkLabelHardcodeOp = linkLabelHardcodeOp.Text;
            datosFormulario.linkLabelHardcodeSup = linkLabelHardcodeSup.Text;
            datosFormulario.linkLabelRegistrarse = linkLabelRegistrarse.Text;

            archivo.SerializarXML(datosFormulario, "FrmLogin");
        }

    }
}