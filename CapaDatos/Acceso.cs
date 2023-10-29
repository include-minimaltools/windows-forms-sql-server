using System.Data.SqlClient;

namespace CapaDatos
{
    public class Acceso
    {
        private string Cadena = "Data Source=(local);Initial Catalog=SIRA;Integrated Security=True;";

        public SqlConnection Conexion;

        public Acceso()
        {
            Conexion = new SqlConnection(Cadena);
        }
    }
}
