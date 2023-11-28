<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="visualizarclientes.aspx.cs" Inherits="BetInGoal.visualizarclientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .ativo {
            color: green;
            font-weight: bold;
        }

        .desativo {
            color: red;
            font-weight: bold;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <br />
    <br />
    <div class="container d-flex justify-content-center align-items-center">
        <div class="p-4 border rounded">
            <h1>Dados dos Clientes</h1>

            <div class="input-group mb-3">
                <asp:TextBox ID="txt_pesquisa" class="form-control" placeholder="Pesquisar pelo nome do Utilizador" runat="server" OnTextChanged="txt_pesquisa_TextChanged"></asp:TextBox>
                <asp:Button ID="btn_pesquisa" class="btn btn-outline-secondary" runat="server" Text="Pesquisar" />
            </div>

            <asp:Repeater ID="rptClientes" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Nome</th>
                                <th scope="col">Email</th>
                                <th scope="col">Utilizador</th>
                                <th scope="col">Tipo Cliente</th>
                                <th scope="col">Estado Conta</th>
                                <th scope="col">Data Registo</th>
                                <th scope="col">Data Nascimento</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="clienteCard">
                        <td><%# Eval("id_cliente")%></td>
                        <td><%# Eval("nome")%></td>
                        <td><%# Eval("email")%></td>
                        <th scope="row"><%# Eval("username")%></th>
                        <td><%# Eval("tipo_cliente")%></td>
                        <td class="<%# Eval("estilosCSS")%>"><%# Eval("estado_conta")%></td>
                        <td><%# Eval("data_registo")%></td>
                        <td><%# Eval("data_nascimento_formatada")%></td>
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
    <!-- Botões de paginação -->
    <div class="text-center">
        <button id="prevPage" class="btn btn-danger">Página Anterior</button>
        <button id="nextPage" class="btn btn-danger">Próxima Página</button>
    </div>
    <br />
    <br />
 <!-- JS para a paginação -->
<script>
    document.addEventListener('DOMContentLoaded', function () {
        const clientes = document.querySelectorAll('.clienteCard');
        const prevPageButton = document.getElementById('prevPage');
        const nextPageButton = document.getElementById('nextPage');
        const clientesPerPage = 20;
        let currentPage = 1;

        function showClientes() {
            const startIndex = (currentPage - 1) * clientesPerPage;
            const endIndex = startIndex + clientesPerPage;

            clientes.forEach((cliente, index) => {
                if (index >= startIndex && index < endIndex) {
                    cliente.style.display = 'table-row'; // Altere para 'table-row' se 'block' não funcionar
                } else {
                    cliente.style.display = 'none';
                }
            });
        }

        function updateButtons() {
            if (currentPage === 1) {
                prevPageButton.disabled = true;
            } else {
                prevPageButton.disabled = false;
            }

            if (currentPage * clientesPerPage >= clientes.length) {
                nextPageButton.disabled = true;
            } else {
                nextPageButton.disabled = false;
            }
        }

        prevPageButton.addEventListener('click', function () {
            if (currentPage > 1) {
                currentPage--;
                showClientes();
                updateButtons();
            }
        });

        nextPageButton.addEventListener('click', function () {
            const totalClientes = clientes.length;
            const totalPages = Math.ceil(totalClientes / clientesPerPage);

            if (currentPage < totalPages) {
                currentPage++;
                showClientes();
                updateButtons();
            }
        });

        showClientes();
        updateButtons();
    });
</script>
</asp:Content>
