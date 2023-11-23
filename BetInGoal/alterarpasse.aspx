<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="alterarpasse.aspx.cs" Inherits="BetInGoal.alterarpasse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="container d-flex justify-content-center align-items-center">
        <div class="p-4 border rounded bg-light" style="max-width: 550px; width: 100%;">
            <div class="card">
                <div class="card-header bg-primary text-white font-weight-bold">
                    <h3 class="text-center">Alterar Palavra-Passe</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="txtSenhaAtual">Palavra-Passe Atual</label>
                        <asp:TextBox ID="txtSenhaAtual" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtNovaSenha">Nova Palavra-Passe</label>
                        <asp:TextBox ID="txtNovaSenha" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtConfirmarNovaSenha">Confirmar Nova Palavra-Passe</label>
                        <asp:TextBox ID="txtConfirmarNovaSenha" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <br />
                    </div>
                    <asp:Button ID="btnAlterarPasse" runat="server" Text="Alterar Palavra-Passe" CssClass="btn btn-primary" />
                    <br />
                    <br />
                    <asp:Label ID="lblInfo" runat="server" CssClass="mt-3" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
