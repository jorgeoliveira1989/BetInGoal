<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="comprarsubscricao.aspx.cs" Inherits="BetInGoal.comprarsubscricao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>
        /* Adicione estilos personalizados aqui, se necessário */
        .subscription-container {
            padding: 20px;
        }

        .btn-purchase {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            font-size: 18px;
            cursor: pointer;
        }

        .btn-purchase:hover {
            background-color: #0056b3;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<br />
    <br />
   <div class="container d-flex justify-content-center align-items-center">
<div class="p-4 border rounded bg-light" style="max-width: 540px; width: 100%;">
    <h1 class="text-center">Comprar Subscrição</h1>
    <p>
        Desbloqueie o potencial máximo da Subscrição PRO!<br /> 
        Com a subscrição PRO vai poder criar ligas e juntar os seus amigos.<br />
        Nessa Liga vai poder acompanhar quem consegue ser o melhor a lançar os prognósticos sobre futebol.<br />
        O que espera para aderir ao nossa Subscrição PRO?

    </p>
    <p class="text-center">
        Subscrição PRO: €10.00/ano
    </p>
    <div class="text-center">
        <asp:Button ID="btn_comprar" class="btn btn-primary" runat="server" Text="Comprar Agora" />
    </div>
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
</asp:Content>
