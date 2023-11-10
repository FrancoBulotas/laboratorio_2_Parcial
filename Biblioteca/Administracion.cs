using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Administracion : Empresa
    {
        private Dictionary<string, string> dictResultadoLogin = new Dictionary<string, string>();
        private Dictionary<string, string> dictResultadoRegistro = new Dictionary<string, string>();
        private Dictionary<string, string> dictInfo = new Dictionary<string, string>();


        public Administracion()
        {
            dictResultadoLogin.Add("Tipo Usuario", "");
            dictResultadoLogin.Add("Indice", "");
            dictResultadoLogin.Add("Error", "");

            dictResultadoRegistro.Add("Error", "");

            dictInfo.Add("Maquinas", "");
            dictInfo.Add("Contador Procesos", "");
            dictInfo.Add("Troquelado Requerido", "");
            dictInfo.Add("Encuadernacion Requerida", "");
        }


        /// <summary>
        /// Se encarga de validar el detalle del pedido seleccionado y que maquinarias hacen falta para su uso.
        /// </summary>
        /// <param name="form">Instancia del Frm del operario</param>
        /// <param name="filasPedidos">Fila elegida por el usuario</param>
        /// <returns>Retorna un Dict con info del pedido</returns>
        public virtual Dictionary<string, string> MostrarInfoPedido(int cantPapel, int cantTroquel, int cantEncu)
        {
            string maquinasNecesarias = "";
            int contProcesos = 0;
            bool troqueladoRequerido = false;
            bool encuadernacionRequerida = false;

            if (Convert.ToInt32(cantPapel) > 0)
            {
                maquinasNecesarias = "IMPRESORA ";
                contProcesos++;
            }
            if (Convert.ToInt32(cantTroquel) > 0)
            {
                maquinasNecesarias += "| TROQUELADORA ";
                troqueladoRequerido = true;
                contProcesos++;
            }
            if (Convert.ToInt32(cantEncu) > 0)
            {
                maquinasNecesarias += "| ENCUADERNADORA ";
                encuadernacionRequerida = true;
                contProcesos++;
            }

            dictInfo["Maquinas"] = maquinasNecesarias;
            dictInfo["Contador Procesos"] = contProcesos.ToString();
            dictInfo["Troquelado Requerido"] = troqueladoRequerido.ToString();
            dictInfo["Encuadernacion Requerida"] = encuadernacionRequerida.ToString();

            return dictInfo;
        }

        /// <summary>
        /// Genera un valor random, de un tipo de libro o de un numero entre el 100 y 10000.
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <param name="cantInsumo"></param>
        /// <returns>Retorna una string con el valor random generado.</returns>
        public string ValorRandomProducto(bool cantInsumo)
        {
            List<string> tiposLibros = new List<string> { "Matematica", "Literatura", "Historia" };
            Random random = new();

            if (cantInsumo)
            {
                return (random.Next(10000) + 100).ToString();
            }
            else
            {
                return tiposLibros[random.Next(tiposLibros.Count)];
            }
        }

        /// <summary>
        /// Genera aleatoriamente los pedidos en el formato adecuado para un DataGridView.
        /// </summary>
        /// <param name="form"></param>
        /// <returns>Retorna una lista de string con los pedidos.</returns>
        public List<string> GenerarPedidosDataGridView()
        {
            List<string> productosTotales = new List<string>();
            List<string> nombresProductos = new List<string> { "boleta", "libro", "cuadernillo" };
            Random random = new();
            string nombreProducto;

            for (int i = 0; i < 20; i++)
            {
                string detallesProducto = "";

                nombreProducto = nombresProductos[random.Next(nombresProductos.Count)];

                if (nombreProducto == "boleta")
                {
                    Boleta boleta = new Boleta();
                    detallesProducto = boleta.MostrarInfoPedido(0, 0, 0)["Info"];
                }
                else if (nombreProducto == "libro")
                {
                    Libro libro = new Libro();
                    detallesProducto = libro.MostrarInfoPedido(0, 0, 0)["Info"];
                }
                else if (nombreProducto == "cuadernillo")
                {
                    Cuadernillo cuadernillo = new Cuadernillo();
                    detallesProducto = cuadernillo.MostrarInfoPedido(0, 0, 0)["Info"];
                }
                productosTotales.Add(detallesProducto);
            }
            return productosTotales;
        }

        /// <summary>
        /// Agrega un usuario a la lista de usuarios. Valida que no exista.
        /// </summary>
        /// <param name="listaUsuariosExtra"></param>
        /// <param name="usuario"></param>
        /// <param name="tipoUsuario"></param>
        /// <returns>Retorna true si se agrego correctamente, false si ya existe</returns>
        //public bool AgregarUsuario(List<Usuario> listaUsuariosExtra, Usuario usuario, string tipoUsuario)
        //{
        //    listaUsuarios = listaUsuariosExtra;

        //    if (tipoUsuario == string.Empty) { return false; }

        //    foreach (Usuario usr in listaUsuarios)
        //    {
        //        if (usr != null)
        //        {
        //            if (usr.NombreUsuario == usuario.NombreUsuario)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    listaUsuarios.Add(usuario);
        //    return true;
        //}


        /// <summary>
        /// Se encarga de Hardcodear el usuario y contrasenia del tipo de usuario seleccionado, para agilizar el ingreso.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="tipoUsuarioDado"></param>
        public Dictionary<string,string> HardcodearUsuario(string tipoUsuarioDado)
        {
            Dictionary<string, string> datosUsuario = new Dictionary<string, string>();

            foreach (Usuario usuario in listaUsuarios)
            {
                if (usuario.TipoUsuario == tipoUsuarioDado)
                {
                    datosUsuario.Add("Nombre", usuario.NombreUsuario);
                    datosUsuario.Add("Contrasenia", usuario.Contrasenia);
                    return datosUsuario;
                }
            }
            return datosUsuario;
        }

        /// <summary>
        /// Valida que los datos ingresados en el Login sean correctos para el login.
        /// </summary>
        /// <param name="nombreIngresado"></param>
        /// <param name="contraseniaIngresada"></param>
        /// <returns></returns>
        public Dictionary<string, string> ValidarUsuarioLogin(string nombreIngresado, string contraseniaIngresada)
        {
            if (ListaUsuarios.Count >= 1)
            {
                if (nombreIngresado != string.Empty)
                {
                    if (contraseniaIngresada != string.Empty)
                    {
                        for (int i = 0; i < ListaUsuarios.Count; i++)
                        {
                            if (nombreIngresado == ListaUsuarios[i].NombreUsuario && contraseniaIngresada == ListaUsuarios[i].Contrasenia)
                            {
                                if (ListaUsuarios[i].TipoUsuario == "operario")
                                {
                                    dictResultadoLogin["Tipo Usuario"] = "operario";
                                }
                                else
                                {
                                    dictResultadoLogin["Tipo Usuario"] = "supervisor";
                                }

                                dictResultadoLogin["Indice"] = i.ToString();
                                return dictResultadoLogin;
                            }
                            else
                            {
                                dictResultadoLogin["Error"] = "Los datos no coinciden.";
                            }
                        }
                    }
                    else
                    {
                        dictResultadoLogin["Error"] = "Contraseña vacia.";
                    }
                }
                else
                {
                    dictResultadoLogin["Error"] = "Nombre de usuario vacio.";
                }
            }
            else
            {
                dictResultadoLogin["Error"] = "No hay usuarios creados.";
            }

            return dictResultadoLogin;
        }


        public Dictionary<string, string> ValidarUsuarioRegistro(string nombre, string contra, string repContra, string tipoUsuario, int id=-1)
        {
            if (nombre != String.Empty)
            {
                if (tipoUsuario != string.Empty && (tipoUsuario.ToLower() == "operario" || tipoUsuario.ToLower() == "supervisor"))
                {
                    if (id <= 0)
                    {
                        if (contra != String.Empty && contra == repContra)
                        {

                            if (UsuarioDAO.Guardar(nombre, contra, tipoUsuario))
                            {
                                ListaUsuarios = UsuarioDAO.LeerTodo();
                                return dictResultadoRegistro;
                            }
                            else
                            {
                                dictResultadoRegistro["Error"] = "Error al registrar usuario.";
                            }
                        }
                        else
                        {
                            if (contra != repContra)
                            {
                                dictResultadoRegistro["Error"] = "Las contraseñas no coinciden.";
                            }
                            else
                            {
                                dictResultadoRegistro["Error"] = "Contraseña vacia.";
                            }
                        }
                    }
                    else
                    {
                        if (contra != String.Empty)
                        {
                            UsuarioDAO.Modificar(nombre, id, "nombre");
                            UsuarioDAO.Modificar(contra, id, "contrasenia");
                            UsuarioDAO.Modificar(tipoUsuario, id, "tipo_usuario");
                        }
                        else
                        {
                            dictResultadoRegistro["Error"] = "Contraseña vacia.";
                        }
                    }
                }
                else
                {
                    dictResultadoRegistro["Error"] = "Seleccionar un tipo de usuario valido.";

                }
            }
            else
            {
                dictResultadoRegistro["Error"] = "Nombre de usuario vacio.";
            }

            return dictResultadoRegistro;
        }


        public int ObtenerIndiceListaUsuarios(int id)
        {
            int indice = -1;

            for (int i=0 ; i < ListaUsuarios.Count; i++)
            {
                if (id == ListaUsuarios[i].ID)
                {
                    indice = i;
                }
            }
            return indice;
        }
    }
}
