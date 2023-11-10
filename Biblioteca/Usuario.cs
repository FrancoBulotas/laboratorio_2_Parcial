using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuario
    {
        private int id;
        private string nombreUsuario;
        private string contrasenia;
        private string tipoUsuario;
        private int cantidadTrabajosRealizados;

        public Usuario(int id, string nombreUsuario, string contrasenia, string tipoUsuario, int cantidadTrabajosRealizados)
        {
            this.id = id;
            this.nombreUsuario = nombreUsuario;
            this.contrasenia = contrasenia;
            this.tipoUsuario = tipoUsuario;
            this.cantidadTrabajosRealizados = cantidadTrabajosRealizados;
        }

        public int ID { get { return id; } }   
        public string NombreUsuario { get { return nombreUsuario; } }
        public string Contrasenia { get { return contrasenia; } }
        public string TipoUsuario { get { return tipoUsuario; } }
        public int TrabajosRealizados { get { return cantidadTrabajosRealizados; } set { cantidadTrabajosRealizados += value; } }
    }
}
