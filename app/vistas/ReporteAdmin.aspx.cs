using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class ReporteAdmin : System.Web.UI.Page
    {
        control contrll = new control();
        app.controles.Pdf controlpd = new app.controles.Pdf();
        app.controles.Excel excel = new app.controles.Excel();
        static string[] header;
        static string titulo;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1Quejas_Click(object sender, EventArgs e)
        {
            string desde = null, hasta = null;
            if (!String.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
            {
                desde = Convert.ToDateTime(TextBox1.Text).ToString("yyyy-MM-dd");
                hasta = Convert.ToDateTime(TextBox2.Text).ToString("yyyy-MM-dd");
            }
            contrll.controlconsulta(gridview1, "select concat(primer_nombre,' ',primer_apellido) as Usuario, nombre_rol as Rol, descripcion as Descripcion from quejas inner join usuario on usuario_fk=id_usuario inner join rol on id_rol_fk=id_rol where fecha_queja between '" + desde + "' and '" + hasta + "' order by fecha_queja asc ");
            contrll.MergeRows(gridview1);
            header = new string[] { "Usuario", "Rol", "Descripcion Queja" };
            titulo = "REPORTE OBSERVACIONES ";
        }

        protected void boton1PDF_Click(object sender, EventArgs e)
        {
            controlpd.crearpdf(gridview1, header, titulo);
        }

        //protected void Button2EXCEL_Click(object sender, EventArgs e)
        //{
        //    excel.ExportToExcel("excelreporte.xlsx", gridview1);
        //}
    }
}