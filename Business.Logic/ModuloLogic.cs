using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        private ModuloAdapter moduloData;

        public ModuloLogic()
        {
            moduloData = new ModuloAdapter();
        }

        public ModuloAdapter ModuloData
        {
            get { return moduloData; }
            set { moduloData = value; }
        }

        public Modulo GetOne(string d)
        {
            return ModuloData.GetOne(d);
        }

        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }
    }
}
