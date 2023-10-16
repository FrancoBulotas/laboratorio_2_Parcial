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
        private const int CantEncuadernacion = 6000;

        public Stock()
        {
            cantPapel = CantPapel;
            cantTinta = CantTinta;
            cantTroquel = CantTroquel;
            cantEncuadernacion = CantEncuadernacion;
            presupuesto = 500000;
            valorPapelUni = 60;
            valorTinta = 80;
            valorTroquel = 150;
            valorEncuadernacion = 65;
        }

        internal void CargarStock(FrmMenuSupervisor form)
        {
            form.label3.Text = Papel.ToString() + " Uni.";
            form.label4.Text = Tinta.ToString() + " L.";
            form.label6.Text = Troquel.ToString() + " Uni.";
            form.label8.Text = Encuadernacion.ToString() + " Uni.";
            form.nombreLogueado.Text = listaUsuarios[form.indexUsuarioLogueado].nombreUsuario;
            form.labelPresupuesto.Text = "$ " + PresupuestoTotal.ToString();
        }

        internal void CargarStock(FrmMenuOperario form)
        {
            form.label3.Text = Papel.ToString() + " Uni.";
            form.label4.Text = Tinta.ToString() + " L.";
            form.label6.Text = Troquel.ToString() + " Uni.";
            form.label8.Text = Encuadernacion.ToString() + " Uni.";
        }

        internal void ControlStock(FrmMenuOperario form)
        {
            if (Papel < CantPapel*0.2)
            {
                form.label3.BackColor = Color.Red;
            }
            if (Tinta < CantTinta*0.2)
            {
                form.label4.BackColor = Color.Red;
            }
            if (Troquel < CantTroquel* 0.2)
            {
                form.label6.BackColor = Color.Red;
            }
            if (Encuadernacion < CantEncuadernacion * 0.1)
            {
                form.label8.BackColor = Color.Red;
            }
        }
        
        internal void ControlStock(FrmMenuOperario form, DataGridViewRow filasPedidos)
        {
            form.stock.Papel = +Convert.ToInt32(filasPedidos.Cells["Papel"].Value);
            form.stock.Tinta = +Convert.ToInt32(filasPedidos.Cells["Tinta"].Value);
            form.stock.Troquel = +Convert.ToInt32(filasPedidos.Cells["Troquel"].Value);
            form.stock.Encuadernacion = +Convert.ToInt32(filasPedidos.Cells["Encuadernacion"].Value);
            CargarStock(form);
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
