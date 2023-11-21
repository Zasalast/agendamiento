using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class CrearUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            Usuarios usuarios = new Usuarios();
            usuarios.Numero_documento = documento.Text;
            usuarios.Primer_nombre = nombre1.Text;
            usuarios.Segundo_nombre = nombre2.Text;
            usuarios.Primer_apellido = apellido1.Text;
            usuarios.Segundo_apellido = apellido2.Text;
            usuarios.Usuario = username.Text;
            usuarios.Clave = contra1.Text;
            usuarios.Confirmar_clave = contra2.Text;
            usuarios.Correo = email.Text;
            usuarios.Id_rol_fk = int.Parse(TipoRol.SelectedValue);
            usuarios.Id_identificacion_fk = int.Parse(Tipodocumento.SelectedValue);

            try
            {
                control control = new control();
                String respuesta = control.Controlregistro(usuarios);

                if (respuesta.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + respuesta + "');", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('REGISTRO EXITOSO!!!');", true);

                    Correo objcorreo = new Correo(usuarios.Correo, "¡¡¡USUARIO REGISTRADO!!!", "¡¡¡Excelente Noticia!!!   Ahora Podra Hacer Uso de los Servicios De la Plataforma");

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + ex.Message + "');", true);
            }


        }
    }
}