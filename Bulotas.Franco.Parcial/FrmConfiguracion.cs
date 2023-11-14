using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frms
{
    public partial class FrmConfiguracion : Form
    {
        private FrmLogin login;
        private Dictionary<string, string> dictConfiguracion;

        public FrmConfiguracion(FrmLogin login)
        {
            this.login = login;

            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            this.Icon = Visual.CargarIcono();

            string directorioEjecutable = AppDomain.CurrentDomain.BaseDirectory;

            pictureBox1.Image = Image.FromFile($"{directorioEjecutable}\\visual\\fondo-app1.jpg");
            pictureBox2.Image = Image.FromFile($"{directorioEjecutable}\\visual\\fondo-app2.jpg");
            pictureBox3.Image = Image.FromFile($"{directorioEjecutable}\\visual\\fondo-app3.jpg");

            pictureBox4.Image = Image.FromFile($"{directorioEjecutable}\\visual\\fondo-login1.jpg");
            pictureBox5.Image = Image.FromFile($"{directorioEjecutable}\\visual\\fondo-login2.jpg");
            pictureBox6.Image = Image.FromFile($"{directorioEjecutable}\\visual\\fondo-login3.jpg");
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFondoApp1_Click(object sender, EventArgs e)
        {
            AplicarFondo(true, "1");
        }

        private void buttonFondoApp2_Click(object sender, EventArgs e)
        {
            AplicarFondo(true, "2");
        }

        private void buttonFondoApp3_Click(object sender, EventArgs e)
        {
            AplicarFondo(true, "3");
        }

        private void buttonFondoLogin1_Click(object sender, EventArgs e)
        {
            AplicarFondo(false, "1");
        }

        private void buttonFondoLogin2_Click(object sender, EventArgs e)
        {
            AplicarFondo(false, "2");
        }

        private void buttonFondoLogin3_Click(object sender, EventArgs e)
        {
            AplicarFondo(false, "3");
        }

        private void AplicarFondo(bool app, string num)
        {

            if (app)
            {
                dictConfiguracion = Administracion.DeserializarJSONConfig();
                dictConfiguracion["FondoApp"] = $"visual\\fondo-app{num}.jpg";
                
                Administracion.SerializarJSONConfig(dictConfiguracion);

                login.menuOperario.BackgroundImage = Visual.CargarFondo(false);
                login.menuSupervisor.BackgroundImage = Visual.CargarFondo(false);
            }
            else
            {
                dictConfiguracion = Administracion.DeserializarJSONConfig();
                dictConfiguracion["FondoLogin"] = $"visual\\fondo-login{num}.jpg";

                Administracion.SerializarJSONConfig(dictConfiguracion);

                login.BackgroundImage = Visual.CargarFondo(true);
                login.registro.BackgroundImage = Visual.CargarFondo(true);
            }
            MessageBox.Show("Modificado correctamente","", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
