﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        private AlumnoInscripcionAdapter _InscripcionData;

        public AlumnoInscripcionLogic()
        {
            _InscripcionData = new AlumnoInscripcionAdapter();
        }

        public AlumnoInscripcionAdapter InscripcionData
        {
            get
            {
                return _InscripcionData;
            }
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            return _InscripcionData.GetOne(ID);
        }

        public bool Existe(int id_alu, int id_cur)
        {
            return _InscripcionData.Existe(id_alu, id_cur);
        }

        public List<AlumnoInscripcion> GetAll(int IDAlumno)
        {
            return _InscripcionData.GetAll(IDAlumno);
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return _InscripcionData.GetAll();
        }

        public void Save(AlumnoInscripcion ins)
        {
            _InscripcionData.Save(ins);
        }

        public void Delete(int ID)
        {
            _InscripcionData.Delete(ID);
        }
    }
}