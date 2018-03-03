using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.WebAPI.Models
{
    public class ItemDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int PriorityId { get; set; }
    }
    public class DateDto
    {
        public DateTime DueDate { get; set; }
    }
    public class NameDTO
    {
        public string Title { get; set; }
    }
}