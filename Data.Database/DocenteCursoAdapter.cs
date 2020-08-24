using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentes = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("select * from docentes_cursos dc INNER JOIN cursos c on c.id_curso=dc.id_curso "
                    + "INNER JOIN personas p on dc.id_docente=p.id_persona INNER JOIN planes pl on p.id_plan=pl.id_plan", sqlConn);
                SqlDataReader drDocentes = cmdGetAll.ExecuteReader();
                while (drDocentes.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDocentes["id_dictado"];
                    switch ((int)drDocentes["cargo"])
                    {
                        case 1:
                            dc.Cargo = "Titular";
                            break;
                        case 2:
                            dc.Cargo = "Auxiliar";
                            break;
                        case 3:
                            dc.Cargo = "Ayudante";
                            break;
                    }
                    Curso cur = new Curso();
                    cur.ID = (int)drDocentes["id_curso"];
                    cur.AnioCalendario = (int)drDocentes["anio_calendario"];
                    cur.Cupo = (int)drDocentes["cupo"];
                    dc.Curso = cur;
                    Persona per = new Persona();
                    per.ID = (int)drDocentes["id_persona"];
                    per.Nombre = (string)drDocentes["nombre"];
                    per.Apellido = (string)drDocentes["apellido"];
                    per.Email = (string)drDocentes["email"];
                    per.Direccion = (string)drDocentes["direccion"];
                    per.Telefono = (string)drDocentes["telefono"];
                    per.FechaNacimiento = (DateTime)drDocentes["fecha_nac"];
                    per.Legajo = (int)drDocentes["legajo"];
                    switch ((int)drDocentes["tipo_persona"])
                    {
                        case 1:
                            per.TipoPersona = "No docente";
                            break;
                        case 2:
                            per.TipoPersona = "Alumno";
                            break;
                        case 3:
                            per.TipoPersona = "Docente";
                            break;
                    }
                    Plan pla = new Plan();
                    pla.ID = (int)drDocentes["id_plan"];
                    per.Plan = pla;
                    dc.Docente = per;

                    docentes.Add(dc);
                }
                drDocentes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al recuperar datos de los docentes.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docentes;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select * from docentes_cursos dc INNER JOIN cursos c on c.id_curso=dc.id_curso "
                + "INNER JOIN personas p on dc.id_docente=p.id_persona INNER JOIN planes pl on p.id_plan=pl.id_plan WHERE id_dictado=@id", sqlConn);
                cmdGetOne.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocentes = cmdGetOne.ExecuteReader();
                if (drDocentes.Read())
                {
                    dc.ID = (int)drDocentes["id_dictado"];
                    switch ((int)drDocentes["cargo"])
                    {
                        case 1:
                            dc.Cargo = "Titular";
                            break;
                        case 2:
                            dc.Cargo = "Auxiliar";
                            break;
                        case 3:
                            dc.Cargo = "Ayudante";
                            break;
                    }
                    Curso cur = new Curso();
                    cur.ID = (int)drDocentes["id_curso"];
                    cur.AnioCalendario = (int)drDocentes["anio_calendario"];
                    cur.Cupo = (int)drDocentes["cupo"];
                    dc.Curso = cur;
                    Persona per = new Persona();
                    per.ID = (int)drDocentes["id_persona"];
                    per.Nombre = (string)drDocentes["nombre"];
                    per.Apellido = (string)drDocentes["apellido"];
                    per.Email = (string)drDocentes["email"];
                    per.Direccion = (string)drDocentes["direccion"];
                    per.Telefono = (string)drDocentes["telefono"];
                    per.FechaNacimiento = (DateTime)drDocentes["fecha_nac"];
                    per.Legajo = (int)drDocentes["legajo"];
                    switch ((int)drDocentes["tipo_persona"])
                    {
                        case 1:
                            per.TipoPersona = "No docente";
                            break;
                        case 2:
                            per.TipoPersona = "Alumno";
                            break;
                        case 3:
                            per.TipoPersona = "Docente";
                            break;
                    }
                    Plan pla = new Plan();
                    pla.ID = (int)drDocentes["id_plan"];
                    per.Plan = pla;
                    dc.Docente = per;
                }

                drDocentes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al recuperar datos del Docente.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dc;
        }

        public bool ExisteDocenteCurso(int idCur, int idDoc, string cargo)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select * from docentes_cursos WHERE id_curso=@idCur and id_docente=@idDoc and cargo=@cargo"
                    , sqlConn);
                cmdGetOne.Parameters.Add("@idCur", SqlDbType.Int).Value = idCur;
                cmdGetOne.Parameters.Add("@idDoc", SqlDbType.Int).Value = idDoc;
                switch (cargo)
                {
                    case "Titular":
                        cmdGetOne.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;
                        break;
                    case "Auxiliar":
                        cmdGetOne.Parameters.Add("@cargo", SqlDbType.Int).Value = 2;
                        break;
                    case "Ayudante":
                        cmdGetOne.Parameters.Add("@cargo", SqlDbType.Int).Value = 3;
                        break;
                }
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al validar que no exista este Docente asignado", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al eliminar el Docente.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE docentes_cursos SET id_docente=@idDoc, id_curso=@idCur, cargo=@cargo "
                    +"WHERE id_dictado=@id", sqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmdUpdate.Parameters.Add("@idDoc", SqlDbType.Int).Value = dc.Docente.ID;
                cmdUpdate.Parameters.Add("@idCur", SqlDbType.Int).Value = dc.Curso.ID;
                switch (dc.Cargo)
                {
                    case "Titular":
                        cmdUpdate.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;
                        break;
                    case "Auxiliar":
                        cmdUpdate.Parameters.Add("@cargo", SqlDbType.Int).Value = 2;
                        break;
                    case "Ayudante":
                        cmdUpdate.Parameters.Add("@cargo", SqlDbType.Int).Value = 3;
                        break;
                }
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al modificar datos del dictado.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso dc)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "insert into docentes_cursos(id_docente,id_curso,cargo) " +
                "values(@idDoc,@idCur,@cargo) " +
                "select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@idDoc", SqlDbType.Int).Value = dc.Docente.ID;
                cmdInsert.Parameters.Add("@idCur", SqlDbType.Int).Value = dc.Curso.ID;
                switch (dc.Cargo)
                {
                    case "Titular":
                        cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = 1;
                        break;
                    case "Auxiliar":
                        cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = 2;
                        break;
                    case "Ayudante":
                        cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = 3;
                        break;
                }
                dc.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al crear un nuevo dictado.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dc)
        {
            if (dc.State == BusinessEntity.States.Deleted)
            {
                this.Delete(dc.ID);
            }
            else if (dc.State == BusinessEntity.States.New)
            {
                this.Insert(dc);
            }
            else if (dc.State == BusinessEntity.States.Modified)
            {
                this.Update(dc);
            }
            dc.State = BusinessEntity.States.Unmodified;
        }
    }
}
