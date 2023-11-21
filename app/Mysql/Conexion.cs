using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba1
{
    public class Conexion
    {
        public static MySqlConnection getConexion()
        {
            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "";
            string bd = "alejandra-valeria-citas";


            //cadena de conexion
            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + bd;

            //MySql connection para generar la conexion
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            return conexion;

        }

    }
}