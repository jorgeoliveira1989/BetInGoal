<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="poli_e_privacidade.aspx.cs" Inherits="BetInGoal.poli_e_privacidade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Políticas e Privacidade</title>
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
           <nav class="navbar navbar-expand-lg navbar-dark bg-dark p-0">
    <div class="container d-flex justify-content-between align-items-center w-100">
        <div class="d-flex align-items-center">
            <a href="index.aspx"><img src="imagens/BET1.png" /></a>
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
        <li class="nav-item"><a class="nav-link fw-bold text-white fs-5" href="index.aspx">Home</a></li>
        <li class="nav-item"><span class="separator">|</span></li>
        
        <!-- Adicione um item de menu suspenso "Classificação" -->
        <li class="nav-item dropdown">
            <a class="nav-link fw-bold text-white fs-5 me-2 dropdown-toggle" href="#" id="navbarDropdownClassificacao" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                Classificação
            </a>
            <!-- Adicione o menu suspenso com os itens do submenu -->
            <div class="dropdown-menu" aria-labelledby="navbarDropdownClassificacao">
                <a class="dropdown-item" href="classGeral.aspx">Classificação Geral</a>
                <a class="dropdown-item" href="classFree.aspx">Classificação FREE</a>
                <a class="dropdown-item" href="classPro.aspx">Classificação PRO</a>
            </div>
        </li>
        
        <li class="nav-item"><span class="separator">|</span></li>
        <li class="nav-item"><a class="nav-link fw-bold text-white fs-5" href="noticias.aspx">Notícias</a></li>
        <li class="nav-item"><span class="separator">|</span></li>
        <li class="nav-item"><a class="nav-link fw-bold text-white fs-5" href="suporte.aspx">Suporte</a></li>
    </ul>
</div>
    </div>
</nav>

     <br /><br />
     <div class="container d-flex justify-content-center align-items-center">
<div class="p-4 border rounded bg-light">
    <h1><b>POLÍTICAS E PRIVACIDADE:</b></h1>
    <br />
    <h3>1. Coleta de Informações Pessoais:</h3>
    <p>A Betingoal compromete-se a proteger a privacidade dos seus clientes. Para fornecer serviços personalizados de prognósticos de futebol, apenas coletamos informações como nome, e-mail e data de nascimento. Nenhuma informação sensível de pagamento é solicitada, pois não realizamos apostas desportivas.</p>
    <br />
    
    <h3>2. Partilhar de dados Pessoais:</h3>
    <p>As informações pessoais dos nossos Clientes não serão vendidas, alugadas ou partilhadas com terceiros sem consentimento expresso. A divulgação de informações pode ocorrer apenas para cumprir requisitos legais ou proteger os direitos e a segurança do Betingoal e dos seus clientes.</p>
    <br />
    
    <h3>3. Segurança:</h3>
    <p>Implementamos medidas de segurança para proteger as informações dos nossos clientes contra acessos não autorizado, alteração, divulgação ou destruição. No entanto, é importante ressaltar que nenhuma transmissão online é 100% segura, e os clientes partilham informações por sua própria conta e risco.</p>
    <br />
    
    <h3>4. Acesso e Controlo:</h3>
    <p>Os nossos clientes têm o direito de aceder, corrigir ou excluir as suas informações pessoais a qualquer momento. Além disso, podem optar por não receber comunicações do Betingoal. Para exercer esses direitos, os clientes podem entrar em contato conosco por meio das opções fornecidas no site.</p>
    <br />
    
    <h3>5. Menores de Idade:</h3>
    <p>O Betingoal não coleta intencionalmente informações pessoais de menores de 18 anos. Se tivermos conhecimento de que coletamos informações de um menor, tomaremos medidas para excluir essas informações o mais rápido possível e excluir a conta do cliente.</p>
    <br />
    
    <h3>6. Alterações na Política de Privacidade:</h3>
    <p>O Betingoal reserva o direito de atualizar esta política de privacidade conforme seja necessário. As alterações serão comunicadas aos clientes por meio do site ou por outro meio apropriado. É recomendável aceder regularmente a esta política para se manter informado sobre como as suas informações são protegidas.</p>
    
</div>
     </div>
     <br /><br />
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
