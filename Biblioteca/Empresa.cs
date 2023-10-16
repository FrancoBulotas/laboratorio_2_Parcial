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
            listaUsuarios = GenerarListaUsuarios();
        }

        private static List<Usuario> GenerarListaUsuarios()
        {
            List<Usuario>? lista = new();
            for(int i = 0; i <= 20; i++)
            {
                string nombreUsuario = RRHH.ValorRandom(true, false);
                string contrasenia = RRHH.ValorRandom(false, false);
                string tipoUsuario = RRHH.ValorRandom(false, true);
                Usuario usuario = new(nombreUsuario, contrasenia, tipoUsuario);
                lista.Add(usuario);
            }
            return lista;
        }

        public List<Usuario> ListaUsuarios { get { return listaUsuarios; } set {; } }
    }
}
