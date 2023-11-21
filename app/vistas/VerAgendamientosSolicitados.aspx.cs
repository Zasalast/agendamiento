using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class VerAgendamientosSolicitados : System.Web.UI.Page
    {
        control contrll = new control();

        protected void Page_Load(object sender, EventArgs e)
        {
            contrll.controlconsulta(gridver, "select concat(profesor.primer_nombre,' ', profesor.primer_apellido) as Instructor, rango_tiempo_minutos as Duracion, tema as Genero, dia as Dia, hora_inicio_asesoria as Fecha from clase_baile_detalle inner join usuario as estudiante on estudiante_fk = estudiante.id_usuario inner join horario on horario_fk=idhorario inner join plantilla_clase_baile on plantilla_fk=idplantilla_agenda inner join usuario as profesor on usuario_fk_plantilla=profesor.id_usuario where estado='S' and estudiante_fk=" + app.Session.id_usuario + " and observaciones is null and asistencia is null group by idagenda_detalle ;");

        }
    }
}