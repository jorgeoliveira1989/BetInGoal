<%@ Page Title="" Language="C#" MasterPageFile="~/menu_admin.Master" AutoEventWireup="true" CodeBehind="desativarupgrade.aspx.cs" Inherits="BetInGoal.aceitarupgrades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
        <div class="p-4 border rounded bg-light">
            <h3 class="mb-4 text-center"><b>Desativar Upgrade de Contas</b></h3>
            <div>
                <div class="mb-3">
                    <label for="txtid" class="form-label">ID</label>
                    <asp:DropDownList ID="ddl_id" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddl_id_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="id_cliente" DataValueField="id_cliente">
                        <asp:ListItem>-----</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BetinGoalConnectionString %>" SelectCommand="SELECT [id_cliente] FROM [clientes] WHERE ([tipo_cliente] = @tipo_cliente)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="PRO" Name="tipo_cliente" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="mb-3">
                    <label for="txt_nome" class="form-label"><b>Nome</b></label>
                    <br />
                    <asp:Label runat="server" ID="lbl_nome" class="form-control"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="txt_tipoCliente" class="form-label"><b>Tipo Cliente Atual</b></label>
                    <br />
                    <asp:Label runat="server" ID="lbl_tipoConta" class="form-control"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="txt_opcao" class="form-label"><b>Alterar Tipo Cliente</b></label>
                    <br />
                    <asp:Label runat="server" ID="lbl_altera_cliente" class="form-control"></asp:Label>
                </div>
                <br />
                <div class="d-grid">
                    <asp:Button ID="btn_alterar_tipo_cliente" class="btn btn-danger w-100" runat="server" Text="Alterar Tipo Cliente" Font-Bold="True" Font-Size="Medium" OnClick="btn_alterar_tipo_cliente_Click" />
                </div>
                <br />
                <div class="mb-3">
                    <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
