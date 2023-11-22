<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administrador.aspx.cs" Inherits="BetInGoal.administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        body {
            background-color: #343a40; /* Cor de fundo escura */
            color: white; /* Cor do texto branco */
            height: 100vh; /* 100% da altura da viewport */
            display: flex;
            align-items: center;
            justify-content: center;
            margin: 0; /* Remover margens padrão do corpo */
        }

        .login-container {
            max-width: 300px;
            width: 100%;
            padding: 15px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
        }

        .login-container h2 {
            font-size: 2em;
            margin-bottom: 20px;
        }

        .form-control {
            width: 100%;
            margin-bottom: 15px;
        }

        .btn-login {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2 class="text-center">ADMINISTRAÇÃO</h2>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txt_user" Text="Username" CssClass="sr-only" />
                <asp:TextBox runat="server" ID="txt_user" CssClass="form-control" placeholder="Utilizador" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txt_passe" Text="Password" CssClass="sr-only" />
                <asp:TextBox runat="server" ID="txt_passe" TextMode="Password" CssClass="form-control" placeholder="Palavra-Passe" />
            </div>
            <asp:Button runat="server" ID="btn_login" Text="Entrar" CssClass="btn btn-danger btn-login"  />
        </div>
    </form>
</body>
</html>
