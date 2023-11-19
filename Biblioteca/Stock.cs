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
        private const int pocoStock = 2000;
        private Dictionary<string, int> dictCantidadStock;

        private Stock()
        {
            dictCantidadStock = StockDAO.Modificar(0,0,0,0);           
        }

        /// <summary>
        /// Se encarga de consultar la cantidad de insumo disponible.
        /// </summary>
        /// <param name="form"></param>
        /// <returns>Retorna un string con la cantidad de insumo solicitado</returns>
        public string ConsultarCantidadInsumo(string insumo)
        { 
            if (insumo == "papel") { return CantStock["Papel"].ToString(); }
            else if (insumo == "tinta") { return CantStock["Tinta"].ToString(); }
            else if (insumo == "troquel") { return CantStock["Troquel"].ToString(); }
            else if (insumo == "encuadernacion") { return CantStock["Encuadernacion"].ToString(); }
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
                if (CantStock["Papel"] < pocoStock)
                {
                    valores.Add(0);
                    valores.Add(1);
                    return valores;
                }
                if (CantStock["Papel"] >= pocoStock)
                {
                    valores.Add(0);
                    valores.Add(0);
                    return valores;
                }
            }
            if (insumo == "tinta")
            {
                if (CantStock["Tinta"] < pocoStock)
                {
                    valores.Add(1);
                    valores.Add(1);
                    return valores;
                }
                if (CantStock["Tinta"] >= pocoStock)
                {
                    valores.Add(1);
                    valores.Add(0);
                    return valores;
                }
            }
            if (insumo == "troquel")
            {
                if (CantStock["Troquel"] < pocoStock)
                {
                    valores.Add(2);
                    valores.Add(1);
                    return valores;
                }
                if (CantStock["Troquel"] >= pocoStock)
                {
                    valores.Add(2);
                    valores.Add(0);
                    return valores;
                }
            }
            if (insumo == "encuadernacion")
            {
                if (CantStock["Encuadernacion"] < pocoStock)
                {
                    valores.Add(3);
                    valores.Add(1);
                    return valores;
                }
                if (CantStock["Encuadernacion"] >= pocoStock)
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
        /// <returns>True en caso de que se realize la modificacion, false en caso de fallar.</returns>
        public bool BotonComprarStock(string papelIngresadoStr, string tintaIngresadaStr, string troquelIngresadoStr, string encuIngresadoStr)
        {
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

                dictCantidadStock = StockDAO.Modificar(papelIngresado, tintaIngresada, troquelIngresado, encuIngresado);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<string, int> CantStock { get { return dictCantidadStock; } set { dictCantidadStock = value; } }

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
