<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuienesSomos.aspx.cs" Inherits="Prueba1.app.vistas.QuienesSomos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>¿Quienes Somos?</title>
    <link href="../Stilos/StyleQuienesSomos.css" rel="stylesheet" />
    <link href="" rel="stylesheet" />
</head>
<body>


    <div>
        <header class="header">

            <nav class="menu">
                <a href="index.aspx">Volver</a>

            </nav>
        </header>
    </div>


    <div class="contenedor">

        <header>
        </header>



        <div class="login" style="top:0px; left:440px; position:relative">
            <article class="fondo">
               <%--  <img src="../img/pro1.png" alt="User"> --%>
                <h3>Maria Alejandra Marín Galindon</h3>
                <h2>Correo:</h2>
                <h1>m.marin@udla.edu.co</h1>
                <h2>Universidad de la Amazonia</h2>
                <h2>Ingenieria de Sistemas</h2>

            </article>
        </div>

        <div class="login" style="position:relative; top:400px; left:-455px;">
            <article class="fondo">
            <%-- <img src="../img/pro3.png" alt="User"> --%>
                <h3>Valeria Salazar Serna </h3>
                <h2>Correo:</h2>
                <h1>va.salazas@udla.edu.co</h1>
                <h2>Universidad de la Amazonia</h2>
                <h2>Ingenieria de Sistemas</h2>
            </article>
        </div>

    </div>
</body>
</html>
