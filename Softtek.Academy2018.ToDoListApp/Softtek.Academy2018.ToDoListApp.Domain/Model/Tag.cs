using System.Collections.Generic;


namespace Softtek.Academy2018.ToDoListApp.Domain.Model
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
