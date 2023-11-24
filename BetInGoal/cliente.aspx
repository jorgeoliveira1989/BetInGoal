<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="BetInGoal.cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        /* Adicione estilos personalizados aqui, se necessário */
        .info-container {
            max-width: 540px;
            width: 100%;
        }

        .options-container {
            max-width: 740px;
            width: 100%;
            max-height: 650px;
            overflow-y: auto;
        }

        .profile-image {
            max-width: 150px;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <div class="row">
            <!-- Dados do Cliente -->
            <div class="col-md-6">
                <div class="p-3 border rounded bg-light info-container">
                    <h1>Dados do Cliente</h1>
                    <br />
                    <div class="d-flex">
                        <img src="imagens/dados_pessoais.png" alt="Imagem do Perfil" class="profile-image">
                        <div class="ml-3">
                            <p class="mb-1" style="font-size: 22px;">
                                <strong>Utilizador:</strong>
                                <asp:Label ID="lbl_utilizador" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
                            </p>
                            <p class="mb-1" style="font-size: 22px;">
                                <strong>Email:</strong>
                                <asp:Label ID="lbl_email" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
                            </p>
                            <p class="mb-1" style="font-size: 22px;">
                                <strong>Tipo de Conta:</strong>
                                <asp:Label ID="lbl_tipo_conta" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Opções do Cliente -->
            <div class="col-md-6">
                <div class="p-3 border rounded bg-light options-container">
                    <h1>Opções</h1>
                    <br />
                    <div class="d-flex flex-column">
                        <p class="mb-1" style="font-size: 22px;">
                            <i class="fas fa-key"></i>
                            <a href="alterarpasse.aspx" style="text-decoration: none;">Alterar Palavra-Passe</a>
                        </p>
                        <!--Aqui começa-->

                        <asp:Label ID="lbl_alterar_passe" runat="server" CssClass="mb-1" Font-Size="Large">
                            <i class="fas fa-key" style="font-size: 22px;"></i>
                            <asp:HyperLink ID="hl_alterar_passe" runat="server" NavigateUrl="alterarpasse.aspx" Text="Alterar Palavra-Passe" Style="text-decoration: none;font-size: 22px;"></asp:HyperLink>
                        </asp:Label>

                        <!--Aqui termina-->
                        <p class="mb-1" style="font-size: 22px;">
                            <i class="fas fa-envelope"></i>
                            <a href="enviarprog.aspx" style="text-decoration: none;">Enviar Prognóstico</a>
                        </p>
                        <p class="mb-1" style="font-size: 22px;">
                            <i class="fas fa-shopping-cart"></i>
                            <a href="comprarsubscricao.aspx" style="text-decoration: none;">Comprar Subscrição</a>
                        </p>
                        <p class="mb-1" style="font-size: 22px;">
                            <i class="fas fa-trophy"></i>
                            <a href="classGeral.aspx" style="text-decoration: none;">Visualizar Classificação</a>
                        </p>
                        <p class="mb-1" style="font-size: 22px;">
                            <i class="fas fa-users"></i>
                            <a href="criarliga.aspx" style="text-decoration: none;">Criar Liga</a>
                        </p>
                        <p class="mb-1" style="font-size: 22px;">
                            <i class="fas fa-plus-circle"></i>
                            <a href="entrarliga.aspx" style="text-decoration: none;">Visualizar Ligas</a>
                        </p>
                        <!-- Adicione mais opções conforme necessário -->
                    </div>
                </div>
            </div>
        </div>
        <!-- Informações Adicionais -->
        <div class="row mt-4">
            <div class="col-md-6">
                <div class="p-3 border rounded bg-light info-container">
                    <h1>Informações Adicionais</h1>
                    <br />
                    <p class="mb-1" style="font-size: 22px;">
                        <strong>Nome Completo:</strong>
                        <asp:Label ID="lbl_nome_completo" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
                    </p>
                    <p class="mb-1" style="font-size: 22px;">
                        <strong>Data de Nascimento:</strong>
                        <asp:Label ID="lbl_data_nascimento" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label>
                    </p>
                    <p class="mb-1" style="font-size: 22px;">
                        <strong>Estado da Conta:</strong>
                        <asp:Label ID="lbl_estado_conta" runat="server" Font-Bold="True" Text="dsfsdgdfgdgd" ForeColor="#FF9900"></asp:Label>
                    </p>
                    <p class="mb-1" style="font-size: 22px;">
                        <strong>Nome da Liga:</strong>
                        <asp:Label ID="lbl_liga" runat="server" Font-Bold="True" ForeColor="#FF9900" Text="XPTO"></asp:Label>
                    </p>
                    <!-- Adicione mais informações conforme necessário -->
                </div>
            </div>
            <!-- Nova seção -->
            <div class="col-md-6">
                <div class="p-3 border rounded bg-light options-container">
                    <h1>Estatísticas</h1>
                    <br />
                    <div class="row">
                        <div class="col-md-6 text-center">
                            <p class="mb-1" style="font-size: 22px;">
                                <i class="fas fa-chart-bar"></i>
                                <strong>Prognósticos Realizados:</strong>
                                <asp:Label ID="lbl_prognosticos_realizados" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label><br />
                                <asp:Label ID="lbl_total_prognosticos" runat="server" Text="0" Font-Bold="True" Font-Size="XX-Large" ForeColor="Blue"></asp:Label>
                            </p>
                        </div>
                        <div class="col-md-6 text-center">
                            <p class="mb-1" style="font-size: 22px;">
                                <i class="fas fa-trophy"></i>
                                <strong>Classificação Geral:</strong>
                                <asp:Label ID="lbl_classificacao_geral" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label><br />
                                <asp:Label ID="lbl_res_class" runat="server" Text="0º Lugar" Font-Bold="True" Font-Size="XX-Large" ForeColor="Blue"></asp:Label>
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 text-center">
                            <p class="mb-1" style="font-size: 22px;">
                                <i class="fas fa-star"></i>
                                <strong>Total Pontos:</strong>
                                <asp:Label ID="lbl_total_de_pontos" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label><br />
                                <asp:Label ID="lbl_total_pontos" runat="server" Text="0" Font-Bold="True" Font-Size="XX-Large" ForeColor="Blue"></asp:Label>
                            </p>
                        </div>
                        <div class="col-md-6 text-center">
                            <p class="mb-1" style="font-size: 22px;">
                                <i class="fas fa-medal"></i>
                                <strong>Classificação Pro:</strong>
                                <asp:Label ID="lbl_classificacao_pro" runat="server" Font-Bold="True" ForeColor="#FF9900"></asp:Label><br />
                                <asp:Label ID="lbl_class_pro" runat="server" Text="0º Lugar" Font-Bold="True" Font-Size="XX-Large" ForeColor="Blue"></asp:Label>
                            </p>
                        </div>
                    </div>
                    <!-- Adicione mais informações conforme necessário -->
                </div>
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-md-6 offset-md-6">
                <asp:Button ID="btn_sair" class="btn btn-danger btn-lg w-100" runat="server" Text="Sair" />
            </div>
        </div>
    </div>
    <br />
    <br />

</asp:Content>
