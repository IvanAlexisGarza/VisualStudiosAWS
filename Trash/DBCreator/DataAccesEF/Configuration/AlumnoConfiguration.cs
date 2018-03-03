using DataAccesEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace DataAccesEF.Configuration
{
    public class AlumnoConfiguration : EntityTypeConfiguration<Alumno>
    {
        public  AlumnoConfiguration()
        {
		    this.ToTable("Alumno");

            this.HasKey(p => p.Matricula);
            this.Property(p => p.Nombres);
            this.Property(p => p.ApellidoPaterno);
            this.Property(p => p.ApellidoMaterno);
            this.Property(p => p.CorreoUABC);
            this.Property(p => p.Contrasena);
        }
    }
}
