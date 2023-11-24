<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true" CodeBehind="ReporteEstuAgendamiento.aspx.cs" Inherits="Prueba1.app.vistas.ReporteEstuAgendamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.12.4.js"></script>
    <script src="../../Scripts/jquery-ui-1.12.1.js"></script>
     <script>
         $(function () {
             
                 from = $("#<%=TextBox1.ClientID%>")
                     .datepicker({
                         defaultDate: "+1w",
                         changeMonth: true,
                         numberOfMonths: 1,
                         dateFormat : "dd/mm/yy"
                     })
                     .on("change", function () {
                         to.datepicker("option", "minDate", getDate(this));
                     }),
                 to = $("#<%=TextBox2.ClientID%>").datepicker({
                     defaultDate: "+1w",
                     changeMonth: true,
                     numberOfMonths: 1,
                     dateFormat: "dd/mm/yy"
                 })
                     .on("change", function () {
                         from.datepicker("option", "maxDate", getDate(this));
                     });

             function getDate(element) {
                 var date;
                 try {
                     date = $.datepicker.parseDate("dd/mm/yy", element.value);
                 } catch (error) {
                     date = null;
                 }

                 return date;
             }
             
         });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="dinamico">
               <div class="cuadro1">
    <%--<img src="../../Ilustraciones/reportest.png" alt="User"  >--%>
        </div>
    <div class="cuadro2">
             <br />
        <br />
         <asp:Label id="Label3" CssClass="la2" runat="server" Text="Label">Seleccione Desde</asp:Label><br />
    <asp:TextBox ID="TextBox1" runat="server" CssClass="inp" TextMode="Date"></asp:TextBox>
         <br />
        <br />
         <asp:Label id="Label1" CssClass="la2" runat="server" Text="Label">Seleccione Hasta </asp:Label><br />
    <asp:TextBox ID="TextBox2" runat="server" CssClass="inp" TextMode="Date"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Reporte Observaciones" OnClick="Button1_Click" CssClass="boton7"/>
    <br />
        <br />
    <asp:GridView id="gridview1" runat="server" CssClass="inp" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
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
    <br />
    <br />
     <asp:Button id="boton1PDF" runat="server" Text="GENERAR PDF" OnClick="boton1PDF_Click" CssClass="boton7"/>
    <%--<asp:Button ID="Button2EXCEL" runat="server" Text="GENERAR EXCEL" OnClick="Button2EXCEL_Click" CssClass="boton7"/>--%>
        </div>
          </div>
</asp:Content>
