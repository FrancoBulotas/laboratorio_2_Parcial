using Biblioteca;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frms
{
    public class Stock : Administracion
    {
        // son static para que en caso de que se inicialice otro Stock,
        // estos atributos se mantengan iguales (van por clase no por instancia), y evitar que se pisen
        private static int cantPapel;
        private static int cantTinta;
        private static int cantTroquel;
        private static int cantEncuadernacion;
        private static int presupuesto;
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
            presupuesto = 100000;
            valorPapelUni = 60;
            valorTinta = 80;
            valorTroquel = 150;
            valorEncuadernacion = 65;
        }

        /// <summary>
        /// Se encarga de cargar el stock al Frm del supervisor y actualizar el presupuesto
        /// </summary>
        /// <param name="form"></param>
        internal void CargarStock(FrmMenuSupervisor form)
        {
            form.nombreLogueado.Text = listaUsuarios[form.indexUsuarioLogueado].nombreUsuario;
            form.labelPresupuesto.Text = "$ " + PresupuestoTotal.ToString();

            form.dataGridView2.Rows[0].Cells["Cantidad2"].Value = Papel.ToString();
            form.dataGridView2.Rows[1].Cells["Cantidad2"].Value = Tinta.ToString();
            form.dataGridView2.Rows[2].Cells["Cantidad2"].Value = Troquel.ToString();
            form.dataGridView2.Rows[3].Cells["Cantidad2"].Value = Encuadernacion.ToString();
        }

        /// <summary>
        /// Se encarga de cargar el stock al Frm del operario
        /// </summary>
        /// <param name="form"></param>
        internal void CargarStock(FrmMenuOperario form)
        {
            form.dataGridView2.Rows[0].Cells["Cantidad2"].Value = Papel.ToString();
            form.dataGridView2.Rows[1].Cells["Cantidad2"].Value = Tinta.ToString();
            form.dataGridView2.Rows[2].Cells["Cantidad2"].Value = Troquel.ToString();
            form.dataGridView2.Rows[3].Cells["Cantidad2"].Value = Encuadernacion.ToString();
        }

        /// <summary>
        /// Monitorea el stock, en caso de haber poco, notifica pintando de color rojo la fila del DataGridView.
        /// </summary>
        /// <param name="form"></param>
        internal void ControlStock(FrmMenuOperario form)
        {            
            if (Papel < CantPapel*0.2) { form.dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.Red; }
            else { form.dataGridView2.Rows[0].DefaultCellStyle.BackColor = Color.White; }

            if (Tinta < CantTinta*0.2) { form.dataGridView2.Rows[1].DefaultCellStyle.BackColor = Color.Red; }
            else { form.dataGridView2.Rows[1].DefaultCellStyle.BackColor = Color.White; }

            if (Troquel < CantTroquel* 0.2) { form.dataGridView2.Rows[2].DefaultCellStyle.BackColor = Color.Red; }
            else { form.dataGridView2.Rows[2].DefaultCellStyle.BackColor = Color.White; }

            if (Encuadernacion < CantEncuadernacion * 0.1) { form.dataGridView2.Rows[3].DefaultCellStyle.BackColor = Color.Red; }
            else { form.dataGridView2.Rows[3].DefaultCellStyle.BackColor = Color.White; }
        }

        /// <summary>
        /// Controla que al quedar seleccionada una fila, y el usuario se vaya del menu, se reincorpore lo descontado del stock.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="filasPedidos"></param>
        internal void ControlStock(FrmMenuOperario form, DataGridViewRow filasPedidos)
        {
            if (filasPedidos != null)
            {
                if (filasPedidos.DefaultCellStyle.BackColor == Color.Green)
                {
                    try
                    {
                        form.stock.Papel = +Convert.ToInt32(filasPedidos.Cells["Papel"].Value);
                        form.stock.Tinta = +Convert.ToInt32(filasPedidos.Cells["Tinta"].Value);
                        form.stock.Troquel = +Convert.ToInt32(filasPedidos.Cells["Troquel"].Value);
                        form.stock.Encuadernacion = +Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value);
                        CargarStock(form);
                    }
                    catch (System.ArgumentException)
                    {

                    }
                }
            }
        }

        public int Papel { get { return cantPapel; } set { cantPapel += value; } }
        public int Tinta { get { return cantTinta; } set { cantTinta += value; } }
        public int Troquel { get { return cantTroquel; } set { cantTroquel += value; } }
        public int Encuadernacion { get { return cantEncuadernacion; } set { cantEncuadernacion += value; } }
        public int PresupuestoTotal { get { return presupuesto; } set { presupuesto += value; } }
        public int PrecioPapelUni { get { return valorPapelUni; } set {; } }
        public int PrecioTintaUni { get { return valorTinta; } set {; } }
        public int PrecioTroquelUni { get { return valorTroquel; } set {; } }
        public int PrecioEncuadernacionUni { get { return valorEncuadernacion; } set {; } }
    }
}
