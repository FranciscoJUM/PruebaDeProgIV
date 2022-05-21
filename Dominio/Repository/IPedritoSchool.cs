using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos
{
    public interface IPedritoSchoolContext
    {
        DbSet<Estudiante> Estudiantes { get; set; }
        public int SaveChanges();
    }
}
