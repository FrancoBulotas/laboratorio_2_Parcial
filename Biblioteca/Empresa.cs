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

        /// <summary>
        /// Se encarga de generar una lista de usuarios con datos random
        /// </summary>
        /// <returns>Retorna la lista</returns>
        private static List<Usuario> GenerarListaUsuarios()
        {
            List<Usuario>? lista = new();
            for(int i = 0; i <= 20; i++)
            {
                string nombreUsuario = Administracion.ValorRandomUsuario(true, false);
                string contrasenia = Administracion.ValorRandomUsuario(false, false);
                string tipoUsuario = Administracion.ValorRandomUsuario(false, true);
                Usuario usuario = new(nombreUsuario, contrasenia, tipoUsuario);
                lista.Add(usuario);
            }
            return lista;
        }

        //public abstract void ControlProduccion();


        public List<Usuario> ListaUsuarios { get { return listaUsuarios; } set {; } }
    }
}
