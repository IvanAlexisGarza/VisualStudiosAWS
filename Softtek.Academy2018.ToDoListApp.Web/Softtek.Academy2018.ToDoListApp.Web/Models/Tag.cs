using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.Models
{
    public class Tag : Entity
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public Tag()
        {
            Items = new HashSet<Item>();
        }
    }
}