using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba1
{
    public class Usuarios
    {

        int id_usuario;
        string numero_documento;
        string primer_nombre;
        string segundo_nombre;
        string primer_apellido;
        string segundo_apellido;
        string usuario;
        string clave;
        string confirmar_clave;
        string correo;
        int id_rol_fk;
        int id_identificacion_fk;

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Numero_documento { get => numero_documento; set => numero_documento = value; }
        public string Primer_nombre { get => primer_nombre; set => primer_nombre = value; }
        public string Segundo_nombre { get => segundo_nombre; set => segundo_nombre = value; }
        public string Primer_apellido { get => primer_apellido; set => primer_apellido = value; }
        public string Segundo_apellido { get => segundo_apellido; set => segundo_apellido = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Confirmar_clave { get => confirmar_clave; set => confirmar_clave = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Id_rol_fk { get => id_rol_fk; set => id_rol_fk = value; }
        public int Id_identificacion_fk { get => id_identificacion_fk; set => id_identificacion_fk = value; }
    }
}