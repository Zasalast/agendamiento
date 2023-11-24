using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class ReporteEstuAgendamiento : System.Web.UI.Page
    {

        control contrll = new control();
        app.controles.Pdf controlpd = new app.controles.Pdf();
        app.controles.Excel excel = new app.controles.Excel();
        static string[] header;
        static string titulo;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string desde = null, hasta = null;
            if (!String.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
            {
                desde = Convert.ToDateTime(TextBox1.Text).ToString("yyyy-MM-dd");
                hasta = Convert.ToDateTime(TextBox2.Text).ToString("yyyy-MM-dd");
            }
            contrll.controlconsulta(gridview1, "select  hora_inicio_asesoria as 'Hora Inicio Asesoria', concat(profesor.primer_nombre,' ',profesor.primer_apellido ) as Instructor,   observaciones as Observaciones fromagendamiento_detalle inner join usuario as estudiante on estudiante_fk = estudiante.id_usuario inner join horario on horario_fk = idhorario inner join  plantilla_agendamiento on plantilla_fk = idplantilla_agenda inner join usuario as profesor on usuario_fk_plantilla = profesor.id_usuario where estudiante.id_usuario =" + app.Session.id_usuario + " and hora_inicio_asesoria between '" + desde + "' and '" + hasta + "'   and estado='S' and observaciones is not null   order by hora_inicio_asesoria;");
            contrll.MergeRows(gridview1);
            header = new string[] { "Hora ", "Persona que Atendio", "Observaciones" };
            titulo = "REPORTE OBSERVACIONES ";
        }

        protected void boton1PDF_Click(object sender, EventArgs e)
        {
            controlpd.crearpdf(gridview1, header, titulo);

        }

        //protected void Button2EXCEL_Click(object sender, EventArgs e)
        //{
        //    excel.ExportToExcel("excelreporte.xls", gridview1);

        //}
    }
}