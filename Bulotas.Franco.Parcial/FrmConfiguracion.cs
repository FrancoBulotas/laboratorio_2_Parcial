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
        private string rutaFondoAppCargado = "";
        private string rutaFondoLoginCargado = "";

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

            buttonFondoApp1.Click += buttonFondoApp1_Click;
            buttonFondoApp2.Click += buttonFondoApp2_Click;
            buttonFondoApp3.Click += buttonFondoApp3_Click;
            buttonFondoApp4.Click += buttonFondoApp4_Click;
            buttonFondoLogin1.Click += buttonFondoLogin1_Click;
            buttonFondoLogin2.Click += buttonFondoLogin2_Click;
            buttonFondoLogin3.Click += buttonFondoLogin3_Click;
            buttonFondoLogin4.Click += buttonFondoLogin4_Click;

            btnSubirArchivo.Click += btnSubirArchivo_Click;
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFondoApp1_Click(object sender, EventArgs e)
        {
            AplicarFondo(true, "visual\\fondo-app1.jpg");
        }

        private void buttonFondoApp2_Click(object sender, EventArgs e)
        {
            AplicarFondo(true, "visual\\fondo-app2.jpg");
        }

        private void buttonFondoApp3_Click(object sender, EventArgs e)
        {
            AplicarFondo(true, "visual\\fondo-app3.jpg");
        }

        private void buttonFondoApp4_Click(object sender, EventArgs e)
        {
            AplicarFondo(true, rutaFondoAppCargado);
        }

        private void buttonFondoLogin1_Click(object sender, EventArgs e)
        {
            AplicarFondo(false, "visual\\fondo-login1.jpg");
        }

        private void buttonFondoLogin2_Click(object sender, EventArgs e)
        {
            AplicarFondo(false, "visual\\fondo-login2.jpg");
        }

        private void buttonFondoLogin3_Click(object sender, EventArgs e)
        {
            AplicarFondo(false, "visual\\fondo-login3.jpg");
        }

        private void buttonFondoLogin4_Click(object sender, EventArgs e)
        {
            AplicarFondo(false, rutaFondoLoginCargado);
        }

        private void AplicarFondo(bool app, string ruta)
        {
            dictConfiguracion = Archivo.DeserializarJSONConfig();

            if (app)
            {
                dictConfiguracion["FondoApp"] = ruta;
                Archivo.SerializarJSONConfig(dictConfiguracion);

                login.menuOperario.BackgroundImage = Visual.CargarFondo(false);
                login.menuSupervisor.BackgroundImage = Visual.CargarFondo(false);
            }
            else
            {
                dictConfiguracion["FondoLogin"] = ruta;
                Archivo.SerializarJSONConfig(dictConfiguracion);

                login.BackgroundImage = Visual.CargarFondo(true);
                login.registro.BackgroundImage = Visual.CargarFondo(true);
            }
            MessageBox.Show("Modificado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private async void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            await CargarArchivo();
        }

        private async Task CargarArchivo()
        {
            try
            {
                FrmDialogoConfiguracion dialogo = new FrmDialogoConfiguracion();
                DialogResult resultado = dialogo.ShowDialog();

                await Task.Run(() => IniciarCarga(resultado));
            }
            catch (Exception error)
            {
                login.administracion.archivo.CargarErrorLog(login.administracion.MensajeError(error));
            }
        }

        private void IniciarCarga(DialogResult resultado)
        {
            if (InvokeRequired)
            {
                Action<DialogResult> delegado = IniciarCarga;
                object[] parametros = new object[] { resultado };
                Invoke(delegado, parametros);
            }
            else
            {
                using (OpenFileDialog archivosDialog = new OpenFileDialog())
                {
                    archivosDialog.Title = "Seleccionar archivo";

                    if (archivosDialog.ShowDialog() == DialogResult.OK)
                    {

                        try
                        {
                            if (resultado == DialogResult.OK)
                            {
                                pictureBox7.Image = Image.FromFile(archivosDialog.FileName);
                                rutaFondoAppCargado = archivosDialog.FileName;
                                pictureBox7.Visible = true;
                                buttonFondoApp4.Visible = true;
                            }
                            else if (resultado == DialogResult.Yes)
                            {
                                pictureBox8.Image = Image.FromFile(archivosDialog.FileName);
                                rutaFondoLoginCargado = archivosDialog.FileName;
                                pictureBox8.Visible = true;
                                buttonFondoLogin4.Visible = true;
                            }
                            this.Size = new Size(740, 498);
                            botonSalir.Location = new Point(625, 425);
                        }
                        catch (Exception error) 
                        {
                            login.administracion.archivo.CargarErrorLog(login.administracion.MensajeError(error));
                            MessageBox.Show("Tipo de archivo no valido.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                    }
                }
            }
        }


    }
}
