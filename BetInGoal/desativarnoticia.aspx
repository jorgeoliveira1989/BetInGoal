<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="desativarnoticia.aspx.cs" Inherits="BetInGoal.desativarnoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
        <div class="p-4 border rounded bg-light" style="max-width: 540px; width: 100%;">
            <h3 class="mb-4 text-center"><b>Desativar Notícia</b></h3>
                <div>
            <div class="mb-3">
                 <label for="txtid" class="form-label"><b>ID</b></label>
                <asp:DropDownList ID="ddl_id" AppendDataBoundItems="True" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="id_noticia" DataValueField="id_noticia" OnSelectedIndexChanged="ddl_id_SelectedIndexChanged">
                    <asp:ListItem>-----</asp:ListItem>
                </asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BetinGoalConnectionString %>" SelectCommand="SELECT [id_noticia] FROM [noticias] WHERE ([ativo] = @ativo)">
                     <SelectParameters>
                         <asp:Parameter DefaultValue="TRUE" Name="ativo" Type="Boolean" />
                     </SelectParameters>
                 </asp:SqlDataSource>
                </div>
                    <div class="mb-3">
                        <label for="txttitulo" class="form-label"><b>Título</b></label>
                        <br />
                        <asp:Label runat="server" ID="lbl_titulo" class="form-control"></asp:Label>
                    </div>
                <br />
                    <div class="d-grid">
                        <asp:Button ID="btn_desativar_noticia" class="btn btn-danger w-100" runat="server" Text="Desativar Notícia" Font-Bold="True" Font-Size="Medium" OnClick="btn_desativar_noticia_Click" />
                                </div>
            <br />
        <div class="mb-3">
            <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
   </div>
</div>
</div>

</asp:Content>
