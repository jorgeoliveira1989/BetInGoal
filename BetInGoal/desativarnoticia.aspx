<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="desativarnoticia.aspx.cs" Inherits="BetInGoal.desativarnoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
        <div class="p-4 border rounded bg-light" style="max-width: 540px; width: 100%;">
            <h3 class="mb-4 text-center"><b>Desativar Notícia</b></h3>
                <div>
            <div class="mb-3">
                 <label for="txtid" class="form-label">ID</label>
                <asp:DropDownList ID="ddl_id" runat="server">

                </asp:DropDownList>
                </div>
                    <div class="mb-3">
                        <label for="txttitulo" class="form-label">Título</label>
                        <br />
                        <asp:Label runat="server" ID="lbl_titulo" class="form-control"></asp:Label>
                    </div>
                <br />
                    <div class="d-grid">
                        <asp:Button ID="btn_desativar_noticia" class="btn btn-danger w-100" runat="server" Text="Desativar Notícia" Font-Bold="True" Font-Size="Medium" />
                                </div>
            <br />
        <div class="mb-3">
            <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
   </div>
</div>
</div>

</asp:Content>
