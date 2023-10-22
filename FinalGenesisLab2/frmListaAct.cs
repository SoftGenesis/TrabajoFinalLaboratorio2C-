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
    public partial class frmListaAct : Form
    {
        public frmListaAct()
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
            s.ListarAct(cmbActividad, dgvL);
        }

        private void frmListaAct_Load(object sender, EventArgs e)
        {
            a.ComboA(cmbActividad);
            cmbActividad.SelectedIndex = 0;
        }

        private void btnEx_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Exportacion de Archivo por Actividad: Seleccione formato e Ingrese nombre del Archivo";
            sfd.RestoreDirectory = true;
            sfd.Filter = "Archivo separado por coma|*.csv| Archivo de Texto |*.txt";
            sfd.ShowDialog();
            s.IdActividad = cmbActividad.SelectedIndex + 1;
            s.ExportarActividad(sfd.FileName);
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
            String Actividad = a.Actividad(cmbActividad.SelectedIndex + 1);
            s.ImprimirAct(e, cmbActividad);
            MessageBox.Show("Impresión de la actividad " + Actividad + " realizada exitosamente!!");
        }
    }
}
