using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        private ModuloUsuarioAdapter moduloUsuarioData;

        public ModuloUsuarioLogic()
        {
            moduloUsuarioData = new ModuloUsuarioAdapter();
        }

        public ModuloUsuarioAdapter ModuloUsuarioData
        {
            get { return moduloUsuarioData; }
        }

        public List<ModuloUsuario> GetAll(int id)
        {
            return ModuloUsuarioData.GetAll(id);
        }

        public List<ModuloUsuario> GetPermisos(int id)
        {
            return ModuloUsuarioData.GetPermisos(id);
        }

        public ModuloUsuario GetOne(int ID)
        {
            return moduloUsuarioData.GetOne(ID);
        }

        public void Save(ModuloUsuario mu)
        {
            ModuloUsuarioData.Save(mu);
        }
    }
}
