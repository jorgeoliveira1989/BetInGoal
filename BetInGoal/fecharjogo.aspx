<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="fecharjogo.aspx.cs" Inherits="BetInGoal.fecharjogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                <div class="container d-flex justify-content-center align-items-center">
    <div class="p-4 border rounded">

    <h1>Finalizar jornada e Atribuir Pontuação</h1>

        <asp:Repeater ID="rptfecharjogo" runat="server">
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
