using DataAccesEF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Configuration
{
    public class MateriaConfiguration : EntityTypeConfiguration<Materia>
    {
        public MateriaConfiguration()
        {
            this.ToTable("Materia");

            this.HasKey(p => p.ClaveMat);
            this.Property(p => p.Descripcion);

            this.HasMany<Alumno>(a => a.Alumnos).WithMany(m => m.Materias)
                .Map(ma =>
                {
                    ma.MapLeftKey("Matricula");
                    ma.MapRightKey("ClaveMateria");
                    ma.ToTable("AlumnosEnMateria");
                });
        }
    }
}
