using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class ConsultarUsuarios : System.Web.UI.Page
    {
        control contrl = new control();

        protected void Page_Load(object sender, EventArgs e)
        {

            contrl.controlconsulta(GridView1, "select concat(usuario.primer_nombre, ' ',  usuario.primer_apellido) as 'Nombre y Apellido', usuario.numero_documento as Identificacion, usuario.usuario as Usuario, usuario.correo as Email, nombre_rol as Rol from usuario inner join rol on id_rol_fk=id_rol where id_rol_fk>1;");
            //contrl.controlconsulta(GridView2, "select * from rol;");
            //contrl.controlconsulta(GridView3, "select * from permisos;");
            //contrl.controlconsulta(GridView4, "SELECT nombre_rol, descripcion from accion inner join rol on fk_rol = id_rol inner join permisos on dk_permisos = idpermisos  group by dk_permisos; ");

        }
    }
}