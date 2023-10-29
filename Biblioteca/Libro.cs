﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Libro : Administracion
    {
        private string nombre;
        private string cantidad;
        private string tipo;
        private string papelNecesario;
        private string tintaNecesaria;
        private string troquelNecesario;
        private string encuadernacionNecesario;
        private Dictionary<string, string> dictInfo = new Dictionary<string, string>();

        public Libro()
        {
            this.tipo = ValorRandomProducto(false);
            nombre = "Libro " + tipo;
            cantidad = ValorRandomProducto(true);
            papelNecesario = ValorRandomProducto(true);
            tintaNecesaria = ValorRandomProducto(true);
            troquelNecesario = ValorRandomProducto(true);
            encuadernacionNecesario = "0";
            dictInfo.Add("Info", "");
        }

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