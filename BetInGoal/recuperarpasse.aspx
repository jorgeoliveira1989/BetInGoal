<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="recuperarpasse.aspx.cs" Inherits="BetInGoal.recuperarpasse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container mt-5">
    <div class="row justify-content-center">
        <div class="col-md-4">
            <div class="card p-4" style="background-color: #f8f9fa;">
                <div class="card-body">
                    <h3 class="card-title text-center mb-4"><b>Recuperar Passe</b></h3>
                    
                        <div class="mb-3">
                            <label for="username" class="form-label">Utilizador</label>
                            <asp:TextBox ID="txt_user" class="form-control" placeholder="Indique o nome de utilizador" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label">Email</label>
                            <asp:TextBox ID="txt_email" class="form-control" placeholder="Indique o seu email" runat="server"></asp:TextBox>
                        </div>
                    <br />
                        <div class="text-center">
                            <asp:Button ID="btn_recupera_conta" runat="server" Text="Recuperar Passe" class="btn btn-secondary btn-lg w-100" onclick="btn_recupera_conta_Click"/>
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

</asp:Content>
