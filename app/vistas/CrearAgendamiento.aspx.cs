using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class CrearBaile : System.Web.UI.Page
    {
        control contrll = new control();
        string tiempo, fechainicio, fechafin, idmax, idetalle;
        protected void Page_Load(object sender, EventArgs e)
        {
            contrll.controllistadinamicarol(DropDownList5, "nombre_plantilla", "idplantilla_agenda", " plantilla_agendamiento where usuario_fk_plantilla= " + app.Session.id_usuario + "");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {


                String respuesta = contrll.controlinsertarplantilla(int.Parse(DropDownList1.SelectedValue), nombreAgenda.Text, int.Parse(DropDownList2.SelectedValue), TextBox1.Text, TextBox2.Text, NombreTema.Text);

                if (respuesta.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + respuesta + "');", true);



                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + ex.Message + "');", true);
            }
            limpiar();

            Response.Redirect("CrearBaile.aspx");
        }




        public string darnombre()
        {
            string texto = "";
            if (RadioButton1.Checked == true)
            {
                texto = "lunes";
            }
            else
            {
                if (RadioButton2.Checked == true)
                {
                    texto = "martes";
                }
                else
                {
                    if (RadioButton3.Checked == true)
                    {
                        texto = "miercoles";
                    }
                    else
                    {
                        if (RadioButton4.Checked == true)
                        {
                            texto = "jueves";
                        }
                        else
                        {
                            if (RadioButton5.Checked == true)
                            {
                                texto = "viernes";
                            }
                            else
                            {
                                if (RadioButton6.Checked == true)
                                {
                                    texto = "sabado";
                                }
                            }
                        }
                    }
                }
            }
            return texto;
        }

        public void limpiar()
        {
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            RadioButton4.Checked = false;
            RadioButton5.Checked = false;
            RadioButton6.Checked = false;
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
            TextBox1.Text = null;
            TextBox2.Text = null;
            nombreAgenda.Text = null;
            NombreTema.Text = null;
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            // crear horario  y agenda detalle
            contrll.controlinsertarhorario(darnombre(), TextBox3.Text, TextBox4.Text, int.Parse(DropDownList5.SelectedValue));
            idmax = contrll.controltraertiempo("select MAX(idhorario) from horario ;", idmax);
            tiempo = contrll.controltraertiempo("select rango_tiempo_minutos from  plantilla_agendamiento where usuario_fk_plantilla=" + app.Session.id_usuario + " and idplantilla_agenda= " + int.Parse(DropDownList5.SelectedValue) + "", tiempo);
            fechainicio = contrll.controltraertiempo("select fecha_inicio from  plantilla_agendamiento where usuario_fk_plantilla=" + app.Session.id_usuario + " and idplantilla_agenda= " + int.Parse(DropDownList5.SelectedValue) + "", tiempo);
            fechafin = contrll.controltraertiempo("select fecha_fin from  plantilla_agendamiento where usuario_fk_plantilla=" + app.Session.id_usuario + " and idplantilla_agenda= " + int.Parse(DropDownList5.SelectedValue) + "", tiempo);
            //           hoinicio = control.controltraertiempo("select hora_inicio from plantilla_agenda where usuario_fk_plantilla=" + app.Session.id_usuario + " and idplantilla_agenda= " + int.Parse(DropDownList5.SelectedValue) + "", hoinicio);
            //           hofin = control.controltraertiempo("select hora_fin from plantilla_agenda where usuario_fk_plantilla=" + app.Session.id_usuario + " and idplantilla_agenda= " + int.Parse(DropDownList5.SelectedValue) + "", hofin);





            DateTime fecha_inicio;
            DateTime.TryParse(fechainicio, out fecha_inicio);
            DateTime fecha_fin;
            DateTime.TryParse(fechafin, out fecha_fin);





            for (DateTime fecha = fecha_inicio; fecha <= fecha_fin; fecha = fecha.AddDays(1))
            {
                DateTime tiempoactual;
                DateTime.TryParse(TextBox3.Text, out tiempoactual);
                tiempoactual.ToString("HH:mm:ss");

                for (int i = 0; i < darrepeticiones(); i++)
                {


                    if (darnumero().Equals((int)fecha.DayOfWeek))
                    {


                        String respuesta = contrll.controlinsertardetalle(Convert.ToString(fecha.Year) + "-" + Convert.ToString(fecha.Month) + "-" + Convert.ToString(fecha.Day) + " " + Convert.ToString(tiempoactual.Hour + ":" + tiempoactual.Minute + ":" + tiempoactual.Second), int.Parse(idmax));

                    }
                    tiempoactual = tiempoactual.AddMinutes(int.Parse(tiempo));

                }

            }



            // this.Page.Response.Write("<script language='JavaScript'>var resultado=window.confirm('" + respuesta + "');");
            //DinamicoGridview();


            consulta();
        }

        public int darrepeticiones()
        {
            DateTime inicio;
            DateTime.TryParse(TextBox3.Text, out inicio);
            DateTime fin;
            DateTime.TryParse(TextBox4.Text, out fin);
            TimeSpan difenciahoras = fin - inicio;
            int repeticiones = (difenciahoras.Hours * 60) / int.Parse(tiempo);
            return repeticiones;
        }


        public int darnumero()
        {
            int texto = 8;
            if (RadioButton1.Checked == true)
            {
                texto = 1;
            }
            else
            {
                if (RadioButton2.Checked == true)
                {
                    texto = 2;
                }
                else
                {
                    if (RadioButton3.Checked == true)
                    {
                        texto = 3;
                    }
                    else
                    {
                        if (RadioButton4.Checked == true)
                        {
                            texto = 4;
                        }
                        else
                        {
                            if (RadioButton5.Checked == true)
                            {
                                texto = 5;
                            }
                            else
                            {
                                if (RadioButton6.Checked == true)
                                {
                                    texto = 6;
                                }
                            }
                        }
                    }
                }
            }
            return texto;
        }


        public void consulta()
        {
            contrll.controlconsulta(GridView1, "select  fecha_inicio, fecha_fin, dia, hora_inicio, horafin  from horario inner join  plantilla_agendamiento on plantilla_fk=idplantilla_agenda where usuario_fk_plantilla= " + app.Session.id_usuario + " and idplantilla_agenda=" + int.Parse(DropDownList5.SelectedItem.Value) + "");
        }



        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList5.SelectedItem.Selected)
            {
                contrll.controlconsulta(GridView1, "select  fecha_inicio as 'Inicio de Clase', fecha_fin as 'Fin de Clase', dia as Dia, hora_inicio as 'Hora Inicio', horafin as Fin  from horario inner join  plantilla_agendamiento on plantilla_fk=idplantilla_agenda where usuario_fk_plantilla= " + app.Session.id_usuario + " and idplantilla_agenda=" + int.Parse(DropDownList5.SelectedItem.Value) + "");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string dia = (GridView1.Rows[e.RowIndex].Cells[3].Text);


            string horainicio = GridView1.Rows[e.RowIndex].Cells[4].Text;
            string horafin = GridView1.Rows[e.RowIndex].Cells[5].Text;


            //string str4 = GridView1.Rows[e.RowIndex].Cells[4].Text;
            //Response.Write(str1);
            //DataTable detalle = (DataTable)Session["dt"];

            // detalle.Rows.Find(Convert.ToInt32(str)).Delete();

            //Session["dt"] = detalle;

            //Guardo los nuevos valores
            contrll.controleliminardetalle(dia, Convert.ToDateTime(horainicio).ToString("HH:mm"), Convert.ToDateTime(horafin).ToString("HH:mm"), int.Parse(DropDownList5.SelectedValue));

            //control.controlconsulta(GridView1, "select  plantilla_agenda.nombre_plantilla , agenda_detalle.dia_asesoria, agenda_detalle.hora_inicio_asesoria, agenda_detalle.hora_fin_asesoria from agenda_detalle inner join plantilla_agenda on agenda_fk=idplantilla_agenda ");
            consulta();
            //GridView1.DataSource = detalle;
            // GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //Bind data to the GridView control.
            BindData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.

            idetalle = contrll.controltraertiempo("select idagenda_detalle fromagendamiento_detalle where hora_inicio_asesoria='" + Convert.ToDateTime(GridView1.Rows[e.NewEditIndex].Cells[3].Text).ToString("yyyy-MM-dd HH:mm:ss") + "' ;", idetalle);

            GridView1.EditIndex = e.NewEditIndex;
            Response.Write(idetalle);
            //Bind data to the GridView control.
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reset the edit index.
            GridView1.EditIndex = -1;
            //Bind data to the GridView control.
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Retrieve the table from the session object.
            //DataTable dt = (DataTable)Session["TaskTable"];

            ////Update the values.
            //GridViewRow row = GridView1.Rows[e.RowIndex];
            //dt.Rows[row.DataItemIndex]["dia"] = ((TextBox)(row.Cells[1].Controls[0])).Text;
            //dt.Rows[row.DataItemIndex]["hora_inicio"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
            //Response.Write(dt.Rows[0].ToString());
            //string str1 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
            //string str2 = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
            // control.controlmodificardiahora(dt.Rows[0].ToString(), Convert.ToDateTime(str2).ToString("yyyy-MM-dd HH:mm:ss"), int.Parse(idetalle));

            //Reset the edit index.
            GridView1.EditIndex = -1;

            //Bind data to the GridView control.
            BindData();
        }

        private void BindData()
        {
            //GridView1.DataSource = Session["TaskTable"];
            contrll.controlconsulta(GridView1, "select  dia, hora_inicio_asesoria fromagendamiento_detalle inner join horario on horario_fk=idhorario inner join  plantilla_agendamiento on plantilla_fk = idplantilla_agenda where usuario_fk_plantilla= " + app.Session.id_usuario);
        }

    }
}