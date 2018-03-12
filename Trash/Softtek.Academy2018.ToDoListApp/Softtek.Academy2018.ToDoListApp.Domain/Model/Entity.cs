﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Domain.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
