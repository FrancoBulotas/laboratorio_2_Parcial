using Biblioteca;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frms
{
    public static class Visual
    {
        private static bool troqueladoRequerido = false;
        private static bool encuadernacionRequerida = false;
        private static DataGridViewRow filaPedidoElegido;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void CargarStockDg(DataGridView dg, Stock stock)
        {
            dg.Rows[0].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("papel");
            dg.Rows[1].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("tinta");
            dg.Rows[2].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("troquel");
            dg.Rows[3].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("encuadernacion");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ControlColorCantidadStock(Stock stock, DataGridView dg, string insumo)
        {
            ArrayList arrayControlStock = new ArrayList();
            arrayControlStock = stock.ControlStock(insumo);

            if ((int)arrayControlStock[0] >= 0)
            {
                if ((int)arrayControlStock[1] == 1) { dg.Rows[(int)arrayControlStock[0]].DefaultCellStyle.BackColor = Color.Red; }

                else if ((int)arrayControlStock[1] == 0) { dg.Rows[(int)arrayControlStock[0]].DefaultCellStyle.BackColor = Color.White; }
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="dg"></param>
        internal static void ControlDataGridStock(Stock stock, DataGridView dg, bool salir)
        {
            ControlColorCantidadStock(stock, dg, "papel");
            ControlColorCantidadStock(stock, dg, "tinta");
            ControlColorCantidadStock(stock, dg, "troquel");
            ControlColorCantidadStock(stock, dg, "encuadernacion");

            //if (salir)
            //{
            //    if (filaPedidoElegido.Index >= 0)
            //    {
            //        stock.Papel = +Convert.ToInt32(filaPedidoElegido.Cells["Papel"].Value);
            //        stock.Tinta = +Convert.ToInt32(filaPedidoElegido.Cells["Tinta"].Value);
            //        stock.Troquel = +Convert.ToInt32(filaPedidoElegido.Cells["Troquel"].Value);
            //        stock.Encuadernacion = +Convert.ToInt32(filaPedidoElegido.Cells["Encuadernacion"].Value);
            //        CargarStockDg(dg, stock);
            //    }
            //}
        }


        /// <summary>
        /// Carga los materiales con su respectivo stock al DataGridView del Frm del supervisor.
        /// </summary>
        /// <param name="form"></param>
        public static void CargarMaterialesDataGridView(DataGridView dg, Stock stock)
        {
            dg.Rows.Add("Papel", stock.Papel.ToString());
            dg.Rows.Add("Tinta", stock.Tinta.ToString());
            dg.Rows.Add("Troquel", stock.Troquel.ToString());
            dg.Rows.Add("Encuadernacion", stock.Encuadernacion.ToString());
        }


        public static void CargarPedidosDataGridView(DataGridView dg, List<string> pedidos) 
        {
            for (int i = 0; i < pedidos.Count(); i++)
            {
                string[] pedido = pedidos[i].Split("-");
                dg.Rows.Add(pedido);
            }
        }

        /// <summary>
        /// Se encarga de manejear los eventos del DataGridView del Frm del operario, en caso
        /// de que se seleccione alguna fila.
        /// </summary>
        /// <param name="form">Instancia del Frm del operario.</param>
        /// <param name="e">Eventos sobre el DataGridView.</param>
        public static void ManejoDataGrid(FrmMenuOperario form, DataGridViewCellEventArgs e)
        {
            Dictionary<string, string> dictInfo = new Dictionary<string, string>();
            if (form.dataGridView1.Columns[e.ColumnIndex].Name == "Seleccion")
            {
                bool resultado;
                form.contProcesos = 0;
                // Se toma la fila seleccionada
                DataGridViewRow filasPedidos = form.dataGridView1.Rows[e.RowIndex];
                filaPedidoElegido = filasPedidos;

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
                    if (Convert.ToInt32(filasPedidos.Cells["Papel"].Value) <= form.login.stock.Papel &&
                        Convert.ToInt32(filasPedidos.Cells["Tinta"].Value) <= form.login.stock.Tinta &&
                        Convert.ToInt32(filasPedidos.Cells["Troquel"].Value) <= form.login.stock.Troquel &&
                        Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value) <= form.login.stock.Encuadernacion)
                    {
                        form.login.stock.Papel = -Convert.ToInt32(filasPedidos.Cells["Papel"].Value);
                        form.login.stock.Tinta = -Convert.ToInt32(filasPedidos.Cells["Tinta"].Value);
                        form.login.stock.Troquel = -Convert.ToInt32(filasPedidos.Cells["Troquel"].Value);
                        form.login.stock.Encuadernacion = -Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value);

                        CargarStockDg(form.dataGridView2, form.login.stock);

                        filasPedidos.DefaultCellStyle.BackColor = Color.Green;
                        form.labelPedido.Visible = true;
                        form.labelPedidoSeleccionado.Text = filasPedidos.Cells["Pedido"].Value.ToString();
                        form.labelPedidoSeleccionado.Visible = true;
                        form.labelMaquinaria.Visible = true;
                        form.labelMaquinariaNecesaria.Visible = true;
                        form.radioButtonImpresora.Enabled = true;

                        dictInfo = form.login.administracion.MostrarInfoPedido(Convert.ToInt32(filasPedidos.Cells["Papel"].Value), Convert.ToInt32(filasPedidos.Cells["Troquel"].Value), Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value));
                        form.labelMaquinariaNecesaria.Text += dictInfo["Maquinas"];
                        form.contProcesos = Convert.ToInt32(dictInfo["Contador Procesos"]);
                        troqueladoRequerido = bool.Parse(dictInfo["Troquelado Requerido"]);
                        encuadernacionRequerida = bool.Parse(dictInfo["Encuadernacion Requerida"]);

                        form.labelCantImp.Text = filasPedidos.Cells["Papel"].Value.ToString();
                        form.labelCantTroq.Text = filasPedidos.Cells["Troquel"].Value.ToString();
                        form.labelCantEncu.Text = filasPedidos.Cells["Encuadernacion"].Value.ToString();

                        form.filaPedidoEnProceso = filasPedidos;

                        ControlDataGridStock(form.login.stock, form.dataGridView2, false);

                        form.dataGridView1.Enabled = false;
                    }
                    else
                    {
                        string mensaje = string.Format("NO hay stock suficiente para \n\nPedido: '{0}''",
                                    filasPedidos.Cells["Pedido"].Value);
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
                    string mensaje = string.Format("Se ha quitado la seleccion n\nPedido: '{0}'",
                                                        filasPedidos.Cells["Pedido"].Value);
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

        /// <summary>
        /// Se encarga de indicar con MessageBox cuando se termine el producto, y reestablece valores 
        /// necesarios para seguir con la produccion.
        /// </summary>
        /// <param name="form">Instancia del Frm del operario</param>
        /// <param name="impresionFinalizada">Indica si se finalizo la tarea</param>
        /// <param name="troqueladoFinalizado">Indica si se finalizo la tarea</param>
        /// <param name="encuadernacionFinalizada">Indica si se finalizo la tarea</param>
        /// <param name="usuario">Instancia de un usuario</param>
        public static void InfoProcesoProduccion(FrmMenuOperario form, bool impresionFinalizada, bool troqueladoFinalizado, bool encuadernacionFinalizada, Usuario usuario)
        {
            //string gananciaEnLimpio = filaPedidoElegido.Cells["Ganancia"].Value.ToString().Remove(0,1);
            string mensaje = "";
            if (form.contProcesos == 1 && impresionFinalizada)
            {
                mensaje = String.Format("Impresion de:\n{0}\nFinalizada!",
                                        filaPedidoElegido.Cells["Pedido"].Value);
                form.radioButtonImpresora.Checked = false;
            }
            else if (form.contProcesos == 2 && troqueladoFinalizado)
            {
                mensaje = String.Format("Impresion y troquelado de:\n{0}\nFinalizada!",
                                        filaPedidoElegido.Cells["Pedido"].Value);
                form.radioButtonTroqueladora.Checked = false;
            }
            else if (form.contProcesos == 3 && encuadernacionFinalizada)
            {
                mensaje = String.Format("Impresion, troquelado y encuadernacion de:\n{0}\nFinalizada!",
                                        filaPedidoElegido.Cells["Pedido"].Value);
                form.radioButtonEncuadernadora.Checked = false;
            }

            if ((form.contProcesos == 1 && impresionFinalizada) ||
                (form.contProcesos == 2 && troqueladoFinalizado) ||
                (form.contProcesos == 3 && encuadernacionFinalizada))
            {
                MessageBox.Show(mensaje, "Sispro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                form.dataGridView1.Rows.Remove(form.filaPedidoEnProceso);
                usuario.TrabajosRealizados = 1;
                form.dataGridView1.Enabled = true;
                form.progressBarImpresora.Value = form.progressBarImpresora.Minimum;
                form.progressBarTroqueladora.Value = form.progressBarTroqueladora.Minimum;
                form.progressBarEncuadernadora.Value = form.progressBarEncuadernadora.Minimum;

                form.labelImpresionExitosa.Visible = false;
                form.labelTroqueladoExitoso.Visible = false;
                form.labelEncuExitosa.Visible = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="materiales"></param>
        public static void MostrarStockComprado(FrmMenuSupervisor form, Dictionary<string, int> materiales)
        {
            if (materiales.Count() == 0)
            {
                MessageBox.Show("Ingrese valores numericos positivos", "Sispro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                form.login.stock.Papel = materiales["Papel"];
                form.login.stock.Tinta = materiales["Tinta"];
                form.login.stock.Troquel = materiales["Troquel"];
                form.login.stock.Encuadernacion = materiales["Encuadernacion"];

                form.textBoxPapel.Text = "0";
                form.textBoxTinta.Text = "0";
                form.textBoxTroquel.Text = "0";
                form.textBoxEncuadernacion.Text = "0";
            }
        }

        /// <summary>
        /// Controla que no se puedan seleccionar los demas RadioButtons de la linea de produccion, hasta
        /// que no termine el anterior paso.
        /// </summary>
        /// <param name="form">Instancia del Frm del operario</param>
        /// <param name="troquelado">Indica que tarea es la proxima a realizar</param>
        /// <param name="encuadernacion">Indica que tarea es la proxima a realizar</param>
        public static void ControlSeleccionProduccion(FrmMenuOperario form, bool troquelado, bool encuadernacion)
        {
            if (troqueladoRequerido && troquelado)
            {
                form.radioButtonTroqueladora.Enabled = true;
            }
            if (encuadernacionRequerida && encuadernacion)
            {
                form.radioButtonEncuadernadora.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="barraProgeso"></param>
        public static void ModificarProgressBar(ProgressBar barraProgeso)
        {
            for (int i = 0; i <= 100; i++)
            {
                barraProgeso.Value = i;
                barraProgeso.Refresh();
                Thread.Sleep(30);
            }
            barraProgeso.Value = barraProgeso.Maximum;
        }
    }
}
