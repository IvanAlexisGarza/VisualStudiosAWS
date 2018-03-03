using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}