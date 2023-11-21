<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="EliminarRol.aspx.cs" Inherits="Prueba1.app.vistas.EliminarRol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="dinamico">
        <div class="cuadro1">
            <%--<img src="../../Ilustraciones/Eliminar.png" alt="User">--%>
        </div>
        <div class="cuadro2">
            <br />
            <br />
            <asp:Label ID="la1" CssClass="la2" runat="server" Text="Label">ELIMINAR ROL </asp:Label><br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" CssClass="la2" runat="server" Text="Label">Seleccione El Rol a Eliminar</asp:Label><br />
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="38px" Width="350px" CssClass="inp">
                <asp:ListItem Value="0">Elije el  rol a eliminar</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Button ID="Button1" runat="server" Height="46px" Text="Eliminar" OnClick="Button1_Click1" CssClass="boton2" />
        </div>
    </div>

</asp:Content>
