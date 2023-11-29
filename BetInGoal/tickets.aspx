<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="tickets.aspx.cs" Inherits="BetInGoal.tickets" %>
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
            <div>
                <b>NOME:</b><br />
                <asp:Label ID="lbl_nome" class="form-control" runat="server" Text=""></asp:Label><br />
                 <b>EMAIL:</b><br />
                <asp:Label ID="lbl_email" class="form-control" runat="server" Text=""></asp:Label><br />
                 <b>SITUAÇÃO:</b><br />
                <asp:Label ID="lbl_assunto" class="form-control" runat="server" Text=""></asp:Label><br />
                 <b>PERGUNTA:</b><br />
                <asp:Literal ID="lt_mensagem" runat="server"></asp:Literal><br /><br />

                <asp:Button ID="btn_responder_ticket" runat="server"  Text="Responder" CssClass="btn btn-primary btn-lg w-100" onclick="btn_responder_ticket_Click" /><br />
                <asp:Panel ID="pnl_resposta" runat="server" Visible="False">
                    
                    <br />
                    <br />
                    <b>RESPOSTA:</b><br />
                    <asp:TextBox ID="txt_resposta" class="form-control" runat="server" Rows="5" TextMode="MultiLine" placeholder="Indique o que vai responder ao Cliente"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btn_responder" runat="server" CssClass="btn btn-danger btn-lg w-100" Text="Responder ao Cliente" OnClick="btn_responder_Click" />
                    <br />
                    <asp:Label ID="lbl_info" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />

                </asp:Panel>
                
                
                
                
               
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
