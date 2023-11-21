using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class Observaciones : System.Web.UI.Page
    {
        control contrll = new control();
        static string tema = null, dia = null, fecha = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            consulta();
            textbox1.Visible = false;
            boton1.Visible = false;
            RadioButton1.Visible = false;
            RadioButton2.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
        }



        protected void RowObservacion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            tema = RowObservacion.Rows[e.RowIndex].Cells[2].Text;
            dia = RowObservacion.Rows[e.RowIndex].Cells[3].Text;
            fecha = RowObservacion.Rows[e.RowIndex].Cells[4].Text;
            textbox1.Visible = true;
            boton1.Visible = true;
            RadioButton1.Visible = true;
            RadioButton2.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            RowObservacion.Visible = false;

        }

        protected void boton1_Click(object sender, EventArgs e)
        {
            contrll.controlinsertarobservacion(textbox1.Text, Convert.ToDateTime(fecha).ToString("yyyy-MM-dd HH:mm:ss"), dia, tema, asistio());

            textbox1.Visible = false;
            boton1.Visible = false;
            textbox1.Text = null;
            RadioButton1.Visible = false;
            RadioButton2.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            RowObservacion.Visible = true;
            Response.Redirect("Observaciones.aspx");
        }

        public Boolean asistio()
        {
            Boolean asistio = false;
            if (RadioButton1.Checked)
            {
                asistio = true;
            }
            else
            {
                if (RadioButton2.Checked)
                {
                    asistio = false;
                }
            }
            return asistio;
        }



        public void consulta()
        {
            contrll.controlconsulta(RowObservacion, "select concat(estudiante.primer_nombre,' ', estudiante.primer_apellido) as Bailarin, tema as Genero, dia as Dia, hora_inicio_asesoria as 'Fecha y Hora' from clase_baile_detalle inner join  usuario as estudiante on estudiante_fk=estudiante.id_usuario  inner join horario on horario_fk=idhorario inner join plantilla_clase_baile on plantilla_fk=idplantilla_agenda inner join usuario as docente on usuario_fk_plantilla=docente.id_usuario where estado='S' and docente.id_usuario=" + app.Session.id_usuario + " and observaciones is null group by idagenda_detalle  ;");
        }




    }
}