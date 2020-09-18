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
    public partial class MenuPrincipal : ApplicationForm
    {
        
        public MenuPrincipal(Usuario u)
        {
            InitializeComponent();
            this.usuarioActual = u;
        }

        private Usuario usuarioActual;
        public Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }
        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades(UsuarioActual);
            esp.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios(UsuarioActual);
            user.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes planes = new Planes(UsuarioActual);
            planes.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            ChequearPermisos();
        }

        private void ChequearPermisos()
        {
            try
            {
                lblComisiones.Visible =
                lblCursos.Visible =
                lblEspecialidades.Visible =
                lblInscripcion.Visible =
                lblMaterias.Visible =
                lblPersonas.Visible =
                lblPlanes.Visible =
                lblRegistrarNotas.Visible =
                lblUsuarios.Visible =
                comisionesToolStripMenuItem.Visible =
                cursosToolStripMenuItem1.Visible =
                especialidadesToolStripMenuItem.Visible =
                inscripcionACursoToolStripMenuItem.Visible =
                materiasToolStripMenuItem.Visible =
                personasToolStripMenuItem.Visible =
                planesToolStripMenuItem1.Visible =
                registrarNotasToolStripMenuItem.Visible =
                usuariosToolStripMenuItem.Visible =
                reportesToolStripMenuItem.Visible =
                aBMToolStripMenuItem.Visible =
                btnComisiones.Visible =
                btnCursos.Visible =
                btnEspecialidades.Visible =
                btnInscripciones.Visible =
                btnMaterias.Visible =
                btnPersonas.Visible =
                btnPlanes.Visible =
                btnRegistrarNotas.Visible =
                btnUsuarios.Visible = false;

                ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                UsuarioActual.ModulosUsuarios = mul.GetPermisos(UsuarioActual.ID);

                if (UsuarioActual.Persona.TipoPersona == "Alumno")
                {
                    btnInscripciones.Visible = true;
                    lblInscripcion.Visible = true;
                    inscripcionACursoToolStripMenuItem.Visible = true;

                }
                else if (UsuarioActual.Persona.TipoPersona == "Docente")
                {
                    //btnRegistrarNotas.Visible = true;
                    registrarNotasToolStripMenuItem.Visible = true;
                }
                else if (UsuarioActual.Persona.TipoPersona == "No docente")
                {
                    //btnReportes.Visible = true;
                    reportesToolStripMenuItem.Visible = true;
                }

                foreach (ModuloUsuario mu in UsuarioActual.ModulosUsuarios)
                {
                    if (mu.Modulo.Descripcion == "Usuarios")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                        {
                            aBMToolStripMenuItem.Visible = true;
                            btnUsuarios.Visible = true;
                            lblUsuarios.Visible = true;
                            usuariosToolStripMenuItem.Visible = true;
                        }
                    }
                    else if (mu.Modulo.Descripcion == "Personas")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                        {
                            aBMToolStripMenuItem.Visible = true;
                            lblPersonas.Visible = true;
                            btnPersonas.Visible = true;
                            personasToolStripMenuItem.Visible = true;
                        }
                    }
                    else if (mu.Modulo.Descripcion == "Planes")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                        {
                            aBMToolStripMenuItem.Visible = true;
                            lblPlanes.Visible = true;
                            btnPlanes.Visible = true;
                            planesToolStripMenuItem1.Visible = true;
                        }
                    }
                    else if (mu.Modulo.Descripcion == "Materias")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                        {
                            aBMToolStripMenuItem.Visible = true;
                            btnMaterias.Visible = true;
                            lblMaterias.Visible = true;
                            materiasToolStripMenuItem.Visible = true;
                        }
                    }
                    else if (mu.Modulo.Descripcion == "Especialidades")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                        {
                            aBMToolStripMenuItem.Visible = true;
                            btnEspecialidades.Visible = true;
                            lblEspecialidades.Visible = true;
                            especialidadesToolStripMenuItem.Visible = true;
                        }
                    }
                    else if (mu.Modulo.Descripcion == "Cursos")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                        {
                            aBMToolStripMenuItem.Visible = true;
                            btnCursos.Visible = true;
                            lblCursos.Visible = true;
                            cursosToolStripMenuItem1.Visible = true;
                        }
                    }
                    else if (mu.Modulo.Descripcion == "Comisiones")
                    {
                        if (mu.PermiteAlta || mu.PermiteBaja || mu.PermiteConsulta || mu.PermiteModificacion)
                        {
                            aBMToolStripMenuItem.Visible = true;
                            btnComisiones.Visible = true;
                            lblComisiones.Visible = true;
                            comisionesToolStripMenuItem.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comisiones = new Comisiones(UsuarioActual);
            comisiones.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias(UsuarioActual);
            materias.ShowDialog();
        }

        private void ctnCursos_Click(object sender, EventArgs e)
        {
            Cursos curso = new Cursos(UsuarioActual);
            curso.ShowDialog();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Personas persona = new Personas(UsuarioActual);
            persona.ShowDialog();
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            Inscripciones alumnoInscripcion = new Inscripciones(usuarioActual);
            alumnoInscripcion.ShowDialog();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.usuarioActual = login.UsuarioActual;
                this.Visible = true;
            }
            else
            {
                this.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}