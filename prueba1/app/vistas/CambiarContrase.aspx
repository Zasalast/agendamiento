<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="CambiarContrase.aspx.cs" Inherits="Prueba1.app.vistas.CambiarContrase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="dinamico">
    <div class="cuadro1">
    <%--<img src="../../Ilustraciones/contraseña.png" alt="User"  >--%>
        </div>


        <div class="cuadro2">
        <br /><br /><br /><asp:Label id="la1" CssClass="la2" runat="server" Text="Label">CAMBIAR CONTRASEÑA </asp:Label><br /><br /><br /><br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="31px" Width="400px" CssClass="inp">
            <asp:ListItem Value="0">Elije el usuario a cambiar la contraseña</asp:ListItem>
            </asp:DropDownList>
            <br /><br /><br /><asp:Label id="Label1" CssClass="la3" runat="server" Text="Label">DIGITE LA NUEVA CONTRASEÑA</asp:Label><br />
            <asp:TextBox ID="TextBox1" runat="server" Height="30px" TextMode="Password" Width="250px" CssClass="inp"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cambiar Contraseña" CssClass="boton3"/>
              </div>
        </div>

</asp:Content>
