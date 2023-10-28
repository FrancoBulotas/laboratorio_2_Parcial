using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuario
    {
        private string nombreUsuario;
        private string contrasenia;
        private string tipoUsuario;
        private int cantidadTrabajosRealizados = 0;

        public Usuario(string nombreUsuario, string contrasenia, string tipoUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.contrasenia = contrasenia;
            this.tipoUsuario = tipoUsuario;
        }

        public string NombreUsuario { get { return nombreUsuario; } }
        public string Contrasenia { get { return contrasenia; } }
        public string TipoUsuario { get { return tipoUsuario; } }
        public int TrabajosRealizados{ get { return cantidadTrabajosRealizados; } set { cantidadTrabajosRealizados += value; } }
    }
}
