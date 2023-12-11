<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="fecharjogos.aspx.cs" Inherits="BetInGoal.fecharjogos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container d-flex justify-content-center align-items-center vh-100">
     <div class="p-4 border rounded" style="max-width: 540px; width: 100%;">

         <h1 class="mb-4 text-center">Fechar Jogo</h1>

         <!-- Detalhes para fechar jogo -->
         <div class="row mb-3">
             <div class="col-md-9">
                 <label for="txt_nome_liga">Competição:</label>
                 <asp:Label ID="lbl_nome_liga" runat="server" CssClass="form-control" Text=""></asp:Label>
             </div>
             <div class="col-md-3">
                 <label for="txt_jornada">Jornada:</label>
                 <asp:Label ID="lbl_jornada" runat="server" CssClass="form-control" Text=""></asp:Label>
             </div>
         </div>

         <!-- Separador -->
         <hr />

         <!-- Detalhes do Jogo -->
         <div class="row mb-3">
             <div class="col-md-6">
                 <label for="txt_data">Data:</label>
                 <asp:Label ID="lbl_data" runat="server" Text="" CssClass="form-control"></asp:Label>
             </div>
             <div class="col-md-6">
                 <label for="txt_hora">Hora:</label>
                 <asp:Label ID="lbl_hora" runat="server" CssClass="form-control" Text=""></asp:Label>
             </div>
         </div>

         <div class="row mb-3">
             <div class="col-md-6">
                 <label for="txt_equipa_casa">Equipa da Casa:</label>
                 <asp:Label ID="lbl_equipa_casa" runat="server" Text="" CssClass="form-control"></asp:Label>
             </div>
             <div class="col-md-3">
                 <label for="txt_resultado_casa">Resultado Casa:</label>
                 <asp:TextBox ID="txt_resultado_casa" runat="server" CssClass="form-control"></asp:TextBox>
             </div>
             <div class="col-md-3">
                 <label for="txt_resultado_fora">Resultado Fora:</label>
                 <asp:TextBox ID="txt_resultado_fora" runat="server" CssClass="form-control" ></asp:TextBox>
             </div>
         </div>

         <div class="row mb-3">
             <div class="col-md-6">
                 <label for="txt_equipa_fora">Equipa de Fora:</label>
                 <asp:Label ID="lbl_equipa_fora" runat="server" Text="" CssClass="form-control"></asp:Label>
             </div>
             <div class="col-md-6">
                 <label>Jogo da Jornada:</label>
                 <asp:Label ID="lbl_jogo_especial" runat="server" CssClass="form-control" Text=""></asp:Label>
             </div>
         </div>

         <!-- Botão para Criar Jornada -->
         <div class="text-center">
             <asp:Button ID="btn_fechar_jogo" runat="server" Text="Atribuir Resultado Final" CssClass="btn btn-dark btn-block" OnClick="btn_fechar_jogo_Click" Font-Size="Large" />
         <br />
             <asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>
         </div>
     </div>
 </div>

</asp:Content>
