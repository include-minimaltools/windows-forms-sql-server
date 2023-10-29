using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class EstudianteMCD
    {
        Acceso db = new Acceso();
        private SqlCommand Comando;

        public bool Insertar(Estudiante est)
        {
            db.Conexion.Open();

            Comando = new SqlCommand();

            Comando.Connection = db.Conexion;

            Comando.CommandText = "insert into Estudiante (Carnet, Nombres, Apellidos, FechaNac, Nota) " +
            "values (@Carnet, @Nombres, @Apellidos, @FechaNac, @Nota)";            

            Comando.Parameters.AddWithValue("@Carnet", est.Carnet);
            Comando.Parameters.AddWithValue("@Nombres", est.Nombres);
            Comando.Parameters.AddWithValue("@Apellidos", est.Apellidos);
            Comando.Parameters.AddWithValue("@FechaNac", est.FechaNac);
            Comando.Parameters.AddWithValue("@Nota", est.Nota);

            int i = Comando.ExecuteNonQuery();

            db.Conexion.Close();

            return i > 0;
        }

        public bool Actualizar(Estudiante est)
        {
            db.Conexion.Open();

            Comando = new SqlCommand();

            Comando.Connection = db.Conexion;

            Comando.CommandText = "update Estudiante set Nombres = @Nombres, Apellidos = @Apellidos, " +
                "FechaNac = @FechaNac, Nota = @Nota where Carnet = @Carnet";

            Comando.Parameters.AddWithValue("@Carnet", est.Carnet);
            Comando.Parameters.AddWithValue("@Nombres", est.Nombres);
            Comando.Parameters.AddWithValue("@Apellidos", est.Apellidos);
            Comando.Parameters.AddWithValue("@FechaNac", est.FechaNac);
            Comando.Parameters.AddWithValue("@Nota", est.Nota);

            int i = Comando.ExecuteNonQuery();

            db.Conexion.Close();

            return i > 0; // Devolvemos true si la cantidad de filas afectadas fue mayor a 0
        }

        public bool Eliminar(int Carnet)
        {
            db.Conexion.Open();

            Comando = new SqlCommand();

            Comando.CommandText = "delete from Estudiante where Carnet = @Carnet";
            Comando.Connection = db.Conexion;
            Comando.Parameters.AddWithValue("@Carnet", Carnet);

            int i = Comando.ExecuteNonQuery();
            db.Conexion.Close();

            return i > 0;
        }

        public Estudiante BuscarEstudiante(int Carnet)
        {
            db.Conexion.Open();

            Comando = new SqlCommand();

            Comando.Connection = db.Conexion;
            Comando.CommandText = "select * from Estudiante where Carnet = @Carnet";

            Comando.Parameters.AddWithValue("@Carnet", Carnet);

            SqlDataReader dr = Comando.ExecuteReader();

            dr.Read();

            if (!dr.HasRows)
            {
                db.Conexion.Close();
                return null;
            }

            Estudiante est = new Estudiante
            {
                Carnet = dr.GetInt32(0),
                Nombres = dr.GetString(1),
                Apellidos = dr.GetString(2),
                FechaNac = dr.GetDateTime(3),
                Nota = dr.GetInt32(4)
            };

            db.Conexion.Close();
            return est;
        }

        public DataTable ObtenerEstudiantes()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            DataTable dt = new DataTable();

            string sql = "select * from Estudiante";
            da = new SqlDataAdapter(sql, db.Conexion);
            da.Fill(ds, "Estudiante");
            dt = ds.Tables["Estudiante"];

            return dt;
        }
    }
}
