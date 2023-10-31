using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Boleta : Administracion
    {
        private string nombre;
        private string cantidad;
        private string papelNecesario;
        private string tintaNecesaria;
        private string troquelNecesario;
        private string encuadernacionNecesario;
        private Dictionary<string, string> dictInfo = new Dictionary<string, string>();

        public Boleta()
        {
            nombre = "Boleta";
            cantidad = ValorRandomProducto(true);
            papelNecesario = ValorRandomProducto(true);
            tintaNecesaria = ValorRandomProducto(true);
            troquelNecesario = "0";
            encuadernacionNecesario = "0";
            dictInfo.Add("Info", "");
        }

        /// <summary>
        /// Concatena separados por '-' las propiedades de la clase.
        /// </summary>
        /// <param name="cantPapel"></param>
        /// <param name="cantTroquel"></param>
        /// <param name="cantEncu"></param>
        /// <returns>Retorna un diccionario con clave='Info' y valor='Propiedades de la clase separados por -'</returns>
        public override Dictionary<string, string> MostrarInfoPedido(int cantPapel, int cantTroquel, int cantEncu)
        {
            dictInfo["Info"] = Nombre + "-" + Cantidad + "-" + PapelNecesario + "-" + TintaNecesaria + "-" + TroquelNecesario + "-" + EncuadernacionNecesario;
            return dictInfo;
        }

        public string Nombre { get { return nombre; } }
        public string Cantidad { get { return cantidad; } }
        public string PapelNecesario { get { return papelNecesario; } }
        public string TintaNecesaria { get { return tintaNecesaria; } }
        public string TroquelNecesario { get { return troquelNecesario; } }
        public string EncuadernacionNecesario { get { return encuadernacionNecesario; } }
    }
}
