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
    public class TagService : ItagService
    { 
        private readonly ITagRepo _tagrepo;
        public TagService(ITagRepo tagrepo)
        {
            _tagrepo = tagrepo;
        }

        public int Add(Tag tag)
        {
            if (_tagrepo.Exist(tag.Name))
                return 0;
            return _tagrepo.Add(tag);
        }

        public bool Delete(int Id)
        {
            if (_tagrepo.isAttached(Id))
                return false;
            return _tagrepo.Delete(Id);
        }

        public int getItems(int TagId)
        {
            if (_tagrepo.getItems(TagId) == null)
                return 0;
            if (!_tagrepo.Exist(TagId))
                return 0;

            return _tagrepo.getItems(TagId).Count();
        }
    }
}
