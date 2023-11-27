<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="criarnoticia.aspx.cs" Inherits="BetInGoal.criarnoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
    <div class="p-4 border rounded bg-light" style="max-width: 540px; width: 100%;">
        <h3 class="mb-4 text-center"><b>Criar Nova Notícia</b></h3>
        <div>
            <div class="mb-3">
                <label for="txtTitulo" class="form-label">Título</label>
                <asp:TextBox ID="txt_titulo" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtconteudo" class="form-label">Notícia</label>
                <asp:TextBox ID="txt_conteudo" class="form-control" Rows="5" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="d-grid">
                <asp:Button ID="btn_criar_noticia" class="btn btn-danger w-100" runat="server" Text="Adicionar Notícia" Font-Bold="True" Font-Size="Medium" OnClick="btn_criar_noticia_Click" />
            </div>
            <br />
            <div class="mb-3">
                <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </div>

        </div>
    </div>
</div>

</asp:Content>
