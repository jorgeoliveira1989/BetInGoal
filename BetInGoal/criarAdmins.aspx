<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="criarAdmins.aspx.cs" Inherits="BetInGoal.criarAdmins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h1 class="text-center">Criar Conta Admin</h1>
                            <div class="form-group">
                                <label for="txt_nome">Nome:</label>
                                <asp:TextBox runat="server" ID="txt_nome" CssClass="form-control" placeholder="Digite seu nome" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvNome" ControlToValidate="txt_nome" ErrorMessage="Campo obrigatório." Display="Dynamic" CssClass="text-danger" />
                            </div>
                            <div class="form-group">
                                <label for="txt_email">Email:</label>
                                <asp:TextBox runat="server" ID="txt_email" CssClass="form-control" placeholder="Digite seu email" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txt_email" ErrorMessage="Campo obrigatório." Display="Dynamic" CssClass="text-danger" />
                                <asp:RegularExpressionValidator runat="server" ID="revEmail" ControlToValidate="txt_email" ErrorMessage="Formato de email inválido." Display="Dynamic" CssClass="text-danger" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            </div>
                            <div class="form-group">
                                <label for="txt_utilizador">Utilizador:</label>
                                <asp:TextBox runat="server" ID="txt_utilizador" CssClass="form-control" placeholder="Digite seu utilizador" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvUtilizador" ControlToValidate="txt_utilizador" ErrorMessage="Campo obrigatório." Display="Dynamic" CssClass="text-danger" />
                            </div>
                            <div class="form-group">
                                <label for="txt_palavra_passe">Palavra-passe:</label>
                                <asp:TextBox runat="server" ID="txt_palavra_passe" TextMode="Password" CssClass="form-control" placeholder="Digite sua palavra-passe" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvPalavraPasse" ControlToValidate="txt_palavra_passe" ErrorMessage="Campo obrigatório." Display="Dynamic" CssClass="text-danger" />
                            </div>
                            <div class="form-group">
                                <label for="txt_conf_palavra_passe">Confirmar palavra-passe:</label>
                                <asp:TextBox runat="server" ID="txt_conf_palavra_passe" TextMode="Password" CssClass="form-control" placeholder="Confirme sua palavra-passe" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvConfPalavraPasse" ControlToValidate="txt_conf_palavra_passe" ErrorMessage="Campo obrigatório." Display="Dynamic" CssClass="text-danger" />
                                <asp:CompareValidator runat="server" ID="cvConfirmaPalavraPasse" ControlToValidate="txt_conf_palavra_passe" ControlToCompare="txt_palavra_passe" Operator="Equal" ErrorMessage="As palavras-passe não coincidem." Display="Dynamic" CssClass="text-danger" />
                            </div>
                            <asp:Button runat="server" ID="btn_criar_conta" CssClass="btn btn-danger btn-block" Text="Criar Conta Admin" OnClientClick="return criarContaAdmin();" onclick="btn_criar_conta_Click" />
                        </div>
                        <asp:Label ID="lbl_info" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
