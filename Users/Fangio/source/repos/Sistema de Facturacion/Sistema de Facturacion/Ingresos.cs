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
    class Ingresos
    {

        private db db = new db();
        private SqlCommand cmd = new SqlCommand();
        public DataTable dt = new DataTable();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        public DataTable dataTable = new DataTable();
        public DataTable dataFacturaInserted = new DataTable();
        private string ud = "";

        public DataTable SelectIngresos()
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "Ingresos";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

           // cmd.Parameters.AddWithValue("@idProducto", SqlDbType.VarChar).Value = buscar;


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

        public DataTable IngresosPorFecha(DateTime fecha1, DateTime fecha2)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "IngresosPorFecha";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fecha1", SqlDbType.DateTime).Value = fecha1;
            cmd.Parameters.AddWithValue("@fecha2", SqlDbType.DateTime).Value = fecha2;


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


        public DataTable IngresosPorFecha1(DateTime fecha1)
        {
            db.open();
            dt.Clear();
            cmd.Parameters.Clear();
            adapter.Dispose();

            cmd.CommandText = "IngresosPorFecha1";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fecha1", SqlDbType.DateTime).Value = fecha1;
           


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
