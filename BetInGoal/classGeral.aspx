<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="classGeral.aspx.cs" Inherits="BetInGoal.classGeral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="container d-flex justify-content-center align-items-center">
    <div class="p-4 border rounded bg-light">
        <h5>Ranking:</h5><asp:DropDownList ID="ddl_filtro" runat="server">
        <asp:ListItem>------------</asp:ListItem>
        <asp:ListItem>TOP 100</asp:ListItem>
        <asp:ListItem>TOP 50</asp:ListItem>
        <asp:ListItem>TOP 10</asp:ListItem>
        <asp:ListItem>TOP 3</asp:ListItem>

            </asp:DropDownList>
        <br />
        <br />
        <h3>CLASSIFICAÇÃO GERAL</h3>
        <asp:Repeater ID="rpt_classificacao" runat="server">
            <HeaderTemplate>
                 <table border="1" width="1000">
                     <table class="table table-striped">
                        <thead>
                            <tr>
                              <th scope="col">Utilizador</th>
                              <th scope="col">Total Pontos</th>
                              <th scope="col">Nome da Liga</th>
                            </tr>
                        </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                      <td><%# Eval("username")%></td>
                      <td><%# Eval("total_pontos")%></td>
                      <th scope="row"><%# Eval("nome_da_liga")%></th>
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
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
     <br />
    <br />
</asp:Content>
