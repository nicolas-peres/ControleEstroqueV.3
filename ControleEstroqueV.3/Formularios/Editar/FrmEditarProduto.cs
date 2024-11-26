using ControleEstroqueV._3.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleEstroqueV._3.Formularios.Editar
{
    public partial class FrmEditarProduto : Form
    {
        public FrmEditarProduto(int Id)
        {
            InitializeComponent();
            ProdutoC produto = new ProdutoC();
            produto.PesquisarPorId(Id);
            txtId.Text = produto.Id.ToString();
            comboNome.Text = produto.Nome;
            txtDescricao.Text = produto.Descricao;

            txtpreco.Text = produto.Preco;
            produto = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ProdutoC produto = new ProdutoC();
            produto.Id = Convert.ToInt32(txtId.Text);
            produto.Nome = comboNome.Text;
            produto.Descricao = txtDescricao.Text;

            produto.Preco = txtpreco.Text;

            produto.Editar();
            produto = null;
            this.Close();

        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            ProdutoC produto = new ProdutoC();
            produto.Id = Convert.ToInt32(txtId.Text);
            produto.Excluir();
            this.Close();

        }
    }
}
