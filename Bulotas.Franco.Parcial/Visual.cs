using Biblioteca;
using System.Collections;

namespace Frms
{
    public static class Visual
    {
        private static bool troqueladoRequerido = false;
        private static bool encuadernacionRequerida = false;
        private static DataGridViewRow filaPedidoElegido;

        /// <summary>
        /// Carga el stock en las filas del DataGridView pasado como parametro.
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="stock"></param>
        internal static void CargarStockDataGrid(DataGridView dg, Stock stock)
        {
            dg.Rows[0].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("papel");
            dg.Rows[1].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("tinta");
            dg.Rows[2].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("troquel");
            dg.Rows[3].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("encuadernacion");
        }

        /// <summary>
        /// Controla que el stock no este bajo, en caso de estarlo pinta la fila en rojo.
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="dg"></param>
        /// <param name="insumo"></param>
        private static void ControlColorCantidadStock(Stock stock, DataGridView dg, string insumo)
        {
            ArrayList arrayControlStock;
            arrayControlStock = stock.ControlStock(insumo);

            if ((int)arrayControlStock[0] >= 0)
            {
                if ((int)arrayControlStock[1] == 1) { dg.Rows[(int)arrayControlStock[0]].DefaultCellStyle.BackColor = Color.Red; }

                else if ((int)arrayControlStock[1] == 0) { dg.Rows[(int)arrayControlStock[0]].DefaultCellStyle.BackColor = Color.White; }
            }
        }

        /// <summary>
        /// Controla el DataGridView del stock, llama al metodo ControlColorCantidadStock() para ello.
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="dg"></param>
        internal static void ControlDataGridStock(Stock stock, DataGridView dg)
        {
            ControlColorCantidadStock(stock, dg, "papel");
            ControlColorCantidadStock(stock, dg, "tinta");
            ControlColorCantidadStock(stock, dg, "troquel");
            ControlColorCantidadStock(stock, dg, "encuadernacion");
        }

        /// <summary>
        /// Agrega los insumos disponibles en el stock al DataGridView dado.
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="stock"></param>
        public static void CargarMaterialesDataGridView(DataGridView dg, Stock stock)
        {
            dg.Rows.Add("Papel", stock.CantStock["Papel"].ToString());
            dg.Rows.Add("Tinta", stock.CantStock["Tinta"].ToString());
            dg.Rows.Add("Troquel", stock.CantStock["Troquel"].ToString());
            dg.Rows.Add("Encuadernacion", stock.CantStock["Encuadernacion"].ToString());
        }

