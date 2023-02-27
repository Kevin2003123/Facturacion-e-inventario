using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Sistema_de_Facturacion
{
    class db
    {
        public SqlConnection con = new SqlConnection(@"server= DESKTOP-GQ2LBAU\SQLEXPRESS; database=FacturacionFYS; integrated security = true");

        public void open()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

        }

        public void close()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
