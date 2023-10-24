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

    </style>
        <!-- Favicon-->
       
        <link rel="icon" type="image/x-icon" href="assets/bola.png" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="css/styles.css" rel="stylesheet" />
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
        <div class="d-flex">
            <button class="btn btn-secondary mx-2 btn-lg flex-grow-1">Login</button>
            <button class="btn btn-primary btn-lg flex-grow-1">Registrar</button>
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


        <!-- Page Content-->
        <div class="container px-4 px-lg-5">
            <!-- Heading Row-->
            <div class="row gx-4 gx-lg-5 align-items-center my-5">
                <div class="col-lg-5">
                    <h1 class="font-weight-light">Business Name or Tagline</h1>
                    <p>This is a template that is great for small businesses. It doesn't have too much fancy flare to it, but it makes a great use of the standard Bootstrap core components. Feel free to use this template for any project you want!</p>
                    <a class="btn btn-primary" href="#!">Call to Action!</a>
                </div>
                <div class="col-lg-7"><img class="img-fluid rounded mb-4 mb-lg-0" src="imagens/imagem%201920x600.jpg" /></div>
            </div>
            <!-- Call to Action-->
            <div class="card text-white bg-secondary my-5 py-4 text-center">
                <div class="card-body"><p class="text-white m-0">This call to action card is a great place to showcase some important information or display a clever tagline!</p></div>
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
    </form>
</body>
</html>
