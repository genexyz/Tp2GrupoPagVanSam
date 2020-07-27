using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private ComisionAdapter comisionData;

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public ComisionAdapter ComisionData
        {
            get { return comisionData; }
            set { comisionData = value; }
        }

        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }

        public bool Existe(int idPlan, string desc)
        {
            return ComisionData.ExisteComision(idPlan, desc);
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public void Save(Comision comi)
        {
            ComisionData.Save(comi);
        }

        public void Delete(int ID)
        {
            ComisionData.Delete(ID);
        }

        /*public List<Comision> GetComisionesDisponibles(int IDMateria)
        {
            List<Comision> comisiones = new List<Comision>();
            CursoLogic curlog = new CursoLogic();
            foreach (Curso c in curlog.GetAll())
            {
                if (c.Materia.ID == IDMateria && c.Cupo > 0)
                {
                    comisiones.Add(c.Comision);
                }
            }
            return comisiones;
        }*/
    }
}