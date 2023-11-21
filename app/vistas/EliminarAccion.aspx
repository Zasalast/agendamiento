<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="EliminarAccion.aspx.cs" Inherits="Prueba1.app.vistas.EliminarAccion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>






<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="dinamico">
    <div class="cuadro1">
    <%--<img src="../../Ilustraciones/eliminarUsu.png" alt="User"  >--%>
        </div>

    <div class="cuadro2">
        <br /><br /><br /><asp:Label id="la1" CssClass="la2" runat="server" Text="Label">ELIMINAR ACCION </asp:Label><br /><br /><br /><br /><br />
       <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="280px" CssClass="inp">
                    <asp:ListItem Value="0">permisos con roles</asp:ListItem>
            </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Height="42px" OnClick="Button1_Click" Text="Eliminar"  CssClass="boton2"/>
        </div>
        </div>



         


</asp:Content>
