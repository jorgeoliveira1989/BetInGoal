<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="vermensagens.aspx.cs" Inherits="BetInGoal.vermensagens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <div class="container d-flex justify-content-center align-items-center">
        <div class="p-4 border rounded">

            <h1>Visualizar Mensagens</h1>

            <asp:Repeater ID="rptvermensagens" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Nome</th>
                                <th scope="col">Email</th>
                                <th scope="col">Tipo de Mensagem</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="clienteCard">
                        <td><%# Eval("id_suporte")%></td>
                        <td><%# Eval("nome")%></td>
                        <td><%# Eval("email")%></td>
                        <th scope="row"><%# Eval("assunto")%></th>
                        <td>
                        <a href="https://localhost:44398/tickets.aspx?id_suporte=<%# Eval("id_suporte")%>"><button type="button" class="btn btn-danger">Detalhes</button></a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>


        </div>
    </div>
    <br />
    <br />

</asp:Content>
