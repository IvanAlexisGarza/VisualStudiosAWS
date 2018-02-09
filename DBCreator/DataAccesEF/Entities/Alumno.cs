using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Entities
{
    [Table("Alumno")]
    public class Alumno
    {
        [Key]
        [Column("Matricula", Order = 1)]
        public int Matricula { get; set; }

        [Column("Nombres", Order = 2, TypeName = "VarChar")]
        [MaxLength(50)]
        public string Nombres { get; set; }

        [Column("ApellidoPaterno", Order = 3, TypeName = "VarChar")]
        [MaxLength(20)]
        public string ApellidoPaterno { get; set; }

        [Column("ApellidoMaterno", Order = 4, TypeName = "VarChar")]
        [MaxLength(20)]
        public string ApellidoMaterno { get; set; }

        [Column("CorreoUABC", Order = 5, TypeName = "nVarChar")]
        [MaxLength(50)]
        public string CorreoUABC { get; set; }

        [Column("Contrasena", Order = 6, TypeName = "nVarChar")]
        [MaxLength(16)]
        public string Contrasena { get; set; }

        public virtual ICollection<Materia> Materias { get; set; }
    }
}
