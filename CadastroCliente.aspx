<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroCliente.aspx.cs" Inherits="CRUDClientes.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Nome:
    <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
    <br />
    CPF:
    <asp:TextBox runat="server" ID="txtCPF"></asp:TextBox>
    <br />
    Endereço:
    <asp:TextBox runat="server" ID="txtEndereco"></asp:TextBox>
    <br />
    <asp:LinkButton runat="server" ID="btnCadastrar" OnClick="btnCadastrar_Click">Cadastrar novo Cliente </asp:LinkButton>
    <asp:LinkButton runat="server" ID="btnTelaPesquisa" OnClick="btnTelaPesquisa_Click">Tela de Pesquisa </asp:LinkButton>
</asp:Content>
