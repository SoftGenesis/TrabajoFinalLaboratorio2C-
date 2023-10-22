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
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }
        clsSocio s = new clsSocio();
        clsBarrio b = new clsBarrio();
        clsActividad a = new clsActividad();

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            b.ComboB(cmbBarrio);
            a.ComboA(cmbActividad);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            s.IdSocio = Convert.ToInt32(txtIdSocio.Text);
            s.Nombre = txtNombre.Text;
            s.Direccion = txtDireccion.Text;
            s.IdBarrio = Convert.ToInt32(cmbBarrio.SelectedValue);
            s.IdActividad = Convert.ToInt32(cmbActividad.SelectedValue);
            s.Deuda = Convert.ToDecimal(txtDeuda.Text);
            s.Agregar();
            MessageBox.Show("Dato Almacenado Correctamente!!");
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtIdSocio.Text = "";
            txtDeuda.Text = "";
        }

        public void Enable()
        {
            if (txtNombre.Text == "" && txtDireccion.Text == "" && txtDeuda.Text == "" && txtIdSocio.Text == "")
            {
                btnAgregar.Enabled = false;
            }
            else 
            {
                btnAgregar.Enabled = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Enable();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            Enable();
        }

        private void txtDeuda_TextChanged(object sender, EventArgs e)
        {
            Enable();
        }

        private void txtIdSocio_TextChanged(object sender, EventArgs e)
        {
            Enable();
        }
    }
}
