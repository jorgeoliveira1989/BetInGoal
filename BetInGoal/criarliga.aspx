<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="criarliga.aspx.cs" Inherits="BetInGoal.criarliga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
    <br />
     <br />
 <br />
            <div class="container d-flex justify-content-center align-items-center">
    <div class="p-4 border rounded bg-light" style="max-width: 540px; width: 100%;">
        <h3 class="mb-4 text-center"><b>Criar Liga</b></h3>
        <div>
            <div class="mb-3">
                <label for="txtnome" class="form-label">Nome da Liga:</label>
                <asp:TextBox ID="txt_nome" class="form-control" runat="server"></asp:TextBox>
            </div>
            
            <div class="d-grid">
                <asp:Button ID="btn_criar_liga" class="btn btn-danger w-100" runat="server" Text="Criar Liga" Font-Bold="True" Font-Size="Medium" />
            </div>
            <br />
            <div class="mb-3">
                <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
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

</asp:Content>
