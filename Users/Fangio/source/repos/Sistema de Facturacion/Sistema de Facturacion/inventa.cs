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
    class inventa
    {

        private db db = new db();
        private SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        public DataTable dataTable = new DataTable();
        public DataTable dataFacturaInserted = new DataTable();
        private string ud = "";

        public DataTable SelectInventarioByIdProducto(string buscar)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "SelectInventarioByIdProducto";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idProducto", SqlDbType.VarChar).Value = buscar;


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

        public DataTable SelectInventarioAgotado()
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "SelectInventarioAgotado";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

      


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

        public DataTable SelectInventarioExistencia()
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "SelectInventarioExistencia";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;




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

    }
}
