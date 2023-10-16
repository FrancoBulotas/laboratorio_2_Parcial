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
    public class Stock : Empresa
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

        public Stock()
        {
            cantPapel = 7000;
            cantTinta = 3000;
            cantTroquel = 2000;
            cantEncuadernacion = 6000;
            presupuesto = 500000;
            valorPapelUni = 600;
            valorTinta = 800;
            valorTroquel = 1500;
            valorEncuadernacion = 650;
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
