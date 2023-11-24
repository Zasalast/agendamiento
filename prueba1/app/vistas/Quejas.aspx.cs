using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba1.app.vistas
{
    public partial class Quejas : System.Web.UI.Page
    {
        control contrll = new control();



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buttonenviar_Click(object sender, EventArgs e)
        {
            contrll.ControlInsertarQueja(TextBox1.Text, app.Session.id_usuario, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

        }
    }
}