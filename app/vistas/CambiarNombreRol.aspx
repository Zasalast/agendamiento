<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="CambiarNombreRol.aspx.cs" Inherits="Prueba1.app.vistas.CambiarNombreRol" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="dinamico">
    <div class="cuadro1">
    <%--<img src="../../Ilustraciones/cambiarNombre.png" alt="User"  >--%>
        </div>

    <div class="cuadro2">
        <br /><br /><br /><asp:Label id="la1" CssClass="la2" runat="server" Text="Label">MODIFICAR NOMBRE DE ROLES </asp:Label><br /><br /><br /><br /><br />
   
            <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="280px" CssClass="inp">
                 <asp:ListItem value="0">Elije EL ROL a Modificar</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server" Height="37px" Width="250px" CssClass="inp"></asp:TextBox>


            <asp:Button ID="Button1" runat="server" Text="Modificar" OnClick="Button1_Click" CssClass="boton2"/>

        </div>
        </div>



</asp:Content>
