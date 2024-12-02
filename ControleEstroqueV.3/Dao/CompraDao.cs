using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleEstroqueV._3.Classes;
using ControleEstroqueV._3.Formularios;
using MySql.Data.MySqlClient;

namespace ControleEstroqueV._3.Dao
{
    public class CompraDao
    {
        private string LinhaConexao = "Server=localhost;Database=controleestoque;Uid=root;Password=;";
        private MySqlConnection Conexao;

        public CompraDao()
        {
            Conexao = new MySqlConnection(LinhaConexao);
        }

        // Método para preencher ComboBox com produtos disponíveis
        public DataTable PreencherComboBox()
        {
            DataTable dataTable = new DataTable();

            string query = "SELECT Id, Produto FROM compra";

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

        // Método para obter todas as compras realizadas
        public DataTable ObterCompras()
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "SELECT Id, DataC, Produto, Quantidade, Subtotal FROM compras ORDER BY Id DESC";
            MySqlCommand comando = new MySqlCommand(query, Conexao);

            MySqlDataReader Leitura = comando.ExecuteReader();

            foreach (var atributos in typeof(CompraC).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }

            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    CompraC c = new CompraC();
                    c.Id = Convert.ToInt32(Leitura[0]);
                    c.DataC = Convert.ToDateTime(Leitura[1]);
                    c.Produto = Leitura[2].ToString();
                    c.Total = float.Parse(Leitura[3].ToString());
                    dt.Rows.Add(c.Linha());
                }
            }
            Conexao.Close();
            return dt;
        }

        // Método para pesquisar compras com base no nome do produto
        public DataTable Pesquisar(string pesquisa)
        {
            DataTable dt = new DataTable();
            Conexao.Open();
            string query = "";
            if (string.IsNullOrEmpty(pesquisa))
            {
                query = "SELECT Id, DataC, Produto, Quantidade, Subtotal FROM compras ORDER BY Id DESC";
            }
            else
            {
                query = "SELECT Id, DataC, Produto, Quantidade, Subtotal FROM compras WHERE Produto LIKE '%" + pesquisa + "%' ORDER BY Id DESC";
            }
            MySqlCommand comando = new MySqlCommand(query, Conexao);

            MySqlDataReader Leitura = comando.ExecuteReader();

            foreach (var atributos in typeof(CompraC).GetProperties())
            {
                dt.Columns.Add(atributos.Name);
            }

            if (Leitura.HasRows)
            {
                while (Leitura.Read())
                {
                    CompraC c = new CompraC();
                    c.Id = Convert.ToInt32(Leitura[0]);
                    c.DataC = Convert.ToDateTime(Leitura[1]);
                    c.Produto = Leitura[2].ToString();
                    c.Total = float.Parse(Leitura[3].ToString());
                    dt.Rows.Add(c.Linha());
                }
            }
            Conexao.Close();
            return dt;
        }

        // Método para inserir uma nova compra
        public void Inserir(CompraC c)
        {
            try
            {
                Conexao.Open();
                string query = "INSERT INTO compras (DataC, Produto, Quantidade, Subtotal) VALUES (@data, @produto, @quantidade, @subtotal)";
                MySqlCommand comando = new MySqlCommand(query, Conexao);

                comando.Parameters.Add(new MySqlParameter("@data", c.DataC));
                comando.Parameters.Add(new MySqlParameter("@produto", c.Produto));
                comando.Parameters.Add(new MySqlParameter("@quantidade", c.Quantidade));
                comando.Parameters.Add(new MySqlParameter("@subtotal", c.Total));

                comando.ExecuteNonQuery();

                // Mensagem de sucesso (opcional)
                // MessageBox.Show("Compra registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Mensagem de erro (opcional)
                // MessageBox.Show("Erro ao registrar compra: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexao.Close();
            }
        }
    }
}
