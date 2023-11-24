<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="CrearPermisos.aspx.cs" Inherits="Prueba1.app.vistas.CrearPermisos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="dinamico">
    <div class="cuadro1">
    <%--<img src="../../Ilustraciones/crearPermisos.png" alt="User"  >--%>
        </div>

    <div class="cuadro2">
        <br /><br /><br /><asp:Label id="la1" CssClass="la2" runat="server" Text="Label">CREAR PERMISOS </asp:Label><br /><br /><br /><br /><br />
        <asp:Label id="Label3" CssClass="la3" runat="server" Text="Label">Digite El Nombre</asp:Label><br />
      <asp:TextBox ID="TextBox1" runat="server" Height="37px" Width="250px" CssClass="inp"></asp:TextBox><br />
        <asp:Label id="Label1" CssClass="la3" runat="server" Text="Label">Digite La Url</asp:Label><br />
           <asp:TextBox ID="TextBox2" runat="server" Height="37px" Width="250px" CssClass="inp"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Height="42px" OnClick="Button1_Click" Text="Crear"  CssClass="boton2"/>
        </div>
        </div>

</asp:Content>
