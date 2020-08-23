using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private CursoAdapter cursoData;

        public CursoLogic()
        {
            cursoData = new CursoAdapter();
        }

        public CursoAdapter CursoData
        {
            get { return cursoData; }
            set { cursoData = value; }
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }

        public bool Existe(int idMat, int idCom, int anio)
        {
            return cursoData.ExisteCurso(idMat, idCom, anio);
        }

        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }

        public void Save(Curso cur)
        {
            CursoData.Save(cur);
        }

        /*public List<Curso> GetCursosDocente(int IDDocente)
        {
            return CursoData.GetCursosDocente(IDDocente);
        }*/
    }
}