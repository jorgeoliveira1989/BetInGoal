﻿<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="visualizarclientes.aspx.cs" Inherits="BetInGoal.visualizarclientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container d-flex justify-content-center align-items-center">
     <div class="p-4 border rounded">

     <h1>Dados dos Clientes</h1>
     
         <asp:Repeater ID="rptClientes" runat="server">
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