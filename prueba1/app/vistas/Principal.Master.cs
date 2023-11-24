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
    public partial class Principal : System.Web.UI.MasterPage
    {
        string nombrestext;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (app.Session.usuario == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                nombres( );
                label1.Text = "Bienvenido:   " + app.Session.primer_nombre + "   " + app.Session.primer_apellido + "    (" + nombrestext + ") ";
                crearmenu();
            }


        }

        protected void nombres()
        {
            MySqlConnection conexion = Conexion.getConexion();

            MySqlDataAdapter dat = new MySqlDataAdapter("select rol.nombre_rol from rol where rol.id_rol='" + app.Session.id_rol_fk + "';", conexion);
            DataSet dts1 = new DataSet();

            try
            {
                conexion.Open();
                dat.Fill(dts1, "nombres");
                DataTable datatable = null;
                datatable = dts1.Tables["nombres"];
                if (dts1.Tables["nombres"].Rows.Count > 0)
                {
                    foreach (DataRow datarow in datatable.Rows)
                    {
                        nombrestext = Convert.ToString(datarow[0]);
                    }
                }
            }
            catch (Exception e)
            {
                Response.Write(e.Message.ToString());
            }
            finally
            {
                conexion.Close();
            }

        }

        protected void ButtonCerrarlick_Click(object sender, EventArgs e)
        {
            app.Session.usuario = null;
            Response.Redirect("index.aspx");
        }


        protected void crearmenu()
        {

            MySqlConnection conexion = Conexion.getConexion();
            MySqlCommand comando = new MySqlCommand("select permisos.idpermisos, permisos.descripcion, permisos.url from rol inner join accion on rol.id_rol=accion.fk_rol inner join permisos on permisos.idpermisos=dk_permisos where rol.id_rol='" + app.Session.id_rol_fk + "'", conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataSet dataset = new DataSet();
            DataTable datatable = null;

            try
            {
                conexion.Open();
                adapter.Fill(dataset);
                datatable = dataset.Tables[0];
                if (datatable != null && datatable.Rows.Count > 0)
                {

                    foreach (DataRow dataRow in datatable.Rows)
                    {

                        MenuItem menuitem = new MenuItem(Convert.ToString(dataRow[1]), Convert.ToString(dataRow[0]), String.Empty, Convert.ToString(dataRow[2]));
                        this.Menu1.Items.Add(menuitem);

                        for (int x = datatable.Rows.Count + 1; x < Menu1.Items.Count; ++x)
                        {
                            Menu1.Items.RemoveAt(x);

                        }

                        //AddChildItem(ref menuitem, datatable);
                    }



                }

            }

            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());

            }

            finally
            {

                conexion.Close();
                adapter.Dispose();
                dataset.Dispose();
                datatable.Dispose();

            }


        }

        protected void AddChildItem(ref MenuItem menuitem, DataTable datatable)
        {
            foreach (DataRow dataRow in datatable.Rows)
            {
                if (Convert.ToInt32(dataRow[2]) == Convert.ToInt32(menuitem.Value) && Convert.ToInt32(dataRow[0]) != Convert.ToInt32(dataRow[2]))
                {
                    MenuItem menuItemChild = new MenuItem(Convert.ToString(dataRow[1]), Convert.ToString(dataRow[0]), String.Empty, Convert.ToString(dataRow[3]));
                    menuitem.ChildItems.Add(menuItemChild);
                    AddChildItem(ref menuItemChild, datatable);

                }
            }
        }



    }
}