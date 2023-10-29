using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Administracion : Empresa
    {
        private Dictionary<string, string> dictResultado = new Dictionary<string, string>();
        private Dictionary<string, string> dictInfo = new Dictionary<string, string>();


        public Administracion()
        {
            dictResultado.Add("Tipo Usuario", "");
            dictResultado.Add("Indice", "");
            dictResultado.Add("Error", "");

            dictInfo.Add("Maquinas", "");
            dictInfo.Add("Contador Procesos", "");
            dictInfo.Add("Troquelado Requerido", "");
            dictInfo.Add("Encuadernacion Requerida", "");
        }


        /// <summary>
        /// Se encarga de mostrar en el Frm el detalle del pedido seleccionado.
        /// </summary>
        /// <param name="form">Instancia del Frm del operario</param>
        /// <param name="filasPedidos">Fila elegida por el usuario</param>
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
        /// 
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <param name="cantInsumo"></param>
        /// <returns></returns>
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
        /// Carga los pedidos pendientes al DataGridView del Frm del operario.
        /// </summary>
        /// <param name="form"></param>
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
        public bool AgregarUsuario(List<Usuario> listaUsuariosExtra, Usuario usuario, string tipoUsuario)
        {
            //if (listaUsuarios == null) { return false; }
            listaUsuarios = listaUsuariosExtra;

            if (tipoUsuario == string.Empty) { return false; }

            foreach (Usuario usr in listaUsuarios)
            {
                if (usr != null)
                {
                    if (usr.NombreUsuario == usuario.NombreUsuario)
                    {
                        return false;
                    }
                }
            }
            listaUsuarios.Add(usuario);
            return true;
        }

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
        /// Valida que los datos ingresados en el Login sean correctos.
        /// </summary>
        /// <param name="form">Instancia del Frm Login</param>
        public Dictionary<string, string> ValidarUsuario(string nombreIngresado, string contraseniaIngresada)
        {
            int cont = 0;

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
                                    dictResultado["Tipo Usuario"] = "operario";
                                }
                                else
                                {
                                    dictResultado["Tipo Usuario"] = "supervisor";
                                }

                                dictResultado["Indice"] = i.ToString();
                                dictResultado["veces en for"] = cont.ToString();

                                return dictResultado;
                            }
                            else
                            {
                                dictResultado["Error"] = "Los datos no coinciden.";
                            }

                            cont++;
                        }
                    }
                    else
                    {
                        dictResultado["Error"] = "Contraseña vacia.";
                    }
                }
                else
                {
                    dictResultado["Error"] = "Nombre de usuario vacio.";
                }
            }
            else
            {
                dictResultado["Error"] = " No hay usuarios creados.";
            }

            return dictResultado;
        }
    }
}
