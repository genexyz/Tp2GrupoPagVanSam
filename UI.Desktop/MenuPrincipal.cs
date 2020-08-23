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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades();
            esp.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            user.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes planes = new Planes();
            planes.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comisiones = new Comisiones();
            comisiones.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias();
            materias.ShowDialog();
        }

        private void ctnCursos_Click(object sender, EventArgs e)
        {
            Cursos curso = new Cursos();
            curso.ShowDialog();
        }
    }
}