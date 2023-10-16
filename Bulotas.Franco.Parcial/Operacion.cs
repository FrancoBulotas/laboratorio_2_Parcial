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

        public static void CargarPedidosDataGridView(FrmMenuOperario form)
        {
            string[] pedido1 = { "Libros de matematica", "10000", "5000", "1500", "1250", "0", "$100000" };
            string[] pedido2 = { "Boletas", "50000", "7500", "1200", "0", "0", "$170000" };
            string[] pedido3 = { "Cuadernillos", "6000", "5000 ", "1500", "800", "2000", "$130000" };
            string[] pedido4 = { "Libros de literatura", "3000", "2200", "700", "0", "280", "$60000" };
            string[] pedido5 = { "Libros de historia", "3400", "2600", "750", "0", "300", "$70000" };
            string[] pedido6 = { "Envases botellas", "11000", "6200", "3000", "0", "0", "$140000" };

            form.dataGridView1.Rows.Add(pedido1);
            form.dataGridView1.Rows.Add(pedido2);
            form.dataGridView1.Rows.Add(pedido3);
            form.dataGridView1.Rows.Add(pedido4);
            form.dataGridView1.Rows.Add(pedido5);
            form.dataGridView1.Rows.Add(pedido6);
        }

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
                Operacion.CalcularCompra(form, stock);
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
                        form.stock.Papel = +Convert.ToInt32(filasPedidos.Cells["Papel"].Value);
                        form.stock.Tinta = +Convert.ToInt32(filasPedidos.Cells["Tinta"].Value);
                        form.stock.Troquel = +Convert.ToInt32(filasPedidos.Cells["Troquel"].Value);
                        form.stock.Encuadernacion = +Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value);
                        form.stock.CargarStock(form);
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

        public static void ControlProduccion(FrmMenuOperario form, bool impresionFinalizada, bool troqueladoFinalizado, bool encuadernacionFinalizada, Usuario usuario)
        {
            string gananciaEnLimpio = filaPedidoElegido.Cells["Ganancia"].Value.ToString().Remove(0,1);
            string mensaje;
            if (form.contProcesos == 1 && impresionFinalizada)
            {
                mensaje = String.Format("Impresion de {0} Finalizada!\nHa ganado {1}",
                    filaPedidoElegido.Cells["Pedido"].Value,
                    filaPedidoElegido.Cells["Ganancia"].Value.ToString());
                MessageBox.Show(mensaje, "Sispro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.stock.PresupuestoTotal = +Convert.ToInt32(gananciaEnLimpio);

                form.dataGridView1.Rows.Remove(form.filaPedidoEnProceso);
                usuario.TrabajosRealizados = 1;

                MessageBox.Show(usuario.TrabajosRealizados.ToString());

            }
            else if (form.contProcesos == 2 && troqueladoFinalizado)
            {
                mensaje = String.Format("Impresion y troquelado de {0} Finalizada!\nHa ganado {1}",
                    filaPedidoElegido.Cells["Pedido"].Value,
                    filaPedidoElegido.Cells["Ganancia"].Value.ToString());
                MessageBox.Show(mensaje, "Sispro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form.stock.PresupuestoTotal = +Convert.ToInt32(gananciaEnLimpio);

                form.dataGridView1.Rows.Remove(form.filaPedidoEnProceso);
                usuario.TrabajosRealizados = 1;
            }
            else if (form.contProcesos == 3 && encuadernacionFinalizada)
            {
                mensaje = String.Format("Impresion, troquelado y encuadernacion de {0} Finalizada!\nHa ganado {1}",
                    filaPedidoElegido.Cells["Pedido"].Value,
                    filaPedidoElegido.Cells["Ganancia"].Value.ToString());
                MessageBox.Show(mensaje, "Sispro", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                form.stock.PresupuestoTotal = +Convert.ToInt32(gananciaEnLimpio);

                form.dataGridView1.Rows.Remove(form.filaPedidoEnProceso);
                usuario.TrabajosRealizados = 1;
            }
        }

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

        public static void ValidarUsuario(FrmLogin form)
        {
            string nombre = form.tNombre.Text;
            string pass = form.tPass.Text;

            if (form.listaUsuarios.Count >= 1)
            {
                for (int i = 0; i < form.listaUsuarios.Count; i++)
                {
                    //MessageBox.Show(listaUsuarios[0].nombreUsuario);
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
                                    //MessageBox.Show("Logueado Correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }
    }
}
