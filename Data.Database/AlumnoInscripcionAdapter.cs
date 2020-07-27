using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones", sqlConn);
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];
                    ins.Alumno.ID = (int)drInscripciones["id_persona"];
                    ins.Alumno.Nombre = (string)drInscripciones["nombre"];
                    ins.Alumno.Apellido = (string)drInscripciones["apellido"];
                    ins.Alumno.Email = (string)drInscripciones["email"];
                    ins.Alumno.Direccion = (string)drInscripciones["direccion"];
                    ins.Alumno.Telefono = (string)drInscripciones["telefono"];
                    ins.Alumno.FechaNacimiento = (DateTime)drInscripciones["fecha_nac"];
                    ins.Alumno.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            ins.Alumno.TipoPersona = "No docente";
                            break;
                        case 2:
                            ins.Alumno.TipoPersona = "Alumno";
                            break;
                        case 3:
                            ins.Alumno.TipoPersona = "Docente";
                            break;
                    }
                    ins.Alumno.Plan.ID = (int)drInscripciones["id_plan"];
                    ins.Curso.ID = (int)drInscripciones["id_curso"];
                    ins.Curso.AnioCalendario = (int)drInscripciones["anio_calendario"];
                    inscripciones.Add(ins);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de las inscripciones de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }

        public List<AlumnoInscripcion> GetAll(int IDAlumno)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_alumno=@IDAlumno", sqlConn);
                cmdInscripciones.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                while (drInscripciones.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];
                    ins.Alumno.ID = (int)drInscripciones["id_persona"];
                    ins.Alumno.Nombre = (string)drInscripciones["nombre"];
                    ins.Alumno.Apellido = (string)drInscripciones["apellido"];
                    ins.Alumno.Email = (string)drInscripciones["email"];
                    ins.Alumno.Direccion = (string)drInscripciones["direccion"];
                    ins.Alumno.Telefono = (string)drInscripciones["telefono"];
                    ins.Alumno.FechaNacimiento = (DateTime)drInscripciones["fecha_nac"];
                    ins.Alumno.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            ins.Alumno.TipoPersona = "No docente";
                            break;
                        case 2:
                            ins.Alumno.TipoPersona = "Alumno";
                            break;
                        case 3:
                            ins.Alumno.TipoPersona = "Docente";
                            break;
                    }
                    ins.Alumno.Plan.ID = (int)drInscripciones["id_plan"];
                    ins.Curso.ID = (int)drInscripciones["id_curso"];
                    ins.Curso.AnioCalendario = (int)drInscripciones["anio_calendario"];
                    ins.Curso.Comision.Descripcion = (string)drInscripciones["desc_comision"];
                    ins.Curso.Materia.Descripcion = (string)drInscripciones["desc_materia"];
                    inscripciones.Add(ins);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de las inscripciones del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                if (drInscripciones.Read())
                {
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Alumno.ID = (int)drInscripciones["id_persona"];
                    ins.Alumno.Nombre = (string)drInscripciones["nombre"];
                    ins.Alumno.Apellido = (string)drInscripciones["apellido"];
                    ins.Alumno.Email = (string)drInscripciones["email"];
                    ins.Alumno.Direccion = (string)drInscripciones["direccion"];
                    ins.Alumno.Telefono = (string)drInscripciones["telefono"];
                    ins.Alumno.FechaNacimiento = (DateTime)drInscripciones["fecha_nac"];
                    ins.Alumno.Legajo = (int)drInscripciones["legajo"];
                    switch ((int)drInscripciones["tipo_persona"])
                    {
                        case 1:
                            ins.Alumno.TipoPersona = "No docente";
                            break;
                        case 2:
                            ins.Alumno.TipoPersona = "Alumno";
                            break;
                        case 3:
                            ins.Alumno.TipoPersona = "Docente";
                            break;
                    }
                    ins.Alumno.Plan.ID = (int)drInscripciones["id_plan"];
                    ins.Curso.ID = (int)drInscripciones["id_curso"];
                }

                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ins;
        }

        public bool ExisteInscripcion(int idAlu, int idCur)
        {
            bool existeInscripcion;
            try
            {
                this.OpenConnection();
                SqlCommand cmdExisteInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_alumno=@idAlu and id_curso=@idCur", sqlConn);
                cmdExisteInscripcion.Parameters.Add("@idAlu", SqlDbType.Int).Value = idAlu;
                cmdExisteInscripcion.Parameters.Add("@idCur", SqlDbType.Int).Value = idCur;
                existeInscripcion = Convert.ToBoolean(cmdExisteInscripcion.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la Inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return existeInscripcion;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE alumnos_inscripciones SET condicion=@condicion, nota=@nota "
                   + "WHERE id_inscripcion=@id and id_alumno=@idAlumno and id_curso=@idCurso", sqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdUpdate.Parameters.Add("@idAlumno", SqlDbType.Int).Value = inscripcion.Alumno.ID;
                cmdUpdate.Parameters.Add("@idCurso", SqlDbType.Int).Value = inscripcion.Curso.ID;
                cmdUpdate.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into alumnos_inscripciones(id_alumno,id_curso,condicion,nota) " +
                "values(@idAlumno,@idCurso,@condicion,@nota) " +
                "select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@idAlumno", SqlDbType.Int).Value = inscripcion.Alumno.ID;
                cmdInsert.Parameters.Add("@idCurso", SqlDbType.Int).Value = inscripcion.Curso.ID;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                inscripcion.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear nueva inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }

    }
}