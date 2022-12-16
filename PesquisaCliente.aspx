<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PesquisaCliente.aspx.cs" Inherits="CRUDClientes.PesquisaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Nome:
    <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
    CPF:
    <asp:TextBox runat="server" ID="txtCPF"></asp:TextBox>
    Endereço:
    <asp:TextBox runat="server" ID="txtEdnereco"></asp:TextBox>
    <asp:LinkButton runat="server" ID="lnkPesquisar" OnClick="lnkPesquisar_Click">Pesquisar Cliente</asp:LinkButton>
    <asp:LinkButton runat="server" ID="lnkCadastrar" OnClick="lnkCadastrar_Click">Cadastrar Cliente</asp:LinkButton>

    <asp:GridView runat="server" ID="gridClientes" AllowPaging="false" AutoGenerateColumns="false" OnRowCommand="gridClientes_RowCommand">
        <Columns>
            <asp:BoundField DataField="nome" HeaderText="NOME" />
            <asp:BoundField DataField="cpf" HeaderText="CPF" />
            <asp:BoundField DataField="endereco" HeaderText="ENDEREÇO" />
            <asp:ButtonField CommandName="editar" Text="Editar" />
            <asp:ButtonField CommandName="excluir" Text="Excluir" />
        </Columns>
    </asp:GridView>
</asp:Content>
