<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="CrearRol.aspx.cs" Inherits="Prueba1.app.vistas.CrearRol" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>






<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="dinamico">
        <div class="cuadro1">
            <%--<img src="../../Ilustraciones/crearRol.png" alt="User">--%>
        </div>

        <div class="cuadro2">
            <br />
            <br />
            <br />
            <asp:Label ID="la1" CssClass="la2" runat="server" Text="Label">CREAR ROL </asp:Label><br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" CssClass="la2" runat="server" Text="Label">Nombre del Rol</asp:Label><br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="37px" Width="250px" CssClass="inp"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Height="42px" OnClick="Button1_Click" Text="Crear" CssClass="boton2" />
        </div>
    </div>
</asp:Content>
