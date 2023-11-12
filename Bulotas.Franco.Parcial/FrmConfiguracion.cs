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
        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Visual.CargarFondo(false);
            this.Icon = Visual.CargarIcono();

            string directorioEjecutable = AppDomain.CurrentDomain.BaseDirectory;

            pictureBox1.Image = Image.FromFile($"{directorioEjecutable}\\visual\\fondo-app1.jpg");
            pictureBox2.Image = Image.FromFile($"{directorioEjecutable}\\visual\\fondo-login.jpg");
            pictureBox3.Image = Image.FromFile($"{directorioEjecutable}\\visual\\fondo-login.jpg");
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
