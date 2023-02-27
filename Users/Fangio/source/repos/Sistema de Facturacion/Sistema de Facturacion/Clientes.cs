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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        Cliente cliente = new Cliente();
        Utiles utiles = new Utiles();

        private void cbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            switch (cbBuscarPor.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = cliente.SelectClienteByIdCliente(txtBuscar.Text);
                    break;
                case 1:
                    dataGridView1.DataSource = cliente.SelectClienteByRnc(txtBuscar.Text);
                    break;
                case 2:
                    dataGridView1.DataSource = cliente.SelectClienteByEmpresa(txtBuscar.Text);
                    break;
                case 3:
                    dataGridView1.DataSource = cliente.SelectClienteByPersona(txtBuscar.Text);
                    break;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            switch (cbBuscarPor.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = cliente.SelectClienteByIdCliente(txtBuscar.Text);
                    break;
                case 1:
                    dataGridView1.DataSource = cliente.SelectClienteByRnc(txtBuscar.Text);
                    break;
                case 2:
                    dataGridView1.DataSource = cliente.SelectClienteByEmpresa(txtBuscar.Text);
                    break;
                case 3:
                    dataGridView1.DataSource = cliente.SelectClienteByPersona(txtBuscar.Text);
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtIdCliente.Text = "-";
            if (utiles.RevisarTextBox(panel3))
            {
                txtBuscar.Clear();
                cliente.InsertarCliente(txtPersona.Text, txtRnc.Text, txtEmpresa.Text, txtTelefono.Text, txtDireccion.Text);
                dataGridView1.DataSource = cliente.SelectClienteByIdCliente(txtBuscar.Text);
                utiles.limpiarTextBox(panel3);
                MessageBox.Show("Cliente Insertado");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (utiles.RevisarTextBox(panel3))
            {
                txtBuscar.Clear();
                cliente.UpdateCliente(txtIdCliente.Text, txtPersona.Text, txtRnc.Text, txtEmpresa.Text, txtTelefono.Text, txtDireccion.Text);
                dataGridView1.DataSource = cliente.SelectClienteByIdCliente(txtBuscar.Text);
                utiles.limpiarTextBox(panel3);
                MessageBox.Show("Cliente Actualizado");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (utiles.RevisarTextBox(panel3))
            {
                txtBuscar.Clear();
                if (MessageBox.Show("Seguro quiere eliminar esta fila", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtBuscar.Clear();
                    cliente.DeleteCliente(txtIdCliente.Text);
                    dataGridView1.DataSource = cliente.SelectClienteByIdCliente(txtBuscar.Text);
                    utiles.limpiarTextBox(panel3);
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                txtIdCliente.Text = selectedRow.Cells[0].Value.ToString();
                txtPersona.Text = selectedRow.Cells[1].Value.ToString();
                txtRnc.Text = selectedRow.Cells[2].Value.ToString();
                txtEmpresa.Text = selectedRow.Cells[3].Value.ToString();
                txtTelefono.Text = selectedRow.Cells[4].Value.ToString();
                txtDireccion.Text = selectedRow.Cells[5].Value.ToString();
            }

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            cbBuscarPor.SelectedIndex = 0;
            dataGridView1.DataSource = cliente.SelectClienteByIdCliente(txtBuscar.Text);
        }
    }
}
