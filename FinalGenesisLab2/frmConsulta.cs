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
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();
        }
        clsSocio s = new clsSocio();
        clsBarrio b = new clsBarrio();
        clsActividad a = new clsActividad();

        private void btnCon_Click(object sender, EventArgs e)
        {
            lblId.Text = Convert.ToString(s.IdSocio);
            lblDirec.Text = s.Direccion;
            lblDeuda.Text = Convert.ToString(s.Deuda);
            String nom = txtNombre.Text;
            s.Consultar(nom, lblBarrio, lblActividad);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                btnCon.Enabled = false;
            }
            else 
            {
                btnCon.Enabled = true;
            }
        }
    }
}
