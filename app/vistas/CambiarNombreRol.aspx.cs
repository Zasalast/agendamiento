using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class CambiarNombreRol : System.Web.UI.Page
    {
        control contrll = new control();
        protected void Page_Load(object sender, EventArgs e)
        {
            contrll.controllistadinamicarol(DropDownList1, "nombre_rol", "id_rol", "rol");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {


                String respuesta = contrll.controlmodificarol(DropDownList1.SelectedIndex, TextBox1.Text);

                if (respuesta.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + respuesta + "');", true);

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