<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BetInGoal.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>BetinGoal</title>
    <style>
        body {
            height: 100%;
            background-image: url('imagens/versaogrande.jpg');
            background-repeat: repeat; /* Isto faz  a imagem repetir */
        }

        .bola {
            margin-top: 10px;
            margin-bottom: 10px;
            margin-right: 10px;
        }

        .navbar-nav {
            margin: 0 auto;
        }

        .separator {
            color: #999;
            font-size: 1.5em;
            margin-top: -0.15em;
        }

        .nav-link:hover {
            color: #ddd;
        }

        #serverTime {
            font-weight: bold;
            color: dodgerblue;
        }

        #icon_clock {
            padding-right: 8px;
        }

        #meuCarrossel {
            width: 100%;
            max-width: 100%;
            height: auto;
        }

        .card-body {
            background-color: rgba(255, 255, 255, 0.25); /* Cor branca com 25% de opacidade */
        }

        .card-body.bg-light {
            background-color: rgba(255, 255, 255, 0.25); /* Cor branca com 25% de opacidade */
        }

        .mark {
            background-color: blue;
        }

        footer {
            padding: 1rem 0; /* Adiciona algum espaço ao redor do rodapé */
        }
    </style>
    <!-- Favicon-->

    <link rel="icon" type="image/x-icon" href="assets/bola.png" />
    <!-- Core theme CSS (includes Bootstrap)-->
    <link href="css/styles.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="fontawesome/css/all.min.css" />

