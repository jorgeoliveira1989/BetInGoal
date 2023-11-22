<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="aceitarupgrades.aspx.cs" Inherits="BetInGoal.aceitarupgrades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
<div class="p-4 border rounded bg-light">
    <h3 class="mb-4 text-center"><b>Alterar Tipo Conta</b></h3>
    <div>
        <div class="mb-3">
            <label for="txtid" class="form-label">ID</label>
            <asp:DropDownList ID="ddl_id" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="txt_tipoCliente" class="form-label">Tipo Cliente Atual</label>
            <br />
            <asp:Label runat="server" ID="lbl_tipoConta" class="form-control"></asp:Label>
        </div>
        <div class="mb-3">
            <label for="txt_opcao" class="form-label">Alterar Tipo Cliente</label>
            <br />
            <asp:Label runat="server" ID="lbl_altera_cliente" class="form-control"></asp:Label>
        </div>
            <br />
        <div class="d-grid">
            <asp:Button ID="btn_alterar_tipo_cliente" class="btn btn-danger w-100" runat="server" Text="Alterar Tipo Cliente" Font-Bold="True" Font-Size="Medium" />
        </div>
            <br />
        <div class="mb-3">
            <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
   </div>
</div>
</div>

</asp:Content>
