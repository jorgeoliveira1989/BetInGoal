<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="visualizarjogospassados.aspx.cs" Inherits="BetInGoal.visualizarjogospassados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="container d-flex justify-content-center align-items-center">
    <div class="p-4 border rounded">

    <h1>Visualizar Jornadas Passadas</h1>

        <asp:Repeater ID="rptjogospassados" runat="server">
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
