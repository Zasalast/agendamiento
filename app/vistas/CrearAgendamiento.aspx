<%@ Page Language="C#" MasterPageFile="~/app/vistas/Principal.Master" AutoEventWireup="true"
  CodeBehind="CrearAgendamiento.aspx.cs" Inherits="Prueba1.app.vistas.CrearAgendamiento" %>


  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





    <div class="registro3">
      <br />
      <asp:Label id="la1" CssClass="la4" runat="server" Text="Label">CREAR PLANTILLA </asp:Label><br />
      <br />
      <br />

      <asp:Label id="Label3" CssClass="la5" runat="server" Text="Label">Seleccione la Fecha de Inicio</asp:Label>
      <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" CssClass="inp"></asp:TextBox>

      <asp:Label id="Label1" CssClass="la5" runat="server" Text="Label">Seleccione la Fecha Final</asp:Label>
      <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" CssClass="inp"></asp:TextBox><br />

      <asp:TextBox ID="nombreAgenda" runat="server" Height="34px" Width="310px" CssClass="inp4"
        placeholder="Nombre Agendamiento" style="position:relative; top: 10px; left:150px"
        onkeypress="return SoloLetras(event)"></asp:TextBox>
      <asp:TextBox ID="NombreTema" runat="server" Height="34px" Width="310px" CssClass="inp4"
        placeholder="Nombre Del Genero" style="position:relative; top: 10px; left:300px"
        onkeypress="return SoloLetras(event)"></asp:TextBox><br />

      <asp:DropDownList ID="DropDownList1" runat="server" style="position:relative; top: 35px; left:175px" Height="35px"
        Width="280px" CssClass="inp4">
        <asp:ListItem Value="0">Duracion del Encuentro</asp:ListItem>
        <asp:ListItem Value="10">10</asp:ListItem>
        <asp:ListItem Value="20">20</asp:ListItem>
        <asp:ListItem Value="30">30</asp:ListItem>
      </asp:DropDownList>
      <asp:DropDownList ID="DropDownList2" runat="server" Height="35px" style="position:relative; top: 35px; left:250px"
        Width="400px" CssClass="inp4">
        <asp:ListItem Value="0">Seleccionar rango tiempo cancelacion</asp:ListItem>
        <asp:ListItem Value="30">30</asp:ListItem>
        <asp:ListItem Value="40">40</asp:ListItem>
        <asp:ListItem Value="60">60</asp:ListItem>
      </asp:DropDownList><br />

      <asp:Button ID="Button1" runat="server" Height="42px" Text="Crear" CssClass="boton6" OnClick="Button1_Click" />

    </div>



    <asp:Panel ID="Panel1" runat="server" class="registro4">
      <br />
      <asp:Label id="Label5" CssClass="la4" runat="server" style="position:relative; top: 18px; left:65px" Text="Label">
        CREAR Agendamiento</asp:Label><br />
      <br />


      <asp:DropDownList ID="DropDownList5" runat="server" style="position:relative; top: 18px; left:285px" Height="35px"
        Width="280px" CssClass="inp10" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="0">Seleccion la plantilla</asp:ListItem>
      </asp:DropDownList><br />



      <asp:Label id="Label2" CssClass="la4" runat="server" Text="Label">Seleccione los dias de atencion</asp:Label>
      <br />
      <br />
      <br />
      <asp:RadioButton ID="RadioButton1" runat="server" CssClass="inp9" GroupName="dias" />
      <asp:Label ID="Label4" runat="server" Text="Label" CssClass="la3">LUNES</asp:Label>
      <asp:RadioButton ID="RadioButton2" runat="server" CssClass="inp3" GroupName="dias" />
      <asp:Label ID="Label8" CssClass="la3" runat="server" Text="Label">MARTES </asp:Label>
      <asp:RadioButton ID="RadioButton3" runat="server" CssClass="inp3" GroupName="dias" />
      <asp:Label ID="Label9" CssClass="la3" runat="server" Text="Label">MIERCOLES </asp:Label>
      <asp:RadioButton ID="RadioButton4" runat="server" CssClass="inp3" GroupName="dias" />
      <asp:Label ID="Label10" CssClass="la3" runat="server" Text="Label">JUEVES </asp:Label>
      <asp:RadioButton ID="RadioButton5" runat="server" CssClass="inp3" GroupName="dias" />
      <asp:Label ID="Label11" CssClass="la3" runat="server" Text="Label">VIERNES </asp:Label>
      <asp:RadioButton ID="RadioButton6" runat="server" CssClass="inp3" GroupName="dias" />
      <asp:Label ID="Label12" CssClass="la3" runat="server" Text="SABADO"></asp:Label><br />
      <br />
      <br />
      <br />
      <br />
      <asp:Label ID="Label6" runat="server" Text="Label" CssClass="la7">HORA INICIO</asp:Label>
      <asp:TextBox ID="TextBox3" runat="server" CssClass="inp" TextMode="Time"></asp:TextBox>

      <asp:Label ID="Label7" runat="server" Text="Label" CssClass="la5">HORA FIN</asp:Label>
      <asp:TextBox ID="TextBox4" runat="server" TextMode="Time" CssClass="inp"></asp:TextBox>


      <asp:GridView ID="GridView1" runat="server" CssClass="inp10" OnRowDeleting="GridView1_RowDeleting"
        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing"
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" BackColor="White"
        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None"
        Width="753px">

        <Columns>
          <asp:CommandField ButtonType="Button" ShowDeleteButton="true" />
          <%--<asp:CommandField ButtonType="Button" ShowEditButton="true" EditText="Editar" />--%>

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
      </asp:GridView><br />


      <br />



      <asp:Button ID="Button2" runat="server" Text="Crear" CssClass="boton6" OnClick="Button2_Click" />

    </asp:Panel>








  </asp:Content>