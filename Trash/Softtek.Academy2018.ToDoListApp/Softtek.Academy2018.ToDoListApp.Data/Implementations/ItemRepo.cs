using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System.Data.Entity;

namespace Softtek.Academy2018.ToDoListApp.Data.Implementations
{
    public class ItemRepo : IItemRepo
    {
        public ICollection<Item> GetAll()
        {
            using (var context = new ToDoListContext())
            {
                ICollection<Item> result = context.Items.ToList();
                return result;
            }
        }

        public int Add(Item item)
        {
            using (var context= new ToDoListContext())
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = null;
                item.IsArchived = false;
                item.StatusId = 1;
                context.Items.Add(item);
                context.SaveChanges();
                return item.Id;
            }
        }

        public bool AsignStat(int item,int stat)
        {
            using (var context= new ToDoListContext())
            {
                Item current = context.Items.Where(x => x.Id == item).FirstOrDefault();
                if (current == null)
                    return false;
                current.StatusId = stat;
                context.SaveChanges();
                return true;

            }
        }

        public bool AsignTag(int ItemId,int TagId)
        {
            using (var context = new ToDoListContext())
            {
                Tag currentTag = context.Tag.SingleOrDefault(x => x.Id == TagId);

                if (currentTag == null) return false;

                Item currentItem = context.Items.SingleOrDefault(x => x.Id == ItemId);

                if (currentItem == null) return false;

                currentItem.Tags.Add(currentTag);

                context.SaveChanges();

                return true;
            }
        }

        public int CountTags(int itemId)
        {
            using (var context= new ToDoListContext())
            {
                Item currentItem = context.Items.Where(x => x.Id == itemId).FirstOrDefault();
                return currentItem.Tags.Count();
            }
        }

        public bool Delete(int Id)
        {
            using (var context = new ToDoListContext())
            {
                Item currentItem = context.Items.AsNoTracking().SingleOrDefault(x => x.Id == Id);

                if (currentItem == null) return false;

                currentItem.IsArchived = true;

                context.Entry(currentItem).State = EntityState.Modified;

                context.SaveChanges();

                return true;
            }
        }

        public Item Get(int Id)
        {
            using (var context = new ToDoListContext())
            {
                Item result;
                result = context.Items.AsNoTracking().Where(x => x.Id==Id).FirstOrDefault();
                return result;
            }
        }

        public ICollection<Item> GetByStatus(int stat)
        {
            using (var context = new ToDoListContext())
            {
                ICollection<Item> result;
                result = context.Items.AsNoTracking().Where(x => x.StatusId == stat).ToList();
                return result;
            }
        }

        public ICollection<Item> GetByTittle(string tittle)
        {
            using (var context = new ToDoListContext())
            {
                ICollection<Item> result;
                result = context.Items.AsNoTracking().Where(x => x.Title.Equals(tittle)).ToList();
                return result;
            }
        }

        public bool Update(Item item)
        {
            using (var context = new ToDoListContext())
            {
                Item currentItem = context.Items.SingleOrDefault(x => x.Id == item.Id);

                if (currentItem == null) return false;

                currentItem.DueDate = item.DueDate;
                currentItem.PriorityId = item.PriorityId;
                currentItem.ModifiedDate = DateTime.Now;

                context.Entry(currentItem).State = EntityState.Modified;

                context.SaveChanges();

                return true;
            }
        }
    }
}
