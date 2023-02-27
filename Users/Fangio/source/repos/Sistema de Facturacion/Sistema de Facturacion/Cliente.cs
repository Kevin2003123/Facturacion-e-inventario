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
    class Cliente
    {
        private db db = new db();
        private SqlCommand cmd = new SqlCommand();
        private DataTable dt = new DataTable();
        private SqlDataAdapter adapter = new SqlDataAdapter();

        public DataTable SelectClienteByIdCliente(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "SelectClienteByIdCliente";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idCliente", SqlDbType.Int).Value = buscar;


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


        public DataTable SelectClienteByRnc(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "SelectClienteByRnc";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rnc", SqlDbType.VarChar).Value = buscar;
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


        public DataTable SelectClienteByEmpresa(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "SelectClienteByEmpresa";
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

        public DataTable SelectClienteByPersona(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "SelectClienteByPersona";
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


        public void InsertarCliente(string persona, string rnc, string empresa, string telefono, string direccion)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "InsertarCliente";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@persona", SqlDbType.VarChar).Value = persona;
            cmd.Parameters.AddWithValue("@rnc", SqlDbType.VarChar).Value = rnc;
            cmd.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = empresa;
            cmd.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = telefono;
            cmd.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = direccion;
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


        public void UpdateCliente(string idCliente, string persona, string rnc, string empresa, string telefono, string direccion)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "UpdateCliente";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCliente", SqlDbType.VarChar).Value = Int32.Parse(idCliente);
            cmd.Parameters.AddWithValue("@persona", SqlDbType.VarChar).Value = persona;
            cmd.Parameters.AddWithValue("@rnc", SqlDbType.VarChar).Value = rnc;
            cmd.Parameters.AddWithValue("@empresa", SqlDbType.VarChar).Value = empresa;
            cmd.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = telefono;
            cmd.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = direccion;
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


        public void DeleteCliente(string idCliente)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "DeleteCliente";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCliente", SqlDbType.VarChar).Value = Int32.Parse(idCliente);
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
