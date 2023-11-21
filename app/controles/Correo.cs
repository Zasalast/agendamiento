using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Prueba1
{
    public class Correo
    {

        Boolean estado = true;
        String merror;



        public Correo(string destinatario, String asunto, String mensaje)
        {

            MailMessage correo = new MailMessage();
            SmtpClient protocolo = new SmtpClient();

            correo.To.Add(destinatario);
            correo.From = new MailAddress("agenda@gmail.com", "Departamento de tecnico", System.Text.Encoding.UTF8);
            correo.Subject = asunto;
            correo.SubjectEncoding = System.Text.Encoding.UTF8;
            correo.Body = mensaje;
            correo.BodyEncoding = System.Text.Encoding.UTF8;
            correo.IsBodyHtml = false;

            protocolo.Credentials = new System.Net.NetworkCredential("agenda@gmail.com", "Dti123456");
            protocolo.Port = 587;
            protocolo.Host = "smtp.gmail.com";
            protocolo.EnableSsl = true;

            try
            {
                protocolo.Send(correo);
            }
            catch (SmtpException error)
            {
                estado = false;
                merror = error.Message.ToString();
            }

        }


        public Boolean Estado
        {

            get
            {
                return Estado;
            }
        }

        public String mensaje_error
        {
            get
            {
                return merror;
            }
        }

    }
}