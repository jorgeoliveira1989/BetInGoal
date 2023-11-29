<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="editarnoticia.aspx.cs" Inherits="BetInGoal.editarnoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
    <div class="p-4 border rounded bg-light" style="max-width: 540px; width: 100%;">
        <h3 class="mb-4 text-center"><b>Editar Notícia</b></h3>
        <div>
            <div class="mb-3">
                <label for="txtid" class="form-label"><b>ID</b></label>
                <asp:DropDownList ID="ddl_id" runat="server" AutoPostBack="True" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="id_noticia" DataValueField="id_noticia" OnSelectedIndexChanged="ddl_id_SelectedIndexChanged">
                    <asp:ListItem>-----</asp:ListItem>
                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BetinGoalConnectionString %>" SelectCommand="SELECT [id_noticia] FROM [noticias]"></asp:SqlDataSource>

            </div>
            <div class="mb-3">
                <label for="txttitulo" class="form-label"><b>Título</b></label>
                <asp:TextBox ID="txt_titulo" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNoticia" class="form-label"><b>Notícia</b></label>
                <asp:TextBox ID="txt_noticia" class="form-control" Rows="3" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="d-grid">
                <asp:Button ID="btn_editar_noticia" class="btn btn-danger w-100" runat="server" Text="Editar Notícia" Font-Bold="True" Font-Size="Medium" OnClick="btn_editar_noticia_Click" />
            </div>
            <br />
            <div class="mb-3">
                <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </div>

        </div>
    </div>
</div>

</asp:Content>
