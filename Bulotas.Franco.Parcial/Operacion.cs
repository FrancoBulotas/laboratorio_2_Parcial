using Biblioteca;
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
    public static class Operacion
    {
        private static bool impresionRequerida = false;
        private static bool troqueladoRequerido = false;
        private static bool encuadernacionRequerida = false;
        private static DataGridViewRow filaPedidoElegido;

        /// <summary>
        /// Carga los pedidos pendientes al DataGridView del Frm del operario.
        /// </summary>
        /// <param name="form"></param>
        public static void CargarPedidosDataGridView(FrmMenuOperario form)
        {
            //List<string[]> pedidos = new List<string[]>();

            string[] pedido1 = { "Libros de matematica", "10000", "5000", "1500", "1250", "0", "$500000" };
            string[] pedido2 = { "Boletas", "50000", "7500", "1200", "0", "0", "$600000" };
            string[] pedido3 = { "Cuadernillos", "6000", "5000 ", "1500", "800", "2000", "$450000" };
            string[] pedido4 = { "Libros de literatura", "3000", "2200", "700", "200", "280", "$260000" };
            string[] pedido5 = { "Libros de historia", "3400", "2600", "750", "250", "300", "$280000" };
            string[] pedido6 = { "Envoltorio botellas", "11000", "6200", "3000", "0", "0", "$700000" };

            form.dataGridView1.Rows.Add(pedido1);
            form.dataGridView1.Rows.Add(pedido2);
            form.dataGridView1.Rows.Add(pedido3);
            form.dataGridView1.Rows.Add(pedido4);
            form.dataGridView1.Rows.Add(pedido5);
            form.dataGridView1.Rows.Add(pedido6);
        }

        /// <summary>
        /// Carga los materiales con su respectivo stock al DataGridView del Frm del supervisor.
        /// </summary>
        /// <param name="form"></param>
        public static void CargarMaterialesDataGridView(FrmMenuSupervisor form)
        {
            string[] papel = { "Papel", form.stock.Papel.ToString() };
            string[] tinta = { "Tinta", form.stock.Tinta.ToString() };
            string[] troquel = { "Troquel", form.stock.Troquel.ToString() };
            string[] encuadernacion = { "Encuadernacion", form.stock.Encuadernacion.ToString() };

            form.dataGridView2.Rows.Add(papel);
            form.dataGridView2.Rows.Add(tinta);
            form.dataGridView2.Rows.Add(troquel);
            form.dataGridView2.Rows.Add(encuadernacion);
        }

        /// <summary>
        /// Carga los materiales con su respectivo stock al DataGridView del Frm del operario.
        /// </summary>
        /// <param name="form"></param>
        public static void CargarMaterialesDataGridView(FrmMenuOperario form)
        {
            string[] papel = { "Papel", form.stock.Papel.ToString() };
            string[] tinta = { "Tinta", form.stock.Tinta.ToString() };
            string[] troquel = { "Troquel", form.stock.Troquel.ToString() };
            string[] encuadernacion = { "Encuadernacion", form.stock.Encuadernacion.ToString() };

            form.dataGridView2.Rows.Add(papel);
            form.dataGridView2.Rows.Add(tinta);
            form.dataGridView2.Rows.Add(troquel);
            form.dataGridView2.Rows.Add(encuadernacion);
        }

        /// <summary>
        /// Se encarga de Hardcodear el usuario y contrasenia del tipo de usuario seleccionado, para agilizar el ingreso.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="tipoUsuarioDado"></param>
        public static void HardcodearUsuario(FrmLogin form, string tipoUsuarioDado)
        {
            foreach (Usuario usuario in form.listaUsuarios)
            {
                if (usuario.tipoUsuario == tipoUsuarioDado)
                {
                    form.tNombre.Text = usuario.nombreUsuario;
                    form.tPass.Text = usuario.contrasenia;
                    break;
                }
            }
        }

        /// <summary>
        /// Se encarga de realizar la compra en el mercado y agregarla al stock.
        /// </summary>
        /// <param name="form">Instancia del Frm del supervisor.</param>
        /// <param name="stock">Instancia del Stock.</param>
        public static void BotonComprarStock(FrmMenuSupervisor form, Stock stock)
        {
            bool papelConvertido = int.TryParse(form.textBoxPapel.Text, out int papelIngresado);
            bool tintaConvertida = int.TryParse(form.textBoxTinta.Text, out int tintaIngresada);
            bool troquelConvertido = int.TryParse(form.textBoxTroquel.Text, out int troquelIngresado);
            bool encuConvertido = int.TryParse(form.textBoxEncuadernacion.Text, out int encuIngresado);

            if ((form.textBoxPapel.Text != string.Empty ||
                form.textBoxTinta.Text != string.Empty ||
                form.textBoxTroquel.Text != string.Empty ||
                form.textBoxEncuadernacion.Text != string.Empty) && 
                (papelConvertido && tintaConvertida && troquelConvertido && encuConvertido))
            {
                form.cantidadPapelAComprar = papelIngresado;
                form.cantidadTintaAComprar = tintaIngresada;
                form.cantidadTroquelAComprar = troquelIngresado;
                form.cantidadEncuadernacionAComprar = encuIngresado;

                form.textBoxPapel.Text = "0";
                form.textBoxTinta.Text = "0";
                form.textBoxTroquel.Text = "0";
                form.textBoxEncuadernacion.Text = "0";

                Operacion.CalcularCompra(form, stock);
            }
            else
            {
                MessageBox.Show("Ingrese valores numericos", "Sispro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Calcula que la compra sea posible en relacion al presupuesto.
        /// </summary>
        /// <param name="form">Instancia del Frm del operario.</param>
        /// <param name="stock">Instancia del Stock.</param>
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

        /// <summary>
        /// Se encarga de manejear los eventos del DataGridView del Frm del operario, en caso
        /// de que se seleccione alguna fila.
        /// </summary>
        /// <param name="form">Instancia del Frm del operario.</param>
        /// <param name="e">Eventos sobre el DataGridView.</param>
        public static void ManejoDataGrid(FrmMenuOperario form, DataGridViewCellEventArgs e)
        {
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
                    if (Convert.ToInt32(filasPedidos.Cells["Papel"].Value) <= form.stock.Papel &&
                        Convert.ToInt32(filasPedidos.Cells["Tinta"].Value) <= form.stock.Tinta && 
                        Convert.ToInt32(filasPedidos.Cells["Troquel"].Value) <= form.stock.Troquel &&
                        Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value) <= form.stock.Encuadernacion)
                    {
                        form.stock.Papel = -Convert.ToInt32(filasPedidos.Cells["Papel"].Value);
                        form.stock.Tinta = -Convert.ToInt32(filasPedidos.Cells["Tinta"].Value);
                        form.stock.Troquel = -Convert.ToInt32(filasPedidos.Cells["Troquel"].Value);
                        form.stock.Encuadernacion = -Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value);
                        form.stock.CargarStock(form);

                        MostrarInfoPedidoElegido(form, filasPedidos);

                        form.filaPedidoEnProceso = filasPedidos;

                        form.stock.ControlStock(form);
                        
                        form.dataGridView1.Enabled = false;
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
                    //if (filasPedidos.DefaultCellStyle.BackColor == Color.Green)
                    //{
                    //    form.stock.Papel = +Convert.ToInt32(filasPedidos.Cells["Papel"].Value);
                    //    form.stock.Tinta = +Convert.ToInt32(filasPedidos.Cells["Tinta"].Value);
                    //    form.stock.Troquel = +Convert.ToInt32(filasPedidos.Cells["Troquel"].Value);
                    //    form.stock.Encuadernacion = +Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value);
                    //    form.stock.CargarStock(form);
                    //}

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

        /// <summary>
        /// Controla que no se puedan seleccionar los demas RadioButtons de la linea de produccion, hasta
        /// que no termine el anterior paso.
        /// </summary>
        /// <param name="form">Instancia del Frm del operario</param>
        /// <param name="troquelado">Indica que tarea es la proxima a realizar</param>
        /// <param name="encuadernacion">Indica que tarea es la proxima a realizar</param>
        public static void ControlProduccion(FrmMenuOperario form, bool troquelado, bool encuadernacion)
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
        /// Se encarga de indicar con MessageBox cuando se termine el producto, y reestablece valores 
        /// necesarios para seguir con la produccion.
        /// </summary>
        /// <param name="form">Instancia del Frm del operario</param>
        /// <param name="impresionFinalizada">Indica si se finalizo la tarea</param>
        /// <param name="troqueladoFinalizado">Indica si se finalizo la tarea</param>
        /// <param name="encuadernacionFinalizada">Indica si se finalizo la tarea</param>
        /// <param name="usuario">Instancia de un usuario</param>
        public static void ControlProduccion(FrmMenuOperario form, bool impresionFinalizada, bool troqueladoFinalizado, bool encuadernacionFinalizada, Usuario usuario)
        {
            string gananciaEnLimpio = filaPedidoElegido.Cells["Ganancia"].Value.ToString().Remove(0,1);
            string mensaje = "";
            if (form.contProcesos == 1 && impresionFinalizada)
            {
                mensaje = String.Format("Impresion de:\n{0}\nFinalizada!",
                    filaPedidoElegido.Cells["Pedido"].Value);
            }
            else if (form.contProcesos == 2 && troqueladoFinalizado)
            {
                mensaje = String.Format("Impresion y troquelado de:\n{0}\nFinalizada!",
                    filaPedidoElegido.Cells["Pedido"].Value);
            }
            else if (form.contProcesos == 3 && encuadernacionFinalizada)
            {
                mensaje = String.Format("Impresion, troquelado y encuadernacion de:\n{0}\nFinalizada!",
                    filaPedidoElegido.Cells["Pedido"].Value);
            }

            if ((form.contProcesos == 1 && impresionFinalizada) ||
                (form.contProcesos == 2 && troqueladoFinalizado) ||
                (form.contProcesos == 3 && encuadernacionFinalizada))
            {
                MessageBox.Show(mensaje, "Sispro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.stock.PresupuestoTotal = +Convert.ToInt32(gananciaEnLimpio);
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
        /// Se encarga de mostrar en el Frm el detalle del pedido seleccionado.
        /// </summary>
        /// <param name="form">Instancia del Frm del operario</param>
        /// <param name="filasPedidos">Fila elegida por el usuario</param>
        private static void MostrarInfoPedidoElegido(FrmMenuOperario form, DataGridViewRow filasPedidos)
        {
            filasPedidos.DefaultCellStyle.BackColor = Color.Green;
            form.labelPedido.Visible = true;
            form.labelPedidoSeleccionado.Text = filasPedidos.Cells["Pedido"].Value.ToString();
            form.labelPedidoSeleccionado.Visible = true;
            form.labelMaquinaria.Visible = true;
            form.labelMaquinariaNecesaria.Visible = true;

            string maquinarias = "";
            if (Convert.ToInt32(filasPedidos.Cells["Papel"].Value) > 0)
            {
                maquinarias = "IMPRESORA ";
                form.radioButtonImpresora.Enabled = true;
                impresionRequerida = true;
                form.contProcesos++;
            }
            if (Convert.ToInt32(filasPedidos.Cells["Troquel"].Value) > 0)
            {
                maquinarias += "| TROQUELADORA ";
                troqueladoRequerido = true;
                form.contProcesos++;
            }
            if (Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value) > 0)
            {
                maquinarias += "| ENCUADERNADORA ";
                encuadernacionRequerida = true;
                form.contProcesos++;
            }
            form.labelMaquinariaNecesaria.Text += maquinarias;

            form.labelCantImp.Text = filasPedidos.Cells["Papel"].Value.ToString();
            form.labelCantTroq.Text = filasPedidos.Cells["Troquel"].Value.ToString();
            form.labelCantEncu.Text = filasPedidos.Cells["Encuadernacion"].Value.ToString();
        }

        /// <summary>
        /// Valida que los datos ingresados en el Login sean correctos.
        /// </summary>
        /// <param name="form">Instancia del Frm Login</param>
        public static void ValidarUsuario(FrmLogin form)
        {
            string nombre = form.tNombre.Text;
            string pass = form.tPass.Text;

            if (form.listaUsuarios.Count >= 1)
            {
                for (int i = 0; i < form.listaUsuarios.Count; i++)
                {
                    if (nombre != String.Empty)
                    {
                        if (pass != String.Empty)
                        {
                            if (form.listaUsuarios != null)
                            {
                                if (nombre == form.listaUsuarios[i].nombreUsuario && pass == form.listaUsuarios[i].contrasenia)
                                {
                                    form.menuOperario = new FrmMenuOperario(form.listaUsuarios, i, form, form.stock);
                                    form.menuSupervisor = new FrmMenuSupervisor(form.listaUsuarios, i, form, form.stock);

                                    if (form.listaUsuarios[i].tipoUsuario == "operario") { form.menuOperario.Show(); }
                                    else { form.menuSupervisor.Show(); }
                                    form.tNombre.Text = "";
                                    form.tPass.Text = "";
                                    form.Hide();

                                    //if (form.contIngresos == 0) 
                                    //{ 
                                        CargarPedidosDataGridView(form.menuOperario); 
                                    //    form.contIngresos++;
                                    //}
                                }
                                else
                                {
                                    form.labelError.Text = "Error. Los datos no coinciden.";
                                    form.labelError.Visible = true;
                                }
                            }
                            else
                            {
                                form.labelError.Text = "Error. No existe el usuario.";
                                form.labelError.Visible = true;
                            }
                        }
                        else
                        {
                            form.labelError.Text = "Error. Contraseña vacia.";
                            form.labelError.Visible = true;
                        }
                    }
                    else
                    {
                        form.labelError.Text = "Error. Nombre de usuario vacio.";
                        form.labelError.Visible = true;
                    }
                }
            }
            else
            {
                form.labelError.Text = "Error. No hay usuarios creados.";
                form.labelError.Visible = true;
            }
        }

        /// <summary>
        /// Se encarga de mover las ProgressBar de cada recurso.
        /// </summary>
        /// <param name="impresora">Indica si es la impresora</param>
        /// <param name="troqueladora">Indica si es la troqueladora</param>
        /// <param name="encuadernadora">Indica si es la encuadernadora</param>
        /// <param name="form">Instancia del Frm del operario</param>
        public static void RealizarTarea(bool impresora, bool troqueladora, bool encuadernadora, FrmMenuOperario form)
        {
            if (impresora)
            {
                for (int i = 0; i <= 100; i++)
                {
                    form.progressBarImpresora.Value = i;
                    form.progressBarImpresora.Refresh();
                    Thread.Sleep(30);
                }
                form.progressBarImpresora.Value = form.progressBarImpresora.Maximum;
                form.labelImpresionExitosa.Visible = true;
            }
            else if (troqueladora)
            {
                for (int i = 0; i <= 100; i++)
                {
                    form.progressBarTroqueladora.Value = i;
                    form.progressBarTroqueladora.Refresh();
                    Thread.Sleep(30);
                }
                form.progressBarTroqueladora.Value = form.progressBarTroqueladora.Maximum;
                form.labelTroqueladoExitoso.Visible = true; 
            }
            else if (encuadernadora)
            {
                for (int i = 0; i <= 100; i++)
                {
                    form.progressBarEncuadernadora.Value = i;
                    form.progressBarEncuadernadora.Refresh();
                    Thread.Sleep(30);
                }
                form.progressBarEncuadernadora.Value = form.progressBarEncuadernadora.Maximum;
                form.labelEncuExitosa.Visible = true;   
            }
        }
    }
}
