using CRUDClientes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace CRUDClientes
{
    public partial class PesquisaCliente : System.Web.UI.Page
    {
        private MySqlConnection _conexao;
        protected void Page_Load(object sender, EventArgs e)
        {
            _conexao = new MySqlConnection(SiteMaster.conexao);
        }

        protected void gridClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var tabela = (DataTable)Session["tabela"];
            var index = (gridClientes.PageSize * gridClientes.PageCount) + (int)e.CommandArgument;
            var id = (index >= 0)? tabela.Rows[index]["id"].ToString() : "";

            if (e.CommandName == "editar")
            {
                Response.Redirect("EditarCliente.aspx?id=" + id);
            }

            if (e.CommandName == "excluir")
            {
                new MySqlCommand("DELETE FROM Dadospessoais WHERE id = " + id, _conexao).ExecuteNonQuery();
                lnkPesquisar_Click(null, null);
            }
        }

        protected void lnkPesquisar_Click(object sender, EventArgs e)
        {
            _conexao.Open();
            var command = new MySqlCommand("SELECT * FROM Dadospessoais WHERE (1=1) ", _conexao);

            if (txtNome.Text != "")
            {
                command.CommandText = command.CommandText + " AND nome like @nome";
                command.Parameters.Add(new MySqlParameter("nome", "%" + txtNome.Text + "%"));
            }
            if (txtCPF.Text != "")
            {
                command.CommandText = command.CommandText + " AND cpf like @cpf";
                command.Parameters.Add(new MySqlParameter("cpf", "%" + txtCPF.Text + "%"));
            }
         

            var tabela = new DataTable();
            tabela.Columns.Add("nome");
            tabela.Columns.Add("cpf");
            tabela.Columns.Add("endereco");
            tabela.Columns.Add("id");

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var linha = tabela.NewRow();
                linha["nome"] = reader.GetString("nome");
                linha["cpf"] = reader.GetString("cpf");
                linha["endereco"] = reader.GetString("endereco");
                linha["id"] = reader.GetInt32("id").ToString();
                tabela.Rows.Add(linha);
            }

            Session["tabela"] = tabela;
            gridClientes.DataSource = tabela;
            gridClientes.DataBind();
        }

        protected void lnkCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroCliente.aspx");
        }
    }
}