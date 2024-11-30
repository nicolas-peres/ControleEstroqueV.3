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
    public class CompraC
    {
        private MySqlConnection Conexao = new MySqlConnection("Server=localhost;Database=projetocsharp;User Id=root;Password=");
        public int Id { get; set; }
        public DateTime DataC { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public float Total { get; set; }
        public object[] Linha()
        {
            return new object[] { Id, DataC, Produto, Quantidade, Total};
        }

        public CompraC()
        {
            DataC = DateTime.Now; // Data atual como padrão
        }
        public void Inserir()
        {
            Conexao.Open();
            string query = "Insert into Usuarios (DataC , Produto, Quantidade, Total) " +
                "               Values (@dataC, @produto, @quantidade, @total) ";
            MySqlCommand comando = new MySqlCommand(query, Conexao);

            MySqlParameter parametro1 = new MySqlParameter("@dataC", DataC);
            MySqlParameter parametro2 = new MySqlParameter("@produto", Produto);
            MySqlParameter parametro3 = new MySqlParameter("@quantidade", Quantidade);
            MySqlParameter parametro4 = new MySqlParameter("@total", Total);

            comando.Parameters.Add(parametro1);
            comando.Parameters.Add(parametro2);
            comando.Parameters.Add(parametro3);
            comando.Parameters.Add(parametro4);
            comando.ExecuteNonQuery();
            Conexao.Close();
        }
        public DataTable PreencherGrid()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT Id, DataC , Produto, Quantidade, Total FROM Compra order by Id desc";
            Conexao.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, Conexao);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar os dados para preencher grid: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Conexao.Close();
            return dataTable;
        }
    }
}
