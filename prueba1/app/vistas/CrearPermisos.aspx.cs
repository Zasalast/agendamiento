using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class CrearPermisos : System.Web.UI.Page
    {
        control contrl = new control();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {


                String respuesta = contrl.controlinsertarpermisos(TextBox1.Text.Trim(), TextBox2.Text.Trim());

                if (respuesta.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + respuesta + "');", true);

                    TextBox1.Text = null;


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