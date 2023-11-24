using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class CrearAccion : System.Web.UI.Page
    {

        control contrll = new control();
        protected void Page_Load(object sender, EventArgs e)
        {
            contrll.controllistadinamicarol(DropDownList1, "nombre_rol", "id_rol", "rol");
            contrll.controllistadinamicarol(DropDownList2, "descripcion", "idpermisos", "permisos");


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {


                String respuesta = contrll.controldarpermisos(int.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue));

                if (respuesta.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + respuesta + "');", true);

                    DropDownList1.ClearSelection();
                    DropDownList2.ClearSelection();

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