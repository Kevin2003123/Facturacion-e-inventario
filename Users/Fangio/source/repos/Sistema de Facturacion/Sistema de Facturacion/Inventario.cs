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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }
        inventa inventario = new inventa();
        Producto producto = new Producto();
        private void Inventario_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            
            
            dataGridView1.DataSource= inventario.SelectInventarioByIdProducto("");
            comboBox1.DataSource = producto.SelectProductoByIdProducto("");
            comboBox1.DisplayMember = "idProducto";
            comboBox1.ValueMember = "idProducto";
            comboBox1.SelectedIndex = -1;
            dataGridView1.DataSource = inventario.SelectInventarioByIdProducto("");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
                dataGridView1.DataSource = inventario.SelectInventarioAgotado();
            }
            else
            {

                radioButton2.Checked = true;
                dataGridView1.DataSource = inventario.SelectInventarioExistencia();
                
            }
            */
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = inventario.SelectInventarioByIdProducto(comboBox1.Text);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
               // dataGridView1.DataSource = inventario.SelectInventarioExistencia();
            }
            else
            {

                radioButton1.Checked = true ;
               // dataGridView1.DataSource = inventario.SelectInventarioAgotado();

            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = inventario.SelectInventarioExistencia();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = inventario.SelectInventarioAgotado();
        }
    }
}
