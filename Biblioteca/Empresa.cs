using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public abstract class Empresa
    {
        protected List<Usuario> listaUsuarios;

        public Empresa()
        {
            //listaUsuarios = GenerarListaUsuarios();
            listaUsuarios = UsuarioDAO.LeerTodo();
        }

        /// <summary>
        /// Se encarga de generar una lista de usuarios con datos random.
        /// </summary>
        /// <returns>Retorna la lista.</returns>
        //private List<Usuario> GenerarListaUsuarios()
        //{
        //    List<string> listaNombres = new List<string>
        //    {
        //        "Franco","Pedro","Juan","Fausto","Adriana","Agustina","Joaquin","Malena","Juana","Enrique",
        //        "Nicolas","Ignacio","Joel"
        //    };

        //    List<Usuario>? lista = new();
        //    for(int i = 0; i < listaNombres.Count() ; i++)
        //    {
        //        string nombreUsuario = listaNombres[i];
        //        string contrasenia = ValorRandomUsuario(false);;
        //        string tipoUsuario = ValorRandomUsuario(true);
        //        Usuario usuario = new(nombreUsuario, contrasenia, tipoUsuario);
        //        lista.Add(usuario);
        //    }
        //    return lista;
        //}

        /// <summary>
        /// Genera un valor random, tipo de usuario o contrasenia.
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <returns>Retorna un string con el valor random de un tipo de usuario o contrasenia</returns>
        public string ValorRandomUsuario(bool tipoUsuario, bool nombreUsuario)
        {
            List<string> listaNombres = new List<string>
            {
                "Franco","Pedro","Juan","Fausto","Adriana","Agustina","Joaquin","Malena","Juana","Enrique",
                "Nicolas","Ignacio","Joel"
            };

            List<string> tiposUsuarios = new List<string> { "operario", "supervisor" };

            string caracteres = "abcdefghijlmnopqrstuv";
            char[] arrayContra = new char[2];
            Random random = new();

            if (tipoUsuario)
            {
                return tiposUsuarios[random.Next(tiposUsuarios.Count)];
            }
            else if (nombreUsuario)
            {
                return listaNombres[random.Next(listaNombres.Count)];
            }
            else
            {
                for (int i = 0; i < arrayContra.Length; i++)
                {
                    arrayContra[i] = caracteres[random.Next(caracteres.Length)];
                }
                return new String(arrayContra);
            }

        }

        public List<Usuario> ListaUsuarios { get { return listaUsuarios; } set { listaUsuarios = value; } }
    }
}
