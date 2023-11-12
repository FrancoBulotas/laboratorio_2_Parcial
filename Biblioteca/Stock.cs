using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca
{
    public class Stock 
    {
        private static Stock stock;
        //private static int cantPapel;
        //private static int cantTinta;
        //private static int cantTroquel;
        //private static int cantEncuadernacion;
        private const int pocoStock = 2000;

        private Stock()
        {
            //cantPapel = StockDAO.Leer()["Papel"];
            //cantTinta = StockDAO.Leer()["Tinta"];
            //cantTroquel = StockDAO.Leer()["Troquel"];
            //cantEncuadernacion = StockDAO.Leer()["Encuadernacion"];            
        }

        /// <summary>
        /// Se encarga de consultar la cantidad de insumo disponible.
        /// </summary>
        /// <param name="form"></param>
        /// <returns>Retorna un string con la cantidad de insumo solicitado</returns>
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
        /// <returns>Un ArrayList con dos numeros enteros. </returns>
        public ArrayList ControlStock(string insumo)
        {
            ArrayList valores = new ArrayList();

            if (insumo == "papel")
            {
                if (Papel < pocoStock)
                {
                    valores.Add(0);
                    valores.Add(1);
                    return valores;
                }
                if (Papel >= pocoStock)
                {
                    valores.Add(0);
                    valores.Add(0);
                    return valores;
                }
            }
            if (insumo == "tinta")
            {
                if (Tinta < pocoStock)
                {
                    valores.Add(1);
                    valores.Add(1);
                    return valores;
                }
                if (Tinta >= pocoStock)
                {
                    valores.Add(1);
                    valores.Add(0);
                    return valores;
                }
            }
            if (insumo == "troquel")
            {
                if (Troquel < pocoStock)
                {
                    valores.Add(2);
                    valores.Add(1);
                    return valores;
                }
                if (Troquel >= pocoStock)
                {
                    valores.Add(2);
                    valores.Add(0);
                    return valores;
                }
            }
            if (insumo == "encuadernacion")
            {
                if (Encuadernacion < pocoStock)
                {
                    valores.Add(3);
                    valores.Add(1);
                    return valores;
                }
                if (Encuadernacion >= pocoStock)
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
        /// Se encarga de validar una compra, que los datos pasados como parametro sean validos.
        /// </summary>
        /// <param name="papelIngresadoStr"></param>
        /// <param name="tintaIngresadaStr"></param>
        /// <param name="troquelIngresadoStr"></param>
        /// <param name="encuIngresadoStr"></param>
        /// <param name="stock"></param>
        /// <returns>Un Dictionary vacio en caso de fallar la compra, y con los elementos a comprar en caso de ser correcta.</returns>
        public bool BotonComprarStock(string papelIngresadoStr, string tintaIngresadaStr, string troquelIngresadoStr, string encuIngresadoStr, Stock stock)
        {
            //Dictionary<string, int> materiales = new Dictionary<string, int>();
            bool agregado = false;

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
                //materiales.Add("Papel", papelIngresado);
                //materiales.Add("Tinta", tintaIngresada);
                //materiales.Add("Troquel", troquelIngresado);
                //materiales.Add("Encuadernacion", encuIngresado);

                StockDAO.Modificar(papelIngresado, "papel");
                StockDAO.Modificar(tintaIngresada, "tinta");
                StockDAO.Modificar(troquelIngresado, "troquel");
                StockDAO.Modificar(encuIngresado, "encuadernacion");
                
                agregado = true;
                return agregado;
            }
            else
            {
                return agregado;
            }
        }

        public int Papel { get { return StockDAO.Leer()["Papel"]; } set { StockDAO.Modificar(value, "papel"); } }
        public int Tinta { get { return StockDAO.Leer()["Tinta"];  } set { StockDAO.Modificar(value, "tinta"); } }
        public int Troquel { get { return StockDAO.Leer()["Troquel"]; } set { StockDAO.Modificar(value, "troquel"); } }
        public int Encuadernacion { get { return StockDAO.Leer()["Encuadernacion"]; } set { StockDAO.Modificar(value, "encuadernacion"); } }
        //public int Papel { get { return cantPapel; } set { cantPapel += value; } }
        //public int Tinta { get { return cantTinta; } set { cantTinta += value; } }
        //public int Troquel { get { return cantTroquel; } set { cantTroquel += value; } }
        //public int Encuadernacion { get { return cantEncuadernacion; } set { cantEncuadernacion += value; } }

        /// <summary>
        /// Para el singleton, solo se puede generar una vez.
        /// </summary>
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
