<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="verligas.aspx.cs" Inherits="BetInGoal.verligas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

    <div class="container d-flex justify-content-center align-items-center">
        <div class="p-4 border rounded">

            <h1>Ligas Criadas</h1>

             <asp:Repeater ID="rptligas" runat="server">
     <HeaderTemplate>
         <table class="table table-striped">
             <thead>
                 <tr>
                     <th scope="col">ID</th>
                     <th scope="col">Nome Liga</th>
                     <th scope="col">Criador da Liga</th>
                     <th scope="col"> </th>
                 </tr>
             </thead>
             <tbody>
     </HeaderTemplate>
     <ItemTemplate>
         <tr class="ligasCard">
             <td><%# Eval("IdLiga")%></td>
             <td><%# Eval("NomeLiga")%></td>
             <td><%# Eval("NomeCliente")%></td>
             <td>
             <a href="https://localhost:44398/detalhe_liga.aspx?id_liga=<%# Eval("IdLiga")%>"><button type="button" class="btn btn-danger">Detalhes</button></a>
             </td>
         </tr>
     </ItemTemplate>
     <FooterTemplate>
             </tbody>
         </table>
     </FooterTemplate>
 </asp:Repeater>

        </div>
    </div>
    <br />
    <br />
</asp:Content>
