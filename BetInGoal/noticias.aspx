<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="noticias.aspx.cs" Inherits="BetInGoal.noticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br />
 <br />
 <div class="container d-flex justify-content-center align-items-center">
 <div class="p-4 border rounded bg-light">
     <h1>NOTÍCIAS</h1>
     <asp:Repeater ID="rpt_noticias" runat="server">
         <HeaderTemplate>

         </HeaderTemplate>
         <ItemTemplate>
             <ItemTemplate>
                <div>
                    <h3><%# Eval("titulo") %></h3>
                    <p><%# Eval("conteudo") %></p>
                    <p>Data de Publicação: <%# Eval("data_publicacao", "{0:dd/MM/yyyy}") %></p>
                    <hr />
                </div>
            </ItemTemplate>
         </ItemTemplate>
         <FooterTemplate>
             </table>
         </FooterTemplate>
     </asp:Repeater>
 </div>
 </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
