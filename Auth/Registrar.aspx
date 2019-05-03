<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Auth.Registrar" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <%--<link href="Content/bootstrap.min.css" rel="stylesheet" />--%>
    <title>Registro - OCA</title>
</head>
<body style="font-family: Segoe UI, Verdana, Helvetica, Sans-Serif; font-size: small">
    <form id="form1" runat="server">
        <asp:Image ImageUrl="Images/Logo Oca_1.png" Width="280" Height="180" alt="imgf" runat="server" ID="OCA" class="imgcenter" />
        <h3 style="text-align: left">Registro de Usuario</h3>
        <hr />
        <div>
            <h4 style="text-align: left">Usuario</h4>
            <asp:Label runat="server" AssociatedControlID="UserName"></asp:Label>
            <asp:TextBox runat="server" ID="UserName"></asp:TextBox>
        </div>
        <div>
            <h4 style="text-align: left">Contraseña</h4>
            <asp:Label runat="server" Style="text-align: center" AssociatedControlID="Password"></asp:Label>
            <asp:TextBox runat="server" ID="Password" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <h4 style="text-align: left">Confirmar constraseña</h4>
            <asp:Label runat="server" Style="text-align: center" AssociatedControlID="Password"></asp:Label>
            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <div class="editor-field">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrar" Class="btn btn-primary" />
            </div>
        </div>
        <hr />
        <p>
            <b>
                <asp:Label runat="server" Style="color: red">
                    <asp:Literal runat="server" ID="StatusMessage" /></asp:Label></b>
        </p>
    </form>
</body>
</html>
