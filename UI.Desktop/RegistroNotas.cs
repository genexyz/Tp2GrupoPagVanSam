using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class RegistroNotas : ApplicationForm
    {
        public RegistroNotas(Usuario us)
        {
            InitializeComponent();
            this.Modo = ModoForm.Modificacion;
            this.dgvCursos.AutoGenerateColumns = false;
            this.dgvAlumnos.AutoGenerateColumns = false;
            this.usuarioActual = us;
        }

        private Usuario usuarioActual;
        private AlumnoInscripcion inscripcionActual;

        private void RegistroNotas_Load(object sender, EventArgs e)
        {
            this.ListarCursos();
            dgvCursos.ClearSelection();
        }

        private void ListarCursos()
        {
            try
            {
                CursoLogic curlog = new CursoLogic();
                dgvCursos.DataSource = curlog.GetCursosDocente(this.usuarioActual.Persona.ID);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ListarAlumnos()
        {
            try
            {
                int IDCurso = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                List<AlumnoInscripcion> alumnosInscriptos = new List<AlumnoInscripcion>();
                foreach (AlumnoInscripcion ai in ail.GetAll())
                {
                    if (ai.Curso.ID == IDCurso)
                        alumnosInscriptos.Add(ai);
                }
                this.dgvAlumnos.DataSource = alumnosInscriptos;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearADatos()
        {
            inscripcionActual = ((AlumnoInscripcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem);
            inscripcionActual.State = AlumnoInscripcion.States.Modified;
            inscripcionActual.Nota = Convert.ToInt32(this.cbxNota.SelectedItem);
            inscripcionActual.Condicion = this.cbxCondicion.SelectedItem.ToString();
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                AlumnoInscripcionLogic AILogic = new AlumnoInscripcionLogic();
                AILogic.Save(inscripcionActual);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            bool EsValido = true;
            if (this.cbxCondicion.SelectedIndex < 0 || this.cbxNota.SelectedIndex < 0)
            {
                EsValido = false;
                this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return EsValido;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.ListarAlumnos();
            }
        }

        private void btnBorrarNota_Click(object sender, EventArgs e)
        {
            try
            {
                inscripcionActual = ((AlumnoInscripcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem);
                inscripcionActual.State = AlumnoInscripcion.States.Modified;
                inscripcionActual.Nota = 0;
                inscripcionActual.Condicion = "Inscripto";
                AlumnoInscripcionLogic AILogic = new AlumnoInscripcionLogic();
                AILogic.Save(inscripcionActual);
                this.ListarAlumnos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ListarAlumnos();
        }
    }
}
