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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        public string usuario { get; set;}
        Producto producto = new Producto();
        Utiles utiles = new Utiles();
        private void cbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            switch (cbBuscarPor.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = producto.SelectProductoByIdProducto(txtBuscar.Text);
                    break;
                case 1:
                    dataGridView1.DataSource = producto.SelectProductoByDescripcion(txtBuscar.Text);
                    break;
                case 2:
                    dataGridView1.DataSource = producto.SelectProductoByNombreProducto(txtBuscar.Text);
                    break;
                case 3:
                    dataGridView1.DataSource = producto.SelectProductoByModelo(txtBuscar.Text);
                    break;
                case 4:
                    dataGridView1.DataSource = producto.SelectProductoByMarca(txtBuscar.Text);
                    break;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            switch (cbBuscarPor.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = producto.SelectProductoByIdProducto(txtBuscar.Text);
                    break;
                case 1:
                    dataGridView1.DataSource = producto.SelectProductoByDescripcion(txtBuscar.Text);
                    break;
                case 2:
                    dataGridView1.DataSource = producto.SelectProductoByNombreProducto(txtBuscar.Text);
                    break;
                case 3:
                    dataGridView1.DataSource = producto.SelectProductoByModelo(txtBuscar.Text);
                    break;
                case 4:
                    dataGridView1.DataSource = producto.SelectProductoByMarca(txtBuscar.Text);
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtIdProducto.Text = "-";
            txtPrecio.Text = Double.Parse(txtPrecio.Text).ToString("N2");
            if (utiles.RevisarTextBox(panel2))
            {

                producto.InsertarProducto(txtNombre.Text, txtModelo.Text, txtMarca.Text, txtDescripcion.Text, txtPrecio.Text, txtDistribuidor.Text, txtContacto.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, Convert.ToInt32(cbUnidad.SelectedValue), txtCantidad.Text);
                txtBuscar.Clear();
                utiles.limpiarTextBox(panel2);
                dataGridView1.DataSource = producto.SelectProductoByIdProducto(txtBuscar.Text);
                
                MessageBox.Show("Producto Insertado");


            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtPrecio.Text = Double.Parse(txtPrecio.Text).ToString("N2");
            if (utiles.RevisarTextBox(panel2))
            {
                producto.UpdateProducto(txtIdProducto.Text, txtNombre.Text, txtModelo.Text, txtMarca.Text, txtDescripcion.Text, txtPrecio.Text, txtDistribuidor.Text, txtContacto.Text, txtTelefono.Text, txtDireccion.Text, txtCorreo.Text, Convert.ToInt32(cbUnidad.SelectedValue),txtCantidad.Text);
                txtBuscar.Clear();
               
                utiles.limpiarTextBox(panel2);
                dataGridView1.DataSource = producto.SelectProductoByIdProducto(txtBuscar.Text);
                MessageBox.Show("Producto Actualizado");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (utiles.RevisarTextBox(panel2))
            {
                txtBuscar.Clear();
                if (MessageBox.Show("Seguro quiere eliminar esta fila", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    producto.DeleteProducto(txtIdProducto.Text);
                    txtBuscar.Clear();
                    utiles.limpiarTextBox(panel2);
                    dataGridView1.DataSource = producto.SelectProductoByIdProducto(txtBuscar.Text);
                }

            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            cbBuscarPor.SelectedIndex = 0;
            dataGridView1.DataSource = producto.SelectProductoByIdProducto(txtBuscar.Text);
           
            cbUnidad.DataSource = producto.unidades();
            cbUnidad.ValueMember = "idUnidad";
            cbUnidad.DisplayMember = "ud";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                txtIdProducto.Text = selectedRow.Cells[0].Value.ToString();
                txtNombre.Text = selectedRow.Cells[1].Value.ToString();
                txtModelo.Text = selectedRow.Cells[2].Value.ToString();
                txtMarca.Text = selectedRow.Cells[3].Value.ToString();
                txtDescripcion.Text = selectedRow.Cells[4].Value.ToString();
                txtPrecio.Text = selectedRow.Cells[5].Value.ToString();
                txtDistribuidor.Text = selectedRow.Cells[6].Value.ToString();
                txtContacto.Text = selectedRow.Cells[7].Value.ToString();
                txtTelefono.Text = selectedRow.Cells[8].Value.ToString();
                txtDireccion.Text = selectedRow.Cells[9].Value.ToString();
                txtCorreo.Text = selectedRow.Cells[10].Value.ToString();
                txtCantidad.Text = selectedRow.Cells[12].Value.ToString();
                cbUnidad.SelectedValue = selectedRow.Cells[11].Value.ToString();
            }
        }

     
    }
}
