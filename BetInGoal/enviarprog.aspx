<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="enviarprog.aspx.cs" Inherits="BetInGoal.enviarprog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />

    <div class="container d-flex justify-content-center align-items-center">
        <div class="p-4 border rounded bg-light" style="max-width: 1200px; width: 100%;">

            <h1>Prognósticos Disponíveis: </h1>
            <br />
            <asp:Repeater ID="rptprogdisponiveis" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped table-lg">
                        <thead>
                            <tr>
                                <th scope="col">Liga</th>
                                <th scope="col">Jornada</th>
                                <th scope="col">Data</th>
                                <th scope="col">Hora</th>
                                <th scope="col">Equipa Casa</th>
                                <th scope="col">Resultado Casa</th>
                                <th scope="col">Resultado Fora</th>
                                <th scope="col">Equipa Fora</th>
                                <th scope="col">Jogo da Jornada</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="clienteCard">
                        <td><%# Eval("liga")%></td>
                        <td><%# Eval("jornada")%></td>
                        <td><%# Eval("data_jogo")%></td>
                        <td><%# Eval("hora_jogo")%></td>
                        <td><%# Eval("equipa_casa")%></td>
                        <td><%# Eval("resultado_casa")%></td>
                        <td><%# Eval("resultado_fora")%></td>
                        <td><%# Eval("equipa_fora")%></td>
                        <th scope="row"><%# Eval("jogo_estrela_jornada")%></th>
                        <td>
                            <a href="https://localhost:44398/enviaprogjogo.aspx?id_jogo=<%# Eval("id_jogo")%>">
                                <button type="button" class="btn btn-dark">Detalhes</button></a>
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
