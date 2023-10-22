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
    public partial class frmListaBar : Form
    {
        public frmListaBar()
        {
            InitializeComponent();
        }
        clsSocio s = new clsSocio();
        clsBarrio b = new clsBarrio();

        private void frmListaBar_Load(object sender, EventArgs e)
        {
            b.ComboB(cmbBarrio);
            cmbBarrio.SelectedIndex = 0;    
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            lblCantidad.Text = s.Cantidad.ToString();
            lblDeudaTotal.Text = s.TotalDeuda.ToString("0.00");
            lblPromedio.Text = s.Promedio.ToString("0.00");
            s.ListarBar(cmbBarrio, dgvL);
        }

        private void btnEx_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Exportacion de Archivo por Barrio: Seleccione Formato e Ingrese nombre del Archivo";
            sfd.RestoreDirectory = true;
            sfd.Filter = "Archivo de Texto|*.txt| Archivo Separado por Coma|*.csv";
            sfd.ShowDialog();
            s.IdBarrio = cmbBarrio.SelectedIndex + 1;
            s.ExportarBarrio(sfd.FileName);
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
            s.ImprimirBar(e, cmbBarrio);
            String Barrio = b.Barrio(cmbBarrio.SelectedIndex + 1);
            MessageBox.Show("Impresion del Barrio " + Barrio + " generada exitosamente!!");
        }
    }
}
