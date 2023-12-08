<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="enviaprogjogo.aspx.cs" Inherits="BetInGoal.enviaprogjogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />

    <div class="container d-flex justify-content-center align-items-center">
        <div class="p-4 border rounded bg-light" style="max-width: 550px; width: 100%;">

            <h1 class="mb-4 text-center">
    <%= $"{lbl_equipa_casa.Text} vs {lbl_equipa_fora.Text}" %>
</h1>

            <!-- Detalhes para fechar jogo -->
            <div class="row mb-3">
                <div class="col-md-9">
                    <label for="txt_nome_liga">Competição:</label>
                    <asp:Label ID="lbl_nome_liga" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
                <div class="col-md-3">
                    <label for="txt_jornada">Jornada:</label>
                    <asp:Label ID="lbl_jornada" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>

            <!-- Separador -->
            <hr />

            <!-- Detalhes do Jogo -->
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txt_data">Data:</label>
                    <asp:Label ID="lbl_data" runat="server" Text="" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-6">
                    <label for="txt_hora">Hora:</label>
                    <asp:Label ID="lbl_hora" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txt_equipa_casa">Equipa da Casa:</label>
                    <asp:Label ID="lbl_equipa_casa" runat="server" Text="" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-3">
                    <label for="txt_resultado_casa">Resultado Casa:</label>
                    <asp:TextBox ID="txt_resultado_casa" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label for="txt_resultado_fora">Resultado Fora:</label>
                    <asp:TextBox ID="txt_resultado_fora" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txt_equipa_fora">Equipa de Fora:</label>
                    <asp:Label ID="lbl_equipa_fora" runat="server" Text="" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-6">
                    <label>Jogo da Jornada:</label>
                    <asp:Label ID="lbl_jogo_especial" runat="server" CssClass="form-control" Text=""></asp:Label>
                </div>
            </div>

            <!-- Botão para Criar Jornada -->
            <div class="text-center">
                <asp:Button ID="btn_voltar" runat="server" Text="Voltar" CssClass="btn btn-danger btn-block" OnClick="btn_voltar_Click" />
                <asp:Button ID="btn_enviar_prog" runat="server" Text="Enviar Prognóstico" CssClass="btn btn-primary btn-block" OnClick="btn_enviar_prog_Click" Font-Size="Large" />
                <br /><br />
                <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
    <br />
    <br />

</asp:Content>
