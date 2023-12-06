<%@ Page Title="" Language="C#" MasterPageFile="~/menu_cliente.Master" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="BetInGoal.cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        /* Adicione estilos personalizados aqui, se necessário */
        .info-container {
            max-width: 740px;
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
                        
                        <!--Aqui começa-->

                        <asp:Label ID="lbl_alterar_passe" runat="server" CssClass="mb-1" Font-Size="Large">
                            <i class="fas fa-key" style="font-size: 22px;"></i>
                            <asp:HyperLink ID="hl_alterar_passe" runat="server" NavigateUrl="alterarpasse.aspx" Text="Alterar Palavra-Passe" Style="text-decoration: none;font-size: 22px;"></asp:HyperLink>
                        </asp:Label>

                        <asp:Label ID="lbl_enviar_prog_free" runat="server" CssClass="mb-1" Font-Size="Large">
                            <i class="fas fa-envelope" style="font-size: 22px;"></i>
                            <asp:HyperLink ID="hl_enviar_prog_free" runat="server" NavigateUrl="enviarprog.aspx" Text="Enviar Prognóstico FREE" Style="text-decoration: none;font-size: 22px;"></asp:HyperLink>
                        </asp:Label>

                        <asp:Label ID="lbl_enviar_prog_pro" runat="server" CssClass="mb-1" Font-Size="Large">
                            <i class="fas fa-envelope" style="font-size: 22px;"></i>
                            <asp:HyperLink ID="hl_enviar_prog_pro" runat="server" NavigateUrl="enviarprog.aspx" Text="Enviar Prognóstico PRO" Style="text-decoration: none;font-size: 22px;"></asp:HyperLink>
                        </asp:Label>

                        <asp:Label ID="lbl_comprar_subscricao" runat="server" CssClass="mb-1" Font-Size="Large">
                            <i class="fas fa-shopping-cart" style="font-size: 22px;"></i>
                            <asp:HyperLink ID="hl_comprar_subscricao" runat="server" NavigateUrl="comprarsubscricao.aspx" Text="Comprar Subscrição" Style="text-decoration: none;font-size: 22px;"></asp:HyperLink>
                        </asp:Label>

                         <asp:Label ID="lbl_ver_class_free" runat="server" CssClass="mb-1" Font-Size="Large">
                            <i class="fas fa-trophy" style="font-size: 22px;"></i>
                            <asp:HyperLink ID="hl_ver_class_free" runat="server" NavigateUrl="verclassfree.aspx" Text="Visualizar Classificação FREE" Style="text-decoration: none;font-size: 22px;"></asp:HyperLink>
                        </asp:Label>

                         <asp:Label ID="lbl_ver_class_pro" runat="server" CssClass="mb-1" Font-Size="Large">
                            <i class="fas fa-trophy" style="font-size: 22px;"></i>
                            <asp:HyperLink ID="hl_ver_class_pro" runat="server" NavigateUrl="verclasspro.aspx" Text="Visualizar Classificação PRO" Style="text-decoration: none;font-size: 22px;"></asp:HyperLink>
                        </asp:Label>

                         <asp:Label ID="lbl_criar_liga" runat="server" CssClass="mb-1" Font-Size="Large">
                            <i class="fas fa-users" style="font-size: 22px;"></i>
                            <asp:HyperLink ID="hl_criar_liga" runat="server" NavigateUrl="criarliga.aspx" Text="Criar Liga" Style="text-decoration: none;font-size: 22px;"></asp:HyperLink>
                        </asp:Label>

                          <asp:Label ID="lbl_visualizar_ligas" runat="server" CssClass="mb-1" Font-Size="Large">
                             <i class="fas fa-plus-circle" style="font-size: 22px;"></i>
                             <asp:HyperLink ID="hl_visualizar_ligas" runat="server" NavigateUrl="entrarliga.aspx" Text="Visualizar Ligas" Style="text-decoration: none;font-size: 22px;"></asp:HyperLink>
                          </asp:Label>

                        <!--Aqui termina-->
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

                    <!--começa aqui-->
                    <p class ="mb-1">
                        <asp:Label ID="lbl_data_subscricao" runat="server" CssClass="mb-1" Font-Size="Large" Font-Bold="True" style="font-size: 22px;" Text="Data Compra Subscrição: ">
                           <asp:Label ID="lbl_data_compra_subscricao" runat="server" Text="" Style="text-decoration: none;font-size: 22px;" ForeColor="#FF9900"></asp:Label>
                        </asp:Label>
                   </p>
                    <p class="mb-1">
                        <asp:Label ID="lbl_total_Subscricao" runat="server" CssClass="mb-1" Font-Size="Large" Font-Bold="True" style="font-size: 22px;" Text="Total de Dias Subscrição: ">
                            <asp:Label ID="lbl_total_dias_subscricao" runat="server" Text="" Style="text-decoration: none;font-size: 22px;" ForeColor="#FF9900"></asp:Label>
                        </asp:Label>
                    </p>
                    <!--termina aqui-->

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
                                <!--<strong ID="lbl_classificacao">Classificação Pro:</strong>-->
                                <asp:Label ID="lbl_classificacao" runat="server" Font-Bold="True" ForeColor="black"></asp:Label><br />
                                <asp:Label ID="lbl_class" runat="server" Text="0º Lugar" Font-Bold="True" Font-Size="XX-Large" ForeColor="Blue"></asp:Label>
                            </p>
                        </div>
                    </div>
                    <!-- Adicione mais informações conforme necessário -->
                </div>
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-md-6 offset-md-6">
                <asp:Button ID="btn_sair" class="btn btn-danger btn-lg w-100" runat="server" Text="Sair" OnClick="btn_sair_Click"/>
            </div>
        </div>
    </div>
    <br />
    <br />

</asp:Content>
