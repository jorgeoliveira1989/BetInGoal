<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="addjogo.aspx.cs" Inherits="BetInGoal.addjogo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex justify-content-center align-items-center vh-100">
        <div class="p-4 border rounded" style="max-width: 540px; width: 100%;">

            <h1 class="mb-4 text-center">Jogos Para Prognósticos</h1>

            <!-- Detalhes da Competição e Jornada -->
            <div class="row mb-3">
                <div class="col-md-9">
                    <label for="txt_nome_liga">Competição:</label>
                    <asp:TextBox ID="txt_nome_liga" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txt_jornada">Jornada:</label>
                    <asp:TextBox ID="txt_jornada" runat="server" TextMode="Number" min="1" max="50" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <!-- Separador -->
            <hr />

            <!-- Detalhes do Jogo -->
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txt_data">Data:</label>
                    <asp:TextBox ID="txt_data" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txt_hora">Hora:</label>
                    <asp:TextBox ID="txt_hora" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txt_equipa_casa">Equipa da Casa:</label>
                    <asp:TextBox ID="txt_equipa_casa" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txt_resultado_casa">Resultado Casa:</label>
                    <asp:TextBox ID="txt_resultado_casa" runat="server" CssClass="form-control" min="0" max="15" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txt_resultado_fora">Resultado Fora:</label>
                    <asp:TextBox ID="txt_resultado_fora" runat="server" CssClass="form-control" min="0" max="15" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txt_equipa_fora">Equipa de Fora:</label>
                    <asp:TextBox ID="txt_equipa_fora" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label>Jogo da Jornada:</label>
                    <asp:CheckBox ID="ckb_jogoEspecial" runat="server" />
                </div>
            </div>

            <!-- Botão para Criar Jornada -->
            <div class="text-center">
                <asp:Button ID="btn_criar_jornada" runat="server" Text="Criar Jogo" CssClass="btn btn-danger btn-block" OnClick="btn_criar_jornada_Click" Font-Size="Large" />
            <br />
                <asp:Label ID="lbl_mensagem" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
