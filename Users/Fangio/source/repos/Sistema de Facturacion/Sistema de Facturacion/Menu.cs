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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        public string usuario { get; set; }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.Show();
        }

        private void pbClientes_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.usuario = usuario;
            producto.Show();
        }

        private void pbProductos_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.Show();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            Facturacion factura = new Facturacion();
            factura.Show();
        }

        private void pbFactura_Click(object sender, EventArgs e)
        {
            Facturacion factura = new Facturacion();
            factura.Show();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Login login = new Login();
            login.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            lbUsuario.Text = usuario;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.Show();
        }

        private void pbInventario_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.Show();
        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            Reporte_de_ingreso reporte = new Reporte_de_ingreso();
            reporte.Show();
        }

        private void pbIngresos_Click(object sender, EventArgs e)
        {
            Reporte_de_ingreso reporte = new Reporte_de_ingreso();
            reporte.Show();
        }
    }
}
