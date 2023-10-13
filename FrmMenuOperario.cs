using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frms
{
    public partial class FrmMenuOperario : Form
    {
        private List<Usuario> listaUsuarios;
        private int indexUsuarioLogueado;
        public FrmLogin login;
        private Stock stock;

        public FrmMenuOperario(List<Usuario> listaUsuarios, int indexUsuario, FrmLogin login, Stock stock)
        {
            InitializeComponent();
            this.listaUsuarios = listaUsuarios;
            indexUsuarioLogueado = indexUsuario;
            this.login = login;
            this.stock = stock;
        }

        private void FrmPruebaMenu_Load(object sender, EventArgs e)
        {
            this.nombreLogueado.Text = listaUsuarios[indexUsuarioLogueado].nombreUsuario;
            CargarStock();
            cargarDataGridView();
            controlTrabajosPendientes();
        }
        internal void CargarStock()
        {
            this.label3.Text = stock.Papel.ToString() + " Uni.";
            this.label4.Text = stock.Tinta.ToString() + " L.";
            this.label6.Text = stock.Troquel.ToString() + " Uni.";
            this.label8.Text = stock.Encuadernacion.ToString() + " Uni.";
        }

        private void cargarDataGridView()
        {
            string[] pedido1 = { "Libros de matematica", "10000", "5000", "1500", "1250", "0", "$100000" };
            string[] pedido2 = { "Boletas", "50000", "7500", "1200", "0", "0", "$170000" };
            string[] pedido3 = { "Cuadernillos", "6000", "5000 ", "1500", "800", "2000", "$130000" };
            string[] pedido4 = { "LIbros de literatura", "3000", "2200", "700", "0", "280", "$60000" };

            dataGridView1.Rows.Add(pedido1);
            dataGridView1.Rows.Add(pedido2);
            dataGridView1.Rows.Add(pedido3);
            dataGridView1.Rows.Add(pedido4);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Seleccion")
            {
                int cantElegido = 0;
                bool resultado;
                // Se toma la fila seleccionada
                DataGridViewRow filasPedidos = dataGridView1.Rows[e.RowIndex];

                // Se selecciona la celda del checkbox
                DataGridViewCheckBoxCell celdaSeleccion = filasPedidos.Cells["Seleccion"] as DataGridViewCheckBoxCell;


                // Tuve que hacer esto porque sino al seleccionar por segunda vez un elemento rompia (como que celdaSeleccion.Value cambiaba
                // y no podia convertirlo)
                try
                {
                    resultado = !Convert.ToBoolean(celdaSeleccion.Value);
                }
                catch (FormatException)
                {
                    resultado = false;
                }

                if (resultado)
                {
                    if (Convert.ToInt32(filasPedidos.Cells["Papel"].Value) <= stock.Papel &&
                        Convert.ToInt32(filasPedidos.Cells["Tinta"].Value) <= stock.Tinta &&
                        Convert.ToInt32(filasPedidos.Cells["Troquel"].Value) <= stock.Troquel &&
                        Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value) <= stock.Encuadernacion)
                    {
                        stock.Papel = -Convert.ToInt32(filasPedidos.Cells["Papel"].Value);
                        stock.Tinta = -Convert.ToInt32(filasPedidos.Cells["Tinta"].Value);
                        stock.Troquel = -Convert.ToInt32(filasPedidos.Cells["Troquel"].Value);
                        stock.Encuadernacion = -Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value);
                        CargarStock();

                        string mensaje = string.Format("Hay stock suficiente para \n\nPedido: '{0}' \nGanancia: '{1}'",
                                    filasPedidos.Cells["Pedido"].Value,
                                    filasPedidos.Cells["Ganancia"].Value);
                        MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        filasPedidos.DefaultCellStyle.BackColor = Color.Green;
                        this.labelPedido.Visible = true;
                        this.labelPedidoSeleccionado.Text = filasPedidos.Cells["Pedido"].Value.ToString();
                        this.labelPedidoSeleccionado.Visible = true;
                        this.labelMaquinaria.Visible = true;
                        this.labelMaquinariaNecesaria.Visible = true;

                        string maquinarias = "";
                        if (Convert.ToInt32(filasPedidos.Cells["Papel"].Value) > 0)
                        {
                            maquinarias = "Impresora ";
                        }
                        if (Convert.ToInt32(filasPedidos.Cells["Troquel"].Value) > 0)
                        {
                            maquinarias += "| Troqueladora ";
                        }
                        if (Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value) > 0)
                        {
                            maquinarias += "| Encuadernadora ";
                        }
                        this.labelMaquinariaNecesaria.Text += maquinarias;

                    }
                    else
                    {
                        string mensaje = string.Format("NO hay stock suficiente para \n\nPedido: '{0}' \nGanancia: '{1}'",
                                    filasPedidos.Cells["Pedido"].Value,
                                    filasPedidos.Cells["Ganancia"].Value);
                        MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        filasPedidos.DefaultCellStyle.BackColor = Color.Red;
                        this.labelPedido.Visible = false;
                        this.labelPedidoSeleccionado.Visible = false;
                        this.labelMaquinaria.Visible = false;
                        this.labelMaquinariaNecesaria.Visible = false;
                        this.labelMaquinariaNecesaria.Text = "";
                    }

                    celdaSeleccion.Value = true;

                }
                else
                {
                    if (filasPedidos.DefaultCellStyle.BackColor == Color.Green)
                    {
                        stock.Papel = +Convert.ToInt32(filasPedidos.Cells["Papel"].Value);
                        stock.Tinta = +Convert.ToInt32(filasPedidos.Cells["Tinta"].Value);
                        stock.Troquel = +Convert.ToInt32(filasPedidos.Cells["Troquel"].Value);
                        stock.Encuadernacion = +Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value);
                        CargarStock();
                    }

                    string mensaje = string.Format("Se ha quitado la seleccion n\nPedido: '{0}' \nGanancia: '{1}'",
                                                        filasPedidos.Cells["Pedido"].Value,
                                                        filasPedidos.Cells["Ganancia"].Value);
                    MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    filasPedidos.DefaultCellStyle.BackColor = Color.White;
                    this.labelPedido.Visible = false;
                    this.labelPedidoSeleccionado.Visible = false;
                    this.labelMaquinaria.Visible = false;
                    this.labelMaquinariaNecesaria.Visible = false;
                    this.labelMaquinariaNecesaria.Text = "";
                    celdaSeleccion.Value = false;
                }
            }
        }

        private void controlTrabajosPendientes()
        {

        }

        private void botonVolverSup_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.menuSupervisor.Show();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void nombreLogueado_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
