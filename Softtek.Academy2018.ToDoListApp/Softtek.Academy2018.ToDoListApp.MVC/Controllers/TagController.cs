using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Softtek.Academy2018.ToDoListApp.WebAPI.Controllers
{
    [RoutePrefix("api/tag")]
    public class TagController : ApiController
    {
        private readonly ItagService _TagService;
        public TagController(ItagService tagService)
        {
            _TagService = tagService;
        }
        [Route("")]
        [HttpPost]
        public IHttpActionResult create([FromBody]TagDTO tagDTO)
        {
            Tag tag = new Tag
            {
                Name=tagDTO.Name
            };
            int id = _TagService.Add(tag);
            if (id <= 0) return BadRequest("Unable To Create tag");
            var payload = new { TagId = id };
            return Ok(payload);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            if (!_TagService.Delete(id))
                return BadRequest("Unable to delete");

            var payload = new
            {
                Message="Tag Deleted",
                Tagid=id
            };
            return Ok(payload);
        }

        [Route("{id:int}/items")]
        [HttpGet]
        public IHttpActionResult GetItems([FromUri] int id)
        {
            int num = _TagService.getItems(id);
            
            var payload = new
            {
                Number_Of_Items_Assigned = num
            };
            return Ok(payload);
        }


    }

    public class TagDTO
    {
        public string Name { get; set; }
    }
}
