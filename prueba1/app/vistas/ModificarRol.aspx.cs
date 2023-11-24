using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class ModificarRol : System.Web.UI.Page
    {

        control contro = new control();
        protected void Page_Load(object sender, EventArgs e)
        {

            contro.controllistadinamicarol(DropDownList1, "usuario", "id_usuario", "usuario");
            contro.controllistadinamicarol(DropDownList2, "nombre_rol", "id_rol", "rol");


        }

        protected void ButtonModificar_Click(object sender, EventArgs e)
        {


            try
            {


                String respuesta = contro.controlcambiarolusuario(int.Parse(DropDownList2.SelectedValue), int.Parse(DropDownList1.SelectedValue));

                if (respuesta.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + respuesta + "');", true);

                    DropDownList1.ClearSelection();
                    DropDownList2.ClearSelection();
                    Label1.Text = "";
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (DropDownList1.SelectedItem.Value != "0")
            {
                contro.validarmostrarolusuairo(Label1, int.Parse(DropDownList1.SelectedValue));
            }
            else
            {
                Label1.Text = "";
            }



        }
    }
}