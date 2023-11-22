using MySql.Data.MySqlClient;
using Prueba1.app;
using System;
using System.Data;
using System.Web.UI.WebControls;


namespace Prueba1
{
    public class Modelo
    {

        //METODO DE REGISTRO
        public int Registro(Usuarios usuario)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open(); // abrir la conexion

            string sql = "INSERT INTO usuario (numero_documento, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, usuario, clave, correo, id_rol_fk, id_identificacion_fk) VALUES (@numero_documento, @primer_nombre, @segundo_nombre, @primer_apellido, @segundo_apellido, @usuario, @clave, @correo, @id_rol_fk, @id_identificacion_fk)";
            // comando (preparar la Inserccion)
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@numero_documento", usuario.Numero_documento);
            comando.Parameters.AddWithValue("@primer_nombre", usuario.Primer_nombre);
            comando.Parameters.AddWithValue("@segundo_nombre", usuario.Segundo_nombre);
            comando.Parameters.AddWithValue("@primer_apellido", usuario.Primer_apellido);
            comando.Parameters.AddWithValue("@segundo_apellido", usuario.Segundo_apellido);
            comando.Parameters.AddWithValue("@usuario", usuario.Usuario);
            comando.Parameters.AddWithValue("@clave", usuario.Clave);
            comando.Parameters.AddWithValue("@correo", usuario.Correo);
            comando.Parameters.AddWithValue("@id_rol_fk", usuario.Id_rol_fk);
            comando.Parameters.AddWithValue("@id_identificacion_fk", usuario.Id_identificacion_fk);

            //regresara el numero de filas que se han insertado en la tabla
            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }


        //METODO DE SI EXISTE UN MISMO USUARIO
        public bool ExisteUsuario(string usuario)
        {

            MySqlDataReader reader; //
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT * FROM usuario WHERE usuario LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);

            reader = comando.ExecuteReader();

