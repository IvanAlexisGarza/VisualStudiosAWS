using DataAccesEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF
{
    public class DemoContext : Context
    {
        public DemoContext()
        {

        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }



    }

    public class DbSet<T>
    {
    }
}
