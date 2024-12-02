using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleEstroqueV._3.Classes;
using MySql.Data.MySqlClient;

namespace ControleEstroqueV._3.Dao
{
    public class ProdutoDao
    {
        private string LinhaConexao = "Server=localhost;Database=controleestoque;Uid=root;Password=;";
        private MySqlConnection Conexao;
        public ProdutoDao()
        {
            Conexao = new MySqlConnection(LinhaConexao);
        }

        public DataTable PreencherComboBox()
        {
            DataTable dataTable = new DataTable();

            string query = "SELECT Id, Nome FROM produto";

            using (MySqlConnection connection = new MySqlConnection(LinhaConexao))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                try
                {
                    // Preenche o DataTable com os dados da consulta
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // Lida com erros, se necessário
                    throw new Exception("Erro ao acessar os dados: " + ex.Message);
                }
            }

            return dataTable;
        }
        public DataTable ObterProdutos()
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "SELECT Id, Nome, Descricao, Preco FROM produto Order by Id desc";
            MySqlCommand comando = new MySqlCommand(query, Conexao);

            MySqlDataReader Leitura = comando.ExecuteReader();

            foreach (var atributos in typeof(ProdutoC).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }

            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    ProdutoC p = new ProdutoC();
                    p.Id = Convert.ToInt32(Leitura[0]);
                    p.Nome = Leitura[1].ToString();
                    p.Descricao = Leitura[2].ToString();
                    p.Preco = Leitura[3].ToString();
                    dt.Rows.Add(p.Linha());
                }
            }
            Conexao.Close();
            return dt;
        }
        public DataTable Pesquisar(string pesquisa)
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "";
            if (string.IsNullOrEmpty(pesquisa))
            {
                query = "SELECT Id, Nome, Descricao, Quantidade,Preco FROM produtos Order by Id desc";
            }
            else
            {
                query = "SELECT Id, Nome, Descricao, Quantidade,Preco FROM produtos Where Nome like '%" + pesquisa + "%' Order by Id desc";
            }
            MySqlCommand comando = new MySqlCommand(query, Conexao);

            MySqlDataReader Leitura = comando.ExecuteReader();

            foreach (var atributos in typeof(ProdutoC).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }

            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    ProdutoC p = new ProdutoC();
                    p.Id = Convert.ToInt32(Leitura[0]);
                    p.Nome = Leitura[1].ToString();
                    p.Descricao = Leitura[2].ToString();
                    p.Preco = Leitura[3].ToString();
                    dt.Rows.Add(p.Linha());
                }
            }
            Conexao.Close();
            return dt;
        }
        public void Inserir(ProdutoC p)
        {
            try
            {
                Conexao.Open();
                string query = "INSERT INTO produto (Nome, Descricao, Preco) VALUES (@nome, @descricao, @preco)";
                MySqlCommand comando = new MySqlCommand(query, Conexao);

                comando.Parameters.Add(new MySqlParameter("@nome", p.Nome));
                comando.Parameters.Add(new MySqlParameter("@descricao", p.Descricao));
                comando.Parameters.Add(new MySqlParameter("@preco", decimal.Parse(p.Preco)));

                comando.ExecuteNonQuery();

                // MessageBox.Show("Produto inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Erro ao inserir produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexao.Close();
            }
        }





    }
}
