using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Facturacion
{
    public partial class Reporte_de_ingreso : Form
    {
        public Reporte_de_ingreso()
        {
            InitializeComponent();
        }
        Ingresos ingresos = new Ingresos();
        private void Reporte_de_ingreso_Load(object sender, EventArgs e)
        {
            decimal subtotal = 0;
            decimal total = 0;
            decimal itebis = 0;

            dataGridView1.DataSource = ingresos.SelectIngresos();


            if ( dataGridView1.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                   
                    if(row.Cells[0].Value!= null)
                    {
                        subtotal += Decimal.Parse(row.Cells[4].Value.ToString());
                        itebis += Decimal.Parse(row.Cells[5].Value.ToString());
                        total += Decimal.Parse(row.Cells[6].Value.ToString());
                    }
                    else
                    {
                        break;
                    }
                  
                }

                txtSubtotal.Text = subtotal.ToString("N2");
                txtItebis.Text = itebis.ToString("N2");
                txtTotal.Text = total.ToString("N2");


            }
            else
            {
                txtSubtotal.Text = "0.00";
                txtItebis.Text = "0.00";
                txtTotal.Text = "0.00";
            }
        }

        private void dtpFecha1_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dtpFecha1.Value.ToString());
            dataGridView1.DataSource = ingresos.IngresosPorFecha(dtpFecha1.Value.Date, dtpFecha2.Value.Date);
            decimal subtotal = 0;
            decimal total = 0;
            decimal itebis = 0;
            if (dataGridView1.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (row.Cells[0].Value != null)
                    {
                        subtotal += Decimal.Parse(row.Cells[4].Value.ToString());
                        itebis += Decimal.Parse(row.Cells[5].Value.ToString());
                        total += Decimal.Parse(row.Cells[6].Value.ToString());
                    }
                    else
                    {
                        break;
                    }

                }

                txtSubtotal.Text = subtotal.ToString("N2");
                txtItebis.Text = itebis.ToString("N2");
                txtTotal.Text = total.ToString("N2");


            }
            else
            {
                txtSubtotal.Text = "0.00";
                txtItebis.Text = "0.00";
                txtTotal.Text = "0.00";
            }

        }

        private void dtpFecha2_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ingresos.IngresosPorFecha(dtpFecha1.Value.Date, dtpFecha2.Value.Date);

            decimal subtotal = 0;
            decimal total = 0;
            decimal itebis = 0;
            if (dataGridView1.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (row.Cells[0].Value != null)
                    {
                        subtotal += Decimal.Parse(row.Cells[4].Value.ToString());
                        itebis += Decimal.Parse(row.Cells[5].Value.ToString());
                        total += Decimal.Parse(row.Cells[6].Value.ToString());
                    }
                    else
                    {
                        break;
                    }

                }

                txtSubtotal.Text = subtotal.ToString("N2");
                txtItebis.Text = itebis.ToString("N2");
                txtTotal.Text = total.ToString("N2");


            }
            else
            {
                txtSubtotal.Text ="0.00";
                txtItebis.Text = "0.00";
                txtTotal.Text = "0.00";
            }
        }
    }
}
