using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones c INNER JOIN planes p on c.id_plan = p.id_plan "
                    + "INNER JOIN especialidades e on p.id_especialidad = e.id_especialidad", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision comi = new Comision();
                    comi.ID = (int)drComisiones["id_comision"];
                    comi.Descripcion = (string)drComisiones["desc_comision"];
                    comi.AnioEspecialidad = (int)drComisiones["anio_especialidad"];

                    Plan pla = new Plan();
                    pla.ID = (int)drComisiones["id_plan"];
                    pla.Descripcion = (string)drComisiones["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drComisiones["id_especialidad"];
                    esp.Descripcion = (string)drComisiones["desc_especialidad"];

                    pla.Especialidad = esp;
                    comi.Plan = pla;
                    comisiones.Add(comi);
                }
                drComisiones.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision comi = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones c INNER JOIN planes p on c.id_plan = p.id_plan "
                    + "INNER JOIN especialidades e on p.id_especialidad = e.id_especialidad where id_comision=@id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    comi.ID = (int)drComisiones["id_comision"];
                    comi.Descripcion = (string)drComisiones["desc_comision"];
                    comi.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    Plan pla = new Plan();
                    pla.ID = (int)drComisiones["id_plan"];
                    pla.Descripcion = (string)drComisiones["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drComisiones["id_especialidad"];
                    esp.Descripcion = (string)drComisiones["desc_especialidad"];

                    pla.Especialidad = esp;
                    comi.Plan = pla;
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comi;
        }

        public bool ExisteComision(int idPlan, string desc)
        {
            bool existeComi;
            try
            {
                this.OpenConnection();
                SqlCommand cmdExisteComi = new SqlCommand("select * from comisiones where "
                    +"id_plan=@idPlan and desc_comision=@desc", sqlConn);
                cmdExisteComi.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = desc;
                cmdExisteComi.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
                existeComi = Convert.ToBoolean(cmdExisteComi.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return existeComi;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE comisiones SET desc_comision=@desc, anio_especialidad=@anio WHERE "
                    +"id_comision=@id and id_plan=@idPlan", sqlConn);
                cmdUpdate.CommandType = CommandType.StoredProcedure;

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdUpdate.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdUpdate.Parameters.Add("@anio", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdUpdate.Parameters.Add("@idPlan", SqlDbType.Int).Value = comision.Plan.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into comisiones(desc_comision,anio_especialidad,id_plan) " +
                "values(@desc,@anio,@idPlan) " +
                "select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdInsert.Parameters.Add("@anio", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdInsert.Parameters.Add("@idPlan", SqlDbType.Int).Value = comision.Plan.ID;

                comision.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear una nueva comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}