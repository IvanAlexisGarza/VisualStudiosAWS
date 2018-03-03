using Softtek.Academy2018.ToDoListApp.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.ViewModels
{
    public class ItemFormViewModel
    {
        public ItemFormViewModel()
        {
            Id = 0;
            Status = new HashSet<Status>();
        }

        public ItemFormViewModel(Item item)
        {
            Id = item.Id;
            Title = item.Title;
            Description = item.Description;
            DueDate = item.DueDate;
            IsArchived = item.IsArchived;
            StatusId = item.StatusId;
            PriorityId = item.PriorityId;
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        [Display(Name = "Archived")]
        public bool IsArchived { get; set; }

        [Display(Name = "Current Status")]
        public int StatusId { get; set; }

        public virtual ICollection<Status> Status { get; set; }

        [Display(Name = "Current Priority")]
        public int PriorityId { get; set; }

        [Display(Name = "Current Tag")]
        public int TagId { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}