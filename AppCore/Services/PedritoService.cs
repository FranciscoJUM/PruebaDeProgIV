using AppCore.Interface;
using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class PedritoService : IPedritoService
    {
        IEstudianteRepository estudiante;

        public PedritoService(IEstudianteRepository estudiante)
        {
            this.estudiante = estudiante;
        }


        public decimal CalculateProm(decimal q, decimal w, decimal e, decimal r)
        {
            return estudiante.CalculateProm(q, w, e, r);
        }

        public void Create(Estudiante t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("El estudiante no puede ser null.");
            }

            estudiante.Create(t);
        }

        public bool Delete(Estudiante t)
        {

            if (t == null)
            {
                throw new ArgumentNullException("El Estudiante no puede ser null.");
            }

            return estudiante.Delete(t);
        }

        public Estudiante FindByCode(string code)
        {

            if (code == null)
            {
                throw new ArgumentNullException("El estudiante no puede ser null.");
            }

            return estudiante.FindByCode(code);
        }

        public Estudiante FindById(int id)
        {
            return estudiante.FindById(id);
        }

        public List<Estudiante> FindByName(string name)
        {
           return estudiante.FindByName(name);
        }

        public List<Estudiante> GetAll()
        {
            return estudiante.GetAll();
        }

        public int Update(Estudiante t)
        {
           return estudiante.Update(t);
        }
    }
}
