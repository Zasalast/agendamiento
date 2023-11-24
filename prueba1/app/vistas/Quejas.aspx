<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="Quejas.aspx.cs" Inherits="Prueba1.app.vistas.Quejas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="dinamico">
               <div class="cuadro1">
    <%--<img src="../../Ilustraciones/enojo.png" alt="User"  >--%>
        </div>
    <div class="cuadro2">
           <br />
        <br />
         <asp:Label id="Label3" CssClass="la2" runat="server" Text="Label">Digite Su Queja</asp:Label><br />
        <br />
        <br />
        <br />
    <asp:TextBox ID="TextBox1" runat="server" CssClass="inp"></asp:TextBox>
    <br />
        <br />
    <asp:Button ID="Buttonenviar" runat="server" Text="Enviar" OnClick="Buttonenviar_Click" CssClass="boton7"/>
        </div>
         </div>
</asp:Content>
