<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="Prueba1.app.vistas.CrearUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



  

         
       <br /><asp:Label id="la1" CssClass="la4" runat="server" Text="Label">CREAR USUARIOS </asp:Label>

                   <div class="dinamico2">
  
        <div class="registro2">
          
                  
                    <asp:TextBox ID="username" runat="server" Height="34px" Width="310px" CssClass="inp2" placeholder="digite su nombre de usuario"  ></asp:TextBox>
                    <br />
                     <asp:DropDownList ID="Tipodocumento" CssClass="inp4" runat="server" Height="34px" Width="350px" >
                        <asp:ListItem Value="0">Elije El Tipo De Identificacion</asp:ListItem>
                    <asp:ListItem Value="1">Tarjeta de Identidad</asp:ListItem>
                    <asp:ListItem Value="2">Cedula de Ciudadania</asp:ListItem>
                    <asp:ListItem Value="3">Cedula de Extranjeria</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    
                    <asp:TextBox ID="documento" runat="server" Height="34px" Width="310px" CssClass="inp2" placeholder="digite  Numero de documento" onkeypress="return SoloNumeros(event)"></asp:TextBox><br />
                    
                   
                    <asp:TextBox ID="nombre1" runat="server" Height="34px" Width="310px" CssClass="inp3" placeholder="digite  primer nombre" onkeypress="return SoloLetras(event)"></asp:TextBox>
                    
                    
                    <asp:TextBox ID="nombre2" runat="server" Height="34px" Width="310px" CssClass="inp3" placeholder="digite  segundo nombre" onkeypress="return SoloLetras(event)"></asp:TextBox><br />
                    <br />
                   
                    <asp:TextBox ID="apellido1" runat="server" Height="34px" Width="310px" CssClass="inp3" placeholder="digite  primer apellido" onkeypress="return SoloLetras(event)"></asp:TextBox>
                   
                    
                    <asp:TextBox ID="apellido2" runat="server" Height="34px" Width="309px" CssClass="inp3" placeholder="digite  segundo apellido" onkeypress="return SoloLetras(event)"></asp:TextBox><br />
                    
           
                    <asp:TextBox ID="email" runat="server" Height="34px" Width="310px" CssClass="inp2" placeholder="digite  email" TextMode="Email"></asp:TextBox><br />
                    
                   
                    <asp:TextBox ID="contra1" runat="server" Height="34px" Width="310px" CssClass="inp3" placeholder="digite  contraseña"  TextMode="Password" ></asp:TextBox>
                    
                    <asp:TextBox ID="contra2" runat="server" Height="34px" Width="310px" CssClass="inp3" placeholder="Confirme  contraseña"  TextMode="Password" ></asp:TextBox><br /> 
                    <br /> <asp:DropDownList ID="TipoRol" CssClass="inp4" runat="server" Height="34px" Width="350px" >
                        <asp:ListItem Value="0">Elija un Rol</asp:ListItem>
                    <asp:ListItem Value="2">Estudiante</asp:ListItem>
                    <asp:ListItem Value="3">Profesor</asp:ListItem>
                        <asp:ListItem Value="4">Persona</asp:ListItem>
                    </asp:DropDownList><br />
                    

                   
                <asp:Button ID="Button1" runat="server"  Text="REGISTRAR USUARIO"  CssClass="boton4" OnClick="Button1_Click" />
           
        
        </div>

          </div>
    

</asp:Content>
