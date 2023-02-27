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
    class Validacion
    {
        private db db = new db();
        private SqlCommand command = new SqlCommand();
        public DataTable dt = new DataTable();
        private SqlDataAdapter adapter = new SqlDataAdapter();


        public void validacionUsuario(string usuario, string contraseña)
        {

            dt.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            adapter.Dispose();
            cmd.CommandText = "validacionUsuario";
            cmd.Connection = db.con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", SqlDbType.VarChar).Value = usuario;
            cmd.Parameters.AddWithValue("@contraseña", SqlDbType.VarChar).Value = contraseña;
            adapter.SelectCommand = cmd;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }
    }
}
