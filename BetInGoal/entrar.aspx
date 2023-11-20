<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="entrar.aspx.cs" Inherits="BetInGoal.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-4">
            <div class="card p-4" style="background-color: #f8f9fa;">
                <div class="card-body">
                    <h3 class="card-title text-center mb-4"><b>Entrar na Conta</b></h3>
                    
                        <div class="mb-3">
                            <label for="username" class="form-label">Utilizador</label>
                            <asp:TextBox ID="txt_user" class="form-control" placeholder="Indique o nome de utilizador" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="password" class="form-label">Palavra-Passe </label>
                            &nbsp;<asp:TextBox ID="txt_passe" class="form-control" placeholder="Indique a sua Palavra-passe" runat="server" TextMode="Password" TabIndex="1" ></asp:TextBox>
                        </div>
                    <br />
                        <div class="text-center">
                            <asp:Button ID="btn_entra" runat="server" Text="Entrar" class="btn btn-secondary btn-lg w-100" onclick="btn_entra_Click" />
                        <br />
                        <br />
                            <a href="criarconta.aspx" class="btn btn-primary btn-lg w-100">Criar Conta</a>
                        <br />
                        <br />
                            <a href="recuperarpasse.aspx">Não sabes a tua palavra-passe?</a>
                        <br />
                        <br />
                            <asp:Label ID="lbl_info" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </div>  
                </div>
            </div>
        </div>
    </div>
</div>
<br />
    <br />
    <br />
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.9/dist/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
