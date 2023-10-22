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
    public partial class frmListaCompleta : Form
    {
        public frmListaCompleta()
        {
            InitializeComponent();
        }
        clsSocio s = new clsSocio();

        private void btnListar_Click(object sender, EventArgs e)
        {
            lblCantidad.Text = s.Cantidad.ToString();
            lblDeudaTotal.Text = s.TotalDeuda.ToString("0.00");
            lblPromedio.Text = s.Promedio.ToString("0.00");
            //if (cmb.SelectedIndex == 3) 
            //{
                s.OrdenarIdM();
                s.ListarTodo(dgvL);
            //}
        }

        private void frmListaCompleta_Load(object sender, EventArgs e)
        {
            //cmb.SelectedIndex = 0;
        }

        private void btnIm_Click(object sender, EventArgs e)
        {
            prtVe.ShowDialog();
            prtDoc.PrinterSettings = prtVe.PrinterSettings;
            prtDoc.Print();
        }

        private void btnEx_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Seleccione el formato del Archivo e indique el nombre";
            sfd.RestoreDirectory = true;
            sfd.Filter = "Archivo de texto|*.txt|Archivo separado por coma|*.csv";
            sfd.ShowDialog();
            s.Exportar(sfd.FileName);
            MessageBox.Show("Archivo Generado con Exito!!");
        }

        private void prtDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            s.Imprimir(e);
            MessageBox.Show("Impresion generada exitosamente!!");
        }
    }
}
