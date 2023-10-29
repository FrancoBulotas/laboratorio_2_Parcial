using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Stock : Administracion
    {
        // son static para que en caso de que se inicialice otro Stock,
        // estos atributos se mantengan iguales (van por clase no por instancia), y evitar que se pisen
        private static Stock stock;

        private static int cantPapel;
        private static int cantTinta;
        private static int cantTroquel;
        private static int cantEncuadernacion;
        private static int valorPapelUni;
        private static int valorTinta;
        private static int valorTroquel;
        private static int valorEncuadernacion;
        private const int CantPapel = 7000;
        private const int CantTinta = 3000;
        private const int CantTroquel = 2000;
        private const int CantEncuadernacion = 2200;
             
        private Stock()
        {
            cantPapel = CantPapel;
            cantTinta = CantTinta;
            cantTroquel = CantTroquel;
            cantEncuadernacion = CantEncuadernacion;
            valorPapelUni = 60;
            valorTinta = 80;
            valorTroquel = 150;
            valorEncuadernacion = 65;
        }

        /// <summary>
        /// Se encarga de devolver la cantidad de insumo disponible.
        /// </summary>
        /// <param name="form"></param>

        public string ConsultarCantidadInsumo(string insumo)
        { 
            if (insumo == "papel") { return Papel.ToString(); }
            else if (insumo == "tinta") { return Tinta.ToString(); }
            else if (insumo == "troquel") { return Troquel.ToString(); }
            else if (insumo == "encuadernacion") { return Encuadernacion.ToString(); }
            else { return ""; }
        }

        /// <summary>
        /// Monitorea el stock, en caso de haber poco, retorna el indice de la fila que tiene poco y el indice de que color 
        /// tiene que ser pintado (1 en caso de ser rojo, 0 en caso de ser blanco), si hay suficiente retorna -1 en ambos valores.
        /// </summary>
        /// <param name="form"></param>
        public ArrayList ControlStock(string insumo)
        {
            ArrayList valores = new ArrayList();

            if (insumo == "papel")
            {
                if (Papel < CantPapel * 0.2)
                {
                    valores.Add(0);
                    valores.Add(1);
                    return valores;
                }
                if (Papel >= CantPapel * 0.2)
                {
                    valores.Add(0);
                    valores.Add(0);
                    return valores;
                }
            }
            if (insumo == "tinta")
            {
                if (Tinta < CantTinta * 0.2)
                {
                    valores.Add(1);
                    valores.Add(1);
                    return valores;
                }
                if (Tinta >= CantTinta * 0.2)
                {
                    valores.Add(1);
                    valores.Add(0);
                    return valores;
                }
            }
            if (insumo == "troquel")
            {
                if (Troquel < CantTroquel * 0.2)
                {
                    valores.Add(2);
                    valores.Add(1);
                    return valores;
                }
                if (Troquel >= CantTroquel * 0.2)
                {
                    valores.Add(2);
                    valores.Add(0);
                    return valores;
                }
            }
            if (insumo == "encuadernacion")
            {
                if (Encuadernacion < CantEncuadernacion * 0.2)
                {
                    valores.Add(3);
                    valores.Add(1);
                    return valores;
                }
                if (Encuadernacion >= CantEncuadernacion * 0.2)
                {
                    valores.Add(3);
                    valores.Add(0);
                    return valores;
                }
            }
            valores.Add(-1);
            valores.Add(-1);
            return valores;
        }

        /// <summary>
        /// Se encarga de realizar la compra en el mercado y agregarla al stock.
        /// </summary>
        /// <param name="form">Instancia del Frm del supervisor.</param>
        /// <param name="stock">Instancia del Stock.</param>
        public Dictionary<string, int> BotonComprarStock(string papelIngresadoStr, string tintaIngresadaStr, string troquelIngresadoStr, string encuIngresadoStr, Stock stock)
        {
            Dictionary<string, int> materiales = new Dictionary<string, int>();

            bool papelConvertido = int.TryParse(papelIngresadoStr, out int papelIngresado);
            bool tintaConvertida = int.TryParse(tintaIngresadaStr, out int tintaIngresada);
            bool troquelConvertido = int.TryParse(troquelIngresadoStr, out int troquelIngresado);
            bool encuConvertido = int.TryParse(encuIngresadoStr, out int encuIngresado);

            if ((papelIngresadoStr != string.Empty ||
                tintaIngresadaStr != string.Empty ||
                troquelIngresadoStr != string.Empty ||
                encuIngresadoStr != string.Empty) &&
                (papelConvertido && tintaConvertida && troquelConvertido && encuConvertido) &&
                (papelIngresado >= 0 && tintaIngresada >= 0 && troquelIngresado >= 0 && encuIngresado >= 0))
            {
                materiales.Add("Papel", papelIngresado);
                materiales.Add("Tinta", tintaIngresada);
                materiales.Add("Troquel", troquelIngresado);
                materiales.Add("Encuadernacion", encuIngresado);

                return materiales;
            }
            else
            {
                return materiales;
            }
        }

        public int Papel { get { return cantPapel; } set { cantPapel += value; } }
        public int Tinta { get { return cantTinta; } set { cantTinta += value; } }
        public int Troquel { get { return cantTroquel; } set { cantTroquel += value; } }
        public int Encuadernacion { get { return cantEncuadernacion; } set { cantEncuadernacion += value; } }
        public int PrecioPapelUni { get { return valorPapelUni; } }
        public int PrecioTintaUni { get { return valorTinta; } }
        public int PrecioTroquelUni { get { return valorTroquel; } }
        public int PrecioEncuadernacionUni { get { return valorEncuadernacion; } }

        public static Stock InstanciaStock
        {
            get
            {
                if (stock == null)
                {
                    stock = new Stock();
                }
                return stock;
            }
        }
    }
}
