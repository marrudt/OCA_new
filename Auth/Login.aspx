<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Auth.Login" %>

<!DOCTYPE html>


<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <%--<link href="Content/bootstrap.min.css" rel="stylesheet" />--%>
    <title>Login - OCA</title>
</head>

<body style="font-family: Segoe UI, Verdana, Helvetica, Sans-Serif; font-size: small">
    <form id="form1" runat="server">
        <asp:Image ImageUrl="Images/Logo Oca_1.png" Width="280" Height="180" alt="imgf" runat="server" ID="OCA" class="imgcenter" />
        <h4 style="text-align: left"><b>Inicio de sesión</b></h4>
        <hr />
        <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false"></asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
            <div>
                <h4 style="text-align: left">Usuario</h4>
                <asp:Label runat="server" AssociatedControlID="UserName" autocomplete="on"></asp:Label>
                <asp:TextBox runat="server" ID="UserName" autocomplete="off"></asp:TextBox>
            </div>
            <div>
                <h4 style="text-align: left">Contraseña</h4>
                <asp:Label runat="server" Style="text-align: center" AssociatedControlID="Password"></asp:Label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" autocomplete="off"></asp:TextBox>
            </div>
            <div>
                <div class="editor-field">
                    <asp:Button runat="server" OnClick="SignIn" Text="Entrar" Class="btn btn-success"></asp:Button>
                    <%--<button class="btn btn-primary" role="link" onclick="CreateUser_Click">Registrar</button>--%>
                    <a class="btn btn-primary" href="http://localhost:62536/registrar.aspx">Registrar</a>
                </div>
            </div>
        </asp:PlaceHolder>     

        <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
            <div>
                <div>
                    <%--<h4 style="text-align: left">Usuario registrado correctamente</h4>--%>
                    <asp:Button runat="server" Style="margin: auto" OnClick="SignOut" Text="Iniciar Sesión" Class="btn btn-success" />
                </div>

            </div>
        </asp:PlaceHolder>
        <hr />
        <p>
            <b>
                <asp:Label runat="server" Style="color: red">
                    <asp:Literal runat="server" ID="StatusText" /></asp:Label></b>
        </p>
    </form>
</body>
</html>
