using Softtek.Academy2018.ToDoListApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.Context
{
    public class ToDoListContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Tag> Tag { get; set; }

        public ToDoListContext() : base("ToDoListDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Item>()
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Status>()
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Tag>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);

            base.OnModelCreating(modelBuilder);
        }
    }
}