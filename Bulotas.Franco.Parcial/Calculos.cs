using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frms
{
    public static class Calculos
    {

        public static void BotonComprarStock(FrmMenuSupervisor form, Stock stock)
        {
            if ((form.textBoxPapel.Text != string.Empty ||
                form.textBoxTinta.Text != string.Empty ||
                form.textBoxTroquel.Text != string.Empty ||
                form.textBoxEncuadernacion.Text != string.Empty))
            {
                int.TryParse(form.textBoxPapel.Text, out int papelIngresado);
                int.TryParse(form.textBoxTinta.Text, out int tintaIngresada);
                int.TryParse(form.textBoxTroquel.Text, out int troquelIngresado);
                int.TryParse(form.textBoxEncuadernacion.Text, out int encuIngresado);

                form.cantidadPapelAComprar = papelIngresado;
                form.cantidadTintaAComprar = tintaIngresada;
                form.cantidadTroquelAComprar = troquelIngresado;
                form.cantidadEncuadernacionAComprar = encuIngresado;
                Calculos.CalcularCompra(form, stock);
            }
        }

        private static void CalcularCompra(FrmMenuSupervisor form, Stock stock)
        {
            form.cantidadTotalAComprar = (form.cantidadPapelAComprar * stock.PrecioPapelUni)
                        + (form.cantidadTroquelAComprar * stock.PrecioTroquelUni)
                        + (form.cantidadTintaAComprar * stock.PrecioTintaUni)
                        + (form.cantidadEncuadernacionAComprar * stock.PrecioEncuadernacionUni);

            if (stock.PresupuestoTotal - form.cantidadTotalAComprar >= 0)
            {
                if (form.cantidadPapelAComprar >= 0) { stock.Papel = form.cantidadPapelAComprar; }
                else { form.textBoxPapel.Text = ""; }
                if (form.cantidadTintaAComprar >= 0) { stock.Tinta = form.cantidadTintaAComprar; }
                else { form.textBoxTinta.Text = ""; }
                if (form.cantidadTroquelAComprar >= 0) { stock.Troquel = form.cantidadTroquelAComprar; }
                else { form.textBoxTroquel.Text = ""; }
                if (form.cantidadEncuadernacionAComprar >= 0) { stock.Encuadernacion = form.cantidadEncuadernacionAComprar; }
                else { form.textBoxEncuadernacion.Text = ""; }

                stock.PresupuestoTotal = -form.cantidadTotalAComprar;
            }
            else
            {
                MessageBox.Show("Presupuesto insuficiente");
            }
        }

        public static void ManejoDataGrid(FrmMenuOperario form, Stock stock, DataGridViewCellEventArgs e)
        {
            if (form.dataGridView1.Columns[e.ColumnIndex].Name == "Seleccion")
            {
                bool resultado;
                // Se toma la fila seleccionada
                DataGridViewRow filasPedidos = form.dataGridView1.Rows[e.RowIndex];

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
                        stock.CargarStock(form);

                        //string mensaje = string.Format("Hay stock suficiente para \n\nPedido: '{0}' \nGanancia: '{1}'",
                        //            filasPedidos.Cells["Pedido"].Value,
                        //            filasPedidos.Cells["Ganancia"].Value);
                        //MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       


                        filasPedidos.DefaultCellStyle.BackColor = Color.Green;
                        form.labelPedido.Visible = true;
                        form.labelPedidoSeleccionado.Text = filasPedidos.Cells["Pedido"].Value.ToString();
                        form.labelPedidoSeleccionado.Visible = true;
                        form.labelMaquinaria.Visible = true;
                        form.labelMaquinariaNecesaria.Visible = true;

                        string maquinarias = "";
                        if (Convert.ToInt32(filasPedidos.Cells["Papel"].Value) > 0)
                        {
                            maquinarias = "Impresora ";
                            form.radioButtonImpresora.Enabled = true;
                        }
                        if (Convert.ToInt32(filasPedidos.Cells["Troquel"].Value) > 0)
                        {
                            maquinarias += "| Troqueladora ";
                            form.radioButtonTroqueladora.Enabled = true;
                        }
                        if (Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value) > 0)
                        {
                            maquinarias += "| Encuadernadora ";
                            form.radioButtonEncuadernadora.Enabled = true;
                        }
                        form.labelMaquinariaNecesaria.Text += maquinarias;

                    }
                    else
                    {
                        string mensaje = string.Format("NO hay stock suficiente para \n\nPedido: '{0}' \nGanancia: '{1}'",
                                    filasPedidos.Cells["Pedido"].Value,
                                    filasPedidos.Cells["Ganancia"].Value);
                        MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        filasPedidos.DefaultCellStyle.BackColor = Color.Red;
                        form.labelPedido.Visible = false;
                        form.labelPedidoSeleccionado.Visible = false;
                        form.labelMaquinaria.Visible = false;
                        form.labelMaquinariaNecesaria.Visible = false;
                        form.labelMaquinariaNecesaria.Text = "";
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
                        stock.CargarStock(form);
                    }

                    string mensaje = string.Format("Se ha quitado la seleccion n\nPedido: '{0}' \nGanancia: '{1}'",
                                                        filasPedidos.Cells["Pedido"].Value,
                                                        filasPedidos.Cells["Ganancia"].Value);
                    MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    filasPedidos.DefaultCellStyle.BackColor = Color.White;
                    form.labelPedido.Visible = false;
                    form.labelPedidoSeleccionado.Visible = false;
                    form.labelMaquinaria.Visible = false;
                    form.labelMaquinariaNecesaria.Visible = false;
                    form.labelMaquinariaNecesaria.Text = "";
                    celdaSeleccion.Value = false;
                }
            }
        }

    }
}
