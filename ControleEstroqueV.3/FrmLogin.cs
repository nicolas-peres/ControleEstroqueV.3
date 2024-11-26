using ControleEstroqueV._3.Classes;
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
    public partial class FrmLogin : Form
    {
        private LoginC login;
        public FrmLogin()
        {
            InitializeComponent();
            login = new LoginC();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            login.Usuario = txtLogin.Text;
            login.Senha = txtSenha.Text;

            if (login.Logar())
            {
                Principal p = new Principal();
                p.FormClosed += FecharForm;
                this.Hide();
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtLogin.Focus();
                p.Show();
            }
            else
            {
                MessageBox.Show("Usuário e senha inválidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FecharForm(object sender, FormClosedEventArgs e)
        {
            Visible = true;
        }
        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEntrar_Click(sender, e);
            }
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnCriar_Click(object sender, EventArgs e)
        {
            FrmCadastrarUsuario u = new FrmCadastrarUsuario();
            u.ShowDialog();
        }

        private void btnFunci_Click(object sender, EventArgs e)
        {

        }
    }
    }

