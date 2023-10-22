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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaDeLaDesarrolladoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcerca ace = new frmAcerca();
            ace.ShowDialog();
        }

        private void agregarNuevosSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregar ag = new frmAgregar();
            ag.ShowDialog();
        }

        private void busquedaDeSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscar bus = new frmBuscar();
            bus.ShowDialog();
        }

        private void consultaSobreSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulta co = new frmConsulta();
            co.ShowDialog();
        }

        private void todosLosSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaCompleta soc = new frmListaCompleta();
            soc.ShowDialog();
        }

        private void sociosDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaDeudores de = new frmListaDeudores();
            de.ShowDialog();
        }

        private void sociosDeUnaActividadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaAct liA = new frmListaAct();
            liA.ShowDialog();
        }

        private void sociosDeUnBarrioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaBar liB = new frmListaBar();
            liB.ShowDialog();   
        }
    }
}
