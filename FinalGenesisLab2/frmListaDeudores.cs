using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalGenesisLab2
{
    public partial class frmListaDeudores : Form
    {
        public frmListaDeudores()
        {
            InitializeComponent();
        }
        clsSocio s = new clsSocio();
        clsActividad a = new clsActividad();


        private void btnListar_Click(object sender, EventArgs e)
        {
            lblCantidad.Text = s.Cantidad.ToString();
            lblDeudaTotal.Text = s.TotalDeuda.ToString("0.00");
            lblPromedio.Text = s.Promedio.ToString("0.00");
            s.ListarDe(dgvL);

        }

        private void btnEx_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Seleccione el formato del Archivo e ingrese el nombre";
            sfd.RestoreDirectory = true;
            sfd.Filter = "Archivo de Texto|*.txt| Archivo separado por coma |*.csv";
            sfd.ShowDialog();
            s.ExportarDeudores(sfd.FileName);
            MessageBox.Show("Archivo Generado con Éxito!!\n" + sfd.FileName);
        }

        private void btnIm_Click(object sender, EventArgs e)
        {
            prtVe.ShowDialog();
            prtDoc.PrinterSettings = prtVe.PrinterSettings;
            prtDoc.Print();
        }

        private void prtDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            s.ImprimirDeu(e);
            MessageBox.Show("Impresion generada con Exito!!");
        }
    }
}
