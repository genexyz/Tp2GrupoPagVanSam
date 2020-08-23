using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll(int tipo)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand();
                cmdPersonas.Connection = sqlConn;
                if (tipo != 0)
                {
                    cmdPersonas.CommandText = "select * from personas pe INNER JOIN planes p on p.id_plan=pe.id_plan"
                   + " INNER JOIN especialidades e on e.id_especialidad = p.id_especialidad WHERE tipo_persona=@tipo";
                    cmdPersonas.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                }
                else
                {
                    cmdPersonas.CommandText = "select * from personas pe INNER JOIN planes p on p.id_plan=pe.id_plan"
                   + " INNER JOIN especialidades e on e.id_especialidad = p.id_especialidad";
                }
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona pers = new Persona();
                    pers.ID = (int)drPersonas["id_persona"];
                    pers.Nombre = (string)drPersonas["nombre"];
                    pers.Apellido = (string)drPersonas["apellido"];
                    pers.Email = (string)drPersonas["email"];
                    pers.Direccion = (string)drPersonas["direccion"];
                    pers.Telefono = (string)drPersonas["telefono"];
                    pers.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    pers.Legajo = (int)drPersonas["legajo"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 1:
                            pers.TipoPersona = "No docente";
                            break;
                        case 2:
                            pers.TipoPersona = "Alumno";
                            break;
                        case 3:
                            pers.TipoPersona = "Docente";
                            break;
                    }

                    Plan pla = new Plan();
                    pla.ID = (int)drPersonas["id_plan"];
                    pla.Descripcion = (string)drPersonas["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drPersonas["id_especialidad"];
                    esp.Descripcion = (string)drPersonas["desc_especialidad"];

                    pla.Especialidad = esp;
                    pers.Plan = pla;
                    personas.Add(pers);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public List<Persona> GetDocentesPorPlan(int idPlan)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesPlan = new SqlCommand("select * from personas pe INNER JOIN planes p on p.id_plan=pe.id_plan"
                   + " INNER JOIN especialidades e on e.id_especialidad = p.id_especialidad WHERE id_plan=@id and tipo_persona='3'", sqlConn);
                cmdDocentesPlan.Parameters.Add("@id", SqlDbType.Int).Value = idPlan;
                SqlDataReader drPersonas = cmdDocentesPlan.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona pers = new Persona();
                    pers.ID = (int)drPersonas["id_persona"];
                    pers.Nombre = (string)drPersonas["nombre"];
                    pers.Apellido = (string)drPersonas["apellido"];
                    pers.Email = (string)drPersonas["email"];
                    pers.Direccion = (string)drPersonas["direccion"];
                    pers.Telefono = (string)drPersonas["telefono"];
                    pers.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    pers.Legajo = (int)drPersonas["legajo"];
                    pers.TipoPersona = "Docente";
                    Plan pla = new Plan();
                    pla.ID = (int)drPersonas["id_plan"];
                    pla.Descripcion = (string)drPersonas["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drPersonas["id_especialidad"];
                    esp.Descripcion = (string)drPersonas["desc_especialidad"];

                    pla.Especialidad = esp;
                    pers.Plan = pla;
                    personas.Add(pers);
                }
                drPersonas.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de docentes por Plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona pers = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("select * from personas pe INNER JOIN planes p on p.id_plan=pe.id_plan"
                   + " INNER JOIN especialidades e on e.id_especialidad = p.id_especialidad WHERE id_persona=@id", sqlConn);
                cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersona.ExecuteReader();
                if (drPersonas.Read())
                {
                    pers.ID = (int)drPersonas["id_persona"];
                    pers.Nombre = (string)drPersonas["nombre"];
                    pers.Apellido = (string)drPersonas["apellido"];
                    pers.Email = (string)drPersonas["email"];
                    pers.Direccion = (string)drPersonas["direccion"];
                    pers.Telefono = (string)drPersonas["telefono"];
                    pers.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    pers.Legajo = (int)drPersonas["legajo"];
                    switch ((int)drPersonas["tipo_persona"])
                    {
                        case 1:
                            pers.TipoPersona = "No docente";
                            break;
                        case 2:
                            pers.TipoPersona = "Alumno";
                            break;
                        case 3:
                            pers.TipoPersona = "Docente";
                            break;
                    }
                    Plan pla = new Plan();
                    pla.ID = (int)drPersonas["id_plan"];
                    pla.Descripcion = (string)drPersonas["desc_plan"];

                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drPersonas["id_especialidad"];
                    esp.Descripcion = (string)drPersonas["desc_especialidad"];

                    pla.Especialidad = esp;
                    pers.Plan = pla;
                }

                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return pers;
        }

        public bool ExistePersona(int leg)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select * from personas where legajo=@legajo", sqlConn);
                cmdGetOne.Parameters.Add("@legajo", SqlDbType.Int).Value = leg;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al validar la existencia de la persona", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE personas SET nombre=@nombre, apellido=@apellido, direccion=@direc, email=@email, "
                    + "telefono=@tel, fecha_nac=@fecha, legajo=@legajo, tipo_persona=@tipoP, id_plan=@idPlan WHERE id_persona=@id", sqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar).Value = persona.Apellido;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar).Value = persona.Email;
                cmdUpdate.Parameters.Add("@direc", SqlDbType.VarChar).Value = persona.Direccion;
                cmdUpdate.Parameters.Add("@tel", SqlDbType.VarChar).Value = persona.Telefono;
                cmdUpdate.Parameters.Add("@fecha", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdUpdate.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                switch (persona.TipoPersona)
                {
                    case "No docente":
                        cmdUpdate.Parameters.Add("@tipoP", SqlDbType.Int).Value = 1;
                        break;
                    case "Alumno":
                        cmdUpdate.Parameters.Add("@tipoP", SqlDbType.Int).Value = 2;
                        break;
                    case "Docente":
                        cmdUpdate.Parameters.Add("@tipoP", SqlDbType.Int).Value = 3;
                        break;
                }
                cmdUpdate.Parameters.Add("@idPlan", SqlDbType.Int).Value = persona.Plan.ID;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into personas(nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan) " +
                "values(@nombre,@apellido,@direc,@email,@tel,@fecha,@legajo,@tipoP,@idPlan) " +
                "select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar).Value = persona.Apellido;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar).Value = persona.Email;
                cmdInsert.Parameters.Add("@direc", SqlDbType.VarChar).Value = persona.Direccion;
                cmdInsert.Parameters.Add("@tel", SqlDbType.VarChar).Value = persona.Telefono;
                cmdInsert.Parameters.Add("@fecha", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                switch (persona.TipoPersona)
                {
                    case "No docente":
                        cmdInsert.Parameters.Add("@tipoP", SqlDbType.Int).Value = 1;
                        break;
                    case "Alumno":
                        cmdInsert.Parameters.Add("@tipoP", SqlDbType.Int).Value = 2;
                        break;
                    case "Docente":
                        cmdInsert.Parameters.Add("@tipoP", SqlDbType.Int).Value = 3;
                        break;
                }
                cmdInsert.Parameters.Add("@idPlan", SqlDbType.Int).Value = persona.Plan.ID;
                persona.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear una nueva Persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