        /// <summary>
        /// Ingresa en el DataGridView los pedidos pasados como parametro en List<string> siendo que estas cadenas separan cada columna por '-'.
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="pedidos"></param>
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
        public static void ManejoDataGridOperario(FrmMenuOperario form, DataGridViewCellEventArgs e)
        {
            Dictionary<string, string> dictInfo = new Dictionary<string, string>();

            if (form.dataGridView1.Columns[e.ColumnIndex].Name == "Seleccion")
            {
                bool resultado;
                form.contProcesos = 0;
                string msjError;
                // Se toma la fila seleccionada
                DataGridViewRow filasPedidos = form.dataGridView1.Rows[e.RowIndex];
                filaPedidoElegido = filasPedidos;

                // Se selecciona la celda del checkbox
                DataGridViewCheckBoxCell celdaSeleccion = filasPedidos.Cells["Seleccion"] as DataGridViewCheckBoxCell;

                try
                {
                    resultado = !Convert.ToBoolean(celdaSeleccion.Value);
                }
                catch (FormatException error)
                {
                    resultado = false;
                    form.administracion.CargarErrorLog(form.administracion.MensajeError(error));
                }

                if (resultado)
                {
                    if (Convert.ToInt32(filasPedidos.Cells["Papel"].Value) <= form.login.stock.CantStock["Papel"] &&
                        Convert.ToInt32(filasPedidos.Cells["Tinta"].Value) <= form.login.stock.CantStock["Tinta"] &&
                        Convert.ToInt32(filasPedidos.Cells["Troquel"].Value) <= form.login.stock.CantStock["Troquel"] &&
                        Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value) <= form.login.stock.CantStock["Encuadernacion"])
                    {
                        form.cantPapelAConsumir = Convert.ToInt32(filasPedidos.Cells["Papel"].Value);
                        form.cantTintaAConsumir = Convert.ToInt32(filasPedidos.Cells["Tinta"].Value);
                        form.cantTroquelAConsumir = Convert.ToInt32(filasPedidos.Cells["Troquel"].Value);
                        form.cantEncuAConsumir = Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value);

                        filasPedidos.DefaultCellStyle.BackColor = Color.Green;
                        form.labelPedidoSeleccionado.Text = filasPedidos.Cells["Pedido"].Value.ToString();
                        ModificarVisibilidadLabels(form, true);
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

                        form.dataGridView1.Enabled = false;
                    }
                    else
                    {
                        string mensaje = string.Format("NO hay stock suficiente para \n\nPedido: '{0}''",
                                    filasPedidos.Cells["Pedido"].Value);
                        MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        filasPedidos.DefaultCellStyle.BackColor = Color.Red;
                        ModificarVisibilidadLabels(form, false);
                    }
                    celdaSeleccion.Value = true;
                }
                else
                {
                    string mensaje = string.Format("Se ha quitado la seleccion n\nPedido: '{0}'",
                                                        filasPedidos.Cells["Pedido"].Value);
                    MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    filasPedidos.DefaultCellStyle.BackColor = Color.White;
                    ModificarVisibilidadLabels(form, false);
                    celdaSeleccion.Value = false;
                }
            }
        }

        /// <summary>
        /// Modifica la visibilidad de los labels que indican el pedido seleccionado.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="valor"></param>
        private static void ModificarVisibilidadLabels(FrmMenuOperario form, bool valor)
        {
            form.labelPedido.Visible = valor;
            form.labelPedidoSeleccionado.Visible = valor;
            form.labelMaquinaria.Visible = valor;
            form.labelMaquinariaNecesaria.Visible = valor;
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
            string mensaje = "";
            if (form.contProcesos == 1 && impresionFinalizada)
            {
                mensaje = String.Format("Impresion de:\n{0}\nFinalizada!",
                                        filaPedidoElegido.Cells["Pedido"].Value);
                form.radioButtonImpresora.Checked = false;
                form.labelMaquinariaNecesaria.Text = "";
                form.labelPedidoSeleccionado.Text = "";
            }
            else if (form.contProcesos == 2 && troqueladoFinalizado)
            {
                mensaje = String.Format("Impresion y troquelado de:\n{0}\nFinalizada!",
                                        filaPedidoElegido.Cells["Pedido"].Value);
                form.radioButtonTroqueladora.Checked = false;
                form.labelMaquinariaNecesaria.Text = "";
                form.labelPedidoSeleccionado.Text = "";
            }
            else if (form.contProcesos == 3 && encuadernacionFinalizada)
            {
                mensaje = String.Format("Impresion, troquelado y encuadernacion de:\n{0}\nFinalizada!",
                                        filaPedidoElegido.Cells["Pedido"].Value);
                form.radioButtonEncuadernadora.Checked = false;
                form.labelMaquinariaNecesaria.Text = "";
                form.labelPedidoSeleccionado.Text = "";
            }

            if ((form.contProcesos == 1 && impresionFinalizada) ||
                (form.contProcesos == 2 && troqueladoFinalizado) ||
                (form.contProcesos == 3 && encuadernacionFinalizada))
            {
                MessageBox.Show(mensaje, "Sispro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                form.dataGridView1.Rows.Remove(form.filaPedidoEnProceso);

                usuario.TrabajosRealizados = 1;
                UsuarioDAO.ModificarTrabajos(usuario.ID);


                if (form.login.menuSupervisor != null) { form.login.menuSupervisor.dataGridView1.Rows[form.indexUsuarioLogueado].Cells["Trabajos"].Value = usuario.TrabajosRealizados.ToString(); }

                form.dataGridView1.Enabled = true;
                form.progressBarImpresora.Value = form.progressBarImpresora.Minimum;
                form.progressBarTroqueladora.Value = form.progressBarTroqueladora.Minimum;
                form.progressBarEncuadernadora.Value = form.progressBarEncuadernadora.Minimum;

                form.labelImpresionExitosa.Visible = false;
                form.labelTroqueladoExitoso.Visible = false;
                form.labelEncuExitosa.Visible = false;

                form.labelCantEncu.Text = "0";
                form.labelCantImp.Text = "0";
                form.labelCantTroq.Text = "0";
            }
        }

        /// <summary>
        /// Se encarga de cargar en la instancia del stock, la cantidad de insumos comprados previamente.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="materiales"></param>
        public static void ValidarStockComprado(FrmMenuSupervisor form, bool insumosComprados)//, Dictionary<string, int> materiales)
        {
            if (!insumosComprados)
            {
                MessageBox.Show("Ingrese valores numericos positivos", "Sispro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
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
        /// Se encarga de aumentar el progeso de la barra.
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

        /// <summary>
        /// Actualiza el stock, labels y avisa cuando termina de producir.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="boton"></param>
        /// <param name="label"></param>
        /// <param name="barra"></param>
        /// <param name="impresora"></param>
        /// <param name="troqueladora"></param>
        public static void ActualizarFormAlChequear(FrmMenuOperario form, RadioButton boton, Label label, ProgressBar barra, bool impresora, bool troqueladora)
        {

            boton.Enabled = false;
            ModificarProgressBar(barra);
            label.Visible = true;

            if (impresora)
            {
                form.login.stock.CantStock = StockDAO.Modificar(-form.cantPapelAConsumir, -form.cantTintaAConsumir, 0, 0);
                form.cantPapelAConsumir = 0;
                form.cantTintaAConsumir = 0;
            }
            else if (troqueladora)
            {
                form.login.stock.CantStock = StockDAO.Modificar(0, 0, -form.cantTroquelAConsumir, 0);
                form.cantTroquelAConsumir = 0;
            }
            else
            {
                form.login.stock.CantStock = StockDAO.Modificar(0, 0, 0, -form.cantEncuAConsumir);
                form.cantEncuAConsumir = 0;
            }

            CargarStockDataGrid(form.dataGridView2, form.login.stock);
            ControlDataGridStock(form.login.stock, form.dataGridView2);

            if (impresora || troqueladora)
            {
                ControlSeleccionProduccion(form, impresora, troqueladora);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="administracion"></param>
        /// <param name="idUsuario"></param>
        public static void CargarUsuariosDataGrid(DataGridView dg, Administracion administracion, int idUsuario = -1)
        {
            if (idUsuario > 0)
            {
                for (int i = 0; i < dg.Rows.Count; i++)
                {
                    if (idUsuario == Convert.ToInt32(dg.Rows[i].Cells["ID"].Value))
                    {
                        dg.Rows[i].Cells["Trabajos"].Value = administracion.ListaUsuarios[i].TrabajosRealizados.ToString();
                    }
                }
            }
            else if (idUsuario == 0)
            {
                if (administracion.ListaUsuarios != null)
                {
                    for (int i = 0; i < administracion.ListaUsuarios.Count; i++)
                    {
                        string[] usuario =
                            { administracion.ListaUsuarios[i].ID.ToString(),
                              administracion.ListaUsuarios[i].NombreUsuario };

                        dg.Rows.Add(usuario);
                    }
                }
            }
            else
            {
                if (administracion.ListaUsuarios != null)
                {
                    for (int i = 0; i < administracion.ListaUsuarios.Count; i++)
                    {
                        string[] usuario =
                            { administracion.ListaUsuarios[i].ID.ToString(),
                          administracion.ListaUsuarios[i].NombreUsuario,
                          administracion.ListaUsuarios[i].Contrasenia,
                          administracion.ListaUsuarios[i].TipoUsuario,
                          administracion.ListaUsuarios[i].TrabajosRealizados.ToString() };

                        dg.Rows.Add(usuario);
                    }
                }
            }
        }


        public static Image CargarFondo(bool login)
        {
            string directorioEjecutable = AppDomain.CurrentDomain.BaseDirectory;
            string rutaImagenFondo;

            if (login)
            {
                rutaImagenFondo = Path.Combine(directorioEjecutable, Administracion.DeserializarJSONConfig()["FondoLogin"]);
            }
            else
            {
                rutaImagenFondo = Path.Combine(directorioEjecutable, Administracion.DeserializarJSONConfig()["FondoApp"]);

            }

            return Image.FromFile(rutaImagenFondo);
        }

        public static Icon CargarIcono()
        {
            string directorioEjecutable = AppDomain.CurrentDomain.BaseDirectory;
            string rutaIcono = Path.Combine(directorioEjecutable, Administracion.DeserializarJSONConfig()["Icono"]);
            return  new Icon(rutaIcono);
        }


        public static void ManejoDataGridCRUD(FrmMenuSupervisorCRUD form, DataGridViewCellEventArgs e)
        {
            if (form.dataGridViewUsr.Columns[e.ColumnIndex].Name == "Seleccion")
            {
                bool resultado;
                
                DataGridViewRow filaElegida = form.dataGridViewUsr.Rows[e.RowIndex];
                               
                DataGridViewCheckBoxCell celdaSeleccion = filaElegida.Cells["Seleccion"] as DataGridViewCheckBoxCell;

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
                    form.buttoneliminarUsr.Enabled = true;
                    form.idUsuarioSeleccionado = Convert.ToInt32(filaElegida.Cells["ID"].Value);
                    form.indiceUsuarioSeleccionado = form.administracion.ObtenerIndiceListaUsuarios(form.idUsuarioSeleccionado);

                    if (form.botonModClickeado)
                    {
                        form.labelNombreActual.Text = form.administracion.ListaUsuarios[form.indiceUsuarioSeleccionado].NombreUsuario;
                        form.labelNombreActual.Visible = true;

                        form.labelContraActual.Text = form.administracion.ListaUsuarios[form.indiceUsuarioSeleccionado].Contrasenia;
                        form.labelContraActual.Visible = true;

                        form.labelTipoUsuarioActual.Text = form.administracion.ListaUsuarios[form.indiceUsuarioSeleccionado].TipoUsuario;
                        form.labelTipoUsuarioActual.Visible = true;

                        form.botonModClickeado = false;
                    }

                    celdaSeleccion.Value = true;
                }
                else
                {
                    MessageBox.Show("Se ha quitado la seleccion", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    form.labelNombreActual.Visible = false;
                    form.labelContraActual.Visible = false;

                    celdaSeleccion.Value = false;
                }
            }
        }

        public static void MostrarMenuModificar(FrmMenuSupervisorCRUD form)
        {
            form.labelActual.Visible = true;
            form.labelContra.Visible = true;
            form.labelNombre.Visible = true;
            form.labelTipoDeUsuario.Visible = true;
            form.textBoxNuevaContra.Visible = true;
            form.textBoxNuevaContra.PlaceholderText = "Nueva contraseña";
            form.textBoxRepetirNuevaContra.Visible = false;
            form.textBoxNuevoNombre.Visible = true;
            form.textBoxTipoDeUsuario.Visible = true;
            form.buttonAplicarModificacion.Visible = true;
            form.buttonAplicarCreacion.Visible = false;
        }

        public static void MostrarMenuCrear(FrmMenuSupervisorCRUD form)
        {
            form.labelActual.Visible = false;
            form.labelContra.Visible = true;
            form.labelNombre.Visible = true;
            form.labelNombreActual.Visible = false;
            form.labelTipoDeUsuario.Visible = true;
            form.labelTipoUsuarioActual.Visible = false;
            form.textBoxNuevaContra.Visible = true;
            form.textBoxNuevaContra.PlaceholderText = "Repetir contraseña";
            form.textBoxRepetirNuevaContra.Visible = true;
            form.textBoxNuevoNombre.Visible = true;
            form.textBoxTipoDeUsuario.Visible = true;
            form.buttonAplicarCreacion.Visible = true;
            form.buttonAplicarModificacion.Visible = false;
        }

        public static void EjecutarSolicitado(FrmMenuSupervisorCRUD form, bool modificar)
        {
            string mensaje;
            string msjError;

            if (modificar)
            {
                form.dictResultadoRegistro = form.administracion.ValidarUsuarioRegistro(form.textBoxNuevoNombre.Text, form.textBoxNuevaContra.Text, "", form.textBoxTipoDeUsuario.Text, form.administracion.ListaUsuarios[form.indiceUsuarioSeleccionado].ID);
                mensaje = "Modificado Correctamente";
            }
            else
            {
                form.dictResultadoRegistro = form.administracion.ValidarUsuarioRegistro(form.textBoxNuevoNombre.Text, form.textBoxNuevaContra.Text, form.textBoxRepetirNuevaContra.Text, form.textBoxTipoDeUsuario.Text);
                mensaje = "Creado Correctamente";
            }

            if (form.dictResultadoRegistro["Error"].Length > 0)
            {
                form.labelErrorRegistro.Text = form.dictResultadoRegistro["Error"];
                form.labelErrorRegistro.Visible = true;

                if(mensaje == "Modificado Correctamente") { msjError = $"{DateTime.Now} | Modificacion Usuario: {form.dictResultadoRegistro["Error"]}"; }
                else { msjError = $"{DateTime.Now} | Creacion Usuario: {form.dictResultadoRegistro["Error"]}"; }

                form.administracion.CargarErrorLog(msjError);
            }
            else
            {
                form.labelErrorRegistro.Visible = false;
                form.textBoxNuevoNombre.Text = "";
                form.textBoxNuevaContra.Text = "";
                form.textBoxRepetirNuevaContra.Text = "";
                form.textBoxTipoDeUsuario.Text = "";

                ActualizarDataGrid(form.formSupervisor.dataGridView1, form.administracion, true);
                ActualizarDataGrid(form.dataGridViewUsr, form.administracion, false);

                MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            mensaje = "";
            form.dictResultadoRegistro["Error"] = "";

        }

        public static void ActualizarDataGrid(DataGridView dg, Administracion administracion, bool supervisor)
        {
            dg.Rows.Clear();
            administracion.ListaUsuarios = UsuarioDAO.LeerTodo();

            if (supervisor)
            {
                CargarUsuariosDataGrid(dg, administracion);
            }
            else
            {
                CargarUsuariosDataGrid(dg, administracion, 0);
            }

        }


    }
}
