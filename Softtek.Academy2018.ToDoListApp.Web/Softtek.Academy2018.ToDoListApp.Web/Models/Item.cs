﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.Models
{
    public class Item : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsArchived { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        public int PriorityId { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Item()
        {
            Tags = new HashSet<Tag>();
        }
    }
}