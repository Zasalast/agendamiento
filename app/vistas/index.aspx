<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Prueba1.app.vistas.index" %>

<!DOCTYPE html>
<html>
<head runat="server">


    <meta charset="utf-8">
    <title>Login</title>
    <link rel="stylesheet" href="~/app/Stilos/Styleslogin.css" type="text/css" runat="server">
    <script src='https://kit.fontawesome.com/a076d05399.js'></script>
    <link rel="stylesheet" href="~/app/font.css" type="text/css" runat="server">
    <link href="https://fonts.googleapis.com/css?family=Josefin+Sans|Montez|Pathway+Gothic+One" rel="stylesheet" type="text/css" runat="server">
</head>
<body runat="server">
         <div class="contenedor">

        <header>
        </header>


        <div class="login">
            <article class="fondo">
                <img src="../img/grupo.png" alt="User">
                <h3>Iniciar Sesión</h3>
                <form id="formatoringresar" runat="server">
                    <span class="fas fa-user-alt"></span>
                    <asp:TextBox ID="txtusername" runat="server" Height="34px" Width="320px" CssClass="inp" placeholder="digite su nombre de usuario"></asp:TextBox><br />
                    <br />
                    <span class="fas fa-user-shield"></span>
                    <asp:TextBox ID="txtpassword" runat="server" Height="34px" Width="320px" CssClass="inp" placeholder="digite su contraseña" TextMode="Password"></asp:TextBox><br />
                    <a href="registro.aspx" class="he2">Registrarse</a><br>
                    <br>
                    <a href="QuienesSomos.aspx" class="he3">¿Quienes Somos?</a><br>
                    <br>
                   <!-- <a href="" class="he">Olvide mi Constraseña?</a>-->
                    <asp:Button ID="botoningreso" runat="server"  Text="INGRESAR USUARIO" CssClass="boton" OnClick="botoningreso_Click"  />
                </form>
            </article>
        </div>

        <div class="imagen">
            <%--imagen flotante--%>
            <img src="" alt="">
        </div>

    </div>



</body>
</html>


