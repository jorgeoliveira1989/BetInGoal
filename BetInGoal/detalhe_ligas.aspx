﻿<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="detalhe_ligas.aspx.cs" Inherits="BetInGoal.detalhe_ligas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-5">
    <h1>Detalhes da Liga</h1>
    <hr />

    <div class="row">
        <div class="col-md-3">
            <!-- Detalhes da Liga -->
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Nome da Liga</h5>
                    <asp:Label ID="lbl_nome_liga" runat="server" CssClass="font-weight-bold larger-font" Text=""></asp:Label><br />
                    <h5 class="card-title">Criador da Liga</h5>
                    <asp:Label ID="lbl_criador_liga" runat="server" CssClass="font-weight-bold larger-font" Text=""></asp:Label><br />
                    <h5 class="card-title">Limite de Amigos</h5>
                    <asp:Label ID="lbl_limite_liga" runat="server" Text=""></asp:Label>/<asp:Label ID="lbl_total_clientes_liga" runat="server" Text=""></asp:Label><br /><br />
                    <asp:Button ID="btn_adiciona_liga" runat="server" CssClass="btn btn-primary btn-lg" Text="Entrar na Liga" OnClick="btn_adiciona_liga_Click" />
                    <br /><br />
                    <asp:Button ID="btn_voltar" CssClass="btn btn-danger btn-lg" runat="server" Text="<< Voltar" OnClick="btn_voltar_Click" />
                    <br /><br />
                    <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-9">
            <!-- Lista de Pessoas na Liga -->
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Lista de Pessoas na Liga</h5>
                    <ul class="list-group" runat="server" id="listaPessoas">
                        <asp:Repeater ID="rpt_amigos_liga" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th scope="col">Nome Amigo</th>
                                            <th scope="col">Nome Liga</th>
                                            <th scope="col">Pontos Individuais</th>
                                            <th scope="col">Pontos Jornada</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("NomeAmigo")%></td>
                                    <td><%# Eval("NomeLiga")%></td>
                                    <td><%# Eval("PontosIndividuais")%></td>
                                    <td><%# Eval("PontosJornada")%></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                                    </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
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
</asp:Content>
