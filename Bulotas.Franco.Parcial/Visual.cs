using Biblioteca;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frms
{
    public static class Visual
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void CargarStock(DataGridView dg, Stock stock)
        {
            dg.Rows[0].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("papel");
            dg.Rows[1].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("tinta");
            dg.Rows[2].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("troquel");
            dg.Rows[3].Cells["Cantidad2"].Value = stock.ConsultarCantidadInsumo("encuadernacion");

            //ControlStock();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        //internal static void CargarStock(FrmMenuSupervisor form)
        //{
        //    form.dataGridView2.Rows[0].Cells["Cantidad2"].Value = form.stock.ConsultarCantidadInsumo("papel");
        //    form.dataGridView2.Rows[1].Cells["Cantidad2"].Value = form.stock.ConsultarCantidadInsumo("tinta");
        //    form.dataGridView2.Rows[2].Cells["Cantidad2"].Value = form.stock.ConsultarCantidadInsumo("troquel");
        //    form.dataGridView2.Rows[3].Cells["Cantidad2"].Value = form.stock.ConsultarCantidadInsumo("encuadernacion");
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal static void ControlStock(Stock stock, DataGridView dg, string insumo)
        {
            ArrayList arrayControlStock = new ArrayList();
            arrayControlStock = stock.ControlStock(insumo);

            if ((int)arrayControlStock[0] >= 0)
            {
                if ((int)arrayControlStock[1] == 1) { dg.Rows[(int)arrayControlStock[0]].DefaultCellStyle.BackColor = Color.Red; }

                else if ((int)arrayControlStock[1] == 0) { dg.Rows[(int)arrayControlStock[0]].DefaultCellStyle.BackColor = Color.White; }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //internal static void ControlStock(FrmMenuSupervisor form, string insumo)
        //{
        //    form.arrayControlStock = form.stock.ControlStock(insumo);

        //    if ((int)form.arrayControlStock[0] >= 0)
        //    {
        //        if ((int)form.arrayControlStock[1] == 1) { form.dataGridView2.Rows[(int)form.arrayControlStock[0]].DefaultCellStyle.BackColor = Color.Red; }

        //        else { form.dataGridView2.Rows[(int)form.arrayControlStock[0]].DefaultCellStyle.BackColor = Color.White; }
        //    }
        //}
    }
}
