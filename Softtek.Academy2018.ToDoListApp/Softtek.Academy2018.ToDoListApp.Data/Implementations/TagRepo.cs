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
    public class TagRepo : ITagRepo
    {
        public int Add(Tag tag)
        {
            using (var context = new ToDoListContext())
            {
                tag.CreatedDate = DateTime.Now;
                tag.ModifiedDate = null;
                tag.IsActive = true;
                context.Tag.Add(tag);
                context.SaveChanges();
                return tag.Id;
            }
        }

        public bool Delete(int Id)
        {
            using (var context = new ToDoListContext())
            {
                Tag currentTag = context.Tag.AsNoTracking().SingleOrDefault(x => x.Id == Id);

                if (currentTag == null) return false;

                if (currentTag.IsActive == false) return false;

                currentTag.IsActive = false;

                context.Entry(currentTag).State = EntityState.Modified;

                context.SaveChanges();

                return true;
            }
        }

        public bool Exist(string tag)
        {
            using (var context= new ToDoListContext())
            {
                if (context.Tag.Where(t => t.Name.Equals(tag)&&t.IsActive==true).FirstOrDefault() != null)
                    return true;
                return false;
            }
        }

        public bool Exist(int tag)
        {
            using (var context = new ToDoListContext())
            { 
            if (context.Tag.Where(t => t.Id==tag && t.IsActive == true).FirstOrDefault() != null)
                return true;
            return false;
            }
        }

        public ICollection<Item> getItems(int TagId)
        {
            using (var context = new ToDoListContext())
            {
                Tag currentTag = context.Tag.SingleOrDefault(x => x.Id == TagId);
                if (currentTag == null) return null;
                return currentTag.Items;
            }
        }

        public bool isAttached(int tagId)
        {
            using (var context = new ToDoListContext())
            {
                ICollection<Item> OMG = context.Items.Where(x => x.IsArchived == false).ToList();
                foreach(Item i in OMG)
                {
                    foreach (Tag t in i.Tags)
                    {
                        if (t.Id == tagId)
                            return true;
                    }
                }
                return false;
                    
            }
        }
    }
}
