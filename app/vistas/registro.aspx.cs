using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class registro : System.Web.UI.Page
    {
        control control = new control();
        protected void Page_Load(object sender, EventArgs e)
        {
            control.controllistadinamicarol(TipoRol, "nombre_rol", "id_rol", "rol where id_rol != 1");
            control.controllistadinamicarol(TipoIdentificacion, "nombre_identificacion", "id_identificacion", "identificacion where id_identificacion >= 1");

        }
            
        protected void Buttonregistro_Click(object sender, EventArgs e)
        {


            //VARIABLES DE LA INSTANCIA USUARIOS REMPLAZANDO POR LAS ID DE LOS COMPONENTES
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
            usuarios.Id_identificacion_fk = int.Parse(TipoIdentificacion.SelectedValue);


            try
            {

                String respuesta = control.Controlregistro(usuarios); //METODO DE REGISTRO

                if (respuesta.Length > 0) // SI RESPUESTA TIENE UN MENSAJE
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + respuesta + "');", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('REGISTRO EXITOSO!!!');", true);
                    //ENVIO DEL CORREO SI EL REGISTRO FUE EXITOSO
                    Correo objcorreo = new Correo(usuarios.Correo, "¡¡¡USUARIO REGISTRADO!!!", "¡¡¡Excelente Noticia!!!   Ahora Podra Hacer Uso de los Servicios De la Plataforma");

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('" + ex.Message + "');", true);
            }



            // Response.Write("<script lengueage='javascript'> alert('USUARIO REGISTRADO'); </script>");
        }


    }
}
