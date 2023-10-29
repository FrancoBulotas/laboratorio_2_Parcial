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


        public Administracion()
        {
            dictResultado.Add("Tipo Usuario", "");
            dictResultado.Add("Indice", "");
            dictResultado.Add("Error", "");
        }


        /// <summary>
        /// Carga los pedidos pendientes al DataGridView del Frm del operario.
        /// </summary>
        /// <param name="form"></param>
        public static void CargarPedidosDataGridView(FrmMenuOperario form) 
        {
            //List<string[]> pedidos = new List<string[]>();

            string[] pedido1 = { "Libros de matematica", "10000", "5000", "1500", "1250", "0" };
            string[] pedido2 = { "Boletas", "50000", "7500", "1200", "0", "0" };
            string[] pedido3 = { "Cuadernillos", "6000", "5000 ", "1500", "800", "2000" };
            string[] pedido4 = { "Libros de literatura", "3000", "2200", "700", "200", "280" };
            string[] pedido5 = { "Libros de historia", "3400", "2600", "750", "250", "300" };
            string[] pedido6 = { "Envoltorio botellas", "11000", "6200", "3000", "0", "0" };

            form.dataGridView1.Rows.Add(pedido1);
            form.dataGridView1.Rows.Add(pedido2);
            form.dataGridView1.Rows.Add(pedido3);
            form.dataGridView1.Rows.Add(pedido4);
            form.dataGridView1.Rows.Add(pedido5);
            form.dataGridView1.Rows.Add(pedido6);
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
                    return  datosUsuario;
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


        //public override void ControlProduccion()
        //{

        //}
    }
}
