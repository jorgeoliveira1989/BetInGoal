<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="desativarclientes.aspx.cs" Inherits="BetInGoal.desativarclientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
        <div class="p-4 border rounded bg-light">
            <h3 class="mb-4 text-center"><b>Desativar Cliente</b></h3>
                <div>
            <div class="mb-3">
                 <label for="txtid" class="form-label">ID</label>
                <asp:DropDownList ID="ddl_id" runat="server">

                </asp:DropDownList>
                </div>
                    <div class="mb-3">
                        <label for="txtCliente" class="form-label">Nome</label>
                        <br />
                        <asp:Label runat="server" ID="lbl_cliente" class="form-control"></asp:Label>
                    </div>
                <br />
                    <div class="d-grid">
                        <asp:Button ID="btn_desativar_cliente" class="btn btn-danger w-100" runat="server" Text="Desativar Cliente" Font-Bold="True" Font-Size="Medium" />
                                </div>
            <br />
        <div class="mb-3">
            <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
   </div>
</div>
</div>

</asp:Content>
