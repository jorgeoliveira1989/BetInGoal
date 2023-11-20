<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="suporte.aspx.cs" Inherits="BetInGoal.suporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <br />
        <br />
  <div class="container mt-6">
  <div class="row justify-content-center">
      <div class="col-md-6">
          <div class="card p-6" style="background-color: #f8f9fa;">
              <div class="card-body">
        <div>
            <h1 class="text-center">Suporte</h1>
            <br />
            <div>
                <asp:TextBox ID="txt_nome" class="form-control" runat="server" placeholder="Seu Nome" CssClass="form-control" /><br />
                <asp:TextBox ID="txt_email" class="form-control" runat="server" placeholder="Seu Email" CssClass="form-control" /><br />
                <asp:DropDownList ID="ddl_assunto" class="form-control" runat="server" AutoPostBack="True">
                    <asp:ListItem>-------------</asp:ListItem>
                    <asp:ListItem>Sugestão</asp:ListItem>
                    <asp:ListItem>Crítica</asp:ListItem>
                    <asp:ListItem>Elogio</asp:ListItem>
                    <asp:ListItem>Problema</asp:ListItem>
                    <asp:ListItem>Dúvida</asp:ListItem>
                    <asp:ListItem>Geral</asp:ListItem>

                </asp:DropDownList>
                <br />
                <br />
                <asp:TextBox ID="txtMessage" class="form-control" runat="server" TextMode="MultiLine" placeholder="Qual a sua mensagem?" CssClass="form-control" Rows="8"></asp:TextBox><br />
                <asp:Button ID="btn_submeter" runat="server"  Text="Enviar Mensagem" CssClass="btn btn-primary btn-lg w-100" /><br />
                <asp:Label ID="lbl_info" runat="server" ForeColor="Red"></asp:Label>
            </div>
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
