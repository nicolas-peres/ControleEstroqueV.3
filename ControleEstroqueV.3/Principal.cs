using ControleEstroqueV._3.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleEstroqueV._3
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void cadastrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastrarUsuario u = new FrmCadastrarUsuario();
            u.ShowDialog();
        }

        private void cadastrarProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastrarProduto cp = new FrmCadastrarProduto();
            cp.ShowDialog();

        }

        private void comprarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompra c = new FrmCompra();
            c.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
