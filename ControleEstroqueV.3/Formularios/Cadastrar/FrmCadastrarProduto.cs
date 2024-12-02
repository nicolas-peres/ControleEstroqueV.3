using ControleEstroqueV._3.Classes;
using ControleEstroqueV._3.Dao;
using MySqlX.XDevAPI;
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
    public partial class FrmCadastrarProduto : Form
    {
        ProdutoDao dao = new ProdutoDao();
        int LinhaSelecionada;
        DataTable dados;
        public FrmCadastrarProduto()
        {
            InitializeComponent();
            dados = new DataTable();
            foreach (var atributos in typeof(ProdutoC).GetProperties())
            {
                dados.Columns.Add(atributos.Name);
            }

            dados = dao.ObterProdutos();

            dtGridProduto.DataSource = dados;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ProdutoC p = new ProdutoC();
            p.Id = Convert.ToInt32(numId.Value);
            p.Nome = comboNome.Text;
            p.Descricao = txtDescricao.Text;
            p.Preco = txtPreco.Text;


            dao.Inserir(p);
            dtGridProduto.DataSource = dao.ObterProdutos();
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtPreco.Text = "";
            txtDescricao.Text = "";
            comboNome.Text = "";
            numQtd.Value = 0;
            numId.Value = 0;
        }

        private void comboNome_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
