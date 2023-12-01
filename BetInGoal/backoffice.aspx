﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="backoffice.aspx.cs" Inherits="BetInGoal.backoffice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Backoffice</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        /* Estilo personalizado para o menu */
        .custom-menu {
            background-color: #343a40; /* Cor de fundo escuro */
            color: white; /* Texto branco */
            padding: 10px; /* Preenchimento interno */
        }

        /* Estilo personalizado para o botão Sair */
        .custom-logout {
            margin-left: auto; /* Mover para a direita */
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-xl navbar-dark custom-menu">
            <div class="container-fluid custom-content">
                <a class="nav-link" href="backoffice.aspx">
                    <h1 class="navbar-brand">BACKOFFICE</h1>
                </a>
                <p class="m-0">Hora do Servidor: <strong id="serverTime"></strong></p>
                <p class="m-0 mr-5">
                    Utilizador:
            <asp:Label ID="lbl_utilizador" runat="server" CssClass="text-warning" />
                </p>

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarExemplos" aria-controls="navbarExemplos" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

            </div>
            <!-- Adicione a seção Exemplos aqui -->
            <div class="collapse navbar-collapse" id="navbarExemplos">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item ml-5">
                        <div class="dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" id="clientesDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Clientes
                            </a>
                            <div class="dropdown-menu" aria-labelledby="clientesDropdown">
                                <a class="dropdown-item" href="visualizarclientes.aspx">Visualizar Clientes</a>
                                <a class="dropdown-item" href="ativarclientes.aspx">Ativar Cliente</a>
                                <a class="dropdown-item" href="desativarclientes.aspx">Desativar Cliente</a>
                            </div>
                        </div>
                    </li>
                    <li class="nav-item">
                        <div class="dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" id="classificacaoDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Classificação
                            </a>
                            <div class="dropdown-menu" aria-labelledby="classificacaoDropdown">
                                <a class="dropdown-item" href="classificacaofree.aspx">Visualizar Classificação FREE</a>
                                <a class="dropdown-item" href="classificacaopro.aspx">Visualizar Classificação PRO</a>
                            </div>
                        </div>
                    </li>
                    <li class="nav-item">
                        <div class="dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" id="jogosDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Jogos
                            </a>
                            <div class="dropdown-menu" aria-labelledby="jogosDropdown">
                                <a class="dropdown-item" href="visualizarjogospassados.aspx">Visualizar Jogos Passados</a>
                                <a class="dropdown-item" href="addjogo.aspx">Adicionar Jogo</a>
                                <a class="dropdown-item" href="fecharjogo.aspx">Fechar Jogo</a>
                            </div>
                        </div>
                    </li>

                    <li class="nav-item">
                        <div class="dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" id="suporteDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Suporte
                            </a>
                            <div class="dropdown-menu" aria-labelledby="suporteDropdown">
                                <a class="dropdown-item" href="vermensagens.aspx">Ver Mensagens</a>
                                <a class="dropdown-item" href="mensagensrespondidas.aspx">Mensagens Respondidas</a>
                                <a class="dropdown-item" href="alterarestadomensagem.aspx">Alterar estado</a>
                            </div>
                        </div>
                    </li>

                    <li class="nav-item">
                        <div class="dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" id="ligasDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Ligas
                            </a>
                            <div class="dropdown-menu" aria-labelledby="ligasDropdown">
                                <a class="dropdown-item" href="verligas.aspx">Ver Ligas</a>
                            </div>
                        </div>
                    </li>

                    <li class="nav-item">
                        <div class="dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" id="noticiasDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Notícias
                            </a>
                            <div class="dropdown-menu" aria-labelledby="noticiasDropdown">
                                <a class="dropdown-item" href="criarnoticia.aspx">Criar Notícia</a>
                                <a class="dropdown-item" href="editarnoticia.aspx">Editar Notícia</a>
                                <a class="dropdown-item" href="desativarnoticia.aspx">Desativar Notícia</a>
                            </div>
                        </div>
                    </li>

                    <li class="nav-item">
                        <div class="dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" id="adminsDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Admin
                            </a>
                            <div class="dropdown-menu" aria-labelledby="adminsDropdown">
                                <a class="dropdown-item" href="criarAdmins.aspx">Criar Conta</a>
                            </div>
                        </div>
                    </li>

                    <li class="nav-item mr-5">
                        <div class="dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" id="upgradeDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Upgrades
                            </a>
                            <div class="dropdown-menu" aria-labelledby="upgradeDropdown">
                                <a class="dropdown-item" href="verupgrades.aspx">Ver Upgrades</a>
                                <a class="dropdown-item" href="desativarupgrade.aspx">Desativar Upgrade</a>
                            </div>
                        </div>
                    </li>


                    <li class="nav-item mr-3 ml-5">
                        <!-- Adicionei a classe mr-3 para adicionar marg<!-- Script JavaScript para atualizar a hora do servidor -->
                        <asp:Button ID="btn_sair" class="btn btn-danger custom-logout" runat="server" Text="SAIR" OnClick="btn_sair_Click" />
                    </li>
                </ul>
            </div>
        </nav>

      <br />
        <br />
        
<div class="row text-center justify-content-center">
    <div class="col-lg-2 mb-4 mx-lg-3">
        <!-- Quadro 1 -->
        <div class="single_quick_activity bg-success text-white p-3">
            <h2>CLIENTES</h2>
            <h3><asp:Label ID="lbl_quant_clientes" runat="server" Text=""></asp:Label></h3>
            <p>Saved 25%</p>
        </div>
    </div>
    <div class="col-lg-2 mb-4 mx-lg-3">
        <!-- Quadro 2 -->
        <div class="single_quick_activity bg-primary text-white p-3">
            <h2>VENDAS</h2>
            <h3>$ <span class="counter">79,000</span> </h3>
            <p>Saved 25%</p>
        </div>
    </div>
    <div class="col-lg-2 mb-4 mx-lg-3">
        <!-- Quadro 3 -->
        <div class="single_quick_activity bg-secondary text-white p-3">
            <h2>MENSAGENS</h2>
            <h3>$ <span class="counter">92,000</span> </h3>
            <p>Saved 25%</p>
        </div>
    </div>
    <div class="col-lg-2 mb-4 mx-lg-3">
        <!-- Quadro 4 -->
        <div class="single_quick_activity bg-danger text-white p-3">
            <h2>LIGAS</h2>
            <h3>$ <span class="counter">179,000</span> </h3>
            <p>Saved 65%</p>
        </div>
    </div>
</div>







    </form>
    <!-- Seu conteúdo do backoffice aqui -->

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.9/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <!-- Script JavaScript para atualizar a hora do servidor -->
    <script>
        // Função para atualizar a hora do servidor
        function updateServerTime() {
            var serverTimeElement = document.getElementById('serverTime');
            var serverTime = new Date().toLocaleTimeString();
            serverTimeElement.textContent = serverTime;
        }

        // Atualizar a hora do servidor a cada segundo
        setInterval(updateServerTime, 1000);
    </script>

</body>
</html>
