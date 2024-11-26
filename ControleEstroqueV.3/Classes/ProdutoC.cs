using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ControleEstroqueV._3.Classes
{
    public class ProdutoC
    {
        private MySqlConnection Conexao = new MySqlConnection("Server=localhost;Database=projetocsharp;User Id=root;Password=");
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }

        public object[] Linha()
        {
            return new object[] { Id, Nome, Descricao, Preco, };
        }

        public DataTable ObterProdutos()
        {
            DataTable dataTable = new DataTable();

            try
            {
                Conexao.Open();
                string query = "SELECT Id, Nome, Descricao, Preco FROM Produto";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, Conexao);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexao.Close();
            }

            return dataTable;
        }

        public void Excluir()
        {
            string query = "Delete from Usuarios WHERE  Id = @id";
            Conexao.Open();
            MySqlCommand comando = new MySqlCommand(query, Conexao);
            comando.Parameters.Add(new MySqlParameter("@id", Id));
            int resposta = comando.ExecuteNonQuery();
            if (resposta == 1)
            {
                MessageBox.Show("Usuário Excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao excluir", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Editar()
        {
            string query = "update Usuarios set Nome = @nome, Descricao = @descricao, Preco = @preco,   WHERE  Id = @id";
            Conexao.Open();
            MySqlCommand comando = new MySqlCommand(query, Conexao);
            comando.Parameters.Add(new MySqlParameter("@nome", Nome));
            comando.Parameters.Add(new MySqlParameter("@Descricao", Descricao));
            comando.Parameters.Add(new MySqlParameter("@preco", Preco));

            comando.Parameters.Add(new MySqlParameter("@id", Id));
            int resposta = comando.ExecuteNonQuery();
            if (resposta == 1)
            {
                MessageBox.Show("Usuário Atualizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao atualizar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PesquisarPorId(int id)
        {
            DataTable dataTable = new DataTable();
            Conexao.Open();
            string query = "SELECT Id, Nome, Quantidade, Nome FROM Usuarios Where Id = @id Order by Id desc";
            MySqlCommand Comando = new MySqlCommand(query, Conexao);
            Comando.Parameters.AddWithValue("@id", id);
            MySqlDataReader resultado = Comando.ExecuteReader();

            if (resultado.Read())
            {
                Id = resultado.GetInt32(0);
                Nome = resultado.GetString(1);

                Descricao = resultado.GetString(3);
                Preco = resultado.GetString(4);
            }

            Conexao.Close();
        }
    }
}
