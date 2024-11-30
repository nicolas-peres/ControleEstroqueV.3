using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleEstroqueV._3.Formularios
{
    public partial class Comprado : Form
    {
        public Comprado()
        {
            InitializeComponent();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            FrmCompra c = new FrmCompra();
            c.ShowDialog();
        }
    }
}
