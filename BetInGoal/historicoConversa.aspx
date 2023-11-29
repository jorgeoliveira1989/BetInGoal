<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="historicoConversa.aspx.cs" Inherits="BetInGoal.historicoConversa" %>
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
                <b>RESPOSTA:</b><br />
                <asp:Literal ID="lt_mensagem_respondida" runat="server"></asp:Literal><br /><br />
                <asp:Button ID="btn_voltar" runat="server" CssClass="btn btn-dark btn-lg w-100" Text="Fechar" OnClick="btn_voltar_Click"  />
                
               
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
