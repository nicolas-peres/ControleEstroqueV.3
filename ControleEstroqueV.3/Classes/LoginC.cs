﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ControleEstroqueV._3.Classes
{
    public class LoginC
    {
        private MySqlConnection Conexao = new MySqlConnection("Server=localhost;Database=projetocsharp;User Id=root;Password=");
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public bool Logar()
        {
            string query = "Select Login, Id from usuarios where Senha = @senha AND Login = @login";
            Conexao.Open();
            MySqlCommand comando = new MySqlCommand(query, Conexao);
            comando.Parameters.Add(new MySqlParameter("@senha", Senha));
            comando.Parameters.Add(new MySqlParameter("@login", Usuario));
            MySqlDataReader resultado = comando.ExecuteReader();

            if (resultado.HasRows)
            {
                Conexao.Close();
                return true;
            }
            else
            {
                Conexao.Close();
                return false;
            }
        }
    }

}