using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Data.Contracts
{
    public interface IItemRepo
    {
        int Add(Item item);
        bool Update(Item item);
        bool Delete(int Id);
        ICollection<Item> GetByStatus(int stat);
        ICollection<Item> GetByTittle(string tittle);
        ICollection<Item> GetAll();
        bool AsignTag(int ItemId,int TagId);
        int CountTags(int itemId);
        bool AsignStat(int item,int stat);
        Item Get(int Id);


    }
}
