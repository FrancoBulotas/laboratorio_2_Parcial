﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca
{
    public class Administracion : Empresa, IMensaje, ILoginUsuario
    {
        private Dictionary<string, string> dictResultadoLogin = new Dictionary<string, string>();
        private Dictionary<string, string> dictResultadoRegistro = new Dictionary<string, string>();
        private Dictionary<string, string> dictInfo = new Dictionary<string, string>();

        public delegate void LogErrores(object sender, string msjError);
        public event LogErrores EventoLogError;

        public delegate void ValidacionLoginUsuario(object sender, Dictionary<string, string> dictResultadoLogin);
        public event ValidacionLoginUsuario EventoLoginUsuario;

        public Archivo archivo;

        public Administracion()
        {
            archivo = new Archivo(this);

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
        public List<Administracion> GenerarPedidosDataGridView()
        {
            List<Administracion> productosTotales = new List<Administracion>();
            List<string> nombresProductos = new List<string> { "boleta", "libro", "cuadernillo" };
            Random random = new();
            string nombreProducto;
            int cant1 = 0;
            int cant2 = 0;

            for (int i = 0; i < 20; i++)
            {
                nombreProducto = nombresProductos[random.Next(nombresProductos.Count)];

                if (nombreProducto == "boleta")
                {
                    Boleta boleta = new Boleta();
                    productosTotales.Add(boleta);
                }
                else if (nombreProducto == "libro")
                {
                    Libro libro = new Libro();
                    productosTotales.Add(libro);
                }
                else if (nombreProducto == "cuadernillo")
                {
                    Cuadernillo cuadernillo = new Cuadernillo();
                    productosTotales.Add(cuadernillo);
                }
            }

            OrdenarPedidosPorCantidad(productosTotales, (p1, p2) =>
            {
                if(p1 is Libro) { cant1 = ((Libro)p1).Cantidad; }
                if(p1 is Boleta) { cant1 = ((Boleta)p1).Cantidad; }
                if(p1 is Cuadernillo) { cant1 = ((Cuadernillo)p1).Cantidad; }
                if(p2 is Libro) { cant2 = ((Libro)p2).Cantidad; }
                if(p2 is Boleta) { cant2 = ((Boleta)p2).Cantidad; }
                if(p2 is Cuadernillo) { cant2 = ((Cuadernillo)p2).Cantidad; }

                return (cant1).CompareTo(cant2);
            });

            return productosTotales;
        }

        /// <summary>
        /// Se encarga de Hardcodear el usuario y contrasenia del tipo de usuario seleccionado, para agilizar el ingreso.
        /// </summary>
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
        /// <returns>Retorna un Dictionary<string, string> con el 'Tipo Usuario' que se loguea, el 'Indice' del usuario, y un 'Error' en caso de haberlo </returns>
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

                                DispararEventoLoginUsuario(dictResultadoLogin);
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

            DispararEventoLoginUsuario(dictResultadoLogin);
            return dictResultadoLogin;
        }

        /// <summary>
        /// Valida que los datos del usuario sean correctos a la hora de un registro.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="contra"></param>
        /// <param name="repContra"></param>
        /// <param name="tipoUsuario"></param>
        /// <param name="id"></param>
        /// <returns>Devuelve un Dictionary<string, string> donde la llave es 'Error', por defecto vacia, y en caso de error con el detalle del mismo.</returns>
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

        /// <summary>
        /// Obtiene el indice de un usuario en la lista de usuarios segun su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna el indice del usuario en caso de encontrarlo, sino devuelve -1.</returns>
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

        /// <summary>
        /// Se encarga de dar formato correcto al mensaje de error en excepcion.
        /// </summary>
        /// <param name="error"></param>
        /// <returns>Devuelve un string con el detalle del error.</returns>
        public string MensajeError(Exception error)
        {
            return $"{DateTime.Now} | {error.ToString().Split(":")[0]} | Info: {error.Message} | Metodo: {error.TargetSite}";
        }

        /// <summary>
        /// En caso de que el evento no se nulo, lo dispara con el mensaje de error.
        /// </summary>
        /// <param name="mensajeError"></param>
        internal void DispararEventoLogError(string mensajeError)
        {
            if (EventoLogError is not null)
            {
                EventoLogError.Invoke(this, mensajeError);
            }
        }

        /// <summary>
        /// En caso de que el evento no se nulo, lo dispara con el mensaje de error.
        /// </summary>
        /// <param name="mensajeError"></param>
        private void DispararEventoLoginUsuario(Dictionary<string, string> dictResultado)
        {
            if (EventoLoginUsuario is not null)
            {
                EventoLoginUsuario.Invoke(this, dictResultado);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pedidos"></param>
        /// <param name="comparador"></param>
        public static void OrdenarPedidosPorCantidad(List<Administracion> pedidos, Comparison<Administracion> comparador)
        {
            pedidos.Sort(comparador);
        }

    }
}
