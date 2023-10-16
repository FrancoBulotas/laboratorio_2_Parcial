using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class RRHH : Empresa
    {

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

        public static string ValorRandom(bool nombreUsuario, bool tipoUsuario)
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
    }
}