</head>
<body>
    <form id="form1" runat="server">
        <!-- Responsive navbar-->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark p-0">
            <div class="container d-flex justify-content-between align-items-center w-100">
                <div class="d-flex align-items-center">
                    <img src="imagens/BET1.png" />
                </div>
                <div class="d-flex mt-3 align-items-center">
                    <i id="icon_clock" class="fa-regular fa-clock" style="color: #ffffff;"></i>
                    <label class="text-white me-2">Server Time:</label>
                    <div id="serverTime"></div>
                    <asp:Button ID="btn_entrar" class="btn btn-secondary mx-2 btn-lg flex-grow-1 ms-5" runat="server" Text="Entrar" OnClick="btn_entrar_Click" />
                    <!-- Adiciona "align-self-center" para centralizar verticalmente relativamente aos outros elementos -->
                    <div class="align-self-center">
                        <asp:Button ID="btn_criar_conta" class="btn btn-primary btn-lg flex-grow-1" runat="server" Text="Criar Conta" OnClick="btn_criar_conta_Click" />
                    </div>
                </div>
            </div>
        </nav>



        <nav class="navbar navbar-expand-lg navbar-secondary bg-secondary">
            <div class="container px-5">
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                        <li class="nav-item"><a class="nav-link fw-bold text-white fs-5 me-2" href="#!">Prognósticos</a></li>
                        <li class="nav-item"><span class="separator">|</span></li>
                        <li class="nav-item"><a class="nav-link fw-bold text-white fs-5 me-2" href="classGeral.aspx">Classificação Geral</a></li>
                        <li class="nav-item"><span class="separator">|</span></li>
                        <li class="nav-item"><a class="nav-link fw-bold text-white fs-5" href="noticias.aspx">Notícias</a></li>
                        <li class="nav-item"><span class="separator">|</span></li>
                        <li class="nav-item"><a class="nav-link fw-bold text-white fs-5" href="suporte.aspx">Suporte</a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <!--Carrossel-->

        <div id="meuCarrossel" class="carousel slide w-100 h-700" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="imagens/imagem 1920x600.jpg" alt="Imagem 1" class="w-100" />
                </div>
                <div class="carousel-item">
                    <img src="imagens/imagem 1920x600_HOMEM.jpg" alt="Imagem 2" class="w-100" />
                </div>
                <div class="carousel-item">
                    <img src="imagens/imagem 1920x600_MULHER.jpg" alt="Imagem 3" class="w-100" />
                </div>
            </div>
            <a class="carousel-control-prev" href="#meuCarrossel" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Anterior</span>
            </a>
            <a class="carousel-control-next" href="#meuCarrossel" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Próximo</span>
            </a>
        </div>

        <!-- Page Content-->
        <div class="container px-4 px-lg-5">
            <!-- Heading Row-->


            <!--Info Client System-->
            <div class="text-center py-4">
                <div class="container">
                    <div class="row">
                        <div class="col-md-4 mb-5">
                            <div class="card h-100">
                                <div class="card-body ">
                                    <i class="fa-solid fa-sheet-plastic fa-2xl"></i>
                                    <p>
                                        <p><b>TOTAL DE PROGNÓSTICOS:</b></p>
                                    </p>
                                    <asp:Label ID="lbl_quantidade_prognosticos" runat="server" Text="0" Font-Bold="True" Font-Size="XX-Large" ForeColor="DodgerBlue"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 mb-5">
                            <div class="card h-100">
                                <div class="card-body">
                                    <i class="fa-solid fa-people-group fa-2xl"></i>
                                    <p>
                                        <p><b>TOTAL DE UTILIZADORES:</b></p>
                                    </p>
                                    <asp:Label ID="lbl_total_users" runat="server" Text="0" Font-Bold="True" Font-Size="XX-Large" ForeColor="DodgerBlue"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 mb-5">
                            <div class="card h-100">
                                <div class="card-body">
                                    <i class="fa-regular fa-address-card fa-2xl"></i>
                                    <p>
                                        <p><b>UTILIZADORES REGISTADOS HOJE:</b></p>
                                    </p>
                                    <asp:Label ID="lbl_novos_users_dia" runat="server" Text="0" Font-Bold="True" Font-Size="XX-Large" ForeColor="DodgerBlue"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <!-- Call to Action-->
                <div class="card text-white bg-light my-5 py-4 text-center">
                    <div class="card-body">
                        <h1 class="text-black mb-4">Junta-te à nossa comunidade <b>BetinGoal</b>.<br />
                        </h1>
                        <div class="align-items-center">
                            <asp:Button ID="btn_criar_conta1" class="btn btn-primary btn-lg flex-grow-1" runat="server" Text="Criar Conta" OnClick="btn_criar_conta1_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- Content Row-->
            <div class="row text-center gx-4 gx-lg-5">
                <div class="col-md-4 mb-5">
                    <div class="card h-100">
                        <div class="card-body">
                            <img src="imagens/icon1.jpg" width="150" height="150" />
                            <h2 class="card-title">Registar no BetinGoal</h2>
                            <p class="card-text">
                                Faz parte da comunidade <b>BetinGoal</b>
                                <br />
                                e desfruta de todos os benefícios.<br />
                                O registo é totalmente GRÁTIS
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 mb-5">
                    <div class="card h-100">
                        <div class="card-body">
                            <img src="imagens/icon2.png" width="150" height="150" />
                            <h2 class="card-title">Enviar Prognósticos</h2>
                            <p class="card-text">
                                Participa semanalmente nos nossos
                                <br />
                                concursos e submete os teus prognósticos
                                <br />
                                para a jornada.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 mb-5">
                    <div class="card h-100">
                        <div class="card-body">
                            <img src="imagens/icon3.png" width="150" height="150" />
                            <h2 class="card-title">Verifica Pontuação</h2>
                            <p class="card-text">
                                No fim de realizada a jornada,
                                <br />
                                verifica a classificação atual no ranking
                                <br />
                                geral do site.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Footer-->
        <footer class="py-5 bg-dark">
            <div class="container px-4 px-lg-5">
                <div class="row">
                    <div class="col-md-4 mb-3">
                        <h5 class="m-0 text-white">Na <b>BetInGoal</b>, cada palpite é uma oportunidade de vitória. Faça parte da nossa comunidade apaixonada e eleve os seus prognósticos a um novo patamar.
                        </h5>
                        <br />
                        <p class="m-0 text-white">
                            © DIREITOS RESERVADOS | <b>BETINGOAL</b>
                        </p>
                    </div>
                    <div class="col-md-4 mb-3 text-center">
                        <h6 class="text-white">Redes Sociais:</h6>
                        <a href="#" class="text-white fs-2 mx-2"><i class="fab fa-facebook-f"></i></a>
                        <a href="#" class="text-white fs-2 mx-2"><i class="fab fa-instagram"></i></a>
                        <a href="#" class="text-white fs-2 mx-2"><i class="fab fa-twitter"></i></a>
                        <div class="mt-3">
                            <br />
                            <p class="m-0 text-white">
                                Designed by <b>BetInGoal</b>
                            </p>
                        </div>
                    </div>

                    <div class="col-md-4 mb-3 text-center">
                        <p class="m-0 text-white">
                            <span class="text-white fw-bold">Links Úteis</span><br />
                            <a href="#" class="text-primary text-decoration-none">Política de Privacidade</a><br />
                            <a href="#" class="text-primary text-decoration-none">Livro de Reclamações</a>
                        </p>
                    </div>

                </div>
            </div>
        </footer>

        <!-- Bootstrap core JS-->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
        <!-- Core theme JS-->
        <script src="js/scripts.js"></script>
        <!-- JavaScript para a hora do servidor -->
        <script>
            function updateServerTime() {
                var serverTimeElement = document.getElementById('serverTime');
                var serverTime = new Date();
                var hours = serverTime.getHours();
                var minutes = serverTime.getMinutes();
                var seconds = serverTime.getSeconds();

                var formattedTime = hours + ':' + (minutes < 10 ? '0' : '') + minutes + ':' + (seconds < 10 ? '0' : '') + seconds;

                serverTimeElement.textContent = formattedTime;

                setTimeout(updateServerTime, 1000);
            }

            updateServerTime();
        </script>
    </form>
</body>

<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.9/dist/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

</html>
