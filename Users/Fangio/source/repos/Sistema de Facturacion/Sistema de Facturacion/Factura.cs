using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sistema_de_Facturacion
{
  class Factura
    {
        private db db = new db();
        private SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        public DataTable dataTable = new DataTable();
        public DataTable dataFacturaInserted = new DataTable();
        private string ud = "";

        public string SelectUnidad(string buscar)
        {

            db.con.Open();
            SqlCommand cmd2 = new SqlCommand("SelectUnidad", db.con);
       
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@idUnidad", SqlDbType.Int).Value = Convert.ToInt32(buscar);
            SqlDataReader reader = cmd2.ExecuteReader();


            if (reader.Read())
            {
                ud = reader["ud"].ToString();
            }
            else
            {
                MessageBox.Show("el valor no existe");
            }
            
           

            db.con.Close();
            return ud;

        }


        public int ControlCantidad(string cantidad, string idProducto)
        {
            int result = 0;

            db.con.Open();
            SqlCommand cmd2 = new SqlCommand("ControlCantidad", db.con);

            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@cantidad", SqlDbType.Int).Value = Convert.ToInt32(cantidad);
            cmd2.Parameters.AddWithValue("@idProducto", SqlDbType.Int).Value = Convert.ToInt32(idProducto);
            SqlDataReader reader = cmd2.ExecuteReader();


            if (reader.Read())
            {
                result=Convert.ToInt32(reader["Cantidad"].ToString());
            }
            else
            {
                MessageBox.Show("el valor no existe");
            }



            db.con.Close();
            return result;

        }


        public void RestarInventario(string cantidad, string idProducto)
        {
           
            db.con.Open();
            SqlCommand cmd2 = new SqlCommand("RestarInventario", db.con);

            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@cantidad", SqlDbType.Int).Value = Convert.ToInt32(cantidad);
            cmd2.Parameters.AddWithValue("@idProducto", SqlDbType.Int).Value = Convert.ToInt32(idProducto);
            cmd2.ExecuteNonQuery();


            db.con.Close();


        }


        public string GetUdByName(string buscar)
        {
            string idUd = "";
            db.con.Open();
            SqlCommand cmd2 = new SqlCommand("SelectUnidad", db.con);

            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@ud", SqlDbType.Int).Value = buscar;
            SqlDataReader reader = cmd2.ExecuteReader();


            if (reader.Read())
            {
                idUd = reader["idUnidad"].ToString();
            }
            else
            {
                MessageBox.Show("el valor no existe");
            }



            db.con.Close();
            return idUd;

        }



        public DataTable SelectFacturaByIdFactura(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "SelectFacturaByIdFactura";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idFactura", SqlDbType.VarChar).Value = buscar;


            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();

            return dt;
        }

        public DataTable SelectFacturaByIdCliente(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "SelectFacturaByIdCliente";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idCliente", SqlDbType.VarChar).Value = buscar;


            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();

            return dt;
        }




        public DataTable SelectFacturaByEmpresa(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "SelectFacturaByEmpresa";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = buscar;


            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();

            return dt;
        }



        public DataTable SelectFacturaByPersona(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "SelectFacturaByPersona";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@persona", SqlDbType.VarChar).Value = buscar;


            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();

            return dt;
        }



        public DataTable SelectFacturaByNcf(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "SelectFacturaByNcf";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ncf", SqlDbType.VarChar).Value = buscar;


            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();

            return dt;
        }


        public DataTable SelectDescripcionFacturaByIdFactura(string buscar)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            db.open();
            dataTable.Clear();
            cmd.Parameters.Clear();
            sqlDataAdapter.Dispose();

            cmd.CommandText = "SelectDescripcionFacturaByIdFactura";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idFactura", SqlDbType.Int).Value = Convert.ToInt32(buscar);

            sqlDataAdapter.SelectCommand = cmd;
            try
            {
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();
            return dataTable;

        }

        public DataTable InsertDescripcionFacturaByIdFactura(string idFactura, string cantidad, string Descripcion, string precio, string total, string unidad, string  idProducto)
        {

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            db.open();
            dataTable.Clear();
            cmd.Parameters.Clear();
            sqlDataAdapter.Dispose();

            cmd.CommandText = "InsertDescripcionFacturaByIdFactura";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idFactura", SqlDbType.Int).Value = Convert.ToInt32(idFactura);
            cmd.Parameters.AddWithValue("@cantidad", SqlDbType.Int).Value = cantidad;
            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.Int).Value = Descripcion;
            cmd.Parameters.AddWithValue("@precio", SqlDbType.Int).Value = precio;
            cmd.Parameters.AddWithValue("@total", SqlDbType.Int).Value = total;
            cmd.Parameters.AddWithValue("@ud", SqlDbType.Int).Value = unidad;
            cmd.Parameters.AddWithValue("@idProducto", SqlDbType.Int).Value = Convert.ToInt32(idProducto);
            sqlDataAdapter.SelectCommand = cmd;
            try
            {
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();
            return dataTable;

        }


        public DataTable UpdateDescripcionFacturaByIdFactura(string idDescripcionFactura, string idFactura, string cantidad, string Descripcion, string precio, string total)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            db.open();
            dataTable.Clear();
            cmd.Parameters.Clear();
            sqlDataAdapter.Dispose();

            cmd.CommandText = "UpdateDescripcionFacturaByIdFactura";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idDescripcionFactura", SqlDbType.Int).Value = Convert.ToInt32(idDescripcionFactura);
            cmd.Parameters.AddWithValue("@idFactura", SqlDbType.Int).Value = Convert.ToInt32(idFactura);
            cmd.Parameters.AddWithValue("@cantidad", SqlDbType.Int).Value = cantidad;
            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.Int).Value = Descripcion;
            cmd.Parameters.AddWithValue("@precio", SqlDbType.Int).Value = precio;
            cmd.Parameters.AddWithValue("@total", SqlDbType.Int).Value = total;
            sqlDataAdapter.SelectCommand = cmd;
            try
            {
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();
            return dataTable;

        }

        public DataTable DeleteDescripcionFacturaByIdDescripcionFactura(string idDescripcionFactura, string idFactura)
        {

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            db.open();
            dataTable.Clear();
            cmd.Parameters.Clear();
            sqlDataAdapter.Dispose();

            cmd.CommandText = "DeleteDescripcionFacturaByIdDescripcionFactura";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idDescripcionFactura", SqlDbType.Int).Value = Convert.ToInt32(idDescripcionFactura);
            cmd.Parameters.AddWithValue("@idFactura", SqlDbType.Int).Value = Convert.ToInt32(idFactura);
            sqlDataAdapter.SelectCommand = cmd;
            try
            {
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();
            return dataTable;

        }

        public void UpdateFacturabyId(string idFactura, string ncf, DateTime validaHasta, DateTime fecha, string subTotal, string itebis, string precioTotal, int conItebis, int conComprobante, string atencion, string empresa)
        {

            db.open();
            cmd.Parameters.Clear();

            cmd.CommandText = "UpdateFacturabyId";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idFactura", SqlDbType.Int).Value = Convert.ToInt32(idFactura);
            cmd.Parameters.AddWithValue("@ncf", SqlDbType.VarChar).Value = ncf;
            cmd.Parameters.AddWithValue("@validaHasta", SqlDbType.DateTime).Value = validaHasta;
            cmd.Parameters.AddWithValue("@fecha", SqlDbType.DateTime).Value = fecha;
            cmd.Parameters.AddWithValue("@subTotal", SqlDbType.VarChar).Value = subTotal;
            cmd.Parameters.AddWithValue("@itebis", SqlDbType.VarChar).Value = itebis;
            cmd.Parameters.AddWithValue("@precioTotal", SqlDbType.VarChar).Value = precioTotal;
            cmd.Parameters.AddWithValue("@conItebis", SqlDbType.Bit).Value = conItebis;
            cmd.Parameters.AddWithValue("@conComprobante", SqlDbType.Bit).Value = conComprobante;
            cmd.Parameters.AddWithValue("@atencion", SqlDbType.VarChar).Value = atencion;
            cmd.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = empresa;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();

        }


        public DataTable InsertarFactura( string idCliente, string ncf, DateTime validaHasta, DateTime fecha, string subTotal, string itebis, string precioTotal, int conItebis, int conComprobante, string atencion)
        {

            SqlDataAdapter adapt = new SqlDataAdapter();

            db.open();
            cmd.Parameters.Clear();
            dataFacturaInserted.Clear();
            cmd.Parameters.Clear();
            adapt.Dispose();


            cmd.CommandText = "InsertarFactura";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idCliente", SqlDbType.Int).Value = Convert.ToInt32(idCliente);
            cmd.Parameters.AddWithValue("@ncf", SqlDbType.VarChar).Value = ncf;
            cmd.Parameters.AddWithValue("@validaHasta", SqlDbType.DateTime).Value = validaHasta;
            cmd.Parameters.AddWithValue("@fecha", SqlDbType.DateTime).Value = fecha;
            cmd.Parameters.AddWithValue("@subTotal", SqlDbType.VarChar).Value = subTotal;
            cmd.Parameters.AddWithValue("@itebis", SqlDbType.VarChar).Value = itebis;
            cmd.Parameters.AddWithValue("@precioTotal", SqlDbType.VarChar).Value = precioTotal;
            cmd.Parameters.AddWithValue("@conItebis", SqlDbType.Bit).Value = conItebis;
            cmd.Parameters.AddWithValue("@conComprobante", SqlDbType.Bit).Value = conComprobante;
            cmd.Parameters.AddWithValue("@atencion", SqlDbType.VarChar).Value = atencion;
            //cmd.Parameters.AddWithValue("@idEmpresa", SqlDbType.Int).Value = idEmpresa;
            adapt.SelectCommand = cmd;
            try
            {
                adapt.Fill(dataFacturaInserted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();
            return dataFacturaInserted;

        }

        public void DeleteFactura(string idFactura)
        {
            db.open();
            cmd.Parameters.Clear();
            cmd.CommandText = "DeleteFactura";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idFactura", SqlDbType.Int).Value = Convert.ToInt32(idFactura);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();
        }
    }
}
