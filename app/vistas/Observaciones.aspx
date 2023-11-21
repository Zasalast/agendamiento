<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true"
  CodeBehind="Observaciones.aspx.cs" Inherits="Prueba1.app.vistas.Observaciones" %>



  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dinamico3">
      <br />
      <asp:Label id="Label3" CssClass="la2" runat="server" Text="Label">Agendamientos Solicitados</asp:Label><br />
      <br />
      <br />

      <asp:GridView ID="RowObservacion" runat="server" OnRowDeleting="RowObservacion_RowDeleting" CssClass="inp4"
        BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
        GridLines="None" Width="691px">
        <Columns>
          <asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Observacion" />
        </Columns>
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

      <asp:TextBox runat="server" ID="textbox1" CssClass="inp4" Width="700px" Height="200px"></asp:TextBox>
      <br />
      <asp:Label ID="Label1" runat="server" Text="Label" CssClass="la3">Asistio</asp:Label>
      <asp:RadioButton ID="RadioButton1" runat="server" GroupName="asistencia" CssClass="inp3" />
      <asp:Label ID="Label2" runat="server" Text="Label" CssClass="la3">No asisitio</asp:Label>
      <asp:RadioButton ID="RadioButton2" runat="server" GroupName="asistencia" CssClass="inp3" />
      <br />
      <br />
      <asp:Button runat="server" ID="boton1" Text="ENVIAR" OnClick="boton1_Click" CssClass="boton4" />
    </div>

  </asp:Content>