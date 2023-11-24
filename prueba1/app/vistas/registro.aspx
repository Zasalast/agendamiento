<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Prueba1.app.vistas.registro" %>

<!DOCTYPE html>
<%--<html>--%>
<head runat="server">
    <meta charset="utf-8">
    <title>Login</title>
    <link href="~/app/Stilos/registro.css" rel="stylesheet" type="text/css" runat="server">
    <script src='https://kit.fontawesome.com/a076d05399.js'></script>
    <link href="~/app/font.css" rel="stylesheet" type="text/css" runat="server">
    <link href="https://fonts.googleapis.com/css?family=Josefin+Sans|Montez|Pathway+Gothic+One" rel="stylesheet" type="text/css" runat="server">
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/bootstrap.min.js"></script>
    <script src="../JavaScript/validacion.js"></script>



</head>
<body>


     <div class="contenedor">
        <div class="registro">
            <article class="fondo">
                <img src="../img/user3.svg" alt="User"><form id="form1" runat="server" >


                 &nbsp;<h3 style="position:absolute">Registro</h3>
                    
     
                 <%--<span>--%>
                    <br />
                     <br /> <br />
                     <asp:DropDownList ID="TipoIdentificacion" CssClass="inp"  Height="34px" Width="280px" runat="server" style="position:relative; top: 224px;" >
                        <asp:ListItem Value="0">Elija tipo de Identificacion</asp:ListItem>
                
                    </asp:DropDownList>



                    <p>
                    <asp:TextBox ID="username" runat="server"  Height="34px" Width="150px" CssClass="inp" placeholder="Usuario"></asp:TextBox>

                 </p>


                      <%--<span class="icon-profile"></span>--%>
                    <asp:TextBox ID="documento" runat="server" Height="34px" Width="150px" CssClass="inp" placeholder="Documento" onkeypress="return SoloNumeros(event)" style="position:relative; top: 245px;"></asp:TextBox><br />
                    <br />
                    <%--<span class="icon-profile"></span>--%>
                    <br />

                    <asp:TextBox ID="nombre1" runat="server" Height="34px" Width="250px" CssClass="inp" placeholder="Primer nombre" onkeypress="return SoloLetras(event)" style="position:absolute; top: 202px; left:346px;"></asp:TextBox>
                    
                   
                    <br />
                    <%--<span class="icon-profile"></span>--%>
                    <asp:TextBox ID="nombre2" runat="server" Height="34px" Width="250px" CssClass="inp" placeholder="Segundo nombre" onkeypress="return SoloLetras(event)" style="position:absolute; top: 198px; left:800px; width: 249px;"></asp:TextBox><br />
                        <br />
                        <%--<span class="icon-profile"></span>--%>
                        <asp:textbox id="apellido1" runat="server" height="34px" width="310px" cssclass="inp" placeholder="Primer apellido" onkeypress="return sololetras(event)"  style="position:absolute; top: 298px; left:343px; width: 249px;"></asp:textbox><br />
                        <br />
                        <%--<span class="icon-profile"></span>--%>
                        <asp:TextBox ID="apellido2" runat="server" Height="34px" Width="309px" CssClass="inp" placeholder="Segundo apellido" onkeypress="return SoloLetras(event)" style="position:absolute; top: 297px; left:800px; width: 249px;"></asp:TextBox><br />
                        <%--<br /><span class="icon-mail4"></span>--%>
                        <br />
                        <br />
                    
                        <asp:TextBox ID="email" runat="server" Height="34px" Width="310px" CssClass="inp" placeholder="Correo" TextMode="Email" style="position:absolute; top: 366px; left:346px; width: 249px;"></asp:TextBox>
                    
                       
                       <%-- <span class="icon-lock"></span>--%>
                        <asp:TextBox ID="contra1" runat="server" Height="34px" Width="310px" CssClass="inp" placeholder="Contraseña"  TextMode="Password" style="position:absolute; top: 368px; left:800px; width: 249px;" ></asp:TextBox><br />
                        <%--<span class="icon-lock"></span>--%> 
                        <asp:TextBox ID="contra2" runat="server" Height="34px" Width="310px" CssClass="inp" placeholder="Confirme su contraseña"  TextMode="Password" style="position:absolute; top: 450px; left:800px; width: 249px;"></asp:TextBox><br /> 
                        
                    <br /> <asp:DropDownList ID="TipoRol" CssClass="inp" runat="server" Height="34px" Width="310"  style="position:absolute; top: 449px; left:346px; width: 249px;">
                            <asp:ListItem Value="0">Elija un Rol</asp:ListItem>
                
                        </asp:DropDownList><br />
                        <br />


                        <b  style="position:absolute; top: 509px; left:189px; width: 249px;">¿Ya tienes una cuenta?</b>
                        <a  style="position:absolute; top: 511px; left:232px; width: 249px;"  href="index.aspx" class="he2">Iniciar Sesion</a>&nbsp; 
                   
                    <asp:Button ID="Button1" runat="server"  Text="REGISTRAR USUARIO"  CssClass="boton" OnClick="Buttonregistro_Click" style="position:absolute; top: 539px; left: 57px;"/>
                   
                    
                       
                    
                    
                </form>
            </article>
        </div>


    </div>
</body>
<%--</html>--%>
