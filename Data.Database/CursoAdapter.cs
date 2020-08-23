using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos c INNER JOIN materias m on c.id_materia = m.id_materia "
                   + " INNER JOIN planes p on p.id_plan = m.id_plan INNER JOIN comisiones co on c.id_comision = co.id_comision", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                    Materia mat = new Materia();
                    mat.ID = (int)drCursos["id_materia"];
                    mat.Descripcion = (string)drCursos["desc_materia"];
                    mat.HSSemanales = (int)drCursos["hs_semanales"];
                    mat.HSTotales = (int)drCursos["hs_totales"];

                    Plan pla = new Plan();
                    pla.ID = (int)drCursos["id_plan"];
                    mat.Plan = pla;

                    Comision com = new Comision();
                    com.ID = (int)drCursos["id_comision"];
                    com.Descripcion = (string)drCursos["desc_comision"];
                    com.AnioEspecialidad = (int)drCursos["anio_especialidad"];
                    com.Plan = pla;

                    cur.Comision = com;
                    cur.Materia = mat;
                    cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos c INNER JOIN materias m on c.id_materia = m.id_materia"
                   + " INNER JOIN planes p on p.id_plan = m.id_plan INNER JOIN especialidades e on e.id_especialidad = p.id_especialidad"
                   + " INNER JOIN comisiones co on c.id_comision = co.id_comision where id_curso=@id"
                   , sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();
                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];

                    Materia mat = new Materia();
                    mat.ID = (int)drCursos["id_materia"];
                    mat.Descripcion = (string)drCursos["desc_materia"];
                    mat.HSSemanales = (int)drCursos["hs_semanales"];
                    mat.HSTotales = (int)drCursos["hs_totales"];

                    Comision com = new Comision();
                    com.ID = (int)drCursos["id_comision"];
                    com.Descripcion = (string)drCursos["desc_comision"];
                    com.AnioEspecialidad = (int)drCursos["anio_especialidad"];

                    Plan pla = new Plan();
                    pla.ID = (int)drCursos["id_plan"];
                    pla.Descripcion = (string)drCursos["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drCursos["id_especialidad"];
                    esp.Descripcion = (string)drCursos["desc_especialidad"];

                    pla.Especialidad = esp;
                    com.Plan = pla;
                    cur.Materia = mat;
                    cur.Comision = com;
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cur;
        }

        public bool ExisteCurso(int idMat, int idCom, int anio)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select * from cursos where "
                    + "id_materia=@idMat and id_comision=@idCom and anio_calendario=@anio", sqlConn);
                cmdGetOne.Parameters.Add("@idMat", SqlDbType.Int).Value = idMat;
                cmdGetOne.Parameters.Add("@idCom", SqlDbType.Int).Value = idCom;
                cmdGetOne.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return existe;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE cursos SET id_comision=@idCom, id_materia=@idMat, anio_calendario=@anio, cupo=@cupo "
                    + "WHERE id_curso=@id", sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdUpdate.Parameters.Add("@idCom", SqlDbType.Int).Value = curso.Comision.ID;
                cmdUpdate.Parameters.Add("@idMat", SqlDbType.Int).Value = curso.Materia.ID;
                cmdUpdate.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdUpdate.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into cursos(id_materia,id_comision,anio_calendario,cupo) " +
                "values(@idMat,@idCom,@anio,@cupo) " +
                "select @@identity", sqlConn);
                cmdInsert.Parameters.Add("@idMat", SqlDbType.Int).Value = curso.Materia.ID;
                cmdInsert.Parameters.Add("@idCom", SqlDbType.Int).Value = curso.Comision.ID;
                cmdInsert.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdInsert.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear un nuevo curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }

       /* public List<Curso> GetCursosDocente(int IDDocente)
        {
            List<Curso> cursosDocente = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursosDocente = new SqlCommand("GetAllPorDocente_Cursos", SqlConn);
                cmdCursosDocente.CommandType = CommandType.StoredProcedure;
                cmdCursosDocente.Parameters.Add("@id", SqlDbType.Int).Value = IDDocente;
                SqlDataReader drCursosDocente = cmdCursosDocente.ExecuteReader();

                while (drCursosDocente.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)drCursosDocente["id_curso"];
                    cur.AnioCalendario = (int)drCursosDocente["anio_calendario"];
                    cur.Cupo = (int)drCursosDocente["cupo"];
                    cur.Materia.ID = (int)drCursosDocente["id_materia"];
                    cur.Materia.Descripcion = (string)drCursosDocente["desc_materia"];
                    cur.Materia.HSSemanales = (int)drCursosDocente["hs_semanales"];
                    cur.Materia.HSTotales = (int)drCursosDocente["hs_totales"];
                    cur.Materia.Plan.ID = (int)drCursosDocente["id_plan"];
                    cur.Comision.ID = (int)drCursosDocente["id_comision"];
                    cur.Comision.Descripcion = (string)drCursosDocente["desc_comision"];
                    cur.Comision.AnioEspecialidad = (int)drCursosDocente["anio_especialidad"];
                    cur.Comision.Plan.ID = (int)drCursosDocente["id_plan"];
                    cursosDocente.Add(cur);
                }
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los cursos del docente.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursosDocente;
        }*/
    }
}