using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class DatosForms
    {
        // FrmLogin
        public string login { get; set; }
        public string tPass { get; set; }
        public string tNombre { get; set; }
        public string labelError { get; set; }
        public string botonSalir { get; set; }
        public string label1 { get; set; }
        public string linkLabelHardcodeOp { get; set; }
        public string linkLabelHardcodeSup { get; set; }
        public string linkLabelRegistrarse { get; set; }

        // FrmRegistro
        public string botonCancelar { get; set; }
        public string labelRegistro { get; set; }
        public string tbNombreUsuario { get; set; }
        public string tbContraseña { get; set; }
        public string tbRepContraseña { get; set; }
        public string botonRegistrar { get; set; }
        public string labelErrorRegistro { get; set; }
        public string linkLabelVaciar { get; set; }
        public string checkBoxOperario { get; set; }
        public string linkLabelRandom { get; set; }
        public string checkBoxSupervisor { get; set; }
    }
}
