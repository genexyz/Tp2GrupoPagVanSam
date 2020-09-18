using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll(int idUsuario)
        {
            List<ModuloUsuario> modulosusuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulosUsuarios = new SqlCommand("select * from modulos_usuarios mu inner join modulos m on m.id_modulo=mu.id_modulo" +
                    " and mu.id_usuario=@id", sqlConn);
                cmdModulosUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                SqlDataReader drModulosUsuarios = cmdModulosUsuarios.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modusu = new ModuloUsuario();
                    modusu.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modusu.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modusu.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modusu.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modusu.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modusu.PermiteConsulta = (bool)drModulosUsuarios["consulta"];

                    Modulo mod = new Modulo();
                    mod.ID = (int)drModulosUsuarios["id_modulo"];
                    mod.Descripcion = (string)drModulosUsuarios["desc_modulo"];
                    modusu.Modulo = mod;
                    modulosusuarios.Add(modusu);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al recuperar datos de los permisos. (getAll)", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosusuarios;
        }

        public List<ModuloUsuario> GetPermisos(int idUsuario)
        {
            List<ModuloUsuario> modulosusuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPermisosModulosUsuarios = new SqlCommand("select * from modulos_usuarios mu " +
                    "inner join modulos m on mu.id_modulo=m.id_modulo " +
                    "WHERE mu.id_usuario=@id", sqlConn);
                cmdPermisosModulosUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                SqlDataReader drModulosUsuarios = cmdPermisosModulosUsuarios.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modusu = new ModuloUsuario();
                    modusu.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modusu.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modusu.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modusu.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modusu.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modusu.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                    Modulo mod = new Modulo();
                    mod.ID = (int)drModulosUsuarios["id_modulo"];
                    mod.Descripcion = (string)drModulosUsuarios["desc_modulo"];
                    modusu.Modulo = mod;
                    modulosusuarios.Add(modusu);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al recuperar datos de los permisos. (getPermisos)", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosusuarios;
        }

        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario modusu = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModuloUsuario = new SqlCommand("select * from modulos_usuarios mu inner join " +
                    "modulos m on mu.id_modulo=m.id_modulo" +
                    "WHERE mu.id_modulo_usuario=@id", sqlConn);
                cmdModuloUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulosUsuarios = cmdModuloUsuario.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    modusu.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modusu.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modusu.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modusu.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modusu.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modusu.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                    Modulo mod = new Modulo();
                    mod.ID = (int)drModulosUsuarios["id_modulo"];
                    modusu.Modulo = mod;
                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al recuperar datos del Modulo Usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modusu;
        }

        protected void Update(ModuloUsuario modusu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE modulos_usuarios SET id_modulo=@idModulo, id_usuario=@idUsuario, " +
                    "alta=@alta, baja=@baja, modificacion=@modif, consulta=@cons WHERE id_modulo_usuario=@id", sqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = modusu.ID;
                cmdUpdate.Parameters.Add("@idModulo", SqlDbType.Int).Value = modusu.Modulo.ID;
                cmdUpdate.Parameters.Add("@idUsuario", SqlDbType.Int).Value = modusu.IdUsuario;
                cmdUpdate.Parameters.Add("@alta", SqlDbType.Bit).Value = modusu.PermiteAlta;
                cmdUpdate.Parameters.Add("@baja", SqlDbType.Bit).Value = modusu.PermiteBaja;
                cmdUpdate.Parameters.Add("@modif", SqlDbType.Bit).Value = modusu.PermiteModificacion;
                cmdUpdate.Parameters.Add("@cons", SqlDbType.Bit).Value = modusu.PermiteConsulta;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al modificar datos del modulo del usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(ModuloUsuario modusu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("" +
                  "insert into modulos_usuarios(id_modulo, id_usuario, alta, baja, modificacion, consulta) " +
                  "values(@idModulo,@idUsuario,@alta,@baja,@modif,@cons) " +
                  "select @@identity", sqlConn);

                cmdInsert.Parameters.Add("@idModulo", SqlDbType.Int).Value = modusu.Modulo.ID;
                cmdInsert.Parameters.Add("@idUsuario", SqlDbType.Int).Value = modusu.IdUsuario;
                cmdInsert.Parameters.Add("@alta", SqlDbType.Bit).Value = modusu.PermiteAlta;
                cmdInsert.Parameters.Add("@baja", SqlDbType.Bit).Value = modusu.PermiteBaja;
                cmdInsert.Parameters.Add("@modif", SqlDbType.Bit).Value = modusu.PermiteModificacion;
                cmdInsert.Parameters.Add("@cons", SqlDbType.Bit).Value = modusu.PermiteConsulta;
                modusu.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear una permiso.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete modulos_usuarios where id_modulo_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = 
                    new Exception("Error al eliminar el permiso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario modusu)
        {
            if (modusu.State == BusinessEntity.States.New)
            {
                this.Insert(modusu);
            }
            else if (modusu.State == BusinessEntity.States.Modified)
            {
                this.Update(modusu);
            }
            modusu.State = BusinessEntity.States.Unmodified;
        }
    }
}
