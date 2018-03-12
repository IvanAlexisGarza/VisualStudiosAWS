using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Business.Contracts
{
    public interface IItemService
    {
        int Add(Item item);
        bool Update(Item item);
        bool Delete(int Id);
        ICollection<Item> GetByStatus(int stat);
        ICollection<Item> GetByTittle(string tittle);
        bool AsignTag(int ItemId, int TagId);
        bool AsignStat(int ItemId, int stat);
        Item Get(int Id);
        ICollection<Item> GetAll();
    }
}
