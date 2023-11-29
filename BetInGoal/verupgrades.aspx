<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="verupgrades.aspx.cs" Inherits="BetInGoal.verupgrades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .terminar{
            color: red;
        }
        .meio prazo{
            color: yellow;
        }
        .recente{
            color: green;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
    <br />
    <div class="container d-flex justify-content-center align-items-center">
        <div class="p-4 border rounded">

            <h1>Ver contas com upgrade</h1>

            <asp:Repeater ID="rptupgrade" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th scope="col">ID Pagamento</th>
                                <th scope="col">Nome Cliente</th>
                                <th scope="col">Data Pagamento</th>
                                <th scope="col">Valor</th>
                                <th scope="col">Duração (dias)</th>
                                <th scope="col">Dias (Terminar)</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="pagamentoCard">
                        <td><%# Eval("IdPagamento")%></td>
                        <td><%# Eval("NomeCliente")%></td>
                        <td><%# Eval("DataPagamento", "{0:dd/MM/yyyy}")%></td>
                        <td><%# Eval("Valor", "{0:C}")%></td>
                        <td><%# Eval("DuracaoDias")%></td>
                         <th scope="row" class="<%# Eval("EstilosCSS")%>"><%# Eval("TotalDiasFalta")%></th>
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
        const pagamentos = document.querySelectorAll('.pagamentoCard');
        const prevPageButton = document.getElementById('prevPage');
        const nextPageButton = document.getElementById('nextPage');
        const pagamentosPerPage = 20;
        let currentPage = 1;

        function showPagamentos() {
            const startIndex = (currentPage - 1) * pagamentosPerPage;
            const endIndex = startIndex + pagamentosPerPage;

            pagamentos.forEach((pagamento, index) => {
                if (index >= startIndex && index < endIndex) {
                    pagamento.style.display = 'table-row'; // Altere para 'table-row' se 'block' não funcionar
                } else {
                    pagamento.style.display = 'none';
                }
            });
        }

        function updateButtons() {
            if (currentPage === 1) {
                prevPageButton.disabled = true;
            } else {
                prevPageButton.disabled = false;
            }

            const totalPagamentos = pagamentos.length;
            const totalPages = Math.ceil(totalPagamentos / pagamentosPerPage);

            if (currentPage * pagamentosPerPage >= totalPagamentos) {
                nextPageButton.disabled = true;
            } else {
                nextPageButton.disabled = false;
            }
        }

        prevPageButton.addEventListener('click', function () {
            if (currentPage > 1) {
                currentPage--;
                showPagamentos();
                updateButtons();
            }
        });

        nextPageButton.addEventListener('click', function () {
            const totalPagamentos = pagamentos.length;
            const totalPages = Math.ceil(totalPagamentos / pagamentosPerPage);

            if (currentPage < totalPages) {
                currentPage++;
                showPagamentos();
                updateButtons();
            }
        });

        showPagamentos();
        updateButtons();
    });
</script>

</asp:Content>
