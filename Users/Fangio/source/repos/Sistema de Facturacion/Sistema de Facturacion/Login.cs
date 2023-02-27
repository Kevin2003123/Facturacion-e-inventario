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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Validacion login = new Validacion();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login.validacionUsuario(txtUsuario.Text, txtContraseña.Text);
            if (login.dt.Rows.Count > 0)
            {
                Menu form = new Menu();
                form.usuario = txtUsuario.Text;
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario incorrecto");
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

   
    }
}
