<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="addjogo.aspx.cs" Inherits="BetInGoal.addjogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function toggleControlesJogoEspecial(chkJogoEspecial) {
            var parentPanel = chkJogoEspecial.parentElement;
            var checkboxes = parentPanel.querySelectorAll('input[type="checkbox"]');

            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] !== chkJogoEspecial) {
                    checkboxes[i].disabled = chkJogoEspecial.checked;
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
           <div class="container d-flex justify-content-center align-items-center">
    <div class="p-4 border rounded" style="max-width: 540px; width: 100%;">

            <h1>Jogos Para Prognósticos</h1>
                <br />
                Liga:
                <asp:TextBox ID="TextBox1" runat="server" Width="302px"></asp:TextBox>
            &nbsp; Jornada:
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Number" min="1" max="50" Width="53px"></asp:TextBox>
            <br />
                <br />
            Quantidade de jogos: <asp:DropDownList ID="ddl_quantidadeJogos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_quantidadeJogos_SelectedIndexChanged">
                    <asp:ListItem>---------</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>

                                </asp:DropDownList>   
                <br />
                <br />
               
                        <asp:Panel ID="pnlJogos" runat="server">
                            <!--Aqui dentro ficam dados gerados-->
                        </asp:Panel>

            
<asp:ScriptManager ID="ScriptManager2" runat="server">
</asp:ScriptManager>
 
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate> 
                <asp:Button ID="btn_criar_jogo" class="btn btn-danger w-100" runat="server" Text="Criar Jogo" Font-Bold="True" Font-Size="Medium" OnClick="btn_criar_jogo_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
            </div>
            </div>

</asp:Content>
