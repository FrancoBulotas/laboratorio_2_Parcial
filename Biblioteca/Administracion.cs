using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Administracion : Empresa
    {
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
                    if (usr.nombreUsuario == usuario.nombreUsuario)
                    {
                        return false;
                    }
                }
            }
            listaUsuarios.Add(usuario);
            return true;
        }

        /// <summary>
        /// Genera un valor random, puede ser un nombre, tipo de usuario o contrasenia si ambos parametros son falsos
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="tipoUsuario"></param>
        /// <returns>Retorna un string, ya sea de un nombre de usuario, tipo de usuario o contrasenia</returns>
        public static string ValorRandomUsuario(bool nombreUsuario, bool tipoUsuario)
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
            else
            {
                if (!nombreUsuario)
                {
                    for (int i = 0; i < arrayContra.Length; i++)
                    {
                        arrayContra[i] = caracteres[random.Next(caracteres.Length)];
                    }
                    return new String(arrayContra);
                }
                else
                {
                    return listaNombres[random.Next(listaNombres.Count)];
                }
            }
        }

        //public override void ControlProduccion()
        //{
            
        //}
    }
}
