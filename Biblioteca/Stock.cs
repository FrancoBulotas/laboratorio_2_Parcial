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

        public Stock()
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

        //internal void CargarStock(FrmMenuSupervisor form)
        //{
        //    form.nombreLogueado.Text = listaUsuarios[form.indexUsuarioLogueado].NombreUsuario;

        //    form.dataGridView2.Rows[0].Cells["Cantidad2"].Value = Papel.ToString();
        //    form.dataGridView2.Rows[1].Cells["Cantidad2"].Value = Tinta.ToString();
        //    form.dataGridView2.Rows[2].Cells["Cantidad2"].Value = Troquel.ToString();
        //    form.dataGridView2.Rows[3].Cells["Cantidad2"].Value = Encuadernacion.ToString();
        //}

        /// <summary>
        /// Se encarga de cargar el stock al Frm del operario
        /// </summary>
        /// <param name="form"></param>
        //internal void CargarStock(FrmMenuOperario form)
        //{
        //    form.dataGridView2.Rows[0].Cells["Cantidad2"].Value = Papel.ToString();
        //    form.dataGridView2.Rows[1].Cells["Cantidad2"].Value = Tinta.ToString();
        //    form.dataGridView2.Rows[2].Cells["Cantidad2"].Value = Troquel.ToString();
        //    form.dataGridView2.Rows[3].Cells["Cantidad2"].Value = Encuadernacion.ToString();
        //}

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


            //if (Papel < CantPapel*0.2) { form.dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.Red; }
            //else { form.dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.White; }

            //if (Tinta < CantTinta*0.2) { form.dataGridView2.Rows[1].DefaultCellStyle.BackColor = Color.Red; }
            //else { form.dataGridView2.Rows[1].DefaultCellStyle.BackColor = Color.White; }

            //if (Troquel < CantTroquel* 0.2) { form.dataGridView2.Rows[2].DefaultCellStyle.BackColor = Color.Red; }
            //else { form.dataGridView2.Rows[2].DefaultCellStyle.BackColor = Color.White; }

            //if (Encuadernacion < CantEncuadernacion * 0.1) { form.dataGridView2.Rows[3].DefaultCellStyle.BackColor = Color.Red; }
            //else { form.dataGridView2.Rows[3].DefaultCellStyle.BackColor = Color.White; }
        }

        /// <summary>
        /// Controla que al quedar seleccionada una fila, y el usuario se vaya del menu, se reincorpore lo descontado del stock.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="filasPedidos"></param>
        //internal void ControlStock(FrmMenuOperario form, DataGridViewRow filasPedidos)
        //{
        //    if (filasPedidos != null)
        //    {
        //        if (filasPedidos.DefaultCellStyle.BackColor == Color.Green)
        //        {
        //            try
        //            {
        //                form.stock.Papel = +Convert.ToInt32(filasPedidos.Cells["Papel"].Value);
        //                form.stock.Tinta = +Convert.ToInt32(filasPedidos.Cells["Tinta"].Value);
        //                form.stock.Troquel = +Convert.ToInt32(filasPedidos.Cells["Troquel"].Value);
        //                form.stock.Encuadernacion = +Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value);
        //                CargarStock(form);
        //            }
        //            catch (System.ArgumentException)
        //            {

        //            }
        //    }
        //    }
        //}

        public int Papel { get { return cantPapel; } set { cantPapel += value; } }
        public int Tinta { get { return cantTinta; } set { cantTinta += value; } }
        public int Troquel { get { return cantTroquel; } set { cantTroquel += value; } }
        public int Encuadernacion { get { return cantEncuadernacion; } set { cantEncuadernacion += value; } }
        public int PrecioPapelUni { get { return valorPapelUni; } }
        public int PrecioTintaUni { get { return valorTinta; } }
        public int PrecioTroquelUni { get { return valorTroquel; } }
        public int PrecioEncuadernacionUni { get { return valorEncuadernacion; } }
    }
}
