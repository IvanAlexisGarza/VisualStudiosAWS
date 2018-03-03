using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccesEF.Entities
{
    [Table("Materia")]
    public class Materia
    {
        [Column("CalveMat",Order =1,TypeName = "int")]
        public int ClaveMat { get; set; }

        [Column("Descripcion", Order =2, TypeName ="VarChar")]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
