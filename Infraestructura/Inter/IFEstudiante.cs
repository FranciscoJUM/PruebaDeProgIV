using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Inter
{
    public class IFEstudiante : IEstudianteRepository
    {
        public IPredritoDBContext pedro;

        public IFEstudiante(IPredritoDBContext pedro)
        {
            this.pedro = pedro;
        }
        public decimal CalculateProm(decimal q, decimal w, decimal e, decimal r)
        {
            decimal suma = (q + w + e + r);
            decimal prom = (suma / 4);
            return prom;
        }

        public void Create(Estudiante t)
        {
            try
            {
                pedro.estudiantes.Add(t);
                pedro.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Estudiante t)
        {

            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto Empleado no puede ser null.");
                }

                Estudiante asset = FindById(t.Id);
                if (asset == null)
                {
                    throw new Exception($"El objeto con id {t.Id} no existe.");
                }

                pedro.estudiantes.Remove(asset);
                int result = pedro.SaveChanges();

                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Estudiante FindByCode(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception($"El parametro code {code} no tiene el formato correcto.");
                }

                return pedro.estudiantes.FirstOrDefault(x => x.Carnet.Equals(code));
            }
            catch
            {
                throw;
            }

        }

        public Estudiante FindById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception($"El id {id} no puede ser menor o igual a cero.");
                }

                return pedro.estudiantes.FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                throw;
            }

        }

        public List<Estudiante> FindByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception($"El parametro name '{name}' no tiene el formato correcto.");
                }

                return pedro.estudiantes
                                        .Where(x => x.Nombres.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                                        .ToList();
            }
            catch
            {
                throw;
            }

        }

        public List<Estudiante> GetAll()
        {
            return pedro.estudiantes.ToList();
        }

        public int Update(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto asset no puede ser null.");
                }

                Estudiante asset = FindById(t.Id);
                if (asset == null)
                {
                    throw new Exception($"El objeto asset con id {t.Id} no existe.");
                }

                asset.Nombres = t.Nombres;
                asset.Apellidos = t.Apellidos;
                asset.Carnet = t.Carnet;
                asset.Phone = t.Phone;
                asset.Direccion = t.Direccion;
                asset.Correo = t.Correo;
                asset.Matematica = t.Matematica;
                asset.Contabilidad = t.Contabilidad;
                asset.Programacion = t.Programacion;
                asset.Estadistica = t.Estadistica;

                pedro.estudiantes.Update(asset);
                return pedro.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}

