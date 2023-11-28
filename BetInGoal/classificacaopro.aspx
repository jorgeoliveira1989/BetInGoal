<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="classificacaopro.aspx.cs" Inherits="BetInGoal.classificacaopro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
    <br />
        <div class="container d-flex justify-content-center align-items-center">
    <div class="p-4 border rounded">

    <h1>Classificação PRO</h1>

        <h5>Ranking</h5><asp:DropDownList AppendDataBoundItems="true"  class="mb-3" ID="ddl_filtro" runat="server">
<asp:ListItem>------------</asp:ListItem>
<asp:ListItem>TOP 100</asp:ListItem>
<asp:ListItem>TOP 50</asp:ListItem>
<asp:ListItem>TOP 10</asp:ListItem>
<asp:ListItem>TOP 3</asp:ListItem>

    </asp:DropDownList>
        <asp:Repeater ID="rptClasspro" runat="server">
                <HeaderTemplate>
         <table border="1" width="1000">
             <table class="table table-striped">
                <thead>
                    <tr>
                      <th scope="col">Classificação</th>
                      <th scope="col">Utilizador</th>
                      <th scope="col">Tipo Conta</th>
                      <th scope="col">Pontos</th>
                    </tr>
                </thead>
    </HeaderTemplate>
    <ItemTemplate>
        <tbody>
            <tr>
              <td><%# Eval("Classificacao")%>º Lugar</td>
              <td><%# Eval("username")%></td>
              <td><%# Eval("TipoCliente")%></td>
              <th scope="row"><%# Eval("TotalPontos")%></th>
            </tr>
        </tbody>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>


</div>
</div>
<br />
    <br />
</asp:Content>
