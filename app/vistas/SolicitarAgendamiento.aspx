<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true"
    CodeBehind="SolicitarAgendamiento.aspx.cs" Inherits="Prueba1.app.vistas.SolicitarAgendamiento" %>


    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../Content/themes/base/jquery-ui.css" rel="stylesheet" />
        <script src="../../Scripts/jquery-1.12.4.js"></script>
        <script src="../../Scripts/jquery-ui-1.12.1.js"></script>
        <script>
            $(function () {

                from = $("#<%=from.ClientID%>")
                    .datepicker({
                        defaultDate: "+1w",
                        changeMonth: true,
                        numberOfMonths: 1,
                        dateFormat: "dd/mm/yy"
                    })
                    .on("change", function () {
                        to.datepicker("option", "minDate", getDate(this));
                    }),
                    to = $("#<%=to.ClientID%>").datepicker({
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

        <div class="scr">
            <asp:Label ID="Label2" CssClass="la4" runat="server" Text="Label">Solicitar Agendamiento</asp:Label><br />
            <br />



            <asp:DropDownList ID="DropDownList2" runat="server" Height="35px" Width="280px" CssClass="inp4">
                <asp:ListItem Value="0">Seleccione El Genero</asp:ListItem>
            </asp:DropDownList>


            <asp:Label ID="Label1" CssClass="la6" runat="server" Text="Label">de</asp:Label>
            <asp:TextBox ID="from" name="from" runat="server" TextMode="Date"></asp:TextBox>
            <asp:Label ID="Label3" CssClass="la6" runat="server" Text="Label">Hasta</asp:Label>
            <asp:TextBox ID="to" name="to" runat="server" TextMode="Date"></asp:TextBox>







            <br />

            <asp:GridView ID="GridView1" runat="server" CssClass="inp4" OnRowDeleting="GridView1_RowDeleting"
                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                CellSpacing="1" GridLines="None" Width="927px">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Solicitar" />

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
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="BUSCAR" CssClass="boton5" OnClick="Button2_Click" /><br />
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"> </asp:Timer>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" />
            </Triggers>

        </asp:UpdatePanel>
    </asp:Content>