<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="erro404.aspx.cs" Inherits="BetInGoal.erro404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Erro 404 - Página Não Encontrada</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f4f4f4;
            color: #333;
            margin: 0;
            padding: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        .error-container {
            text-align: center;
        }

        h1 {
            font-size: 3em;
            color: #d9534f; /* Bootstrap's danger color */
        }

        p {
            font-size: 1.2em;
            margin-top: 20px;
        }

        marquee {
            font-size: 1.5em;
            color: #5bc0de; /* Bootstrap's info color */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="error-container">
            <h1>Erro 404 - Página Não Encontrada</h1>
            <p>Lamentamos, mas a página que está procurar não foi encontrada.</p>
            <marquee>Por favor, verifique o URL e tente novamente.</marquee>
        </div>
    </form>
</body>
</html>
