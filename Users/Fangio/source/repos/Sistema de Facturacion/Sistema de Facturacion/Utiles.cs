using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Facturacion
{
    class Utiles
    {
        public void limpiarTextBox(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
        }

        public bool RevisarTextBox(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox && control.Text == "")
                {
                    MessageBox.Show("Porfavor llenar todos los campos");
                    return false;
                }
            }
            return true;
        }

        public bool RevisarTexBoxSinComprobante(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if(control is TextBox && control.Text == "" && control.Name != "txtNcf")
                {
                    MessageBox.Show("Porfavor llenar todos los campos");
                    return false;
                }
            }

            return true;
        }

        public void SoloNumeros(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
