using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class SolicitarAgendamiento : System.Web.UI.Page
    {

        control contrll = new control();
        protected void Page_Load(object sender, EventArgs e)
        {
            contrll.controllistadinamicarol(DropDownList2, "tema", "idplantilla_agenda", " plantilla_agendamiento group by tema ;");

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string str1 = GridView1.Rows[e.RowIndex].Cells[5].Text;

            //contrll.controlinsertarestudiante(app.Session.id_usuario, Convert.ToDateTime(str1).ToString("yyyy-MM-dd HH:mm:ss"));
            contrll.controlconsulta(GridView1, "SELECT " +
    "CONCAT(u.primer_nombre, ' ', u.primer_apellido) AS usuario, " +
    "pa.rango_tiempo_minutos AS duracion_minutos, " +
    "pa.tema, " +
    "pa.fecha_inicio AS fecha_hora " +
    "FROM plantilla_agendamiento pa " +
    "INNER JOIN usuario u ON pa.usuario_fk_plantilla = u.id_usuario " +
    "WHERE pa.tema = '" + DropDownList2.SelectedItem.ToString() + "' " +
    "OR pa.fecha_inicio BETWEEN '" + Convert.ToDateTime(from.Text).ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + Convert.ToDateTime(to.Text).ToString("yyyy-MM-dd HH:mm:ss") + "' AND pa IS NULL;");
            consulta();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            consulta();
        }

        public void consulta()
        {
            string desde = null, hasta = null;
            if (!String.IsNullOrEmpty(from.Text) && !string.IsNullOrEmpty(to.Text))
            {
                desde = Convert.ToDateTime(from.Text).ToString("yyyy-MM-dd");
                hasta = Convert.ToDateTime(to.Text).ToString("yyyy-MM-dd");
            }
            if (DropDownList2.SelectedIndex != 0 && !String.IsNullOrEmpty(from.Text) && !string.IsNullOrEmpty(to.Text))
            {
                contrll.controlconsulta(GridView1, "select concat(primer_nombre,' ', primer_apellido) as Instructor, rango_tiempo_minutos as Duracion, tema as Tema, dia as Dia, hora_inicio_asesoria as Fecha fromagendamiento_detalle inner join horario on horario_fk=idhorario inner join  plantilla_agendamiento on plantilla_fk=idplantilla_agenda inner join usuario on usuario_fk_plantilla=id_usuario where estado='V' and tema='" + DropDownList2.SelectedItem.ToString() + "' and hora_inicio_asesoria between '" + desde + "' and '" + hasta + "'   group by idagenda_detalle  ");
            }
            else
            {
                contrll.controlconsulta(GridView1, "select concat(primer_nombre,' ', primer_apellido) as Instructor, rango_tiempo_minutos as duracion_minutos, tema, dia, hora_inicio_asesoria as fecha_hora fromagendamiento_detalle inner join horario on horario_fk=idhorario inner join  plantilla_agendamiento on plantilla_fk=idplantilla_agenda inner join usuario on usuario_fk_plantilla=id_usuario where estado='V' and tema='" + DropDownList2.SelectedItem.ToString() + "' or hora_inicio_asesoria between '" + desde + "' and '" + hasta + "' and estado='v'  group by idagenda_detalle  ");
            }
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "select idagenda_detalle,hora_inicio_asesoria fromagendamiento_detalle  where estado='V'  ;";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                string valor = Convert.ToString(reader.GetString("hora_inicio_asesoria"));
                condicionfecha(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), Convert.ToDateTime(Convert.ToDateTime(valor).ToString("yyyy-MM-dd HH:mm:ss")), int.Parse(Convert.ToString(reader.GetString("idagenda_detalle"))), "T");

            }
        }

        public void condicionfecha(DateTime fecha1, DateTime fecha2, int id, string estado)
        {
            int resultado = DateTime.Compare(fecha1, fecha2);
            if (resultado > 0)
            {
                contrll.controlestado(id, estado);
            }
        }


    }
}