using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        int tipousuario1;

        protected void botoningreso_Click(object sender, EventArgs e)
        {

            string usuario = txtusername.Text;
            string clave = txtpassword.Text;



            try
            {
                control ctrl = new control();

                string respuesta = ctrl.ControlLogin(usuario, clave); //OBTENDRA ALGUN TIPO DE MENSAJE QUE GENEREN LOS METODOS
                if (respuesta.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + respuesta + "');", true);
                }
                else
                {
                    tipousuario1 = app.Session.id_rol_fk;

                    Response.Redirect("paginamaestra.aspx");


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + ex.Message + "');", true);

            }
        }
    }
}