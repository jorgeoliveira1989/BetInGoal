<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="enviarprognostico.aspx.cs" Inherits="BetInGoal.enviarprognostico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container d-flex justify-content-center align-items-center">
 <div class="p-4 border rounded bg-light">
     <asp:Repeater ID="rptenviarprognosticos" runat="server">
        
         <HeaderTemplate>

        </HeaderTemplate>
         <ItemTemplate>

         </ItemTemplate>
         <FooterTemplate>

         </FooterTemplate>

     </asp:Repeater>

</div>
     </div>
</asp:Content>
