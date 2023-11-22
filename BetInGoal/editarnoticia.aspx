<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="editarnoticia.aspx.cs" Inherits="BetInGoal.editarnoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
    <div class="p-4 border rounded bg-light" style="max-width: 540px; width: 100%;">
        <h3 class="mb-4 text-center"><b>Editar Notícia</b></h3>
        <div>
            <div class="mb-3">
                <label for="txtid" class="form-label">ID</label>
                <asp:DropDownList ID="ddl_id" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3">
                <label for="txttitulo" class="form-label">Título</label>
                <asp:TextBox ID="txt_titulo" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNoticia" class="form-label">Notícia</label>
                <asp:TextBox ID="txt_noticia" class="form-control" Rows="3" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="d-grid">
                <asp:Button ID="btn_editar_noticia" class="btn btn-danger w-100" runat="server" Text="Editar Notícia" Font-Bold="True" Font-Size="Medium" />
            </div>
            <br />
            <div class="mb-3">
                <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </div>

        </div>
    </div>
</div>

</asp:Content>
