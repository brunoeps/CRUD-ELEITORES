using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDClientes
{
    public partial class Clientes : System.Web.UI.Page
    {
        private MySqlConnection conexao;

        protected void Page_Load(object sender, EventArgs e)
        {
            conexao = new MySqlConnection(SiteMaster.conexao);
          
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            conexao.Open();
            var comando = new MySqlCommand("INSERT INTO (dadospessoais) VALUES (@nome)", conexao);
            comando.Parameters.Add(new MySqlParameter("nome", txtNome.Text));
            comando = new MySqlCommand("INSERT INTO (dadospessoais) VALUES (@cpf)", conexao);
            comando.Parameters.Add(new MySqlParameter("cpf", txtCPF.Text));
            comando = new MySqlCommand("INSERT INTO (dadospessoais) VALUES (@endereco)", conexao);
            comando.Parameters.Add(new MySqlParameter("endereco", txtEndereco.Text));
            comando.ExecuteNonQuery();
            conexao.Close();

            SiteMaster.ExibirAlert(this, "Cliente cadastrado com sucesso!");
            txtNome.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
        }

        protected void btnTelaPesquisa_Click(object sender, EventArgs e)
        {

        }
    }
}