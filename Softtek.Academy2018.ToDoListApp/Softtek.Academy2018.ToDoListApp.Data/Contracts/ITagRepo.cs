using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Data.Contracts
{
    public interface ITagRepo
    {
        int Add(Tag tag);
        ICollection<Item>getItems(int TagId);
        bool Delete(int Id);
        bool Exist(string tag);
        bool Exist(int tag);
        bool isAttached(int tagId);
    }
}
