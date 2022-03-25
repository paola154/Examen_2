using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen_2
{
    public partial class FrmMenu : Syncfusion.Windows.Forms.Office2010Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        FrmPedidos frmpedidos = null;
        FrmProducto frmProducto = null;

        private void ProductostoolStripButton_Click(object sender, EventArgs e)
        {
            if (frmProducto == null)
            {
                frmProducto = new FrmProducto();
                frmProducto.MdiParent = this;
                frmProducto.FormClosed += FrmProducto_FormClosed;
                frmProducto.Show();
            }
            else
            {
                frmProducto.Activate();
            }
        }

        private void FrmProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProducto = null;
        }

        private void pedidostoolStripButton_Click(object sender, EventArgs e)
        {
            if (frmpedidos == null)
            {
                frmpedidos = new FrmPedidos();
                frmpedidos.MdiParent = this;
                frmpedidos.FormClosed += Frmpedidos_FormClosed;
                frmpedidos.Show();
            }
            else
            {
                frmpedidos.Activate();
            }
        }

        private void Frmpedidos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmpedidos = null;
        }
    }
}
