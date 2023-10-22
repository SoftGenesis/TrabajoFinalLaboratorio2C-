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
    public partial class frmBuscar : Form
    {
        public frmBuscar()
        {
            InitializeComponent();
        }
        clsSocio s = new clsSocio();
        clsBarrio b = new clsBarrio();
        clsActividad a = new clsActividad();

        public void limpiar() 
        {
            txtDeu.Text = "";
            txtDir.Text = "";
            txtDNI.Text = "";
            lblNombre.Text = "";
        }

        private void frmBuscar_Load(object sender, EventArgs e)
        {
            b.ComboB(cmbBarrio);
            a.ComboA(cmbActividad);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lblNombre.Text = s.Nombre;
            txtDir.Text = s.Direccion;
            txtDeu.Text = Convert.ToString(s.Deuda);
            Int32 id = Convert.ToInt32(txtDNI.Text);
            s.Buscar(id, cmbBarrio, cmbActividad);
           
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                btnBuscar.Enabled = false;
            }
            else 
            {
                btnBuscar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            s.Deuda = Convert.ToDecimal(txtDeu.Text);
            s.Direccion = txtDir.Text;
            s.IdBarrio = cmbBarrio.SelectedIndex + 1;
            s.IdActividad = cmbActividad.SelectedIndex + 1;
            s.Modificar(s, Convert.ToInt32(txtDNI.Text));
            MessageBox.Show("Dato Guardado Correctamente!!");
            limpiar();
            btnGuardar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            s.Eliminar(Convert.ToInt32(txtDNI.Text));
            MessageBox.Show("Dato Eliminado Correctamente!!");
            limpiar();
        }
    }
}
