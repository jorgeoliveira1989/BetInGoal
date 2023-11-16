﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BetInGoal.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>BetinGoal</title>
    <style>
        body{
            background-image: url('imagens/versaogrande.jpg'); /* Substitua pelo caminho da sua imagem */
            background-repeat: repeat; /* Isso fará com que a imagem se repita */
        }
        .bola{
            margin-top:10px;
            margin-bottom:10px;
            margin-right:10px;
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
        #serverTime{
            font-weight:bold;
            color:dodgerblue;
        }

        #icon_clock{
            padding-right: 8px;
        }

        #meuCarrossel {
            width: 100%;
            max-width: none;
            height: 600px;
        }  
        .card-body {
            background-color: rgba(255, 255, 255, 0.25); /* Cor branca com 25% de opacidade */
        }
        .card-body.bg-light {
            background-color: rgba(255, 255, 255, 0.25); /* Cor branca com 25% de opacidade */
        }
        .mark{
            background-color:blue;
          
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
            <img src="assets/bola.png" width="50" height="50" style="margin-right: 10px;" />
            <a class="navbar-brand" href="#!" style="font-size: 3em; font-weight: bold;">BetinGoal</a>
        </div>
<div class="d-flex mt-3 align-items-center">
    <i id="icon_clock" class="fa-regular fa-clock" style="color: #ffffff;"></i> <label class="text-white me-2">Server Time:</label>
    <div id="serverTime"></div>
    <button class="btn btn-secondary mx-2 btn-lg flex-grow-1 ms-5">Login</button>
    <!-- Adiciona "align-self-center" para centralizar verticalmente relativamente aos outros elementos -->
    <div class="align-self-center">
        <button class="btn btn-primary btn-lg flex-grow-1">Registrar</button>
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
                <li class="nav-item"><a class="nav-link active fw-bold text-white fs-5 me-2" aria-current="page" href="#!">Home</a></li>
                <li class="nav-item"><span class="separator">|</span></li>
                <li class="nav-item"><a class="nav-link fw-bold text-white fs-5 me-2" href="#!">Prognósticos</a></li>
                <li class="nav-item"><span class="separator">|</span></li>
                <li class="nav-item"><a class="nav-link fw-bold text-white fs-5 me-2" href="#!">Classificação Geral</a></li>
                <li class="nav-item"><span class="separator">|</span></li>
                <li class="nav-item"><a class="nav-link fw-bold text-white fs-5" href="#!">Login</a></li>
                <li class="nav-item"><span class="separator">|</span></li>
                <li class="nav-item"><a class="nav-link fw-bold text-white fs-5" href="#!">Notícias</a></li>
                <li class="nav-item"><span class="separator">|</span></li>
                <li class="nav-item"><a class="nav-link fw-bold text-white fs-5" href="#!">Suporte</a></li>
            </ul>
        </div>
    </div>
</nav>

        <!--Carrossel-->

        <div id="meuCarrossel" class="carousel slide w-100 h-700" data-ride="carousel">
    <div class="carousel-inner">
        <div class="carousel-item active">
            <img src="imagens/imagem 1920x600.jpg" alt="Imagem 1" class="w-100"/>
        </div>
        <div class="carousel-item">
            <img src="imagens/imagem 1920x600.jpg" alt="Imagem 2" class="w-100"/>
        </div>
        <div class="carousel-item">
            <img src="imagens/imagem 1920x600.jpg" alt="Imagem 3" class="w-100"/>
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
            <div class="col-md-4 mb-4">
                <div class="card-body p-4">
                     <i class="fa-solid fa-sheet-plastic fa-2xl"></i>
                     <p><p><b>TOTAL DE PROGNÓSTICOS:</b></p></p>
                     <asp:Label ID="lbl_quantidade_prognosticos" runat="server" Text="0" Font-Bold="True" Font-Size="XX-Large" ForeColor="DodgerBlue"></asp:Label>
                </div>
            </div>
            <div class="col-md-4 mb-4">
                <div class="card-body p-4">
                    <i class="fa-solid fa-people-group fa-2xl"></i>
                    <p><p><b>TOTAL DE UTILIZADORES:</b></p></p>
                    <asp:Label ID="lbl_total_users" runat="server" Text="0" Font-Bold="True" Font-Size="XX-Large" ForeColor="DodgerBlue"></asp:Label>
                </div>
            </div>
            <div class="col-md-4 mb-4">
                <div class="card-body p-4">
                    <i class="fa-regular fa-address-card fa-2xl"></i>
                    <p><p><b>UTILIZADORES REGISTADOS HOJE:</b></p></p>
                    <asp:Label ID="lbl_novos_users_dia" runat="server" Text="0" Font-Bold="True" Font-Size="XX-Large" ForeColor="DodgerBlue"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</div>

            <!-- Call to Action-->
            <div class="card text-white bg-light my-5 py-4 text-center">
    <div class="card-body">
        <h1 class="text-black mb-4">Junta-te à comunidade <b>BetinGoal</b> e torna-te um vencedor no mundo do futebol!</h1>
        <div class="align-items-center">
            <button class="btn btn-secondary btn-lg flex-grow-1">Login</button>
            <button class="btn btn-primary btn-lg flex-grow-1">Registrar</button>
        </div>
    </div>
</div>

            <!-- Content Row-->
            <div class="row gx-4 gx-lg-5">
                <div class="col-md-4 mb-5">
                    <div class="card h-100">
                        <div class="card-body">
                            <h2 class="card-title">Card One</h2>
                            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rem magni quas ex numquam, maxime minus quam molestias corporis quod, ea minima accusamus.</p>
                        </div>
                        <div class="card-footer"><a class="btn btn-primary btn-sm" href="#!">More Info</a></div>
                    </div>
                </div>
                <div class="col-md-4 mb-5">
                    <div class="card h-100">
                        <div class="card-body">
                            <h2 class="card-title">Card Two</h2>
                            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quod tenetur ex natus at dolorem enim! Nesciunt pariatur voluptatem sunt quam eaque, vel, non in id dolore voluptates quos eligendi labore.</p>
                        </div>
                        <div class="card-footer"><a class="btn btn-primary btn-sm" href="#!">More Info</a></div>
                    </div>
                </div>
                <div class="col-md-4 mb-5">
                    <div class="card h-100">
                        <div class="card-body">
                            <h2 class="card-title">Card Three</h2>
                            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rem magni quas ex numquam, maxime minus quam molestias corporis quod, ea minima accusamus.</p>
                        </div>
                        <div class="card-footer"><a class="btn btn-primary btn-sm" href="#!">More Info</a></div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Footer-->
        <footer class="py-5 bg-dark">
            <div class="container px-4 px-lg-5"><p class="m-0 text-center text-white">Copyright &copy; Your Website 2023</p></div>
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
