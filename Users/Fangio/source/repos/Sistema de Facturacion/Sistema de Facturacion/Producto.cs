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
    class Producto
    {
        private db db = new db();
        private SqlCommand cmd = new SqlCommand();
        private DataTable dt = new DataTable();
        private DataTable dt2 = new DataTable();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        public DataTable SelectProductoByIdProducto(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "SelectProductoByIdProducto";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProducto", SqlDbType.Int).Value = buscar;
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


        public DataTable SelectProductoByDescripcion(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "SelectProductoByDescripcion";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = buscar;
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

        public DataTable SelectProductoByNombreProducto(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "SelectProductoByNombreProducto";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombreProducto", SqlDbType.VarChar).Value = buscar;
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


        public DataTable SelectProductoByModelo(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "SelectProductoByModelo";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@modelo", SqlDbType.VarChar).Value = buscar;
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

        public DataTable SelectProductoByMarca(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "SelectProductoByMarca";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@marca", SqlDbType.VarChar).Value = buscar;
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

        public DataTable unidades()
        {
            db.open();
            dt2.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "unidades";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            db.close();

            return dt2;
        }

        public void InsertarProducto(string nombreProducto, string modelo, string marca, string Descripcion, string precio, string Distribuidor, string Contacto, string telefono, string Direccion, string Correo, int ud, string cantidad)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "InsertarProducto";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombreProducto", SqlDbType.VarChar).Value = nombreProducto;
            cmd.Parameters.AddWithValue("@modelo", SqlDbType.VarChar).Value = modelo;
            cmd.Parameters.AddWithValue("@marca", SqlDbType.VarChar).Value = marca;
            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
            cmd.Parameters.AddWithValue("@precio", SqlDbType.VarChar).Value = precio;
            cmd.Parameters.AddWithValue("@Distribuidor", SqlDbType.VarChar).Value = Distribuidor;
            cmd.Parameters.AddWithValue("@Contacto", SqlDbType.VarChar).Value = Contacto;
            cmd.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = telefono;
            cmd.Parameters.AddWithValue("@Direccion", SqlDbType.VarChar).Value = Direccion;
            cmd.Parameters.AddWithValue("@Correo", SqlDbType.VarChar).Value = Correo;
            cmd.Parameters.AddWithValue("@ud", SqlDbType.Int).Value = ud;
            cmd.Parameters.AddWithValue("@cantidad", SqlDbType.VarChar).Value = cantidad;
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


        public void UpdateProducto(string idProducto, string nombreProducto, string modelo, string marca, string Descripcion, string precio, string Distribuidor, string Contacto, string telefono, string Direccion, string Correo, int ud, string cantidad)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "UpdateProducto";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProducto", SqlDbType.VarChar).Value = Int32.Parse(idProducto);
            cmd.Parameters.AddWithValue("@nombreProducto", SqlDbType.VarChar).Value = nombreProducto;
            cmd.Parameters.AddWithValue("@modelo", SqlDbType.VarChar).Value = modelo;
            cmd.Parameters.AddWithValue("@marca", SqlDbType.VarChar).Value = marca;
            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
            cmd.Parameters.AddWithValue("@precio", SqlDbType.VarChar).Value = precio;
            cmd.Parameters.AddWithValue("@Distribuidor", SqlDbType.VarChar).Value = Distribuidor;
            cmd.Parameters.AddWithValue("@Contacto", SqlDbType.VarChar).Value = Contacto;
            cmd.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = telefono;
            cmd.Parameters.AddWithValue("@Direccion", SqlDbType.VarChar).Value = Direccion;
            cmd.Parameters.AddWithValue("@Correo", SqlDbType.VarChar).Value = Correo;
            cmd.Parameters.AddWithValue("@ud", SqlDbType.VarChar).Value = ud;
            cmd.Parameters.AddWithValue("@cantidad", SqlDbType.VarChar).Value = cantidad;
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

        public void DeleteProducto(string idProducto)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "DeleteProducto";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProducto", SqlDbType.VarChar).Value = Int32.Parse(idProducto);
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
