using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuario
    {
        public string nombreUsuario;
        public string contrasenia;
        public string tipoUsuario;
        public int cantidadTrabajosRealizados = 0;
        //public List<Usuario> listaUsuarios;

        public Usuario(string nombreUsuario, string contrasenia, string tipoUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.contrasenia = contrasenia;
            this.tipoUsuario = tipoUsuario;
            //listaUsuarios = ObtenerListaUsuarios();
        }

        public int TrabajosRealizados{ get { return cantidadTrabajosRealizados; } set { cantidadTrabajosRealizados += value; } }
    }
}
