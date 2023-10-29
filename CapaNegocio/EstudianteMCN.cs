using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class EstudianteMCN
    {
        EstudianteMCD metodosCapaDatos = new EstudianteMCD();

        public bool Insertar (Estudiante est)
        {
            return metodosCapaDatos.Insertar(est);
        }

        public bool Actualizar (Estudiante est)
        {
            return metodosCapaDatos.Actualizar(est);
        }

        public bool Eliminar (int Carnet)
        {
            return metodosCapaDatos.Eliminar(Carnet);
        }
        
        public Estudiante BuscarEstudiante (int Carnet)
        {
            return metodosCapaDatos.BuscarEstudiante(Carnet);
        }

        public DataTable ObtenerEstudiantes()
        {
            return metodosCapaDatos.ObtenerEstudiantes();
        }
    }
}
