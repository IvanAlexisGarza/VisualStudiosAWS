using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using Softtek.Academy2018.ToDoListApp.Data.Contracts;

namespace Softtek.Academy2018.ToDoListApp.Business.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IItemRepo itemRepo;
        public ItemService(IItemRepo _itemRepo)
        {
            itemRepo = _itemRepo;
        }

        public int Add(Item item)
        {
            if (DateTime.Compare(item.DueDate, DateTime.Now) < 0)
                return 0;

            return itemRepo.Add(item);
        }

        public bool AsignStat(int ItemId, int stat)
        {
            return itemRepo.AsignStat(ItemId, stat);
        }

        public bool AsignTag(int ItemId, int TagId)
        {
            if (itemRepo.CountTags(ItemId) > 9)
                return false;

            return itemRepo.AsignTag(ItemId, TagId);
        }

        public bool Delete(int Id)
        {
            return itemRepo.Delete(Id);
        }

        public Item Get(int Id)
        {
            return itemRepo.Get(Id);
        }

        public ICollection<Item> GetAll()
        {
            return itemRepo.GetAll();
        }

        public ICollection<Item> GetByStatus(int stat)
        {
            return itemRepo.GetByStatus(stat);
        }

        public ICollection<Item> GetByTittle(string tittle)
        {
            return itemRepo.GetByTittle(tittle);
        }

        public bool Update(Item item)
        {
            if (DateTime.Compare(item.DueDate, DateTime.Now) < 0)
                return false;

            return itemRepo.Update(item);
        }
    }
}
