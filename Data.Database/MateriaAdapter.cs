using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("select * from materias m INNER JOIN planes p on m.id_plan = p.id_plan " 
                   +" INNER JOIN especialidades e on p.id_especialidad = e.id_especialidad", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];

                    Plan pla = new Plan();
                    pla.ID = (int)drMaterias["id_plan"];
                    pla.Descripcion = (string)drMaterias["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drMaterias["id_especialidad"];
                    esp.Descripcion = (string)drMaterias["desc_especialidad"];
                    
                    pla.Especialidad = esp;
                    mat.Plan = pla;
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("select * from materias m INNER JOIN planes p on m.id_plan = p.id_plan "
                    + "INNER JOIN especialidades e on p.id_especialidad = e.id_especialidad where id_materia=@id", sqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMateria.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];

                    Plan pla = new Plan();
                    pla.ID = (int)drMaterias["id_plan"];
                    pla.Descripcion = (string)drMaterias["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drMaterias["id_especialidad"];
                    esp.Descripcion = (string)drMaterias["desc_especialidad"];
                    
                    pla.Especialidad = esp;

                    mat.Plan = pla;
                }

                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }

        public bool ExisteMateria(int idPlan, string desc)
        {
            bool existeMate;
            try
            {
                this.OpenConnection();
                SqlCommand cmdExisteMate = new SqlCommand("select * from materias where "
                    + "id_plan=@idPlan and desc_materia=@desc", sqlConn);
                cmdExisteMate.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                cmdExisteMate.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
                existeMate = Convert.ToBoolean(cmdExisteMate.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return existeMate;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE materias SET desc_materia=@desc, hs_semanales=@hsSem, hs_totales=@hsTot WHERE "
                    + "id_materia=@id and id_plan=@idPlan", sqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = mat.ID;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar).Value = mat.Descripcion;
                cmdUpdate.Parameters.Add("@hsSem", SqlDbType.Int).Value = mat.HSSemanales;
                cmdUpdate.Parameters.Add("@hsTot", SqlDbType.Int).Value = mat.HSTotales;
                cmdUpdate.Parameters.Add("@idPlan", SqlDbType.Int).Value = mat.Plan.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into materias(desc_materia,hs_semanales,hs_totales,id_plan) " +
                "values(@desc,@hsSem,@hsTot,@idPlan) " +
                "select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@desc", SqlDbType.VarChar).Value = mat.Descripcion;
                cmdInsert.Parameters.Add("@hsSem", SqlDbType.Int).Value = mat.HSSemanales;
                cmdInsert.Parameters.Add("@hsTot", SqlDbType.Int).Value = mat.HSTotales;
                cmdInsert.Parameters.Add("@idPlan", SqlDbType.Int).Value = mat.Plan.ID;
                mat.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear una nueva materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia mat)
        {
            if (mat.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mat.ID);
            }
            else if (mat.State == BusinessEntity.States.New)
            {
                this.Insert(mat);
            }
            else if (mat.State == BusinessEntity.States.Modified)
            {
                this.Update(mat);
            }
            mat.State = BusinessEntity.States.Unmodified;
        }

        /*public List<Materia> GetMateriasParaInscripcion(int IDPlan, int IDAlumno)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetMateriasParaInscripcion = new SqlCommand("GetMateriasParaInscripcion", sqlConn);
                cmdGetMateriasParaInscripcion.Parameters.Add("@id_plan", SqlDbType.Int).Value = IDPlan;
                cmdGetMateriasParaInscripcion.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drMaterias = cmdGetMateriasParaInscripcion.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.Plan.ID = (int)drMaterias["id_plan"];
                    materias.Add(mat);
                }
            }
            catch (Exception e)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las materias disponibles para el alumno.", e);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }*/
    }
}