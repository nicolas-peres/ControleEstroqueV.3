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

namespace ControleEstroqueV._3.Formularios
{
    public partial class FrmCadastrarUsuario : Form
    {
        public FrmCadastrarUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuarioC u = new UsuarioC();
            u.Login = txtLogin.Text;
            u.Senha = txtSenha.Text;
            u.Ativo = ChkAtivo.Checked;
            u.Inserir();
            MessageBox.Show("Sucesso", "Cadastrado com sucesso");
            Close();
        }
    }
}
