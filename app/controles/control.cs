using System;
using System.Security.Cryptography;
using System.Text;
using Prueba1.app;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace Prueba1
{
    public class control
    {


        public String Controlregistro(Usuarios usuario)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";

            //IsnullOrEmpty ( Si es null o vacio)
            if (string.IsNullOrEmpty(usuario.Numero_documento) || string.IsNullOrEmpty(usuario.Primer_nombre) || string.IsNullOrEmpty(usuario.Primer_apellido) || string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Clave) || string.IsNullOrEmpty(usuario.Confirmar_clave) || string.IsNullOrEmpty(usuario.Correo) || usuario.Id_rol_fk == 0 || usuario.Id_identificacion_fk == 0)
            {

                mensaje = "DEBE LLENAR LOS CAMPOS SOLICITADOS";

            }
            else
            {
                // VALIDAR QUE LAS CONTRASEÑAS COINCIDAN
                if (usuario.Clave == usuario.Confirmar_clave)
                {
                    //VALIDA QUE NO EXISTA UN USUARIO IGUAL
                    if (modelo.ExisteUsuario(usuario.Usuario))
                    {
                        mensaje = "NOMBRE DE USUARIO YA EXISTE!";

                    }
                    //VALIDAR QUE NO EXISTA UN NUMERO DE DOCUMENTO IGUAL
                    else if (modelo.ExisteNUmero_documento(usuario.Numero_documento))
                    {

                        mensaje = "Nº DOCUMENTO YA EXISTE!";

                    }
                    //VALIDAR QUE NO EXISTA UN CORREO IGUAL
                    else if (modelo.ExisteCorreo(usuario.Correo))
                    {
                        mensaje = "EL CORREO YA SE ENCUENTRA REGISTRADO!";
                    }
                    //CIFRADO DE LA CONTRASEÑA
                    else
                    {
                        usuario.Clave = GenerarSHA1(usuario.Clave);
                        modelo.Registro(usuario);

                    }

                }
                else
                {

                    mensaje = "LAS CONTRASEÑAS DEBEN DE COINCIDIR!";

                }
            }
            return mensaje;

        }

        //VALIDAR SI EL USUARIO EXISTE Y COINCIDE CON LA CONTRASEÑA
        public String ControlLogin(String usuario, String clave)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            Usuarios datosusuario = null;

            if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(clave)) //VALIDAR QUE LOS CAMPOS NO ESTEN VACIOS
            {
                mensaje = "DEBE LLENAR LOS CAMPOS SOLICITADOS";
            }
            else
            {
                datosusuario = modelo.ValidarUsuario(usuario); // SERA AL METODO QUE HACE LA CONSULTA 

                if (datosusuario == null)
                {
                    mensaje = "EL USUARIO NO EXISTE!";
                }
                else
                {
                    if (datosusuario.Clave != GenerarSHA1(clave)) //VALIDAMOS CIFRANDO EL PASSWORD QUE DIJITA Y LO COMPARAMOS CON EL QUE ESTA EN LA B.D.
                    {
                        mensaje = "USUARIO O CONTRASEÑA NO VALIDA!";


                    }
                    else

                    {

                        Session.id_usuario = datosusuario.Id_usuario;
                        Session.primer_nombre = datosusuario.Primer_nombre;
                        Session.primer_apellido = datosusuario.Primer_apellido;
                        Session.usuario = usuario;
                        Session.id_rol_fk = datosusuario.Id_rol_fk;


                    }

                }

            }
            return mensaje;
        }



        //CIFRADO DE CONTRASEÑA
        private string GenerarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider(); // PARA PODER UTILIZAR LAS FUNCIONES DE STRING A SHA1

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {

                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            return sb.ToString();
        }

        //PARA LOS ROLES DINAMICOS
        public string controllistadinamicarol(DropDownList lista, String nombres, String values, string from)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            modelo.agregarlistadinamicaRol(lista, nombres, values, from);

            return mensaje;


        }



        //CAMBIAR ROL USUARIO
        public string controlcambiarolusuario(int rol, int usuario)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (rol == 0 || usuario == 0)
            {
                mensaje = "debe elegir una opcion";
            }
            else
            {
                modelo.cambiarolusuario(rol, usuario);
                mensaje = "se cambio el rol";
            }
            return mensaje;
        }


        //VALIDA ROL DE USUARIO
        public string validarmostrarolusuairo(Label muestra, int idusuario)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (idusuario == 0)
            {
                mensaje = "elija un usuario";
            }
            else
            {
                modelo.mostrarrolusuario(muestra, idusuario);

            }
            return mensaje;
        }

        //CONTROLES DEL ADMIN PERMISOS

        //PARA ELIMINAR EL ROL
        public string controleliminarrol(int rol)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (rol == 0)
            {
                mensaje = "seleccione el rol a eliminar";
            }
            else
            {
                modelo.eliminarxrol(rol);
                mensaje = "se elimino registros que contuvieran este rol";
            }
            return mensaje;
        }


        //CREAR UN NUEVO ROL
        public string controlcrearrol(String nombrerol)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (string.IsNullOrEmpty(nombrerol))
            {
                mensaje = "debe llenar el campo";
            }
            else
            {
                if (modelo.exiterol(nombrerol))
                {
                    mensaje = "este rol ya exite";
                }
                else
                {
                    modelo.crearrol(nombrerol);
                }
            }


            return mensaje;
        }

        //MODIFICAR ROL
        public string controlmodificarol(int rol, string nombre)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (string.IsNullOrEmpty(nombre) || rol == 0)
            {
                mensaje = "debe llenar los campos o seleccionar un rol";
            }
            else
            {
                if (modelo.exiterol(nombre))
                {
                    mensaje = "este nombre rol ya existe";
                }
                else
                {
                    modelo.modificarol(rol, nombre);
                }

            }
            return mensaje;

        }


        //CONTROL PARA DAR PERMISOS A UN ROL
        public string controldarpermisos(int rol, int permisos)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (rol == 0 || permisos == 0)
            {
                mensaje = "no tiene permisos";
            }
            else
            {
                modelo.darpermisos(rol, permisos);
                mensaje = "permisos asignados";
            }
            return mensaje;
        }

        //CONTROL PARA< ELIMINAR PERMISOS A UN ROL
        public string controleliminarpermisos(int permisos)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (permisos == 0)
            {
                mensaje = "seleccione una opcion";
            }
            else
            {
                modelo.eliminarpermisos(permisos);
                mensaje = "se elimino el permiso correctamente";
            }
            return mensaje;
        }

        //CONTROL PARA INSERTAR PERMISOS
        public string controlinsertarpermisos(String descripcion, string url)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (modelo.existepermiso(descripcion))
            {
                mensaje = "este permiso ya existe";
            }
            else
            {
                if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(url))
                {
                    mensaje = "campos vacios";
                }
                else
                {
                    modelo.agregarpermisosnuevos(descripcion, url);
                    mensaje = "se agrego el nuevo permiso";
                }
            }
            return mensaje;
        }



        //CONSULTAS PARA MOSTRAR USUARIOS
        public string controlconsulta(GridView grid, string consulta)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            modelo.gridview(grid, consulta);
            return mensaje;
        }

        //CONTROL PARA VALIDAR EL ROL
        public bool validartiporol(DropDownList list)
        {
            if (app.Session.id_rol_fk == 1)
            {
                return true;
            }
            else
            {
                list.Visible = false;
                return false;
            }

        }

        //PARA CAMBIAR LA CONTRASEÑA
        public string controlcambiarclave(DropDownList list, String nueva, int usuario)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (validartiporol(list))
            {
                if (string.IsNullOrEmpty(nueva) || usuario == 0)
                {
                    mensaje = "debe elegir una opcion o llenar los campos";
                }
                else
                {

                    modelo.cambiarclave(GenerarSHA1(nueva), usuario);
                    mensaje = "se cambio el la contraseña";
                }
            }
            else
            {

                if (string.IsNullOrEmpty(nueva))
                {
                    mensaje = "debe elegir una opcion o llenar los campos";
                }
                else
                {

                    modelo.cambiarclave(GenerarSHA1(nueva), app.Session.id_rol_fk);
                    mensaje = "se cambio el la contraseña";
                }
            }
            return mensaje;
        }


        //Agendamiento INSTRUCTOR

        public string controlinsertarplantilla(int tiempo, string nombre, int cancelar, string fecha_inicio, string fecha_fin, string tema)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (tiempo == 0)
            {
                mensaje = "seleccione una opcion";
            }
            else
            {
                modelo.insertarplantillaagenda(tiempo, nombre, cancelar, fecha_inicio, fecha_fin, tema);
                mensaje = "agregado correctamente";
            }
            return mensaje;
        }
        public string controlinsertardetalle(string horainicio, int plantilla)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (plantilla == 0)
            {
                mensaje = "seleccione una opcion";
            }
            else
            {
                modelo.insertardetalle(horainicio, plantilla);
                mensaje = "agregado correctamente";
            }
            return mensaje;
        }
        public string controlinsertarhorario(string dia, string horainicio, string horafin, int plantilla)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (plantilla == 0)
            {
                mensaje = "seleccione una opcion";
            }
            else
            {
                modelo.insertarhorario(dia, horainicio, horafin, plantilla);
                mensaje = "agregado correctamente";
            }
            return mensaje;
        }


        public string controleliminardetalle(string dia, string horainicio, string horafin, int plantilla)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (string.IsNullOrEmpty(dia) || string.IsNullOrEmpty(horafin) || string.IsNullOrEmpty(horainicio) || plantilla == 0)
            {
                mensaje = "faltan vallores por llenar";
            }
            else
            {
                modelo.eliminardetalle(dia, horainicio, horafin, plantilla);
                mensaje = "Eliminado correctamente";
            }
            return mensaje;
        }
        public string controltraertiempo(string consulta, string variable)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";

            mensaje = modelo.traertiempo(consulta, variable);


            return mensaje;
        }
        public string controlinsertarestudiante(int estudiante, string fecha)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";

            mensaje = "";
            modelo.insertarestudiante(estudiante, fecha);


            return mensaje;
        }
        public string controlmodificardiahora(string hora, string dia, int id)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (string.IsNullOrEmpty(hora) || string.IsNullOrEmpty(dia))
            {
                mensaje = "debe llenar los campos ";
            }
            else
            {
                modelo.cambiarfechadia(hora, dia, id);

            }
            return mensaje;

        }
        public string controlestado(int id, string estado)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";
            if (string.IsNullOrEmpty(estado))
            {
                mensaje = "debe llenar los campos ";
            }
            else
            {
                modelo.estado(id, estado);

            }
            return mensaje;

        }
        public string controlinsertarobservacion(string observacion, string fecha, string dia, string tema, Boolean asistio)
        {
            Modelo modelo = new Modelo();
            String mensaje = "";

            mensaje = "";
            modelo.insertarobservacion(observacion, fecha, dia, tema, asistio);


            return mensaje;
        }



        public void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Text == previousRow.Cells[i].Text)
                    {
                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                               previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                    }
                }
            }
        }


        ///PARA INSERTAR LAS QUEJAS
        ///
        public String ControlInsertarQueja(string descripcion, int id_usuario, DateTime fechaQueja)
        {

            Modelo modelo = new Modelo();
            String respuesta = "";

            if (string.IsNullOrEmpty(descripcion) || id_usuario == 0)
            {
                respuesta = "Debe llenar todos los campos";

            }
            else
            {

                modelo.InsertarQueja(descripcion, id_usuario, fechaQueja);

                respuesta = "Queja Enviada";

            }

            return respuesta;

        }




    }
}