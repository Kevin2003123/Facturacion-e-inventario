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
    public partial class ImpresionFactura : Form 
    {
        public ImpresionFactura()
        {
            InitializeComponent();
        }
        public int idFactura { get; set;}
        public bool comprobante { get; set;}
       

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
            if (comprobante)
            {
                FacturaFYS factura = new FacturaFYS();
                factura.SetParameterValue("@idFactura", idFactura);
                factura.SetParameterValue("@idFactura2", idFactura);
                factura.SetParameterValue("@idFactura3", idFactura);
                crystalReportViewer1.ReportSource = factura;
            }
            else
            {
                Cotizacion cotizacion = new Cotizacion();
                cotizacion.SetParameterValue("@idFactura", idFactura);
                cotizacion.SetParameterValue("@idFactura3", idFactura);
                cotizacion.SetParameterValue("@idFactura2", idFactura);
                crystalReportViewer1.ReportSource = cotizacion;
            }
            
        }
    }
}
