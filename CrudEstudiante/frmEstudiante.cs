using CapaDatos;
using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CrudEstudiante
{
    public partial class frmEstudiante : Form
    {
        public frmEstudiante()
        {
            InitializeComponent();
        }

        EstudianteMCN metodosCapaNegocio = new EstudianteMCN();

        private void Imprimir()
        {
            dgvEstudiantes.DataSource = null;
            dgvEstudiantes.DataSource = metodosCapaNegocio.ObtenerEstudiantes();
        }

        private void frmEstudiante_Load(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Estudiante est = metodosCapaNegocio.BuscarEstudiante(int.Parse(txtCarnet.Text));

            if (est is null)
            {
                MessageBox.Show($"No se ha encontrado el estudiante con el carnet {txtCarnet.Text}");
                return;
            }

            txtNombres.Text = est.Nombres;
            txtApellidos.Text = est.Apellidos;
            dtpFechaNac.Value = est.FechaNac;
            txtNota.Text = est.Nota.ToString();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Estudiante est = metodosCapaNegocio.BuscarEstudiante(int.Parse(txtCarnet.Text));

            if (est != null)
            {
                MessageBox.Show($"Ya existe un estudiante con carnet: {txtCarnet.Text}");
                return;
            }

            est = new Estudiante
            {
                Carnet = int.Parse(txtCarnet.Text),
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                FechaNac = dtpFechaNac.Value,
                Nota = int.Parse(txtNota.Text)
            };

            bool resultado = metodosCapaNegocio.Insertar(est);

            if (resultado)
            {
                MessageBox.Show("Se ha agregado al estudiante");
                Imprimir();
            }
            else
                MessageBox.Show("No se ha podido agregar al estudiante");

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Estudiante est = metodosCapaNegocio.BuscarEstudiante(int.Parse(txtCarnet.Text));

            if (est is null)
            {
                MessageBox.Show($"No se ha encontrado el estudiante con el carnet {txtCarnet.Text}");
                return;
            }

            est = new Estudiante
            {
                Carnet = int.Parse(txtCarnet.Text),
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                FechaNac = dtpFechaNac.Value,
                Nota = int.Parse(txtNota.Text)
            };

            bool resultado = metodosCapaNegocio.Actualizar(est);

            if (resultado)
            {
                MessageBox.Show("Se ha actualizado al estudiante");
                Imprimir();
            }
            else
                MessageBox.Show("No se ha podido actualizar al estudiante");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Estudiante est = metodosCapaNegocio.BuscarEstudiante(int.Parse(txtCarnet.Text));

            if (est is null)
            {
                MessageBox.Show($"No se ha encontrado el estudiante con el carnet {txtCarnet.Text}");
                return;
            }

            bool resultado = metodosCapaNegocio.Eliminar(est.Carnet);

            if (resultado)
            {
                MessageBox.Show("Se ha eliminado al estudiante");
                Imprimir();
            }
            else
                MessageBox.Show("No se ha podido eliminar al estudiante");
        }
    }
}
