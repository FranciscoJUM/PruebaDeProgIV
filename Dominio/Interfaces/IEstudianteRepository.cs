using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public  interface IEstudianteRepository : IRepository<Estudiante>
    {
        decimal CalculateProm(decimal q, decimal w, decimal e, decimal r);
        Estudiante FindById(int id);
        Estudiante FindByCode(string code);
        List<Estudiante> FindByName(string name);
    }
}
