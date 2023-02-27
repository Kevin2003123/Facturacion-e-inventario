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
    public partial class Facturacion : Form
    {
        public Facturacion()
        {
            InitializeComponent();
        }

        Producto producto = new Producto();
        Cliente cliente = new Cliente();
        Utiles utiles = new Utiles();
        Factura factura = new Factura();
        bool control = true;
        DataTable dt = new DataTable();
        int index;
        int index2;
        int indexFactura;
        int indexCliente;
        decimal total;
       

        private void cbBuscarCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCliente.DataSource = cliente.SelectClienteByIdCliente("");
            txtBuscarCliente.Clear();
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {

            switch (cbBuscarCliente.SelectedIndex)
            {
                case 0:
                    dgvCliente.DataSource = cliente.SelectClienteByIdCliente(txtBuscarCliente.Text);
                    break;
                case 1:
                    dgvCliente.DataSource = cliente.SelectClienteByRnc(txtBuscarCliente.Text);
                    break;
                case 2:
                    dgvCliente.DataSource = cliente.SelectClienteByEmpresa(txtBuscarCliente.Text);
                    break;
                case 3:
                    dgvCliente.DataSource = cliente.SelectClienteByPersona(txtBuscarCliente.Text);
                    break;
            }
        }

        private void cbBuscarFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscarFactura.Clear();
            dgvFactura.DataSource = factura.SelectFacturaByIdFactura("");
        }

        private void txtBuscarFactura_TextChanged(object sender, EventArgs e)
        {
            switch (cbBuscarFactura.SelectedIndex)
            {
                case 0:
                    dgvFactura.DataSource = factura.SelectFacturaByIdFactura(txtBuscarFactura.Text);
                    break;
                case 1:
                    dgvFactura.DataSource = factura.SelectFacturaByIdCliente(txtBuscarFactura.Text);
                    break;
                case 2:
                    dgvFactura.DataSource = factura.SelectFacturaByEmpresa(txtBuscarFactura.Text);
                    break;
                case 3:
                    dgvFactura.DataSource = factura.SelectFacturaByPersona(txtBuscarFactura.Text);
                    break;
                case 4:
                    dgvFactura.DataSource = factura.SelectFacturaByNcf(txtBuscarFactura.Text);
                    break;

            }
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexCliente = e.RowIndex;
            if (indexCliente != -1)
            {
                DataGridViewRow selectedRow = dgvCliente.Rows[indexCliente];
                txtRnc.Text = selectedRow.Cells[2].Value.ToString();
                txtCliente.Text = selectedRow.Cells[3].Value.ToString();
            }
        }

        private void dgvFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // control = false;
            indexFactura = e.RowIndex;
            /*
            if (indexFactura != -1)
            {
                
                DataGridViewRow selectedRow = dgvFactura.Rows[indexFactura];
                dgvDescripcion.DataSource = factura.SelectDescripcionFacturaByIdFactura(selectedRow.Cells[0].Value.ToString());
                dgvDescripcion.Columns[0].Visible = false;
                dgvDescripcion.Columns[1].Visible = false;
                dgvDescripcion.Columns[6].Visible = false;
                dgvDescripcion.Columns[2].HeaderText = "CANTIDAD";
                dgvDescripcion.Columns[3].HeaderText = "DESCRIPCION";
                dgvDescripcion.Columns[4].HeaderText = "PRECIO";
                dgvDescripcion.Columns[5].HeaderText = "TOTAL";
                txtAtencion.Text = selectedRow.Cells["atencion"].Value.ToString();
                txtNcf.Text = selectedRow.Cells["ncf"].Value.ToString();
                dtpFecha.Text = selectedRow.Cells["fecha"].Value.ToString();
                txtCliente.Text = selectedRow.Cells["empresa"].Value.ToString();
                dtpValidaHasta.Text = selectedRow.Cells["validaHasta"].Value.ToString();
                txtRnc.Text = selectedRow.Cells["rnc"].Value.ToString();
                txtIdFactura.Text = selectedRow.Cells["idFactura"].Value.ToString();
                if (selectedRow.Cells["conItebis"].Value.ToString() == "True")
                {
                    itebisSi.Checked = true;
                    ItebisNo.Checked = false;

                }
                else
                {
                    itebisSi.Checked = false;
                    ItebisNo.Checked = true;
                    txtItebis.Text = "0.00";
                }
                if (selectedRow.Cells["conComprobante"].Value.ToString() == "True")
                {
                    comprobanteSi.Checked = true;
                    CombanteNo.Checked = false;


                }
                else
                {
                    comprobanteSi.Checked = false;
                    CombanteNo.Checked = true;
                }
            }

                */
        }

        private void itebisSi_CheckedChanged(object sender, EventArgs e)
        {
            if (itebisSi.Checked == true)
            {
                ItebisNo.Checked = false;
                txtItebis.Text = (Double.Parse(txtSubtotal.Text) * 0.18).ToString("N2");
                txtTotal.Text = (Double.Parse(txtSubtotal.Text) + Double.Parse(txtItebis.Text)).ToString("N2");
            }
            else
            {
                ItebisNo.Checked = true;
                txtItebis.Text = "0";
                txtTotal.Text = txtSubtotal.Text;
            }
        }

        private void ItebisNo_CheckedChanged(object sender, EventArgs e)
        {
            if (itebisSi.Checked == true)
            {
                ItebisNo.Checked = false;
                txtItebis.Text = (Double.Parse(txtSubtotal.Text) * 0.18).ToString("N2");
                txtTotal.Text = (Double.Parse(txtSubtotal.Text) + Double.Parse(txtItebis.Text)).ToString("N2");
            }
            else
            {
                ItebisNo.Checked = true;
                txtItebis.Text = "0";
                txtTotal.Text = txtSubtotal.Text;
            }
        }

        private void comprobanteSi_CheckedChanged(object sender, EventArgs e)
        {
            if (comprobanteSi.Checked == true)
            {
                CombanteNo.Checked = false;
            }
            else
            {
                CombanteNo.Checked = true;
                txtNcf.Clear();
            }
        }

        private void CombanteNo_CheckedChanged(object sender, EventArgs e)
        {
            if (comprobanteSi.Checked == true)
            {
                CombanteNo.Checked = false;
            }
            else
            {
                CombanteNo.Checked = true;
                txtNcf.Clear();
            }
        }

        private void cbBuscarProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscarProducto.Clear();
            dgvProducto.DataSource = producto.SelectProductoByIdProducto("");
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            switch (cbBuscarProducto.SelectedIndex)
            {
                case 0:
                    dgvProducto.DataSource = producto.SelectProductoByIdProducto(txtBuscarProducto.Text);
                    break;
                case 1:
                    dgvProducto.DataSource = producto.SelectProductoByDescripcion(txtBuscarProducto.Text);
                    break;
                case 2:
                    dgvProducto.DataSource = producto.SelectProductoByNombreProducto(txtBuscarProducto.Text);
                    break;
                case 3:
                    dgvProducto.DataSource = producto.SelectProductoByModelo(txtBuscarProducto.Text);
                    break;
                case 4:
                    dgvProducto.DataSource = producto.SelectProductoByMarca(txtBuscarProducto.Text);
                    break;
            }
        }



        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             index = e.RowIndex;
            if (index != -1)
            {
                DataGridViewRow selectedRow = dgvProducto.Rows[index];
                txtDescripcion.Text = selectedRow.Cells[4].Value.ToString();
                txtPrecio.Text = selectedRow.Cells[5].Value.ToString();
                
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool control2 = true;

            if (utiles.RevisarTextBox(panel11))
            {


                total = (Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecio.Text));
                txtPrecio.Text = double.Parse(txtPrecio.Text).ToString("N2");

                if (control)
                {
                    string unidad;
                    string idProducto;
                    DataGridViewRow selectedRowProducto = dgvProducto.Rows[index];

                    foreach (DataGridViewRow row in dgvDescripcion.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            //MessageBox.Show(factura.dataFacturaInserted.Rows[0]["idFactura"].ToString(), row.Cells[0].Value.ToString() + row.Cells[1].Value.ToString() + row.Cells[3].Value.ToString() + row.Cells[4].Value.ToString()+ row.Cells[2].Value.ToString()+ row.Cells[5].Value.ToString());
                  
                            if (row.Cells[5].Value.ToString()== selectedRowProducto.Cells[0].Value.ToString()) {
                                control2 = false;
                            };
                        }
                        else
                        {
                            break;
                        }

                    }

                    unidad = factura.SelectUnidad(selectedRowProducto.Cells[11].Value.ToString());
                    idProducto = selectedRowProducto.Cells[0].Value.ToString();
                    //MessageBox.Show(unidad);
                    if (factura.ControlCantidad(txtCantidad.Text, idProducto)>=0 && control2)
                    {
                        dt.Rows.Add(txtCantidad.Text, txtDescripcion.Text, unidad, txtPrecio.Text, total.ToString("N2"), idProducto);
                        dgvDescripcion.DataSource = dt;
                    }
                     if (factura.ControlCantidad(txtCantidad.Text, idProducto) < 0)
                    {
                        MessageBox.Show("ESTE PRODUCTO SOLO TIENE " + selectedRowProducto.Cells[12].Value.ToString() + " EN EL INVENTARIO");
                    }

                    if (!control2)
                    {
                        MessageBox.Show("ESTE PRODUCTO YA ESTA AGREGADO");
                    }

              
                  

                    utiles.limpiarTextBox(panel11);

                }
                /*
                else
                {
                    if (indexFactura != -1)
                    {
                        DataGridViewRow selectedRow = dgvFactura.Rows[indexFactura];
                        dgvDescripcion.DataSource = factura.InsertDescripcionFacturaByIdFactura(selectedRow.Cells[0].Value.ToString(), txtCantidad.Text, txtDescripcion.Text, txtPrecio.Text, total.ToString("N2"),"","");
                        utiles.limpiarTextBox(panel11);

                    }
                    else
                    {
                        MessageBox.Show("Favor Selecionar Factura");
                    }

                }

                */

            }
        }

        private void txtDescripcionCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            utiles.SoloNumeros(e);
        }

        private void txtDescripcionValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            utiles.SoloNumeros(e);
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            if (utiles.RevisarTextBox(panel11))
            {
               
                if (control)
                {
                    DataGridViewRow selectedRowProducto = dgvProducto.Rows[index];
                  if(index > -1)
                    {
                        txtPrecio.Text = Double.Parse(txtPrecio.Text).ToString("N2");
                        total = (Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecio.Text));
                        dt.Rows[index2][0] = txtCantidad.Text;
                        dt.Rows[index2][1] = txtDescripcion.Text;
                        dt.Rows[index2][2] = factura.SelectUnidad(selectedRowProducto.Cells[11].Value.ToString());
                        dt.Rows[index2][3] = txtPrecio.Text;
                        dt.Rows[index2][4] = total.ToString("N2");
                        dt.Rows[index2][5] = selectedRowProducto.Cells[0].Value.ToString();
                        dgvDescripcion.DataSource = dt;
                        utiles.limpiarTextBox(panel11);

                    }
                    else
                    {
                        MessageBox.Show("seleccione un producto");
                    }
                    

                    decimal subtotal = 0;
                    if (control && dt.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            subtotal += Decimal.Parse(dr[4].ToString());
                        }

                        txtSubtotal.Text = subtotal.ToString("N2");
                    }

               
                }
                else
                {
                    if (index != -1)
                    {
                        DataGridViewRow selectedRow = dgvDescripcion.Rows[index];
                        dgvDescripcion.DataSource = factura.UpdateDescripcionFacturaByIdFactura(selectedRow.Cells[0].Value.ToString(), selectedRow.Cells[1].Value.ToString(), txtCantidad.Text, txtDescripcion.Text, txtPrecio.Text, total.ToString("N2"));
                        utiles.limpiarTextBox(panel11);
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una fila valida");
                    }
                }

            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (utiles.RevisarTextBox(panel11))
            {
                if (control)
                {
                    if (index2 != -1)
                    {
                        dt.Rows[index2].Delete();
                        decimal subtotal2 = 0;
                        if (control && dt.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                subtotal2 += Decimal.Parse(dr[4].ToString());
                            }

                            txtSubtotal.Text = subtotal2.ToString("N2");
                        }
                        utiles.limpiarTextBox(panel11);

                    }
                    else
                    {
                        MessageBox.Show("Seleccione un producto de la factura");
                    }

                    decimal subtotal = 0;
            if (control && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    subtotal += Decimal.Parse(dr[4].ToString());
                }

                txtSubtotal.Text = subtotal.ToString("N2");
            }

                }
                /*
                else
                {
                    if (index != -1)
                    {
                        DataGridViewRow selectedRow = dgvDescripcion.Rows[index];
                        dgvDescripcion.DataSource = factura.DeleteDescripcionFacturaByIdDescripcionFactura(selectedRow.Cells[0].Value.ToString(), selectedRow.Cells[1].Value.ToString());
                        utiles.limpiarTextBox(panel11);
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un producto de la factura");
                    }

                }
*/
            }
        }



        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            txtItebis.Text = (Double.Parse(txtSubtotal.Text) * 0.18).ToString("N2");
            txtTotal.Text = (Double.Parse(txtSubtotal.Text) + Double.Parse(txtItebis.Text)).ToString("N2");
        }

        private void dgvDescripcion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (!control)
            {
                index = e.RowIndex;
                if (index != -1)
                {
                    DataGridViewRow selectedRow = dgvDescripcion.Rows[index];
                    txtCantidad.Text = selectedRow.Cells[2].Value.ToString();
                    txtDescripcion.Text = selectedRow.Cells[3].Value.ToString();
                    txtPrecio.Text = selectedRow.Cells[4].Value.ToString();

                }

            }
            */
            if(control)
            {
                index2 = e.RowIndex;
                if (index2 != -1)
                {
                    DataGridViewRow selectedRow2 = dgvDescripcion.Rows[index2];
                    txtCantidad.Text = selectedRow2.Cells[0].Value.ToString();
                    txtDescripcion.Text = selectedRow2.Cells[1].Value.ToString();
                    txtPrecio.Text = selectedRow2.Cells[3].Value.ToString();

                }

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            control = true;
            utiles.limpiarTextBox(panel5);
            utiles.limpiarTextBox(panel11);
            utiles.limpiarTextBox(panel4);
            utiles.limpiarTextBox(panel3);
            utiles.limpiarTextBox(panel10);
            dtpFecha.Value = DateTime.Now;
            dtpValidaHasta.Value = DateTime.Now;
            dt.Rows.Clear();
            dgvDescripcion.DataSource = dt;
            dgvCliente.DataSource = cliente.SelectClienteByIdCliente("");
            dgvProducto.DataSource = producto.SelectProductoByIdProducto("");
            dgvFactura.DataSource = factura.SelectFacturaByIdFactura("");
            txtSubtotal.Text = "0.00";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(control)
            {
                txtIdFactura.Text = "-";
                if (utiles.RevisarTextBox(panel9) && utiles.RevisarTextBox(panel5) && dgvDescripcion.Rows.Count > 1)
                {
                    if (indexCliente != -1 && indexCliente.ToString() != "")
                    {
                        DataGridViewRow selectedRow = dgvCliente.Rows[indexCliente];

                        factura.InsertarFactura(selectedRow.Cells[0].Value.ToString(), txtNcf.Text, dtpValidaHasta.Value, dtpFecha.Value, txtSubtotal.Text, txtItebis.Text, txtTotal.Text, itebisSi.Checked == true ? 1 : 0, comprobanteSi.Checked == true ? 1 : 0, txtAtencion.Text);
                        MessageBox.Show("Factura Guardada correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        foreach (DataGridViewRow row in dgvDescripcion.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                //MessageBox.Show(factura.dataFacturaInserted.Rows[0]["idFactura"].ToString(), row.Cells[0].Value.ToString() + row.Cells[1].Value.ToString() + row.Cells[3].Value.ToString() + row.Cells[4].Value.ToString()+ row.Cells[2].Value.ToString()+ row.Cells[5].Value.ToString());
                                factura.InsertDescripcionFacturaByIdFactura(factura.dataFacturaInserted.Rows[0]["idFactura"].ToString(), row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[5].Value.ToString());
                                factura.RestarInventario(row.Cells[0].Value.ToString(), row.Cells[5].Value.ToString());
                            }
                            else
                            {
                                break;
                            }

                        }
                        utiles.limpiarTextBox(panel5);
                        utiles.limpiarTextBox(panel11);
                        utiles.limpiarTextBox(panel4);
                        utiles.limpiarTextBox(panel3);
                        utiles.limpiarTextBox(panel10);
                        dtpFecha.Value = DateTime.Now;
                        dtpValidaHasta.Value = DateTime.Now;
                        dt.Rows.Clear();
                        dgvDescripcion.DataSource = dt;
                        dgvCliente.DataSource = cliente.SelectClienteByIdCliente("");
                        dgvProducto.DataSource = producto.SelectProductoByIdProducto("");
                        dgvFactura.DataSource = factura.SelectFacturaByIdFactura("");
                        txtSubtotal.Text = "0.00";
                    }
                    else
                    {
                        MessageBox.Show("Favor seleccione un cliente");
                    }
                }


            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro quiere eliminar esta Factura", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                if (indexFactura > -1)
                {
                    DataGridViewRow selectedRow = dgvFactura.Rows[indexFactura];
                    factura.DeleteFactura(selectedRow.Cells[0].Value.ToString());
                    utiles.limpiarTextBox(panel4);
                    utiles.limpiarTextBox(panel6);
                    utiles.limpiarTextBox(panel1);
                    utiles.limpiarTextBox(panel3);
                    utiles.limpiarTextBox(panel8);
                    dtpFecha.Value = DateTime.Now;
                    dtpValidaHasta.Value = DateTime.Now;
                    dt.Rows.Clear();
                    dgvDescripcion.DataSource = dt;
                    dgvCliente.DataSource = cliente.SelectClienteByIdCliente("");
                    dgvProducto.DataSource = producto.SelectProductoByIdProducto("");
                    dgvFactura.DataSource = factura.SelectFacturaByIdFactura("");
                    txtSubtotal.Text = "0.00";

                }
                else
                {
                    MessageBox.Show("Seleccione la factura a borrar");
                }
            }
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            cbBuscarProducto.SelectedIndex = 0;
            cbBuscarCliente.SelectedIndex = 0;
            cbBuscarFactura.SelectedIndex = 0;
            dt.Columns.Add("CANTIDAD");
            dt.Columns.Add("DESCRIPCION");
            dt.Columns.Add("UD");
            dt.Columns.Add("PRECIO");
            dt.Columns.Add("TOTAL");
            dt.Columns.Add("idProducto");
            dgvDescripcion.DataSource = dt;
            dgvDescripcion.Columns["idProducto"].Visible = false;
            dgvCliente.DataSource = cliente.SelectClienteByIdCliente("");
            dgvProducto.DataSource = producto.SelectProductoByIdProducto("");
            dgvFactura.DataSource = factura.SelectFacturaByIdFactura("");
            txtSubtotal.Text = "0.00";
        }

        private void dgvDescripcion_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            decimal subtotal = 0;
            if (control && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    subtotal += Decimal.Parse(dr[4].ToString());
                }

                txtSubtotal.Text = subtotal.ToString("N2");
            }
            /*
            if (!control && factura.dataTable.Rows.Count > -1)
            {

                foreach (DataRow dr in factura.dataTable.Rows)
                {

                    subtotal += Decimal.Parse(dr[4].ToString());

                }



                txtSubtotal.Text = subtotal.ToString("N2");
            }
            */
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if(indexFactura>-1 && indexFactura.ToString() != "")
            {
                ImpresionFactura impresionFactura = new ImpresionFactura();
                DataGridViewRow selectedRow = dgvFactura.Rows[indexFactura];
                //MessageBox.Show(selectedRow.Cells[0].Value.ToString());
                impresionFactura.idFactura = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                impresionFactura.comprobante = comprobanteSi.Checked == true ? true : false;
                impresionFactura.Show();
            }
            else
            {
                MessageBox.Show("Sleccione una Factura");
            }
        }

    
    }
}
