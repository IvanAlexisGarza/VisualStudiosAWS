using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Business.Contracts
{
    public interface ItagService
    {
        int Add(Tag tag);
        int getItems(int TagId);
        bool Delete(int Id);
    }
}
