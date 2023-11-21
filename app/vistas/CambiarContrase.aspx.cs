using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class CambiarContrase : System.Web.UI.Page
    {

        control contrl = new control();

        protected void Page_Load(object sender, EventArgs e)
        {
            contrl.controllistadinamicarol(DropDownList1, "usuario", "id_usuario", "usuario");
            contrl.validartiporol(DropDownList1);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {


                String respuesta = contrl.controlcambiarclave(DropDownList1, TextBox1.Text, int.Parse(DropDownList1.SelectedValue));


                if (respuesta.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + respuesta + "');", true);

                    DropDownList1.ClearSelection();

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('ROL modificado');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + ex.Message + "');", true);
            }


        }
    }
}