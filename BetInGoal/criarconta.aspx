<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="criarconta.aspx.cs" Inherits="BetInGoal.criarconta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-4">
            <div class="card p-4" style="background-color: #f8f9fa;">
                <div class="card-body">
                    <h3 class="card-title text-center mb-4"><b>Criar Conta</b></h3>
                        <div class="mb-3">
                            <label for="username" class="form-label">Primeiro e Último nome</label>
                            <asp:TextBox ID="txt_nome" class="form-control" placeholder="Indique o seu nome" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label">Email</label>
                            <asp:TextBox ID="txt_email" class="form-control" placeholder="Indique a seu Email" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="datanascimento" class="form-label">Data de Nascimento</label>
                            <asp:TextBox ID="txt_datanascimento" class="form-control" placeholder="Indique a data de nascimento" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                             <label for="username" class="form-label">Utilizador</label>
                             <asp:TextBox ID="txt_utilizador" class="form-control" placeholder="Indique o nome de Utilizador" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                             <label for="password" class="form-label">Palavra-Passe</label>
                             <asp:TextBox ID="txt_passe" class="form-control" placeholder="Indique a palavra-passe" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="password" class="form-label">Confirmar Palavra-Passe</label>
                            <asp:TextBox ID="txt_confpasse" class="form-control" placeholder="Confirme a palavra-passe" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    <br />
                        <div class="text-center">
                            <asp:Button ID="btn_criar_conta" runat="server" Text="Criar Conta" class="btn btn-primary btn-lg w-100" onclick="btn_criar_conta_Click" />
                        <br />
                        <br />
                            <asp:Label ID="lbl_info" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </div>  
                </div>
            </div>
        </div>
    </div>
</div>
    <br /><br />
</asp:Content>
