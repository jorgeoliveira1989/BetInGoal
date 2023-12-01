<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="entrarliga.aspx.cs" Inherits="BetInGoal.entrarliga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <div class="container d-flex justify-content-center align-items-center">
        <div class="p-4 border rounded bg-light" style="max-width: 540px; width: 100%;">

            <h1>Visualizar Ligas</h1>

            <asp:Repeater ID="rptEntrarLiga" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Nome Liga</th>
                                <th scope="col">Criador da Liga</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="ligasCard">
                        <td><%# Eval("IdLiga")%></td>
                        <td><%# Eval("NomeLiga")%></td>
                        <td><%# Eval("NomeCliente")%></td>
                        <td>
                            <a href="https://localhost:44398/detalhe_ligas.aspx?id_liga=<%# Eval("IdLiga")%>">
                                <button type="button" class="btn btn-primary">Detalhes</button></a>
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
    <br />
    <br />

</asp:Content>
