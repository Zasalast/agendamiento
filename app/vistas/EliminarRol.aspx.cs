using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class EliminarRol : System.Web.UI.Page
    {
        control contrl = new control();
        int cont = 1;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (cont >= 1)
            {
                contrl.controllistadinamicarol(DropDownList1, "nombre_rol", "id_rol", "rol where id_rol != 1");
            }

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {


                String respuesta = contrl.controleliminarrol(Convert.ToInt32(DropDownList1.SelectedValue));
                Response.Write(Convert.ToString(DropDownList1.Items.Count));

                if (respuesta.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + respuesta + "');", true);

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('ROL eliminado');", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + ex.Message + "');", true);
            }
            Response.Redirect("EliminarRol.aspx");

        }
    }
}