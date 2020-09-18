using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * from usuarios u INNER JOIN personas p on u.id_persona=p.id_persona "
                    + "INNER JOIN planes pl on pl.id_plan=p.id_plan", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];

                    Persona per = new Persona();
                    per.ID = (int)drUsuarios["id_persona"];
                    per.Nombre = (string)drUsuarios["nombre"];
                    per.Apellido = (string)drUsuarios["apellido"];
                    per.Email = (string)drUsuarios["email"];
                    per.Direccion = (string)drUsuarios["direccion"];
                    per.Telefono = (string)drUsuarios["telefono"];
                    per.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    per.Legajo = (int)drUsuarios["legajo"];
                    switch ((int)drUsuarios["tipo_persona"])
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
                    pla.ID = (int)drUsuarios["id_plan"];
                    per.Plan = pla;
                    usr.Persona = per;
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * from usuarios u INNER JOIN personas p on u.id_persona=p.id_persona "
                    + "INNER JOIN planes pl on pl.id_plan=p.id_plan where id_usuario=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];

                    Persona per = new Persona();
                    per.ID = (int)drUsuarios["id_persona"];
                    per.Nombre = (string)drUsuarios["nombre"];
                    per.Apellido = (string)drUsuarios["apellido"];
                    per.Email = (string)drUsuarios["email"];
                    per.Direccion = (string)drUsuarios["direccion"];
                    per.Telefono = (string)drUsuarios["telefono"];
                    per.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    per.Legajo = (int)drUsuarios["legajo"];
                    switch ((int)drUsuarios["tipo_persona"])
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
                    pla.ID = (int)drUsuarios["id_plan"];
                    per.Plan = pla;
                    usr.Persona = per;
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public bool ExisteUsuario(string nomUsu)
        {
            bool existe;
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("select * from usuarios where nombre_usuario=@usuario", sqlConn);
                cmdGetOne.Parameters.Add("@usuario", SqlDbType.VarChar).Value = nomUsu;
                existe = Convert.ToBoolean(cmdGetOne.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al validar que no exista este Usuario", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                "UPDATE usuarios SET nombre_usuario=@nombreUsuario, clave=@clave, " +
                "habilitado=@habilitado, id_persona=@idPersona " +
                "WHERE id_usuario=@id", sqlConn);
                
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdUpdate.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                cmdUpdate.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                cmdUpdate.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdUpdate.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuario.Persona.ID;
                cmdUpdate.ExecuteNonQuery();

                ModuloUsuarioAdapter muadapter = new ModuloUsuarioAdapter();
                foreach (ModuloUsuario mu in usuario.ModulosUsuarios)
                {
                    mu.State = BusinessEntity.States.Modified;
                    muadapter.Save(mu);
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                "insert into usuarios(nombre_usuario,clave,habilitado,id_persona,nombre,apellido,email) " +
                "values(@nombreUsuario,@clave,@habilitado,@idPersona,@nombre,@apellido,@email) " +
                "select @@identity", sqlConn);
                
                cmdInsert.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                cmdInsert.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                cmdInsert.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdInsert.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuario.Persona.ID;
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Persona.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar).Value = usuario.Persona.Apellido;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Persona.Email;
                usuario.ID = Convert.ToInt32(cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        public Usuario GetUsuarioForLogin(string user, string pass)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand GetUsuarioForLogin = new SqlCommand("Select * from usuarios u INNER JOIN personas p on u.id_persona=p.id_persona "
                    + "INNER JOIN planes pl on pl.id_plan=p.id_plan INNER JOIN especialidades e on pl.id_especialidad=e.id_especialidad where nombre_usuario=@user and clave=@pass", sqlConn);
                GetUsuarioForLogin.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                GetUsuarioForLogin.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                SqlDataReader drUsuarios = GetUsuarioForLogin.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];

                    Persona per = new Persona();
                    per.ID = (int)drUsuarios["id_persona"];
                    per.Nombre = (string)drUsuarios["nombre"];
                    per.Apellido = (string)drUsuarios["apellido"];
                    per.Email = (string)drUsuarios["email"];
                    per.Direccion = (string)drUsuarios["direccion"];
                    per.Telefono = (string)drUsuarios["telefono"];
                    per.FechaNacimiento = (DateTime)drUsuarios["fecha_nac"];
                    per.Legajo = (int)drUsuarios["legajo"];
                    switch ((int)drUsuarios["tipo_persona"])
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
                    pla.ID = (int)drUsuarios["id_plan"];
                    pla.Descripcion = (string)drUsuarios["desc_plan"];
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drUsuarios["id_especialidad"];
                    esp.Descripcion = (string)drUsuarios["desc_especialidad"];
                    pla.Especialidad = esp;
                    per.Plan = pla;
                    usr.Persona = per;
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al recuperar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
    }
}

