using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class Reportes : System.Web.UI.Page
    {
        control contrll = new control();
        app.controles.Pdf controlpd = new app.controles.Pdf();
        app.controles.Excel excel = new app.controles.Excel();
        static string[] header;
        static string titulo;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(bandera);
            boton1PDF.Visible = false;
            //Button2EXCEL.Visible = false;
        }

        //protected void temavisto_Click(object sender, EventArgs e)
        //{
        //    string desde = null, hasta = null;
        //    if (!String.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
        //    {
        //        desde = Convert.ToDateTime(TextBox1.Text).ToString("yyyy-MM-dd");
        //        hasta = Convert.ToDateTime(TextBox2.Text).ToString("yyyy-MM-dd");
        //    }
        //    contrll.controlconsulta(gridview1, "select   tema ,concat(estudiante.primer_nombre,' ' ,estudiante.primer_apellido) as tema_estudiante, hora_inicio_asesoria, if null(replace(replace(asistencia,1,'asistio'),0,'No asistio'),'Pendiente Observacion') as asistencia  fromagendamiento_detalle inner join usuario as estudiante on estudiante_fk = estudiante.id_usuario inner join horario on horario_fk = idhorario inner join  plantilla_agendamiento on plantilla_fk = idplantilla_agenda inner join usuario as profesor on usuario_fk_plantilla = profesor.id_usuario where profesor.id_usuario =" + app.Session.id_usuario + " and hora_inicio_asesoria between '" + desde + "' and '" + hasta + "' and estado='S'  order by tema desc ; ");
        //    contrll.MergeRows(gridview1);
        //    boton1PDF.Visible = true;
        //    //Button2EXCEL.Visible = true;
        //    header = new string[] { "Tema", "Estudiante que solicito", "Fecha solicitud", "Asistencia Estudiante" };
        //    titulo = "REPORTE DE TEMA, SOLICITADO POR ESTUDIANTE ";

        //}

        protected void estudiantesolicitud_Click(object sender, EventArgs e)
        {
            string desde = null, hasta = null;
            if (!String.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
            {
                desde = Convert.ToDateTime(TextBox1.Text).ToString("yyyy-MM-dd");
                hasta = Convert.ToDateTime(TextBox2.Text).ToString("yyyy-MM-dd");
            }
            contrll.controlconsulta(gridview1, "select  tema as Tema, replace(replace(replace(estado,'T','Horarios Terminados'),'V','Horarios Vacios'),'S','Horarios Solicitados')  as Estado,count(estado) as Detalle fromagendamiento_detalle  inner join horario on horario_fk = idhorario inner join  plantilla_agendamiento on plantilla_fk = idplantilla_agenda inner join usuario as profesor on usuario_fk_plantilla = profesor.id_usuario where  hora_inicio_asesoria  between '" + desde + "' and '" + hasta + "' and profesor.id_usuario =" + app.Session.id_usuario + " and estado='V'  or profesor.id_usuario = " + app.Session.id_usuario + "  and estado='T' or profesor.id_usuario = " + app.Session.id_usuario + "  and estado='S' group by estado, tema; ");
            contrll.MergeRows(gridview1);
            boton1PDF.Visible = true;
            //Button2EXCEL.Visible = true;
            header = new string[] { "Tema", "Estado Horarios", "Cantidad" };

            titulo = "REPORTE ESTADO HORARIOS";
        }

        protected void estudiantesfaltaron_Click(object sender, EventArgs e)
        {
            string desde = null, hasta = null;
            if (!String.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
            {
                desde = Convert.ToDateTime(TextBox1.Text).ToString("yyyy-MM-dd");
                hasta = Convert.ToDateTime(TextBox2.Text).ToString("yyyy-MM-dd");
            }
            contrll.controlconsulta(gridview1, "select   concat(estudiante.primer_nombre,' ',estudiante.primer_apellido ) as Bailarin,  replace(replace(asistencia,1,'asistio'),0,'No asistio') as Asistencia, count(asistencia)  as Cantidad  fromagendamiento_detalle inner join usuario as estudiante on estudiante_fk = estudiante.id_usuario inner join horario on horario_fk = idhorario inner join  plantilla_agendamiento on plantilla_fk = idplantilla_agenda inner join usuario as profesor on usuario_fk_plantilla = profesor.id_usuario where profesor.id_usuario =" + app.Session.id_usuario + " and hora_inicio_asesoria between '" + desde + "' and '" + hasta + "'   and estado='S' and asistencia is not null group by asistencia   order by cantidad asc;");
            contrll.MergeRows(gridview1);
            boton1PDF.Visible = true;
            //Button2EXCEL.Visible = true;
            header = new string[] { "Bailarin", "Asistencia", "Cantidad" };

            titulo = "REPORTE ESTUDIANTES QUE MAS HAN FALTADO Y QUE MENOS HAN FALTADO";

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