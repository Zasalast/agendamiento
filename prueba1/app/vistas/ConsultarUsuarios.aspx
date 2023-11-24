<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuarios.aspx.cs" Inherits="Prueba1.app.vistas.ConsultarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 

  
         <asp:Label id="Label1" CssClass="la4" runat="server" Text="Label">CONSULTAS</asp:Label><br />
    <div class="dinamico2">   
        <asp:Label id="Label2" CssClass="la3" runat="server" Text="Label">USUARIOS</asp:Label><br />
                   <asp:GridView ID="GridView1" runat="server" CssClass="inp6" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" Width="757px">
                       <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                       <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                       <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                       <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                       <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                       <SortedAscendingCellStyle BackColor="#F1F1F1" />
                       <SortedAscendingHeaderStyle BackColor="#594B9C" />
                       <SortedDescendingCellStyle BackColor="#CAC9C9" />
                       <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
         <%--<asp:Label id="Label3" CssClass="la3" runat="server" Text="Label">ROLES</asp:Label><br />
        <asp:GridView ID="GridView2" runat="server" CssClass="inp6">
        </asp:GridView>
           <asp:Label id="Label4" CssClass="la3" runat="server" Text="Label">PERMISOS</asp:Label><br />
        <asp:GridView ID="GridView3" runat="server" CssClass="inp6">--%>
       <%-- </asp:GridView>
        <asp:GridView ID="GridView4" runat="server" CssClass="inp">
        </asp:GridView>--%>

        </div>

</asp:Content>