            if (reader.HasRows) // SI CONTIENE FILAS LA CONSULTA
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //METODO DE SI EXISTE UN MISMO NUMERO DE DOCUMENTO
        public bool ExisteNUmero_documento(string usuario)
        {
            MySqlDataReader reader; //PARA TRAER LOS DATOS DE UNA CONSULTA
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT * FROM usuario WHERE numero_documento LIKE @numero_documento";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@numero_documento", usuario);

            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //METODO DE SI EXISTE UN MISMO CORREO ELECTRONICO
        public bool ExisteCorreo(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT * FROM usuario WHERE correo LIKE @correo";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@correo", usuario);

            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {

                return true;
            }
            else
            {
                return false;
            }
        }



        // METODO DE LOGIN( SI EXISTE EL USUARIO Y COINCIDE CON LA CONTRASEÑA)
        public Usuarios ValidarUsuario(string usuario)
        {
            MySqlDataReader reader; // COMO LA CONSULTA ES UN SELECT NECESITAMOS UN MYSQLDATAREADER 
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT id_usuario, numero_documento, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido,  clave, correo, id_rol_fk  FROM usuario WHERE usuario LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);

            reader = comando.ExecuteReader();

            Usuarios usr = null;
            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Id_usuario = int.Parse(reader["id_usuario"].ToString());
                usr.Numero_documento = (reader["numero_documento"].ToString());
                usr.Primer_nombre = (reader["primer_nombre"].ToString());
                usr.Segundo_nombre = (reader["segundo_nombre"].ToString());
                usr.Primer_apellido = (reader["primer_apellido"].ToString());
                usr.Segundo_apellido = (reader["segundo_apellido"].ToString());
                usr.Clave = (reader["clave"].ToString());
                usr.Correo = (reader["correo"].ToString());
                usr.Id_rol_fk = int.Parse(reader["id_rol_fk"].ToString());



            }

            return usr;


        }


        //PARA LOS ROLES, SACAR EL DROPDOWNS O LISTA DINAMICA
        public void agregarlistadinamicaRol(DropDownList lista, String nombres, string values, String from)
        {
            MySqlConnection conexion = Conexion.getConexion();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select " + nombres + ", " + values + " from " + from + " ;", conexion);
            DataSet dataset = new DataSet();
            DataTable datatable = null;
            try
            {

                conexion.Open();
                adapter.Fill(dataset, "Datos");
                datatable = dataset.Tables["Datos"];
                if (datatable != null && datatable.Rows.Count > 0)
                {
                    ListItem i;
                    foreach (DataRow row in datatable.Rows)
                    {

                        i = new ListItem(row[nombres].ToString(), row[values].ToString());

                        lista.Items.Add(i);
                        for (int x = datatable.Rows.Count + 1; x < lista.Items.Count; ++x)
                        {
                            lista.Items.RemoveAt(x);

                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conexion.Close();
                adapter.Dispose();
                dataset.Dispose();
                datatable.Dispose();
            }
        }





        //DEDE AQUI VAN LOS CONTROLES DEL ADMINISTADOR, TODOS SUS PERMISOS, SU CRUD
        //POR ASI DECIRLO


        //MOSTRAR ROL DE USUARIO
        public void mostrarrolusuario(Label label, int idusuario)
        {
            MySqlConnection conexion = Conexion.getConexion();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select  rol.nombre_rol  from usuario inner join rol on id_rol_fk=id_rol where id_usuario='" + idusuario + "' ;", conexion);
            DataSet dataset = new DataSet();
            DataTable datatable = null;
            try
            {

                conexion.Open();
                adapter.Fill(dataset, "Datos");
                datatable = dataset.Tables["Datos"];
                if (datatable != null && datatable.Rows.Count > 0)
                {

                    foreach (DataRow row in datatable.Rows)
                    {

                        label.Text = "su rol actual es: " + row["nombre_rol"].ToString();
                    }
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conexion.Close();
                adapter.Dispose();
                dataset.Dispose();
                datatable.Dispose();
            }

        }



        //CAMBIAAR ROL USUARIO
        public void cambiarolusuario(int rol, int usuario)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "UPDATE usuario SET usuario.id_rol_fk = '" + rol + "' WHERE usuario.id_usuario = '" + usuario + "'";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        //ELIMINAR EL ROL
        public void eliminarxrol(int idrol)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "delete rol, accion, usuario from rol left join accion on accion.fk_rol=rol.id_rol left join usuario on usuario.id_rol_fk=rol.id_rol  where rol.id_rol='" + idrol + "'";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        //SI EXIXTE UNROL VALIDA
        public bool exiterol(string rol)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "select * from rol where nombre_rol LIKE '" + rol + "'";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
            //conexion.Close();
        }


        // CREAR EL ROL
        public void crearrol(string nombre)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "INSERT INTO rol (nombre_rol) VALUES ('" + nombre + "')";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            //conexion.Close();
        }


        //MODIFICAR ROL
        public void modificarol(int idrol, string nuevonombre)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "UPDATE rol SET rol.nombre_rol = '" + nuevonombre + "' WHERE rol.id_rol = '" + idrol + "'";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            //conexion.Close();
        }


        //PARA DAR PERMISOS ASIGNAR A UN ROL UN PERMISO
        public void darpermisos(int rol, int permisos)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "INSERT INTO accion (fk_rol,dk_permisos) VALUES ('" + rol + "', '" + permisos + "')";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        //PARA ELIMINAR PERMISOS A UN ROL
        public void eliminarpermisos(int permisos)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "delete accion from accion   where accion.idaccion='" + permisos + "'";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }


        //PARA VERIFICAR SI EXISTE UN ROL
        public bool existepermiso(string descripcion)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "select * from permisos where descripcion LIKE '" + descripcion + "' ";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
            //conexion.Close();
        }


        //PARA AGREGAR EL PERMISO 
        public void agregarpermisosnuevos(String descripcion, String url)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "INSERT INTO permisos (descripcion,url) VALUES ('" + descripcion + "', '" + url + "')";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        //GRILLA PARA LAS TABLAS DINAMICAS
        public void gridview(GridView grid, String consulta)
        {
            MySqlConnection conexion = Conexion.getConexion();
            MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, conexion);
            DataSet dataset = new DataSet();
            DataTable datatable = null;
            try
            {

                conexion.Open();
                adapter.Fill(dataset, "Datos");
                datatable = dataset.Tables["Datos"];
                if (datatable != null && datatable.Rows.Count > 0)
                {

                    foreach (DataRow row in datatable.Rows)
                    {
                        grid.DataSource = row.Table;
                        grid.DataBind();

                    }
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conexion.Close();
                adapter.Dispose();
                dataset.Dispose();
                datatable.Dispose();
            }

        }

        //MODELO PARA CAMBIAR LA CONTRASEÑAA
        public void cambiarclave(String clave, int usuario)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "UPDATE usuario SET clave = '" + clave + "' WHERE usuario.id_usuario = '" + usuario + "'";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

        }


        //PARA LOS AGENDAMIENTOS DEL INSTRUCTOR

        public void insertarplantillaagenda(int tiempo, string nombre, int cancelar, string fecha_inicio, string fecha_fin, string tema)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "INSERT INTO  plantilla_agendamiento (rango_tiempo_minutos,nombre_plantilla,usuario_fk_plantilla, rango_cancelar, fecha_inicio, fecha_fin, tema) VALUES (@tiempo, @nombre , @idusuario, @cancelar  , @fecha_inicio, @fecha_fin,  @tema )";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@tiempo", tiempo);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@idusuario", Session.id_usuario);
            comando.Parameters.AddWithValue("@cancelar", cancelar);
            comando.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
            comando.Parameters.AddWithValue("@fecha_fin", fecha_fin);
            comando.Parameters.AddWithValue("@tema", tema);
            comando.ExecuteNonQuery();
            //conexion.Close();
        }
        public void insertarhorario(string dia, string horainicio, string horafin, int value)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "INSERT INTO horario (dia, hora_inicio, horafin, plantilla_fk) VALUES (@dia, @horainicio, @horafin, @value )";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@dia", dia);
            comando.Parameters.AddWithValue("@horainicio", horainicio);

            comando.Parameters.AddWithValue("@horafin", horafin);
            comando.Parameters.AddWithValue("@value", value);
            comando.ExecuteNonQuery();
        }
        public void insertardetalle(string horainicio, int plantilla)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "INSERT INTOagendamiento_detalle (hora_inicio_asesoria, horario_fk,estado) VALUES (@horainicio, @plantilla, 'V' )";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@horainicio", horainicio);
            comando.Parameters.AddWithValue("@plantilla", plantilla);
            comando.ExecuteNonQuery();
        }

        public void eliminardetalle(string dia, string hora_inicio, string hora_fin, int plantilla)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "delete horario,clase_baile_detalle from horario left joinagendamiento_detalle on idhorario=horario_fk where dia= @dia and hora_inicio= @hora_inicio and horafin= @hora_fin  and plantilla_fk= @plantilla ;";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@dia", dia);
            comando.Parameters.AddWithValue("@hora_inicio", hora_inicio);
            comando.Parameters.AddWithValue("@hora_fin", hora_fin);
            comando.Parameters.AddWithValue("@plantilla", plantilla);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public string traertiempo(String consulta, string variable)
        {
            MySqlConnection conexion = Conexion.getConexion();
            MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, conexion);
            DataSet dataset = new DataSet();
            DataTable datatable = null;
            try
            {

                conexion.Open();
                adapter.Fill(dataset, "Datos");
                datatable = dataset.Tables["Datos"];

                if (datatable != null && datatable.Rows.Count > 0)
                {

                    foreach (DataRow row in datatable.Rows)
                    {
                        variable = Convert.ToString(row[0]);


                    }

                }


            }
            catch (Exception ex)
            {

            }
            finally
            {

                conexion.Close();
                adapter.Dispose();
                dataset.Dispose();
                datatable.Dispose();


            }

            return variable;
        }

        public void insertarestudiante(int idestudiante, string fecha)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "UPDATEagendamiento_detalle SET estudiante_fk = @idestudiante, estado='S' WHERE hora_inicio_asesoria = @fecha ;";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@idestudiante", idestudiante);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.ExecuteNonQuery();
        }
        public void cambiarfechadia(String hora, string dia, int id)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "updateagendamiento_detalle inner join horario on horario_fk=idhorario set agenda_detalle.hora_inicio_asesoria= @hora , horario.dia= @dia where idagenda_detalle= @id ";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@hora", hora);

            comando.Parameters.AddWithValue("@dia", dia);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            conexion.Close();

        }
        public void estado(int id, String estado)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "updateagendamiento_detalle set estado= @estado where idagenda_detalle= @id ";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.ExecuteNonQuery();
            conexion.Close();

        }
        public void insertarobservacion(string observacion, string fecha, string dia, string tema, Boolean asistio)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "UPDATEagendamiento_detalle inner join horario on horario_fk=idhorario inner join  plantilla_agendamiento on plantilla_fk=idplantilla_agenda SET observaciones = @observacion, asistencia= @asistio  WHERE hora_inicio_asesoria = @fecha  and dia= @dia  and tema= @tema  ;";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@observacion", observacion);
            comando.Parameters.AddWithValue("@asistio", asistio);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@dia", dia);
            comando.Parameters.AddWithValue("@tema", tema);
            comando.ExecuteNonQuery();
        }

        //PARA INSERTAR LA QUEJA EN LA BD
        public void InsertarQueja(string descripcion, int id_usuario, DateTime fechaQueja)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "INSERT INTO quejas (descripcion, usuario_fk, fecha_queja) VALUES (@descripcion, @id_usuario, @fechaQueja)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@descripcion", descripcion);
            comando.Parameters.AddWithValue("@id_usuario", id_usuario);
            comando.Parameters.AddWithValue("@fechaQueja", fechaQueja);
            comando.ExecuteNonQuery();

        }

    }
}