using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private EspecialidadAdapter especialidadData;

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public EspecialidadAdapter EspecialidadData
        {
            get { return especialidadData; }
            set { especialidadData = value; }
        }

        public Especialidad GetOne(int id)
        {
            return EspecialidadData.GetOne(id);
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public void Save(Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }

        public void Delete(int id)
        {
            EspecialidadData.Delete(id);
        }
    }
}