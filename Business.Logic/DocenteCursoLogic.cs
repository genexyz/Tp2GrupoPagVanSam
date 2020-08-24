using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private DocenteCursoAdapter docenteCursoData;

        public DocenteCursoLogic()
        {
            docenteCursoData = new DocenteCursoAdapter();
        }

        public DocenteCursoAdapter DocenteCursoData
        {
            get { return docenteCursoData; }
            set { docenteCursoData = value; }
        }

        public DocenteCurso GetOne(int ID)
        {
            return docenteCursoData.GetOne(ID);
        }

        public bool Existe(int id_cur, int id_doc, string cargo)
        {
            return docenteCursoData.ExisteDocenteCurso(id_cur, id_doc, cargo);
        }

        public List<DocenteCurso> GetAll()
        {
            return docenteCursoData.GetAll();
        }

        public void Save(DocenteCurso dc)
        {
            docenteCursoData.Save(dc);
        }

        public void Delete(int ID)
        {
            docenteCursoData.Delete(ID);
        }
    }
}
