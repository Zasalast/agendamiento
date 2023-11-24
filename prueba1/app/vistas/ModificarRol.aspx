<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="ModificarRol.aspx.cs" Inherits="Prueba1.app.vistas.ModificarRol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dinamico">
        <div class="cuadro1">
            <%--<img src="../../Ilustraciones/modRol.png" alt="User">--%>
        </div>
        <div class="cuadro2">


            <br />
            <br />
            <br />
            <asp:Label ID="la1" CssClass="la2" runat="server" Text="Label">MODIFICAR ROL DE USUARIOS</asp:Label><br />
            <br />
            <br />
            <br />
            <br />


            <asp:DropDownList ID="DropDownList1" CssClass="inp" runat="server" Height="30px" Width="280px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="0">Elije el usuario existente</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="Label1" runat="server" Text="" CssClass="la3"></asp:Label><br />
            <br />



            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="inp" Width="280px" Height="30px">
                <asp:ListItem Value="0">Elije el rol a cambiar</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="ButtonModificar" runat="server" Text="Modificar" OnClick="ButtonModificar_Click" CssClass="boton2" />



        </div>



    </div>


</asp:Content>
