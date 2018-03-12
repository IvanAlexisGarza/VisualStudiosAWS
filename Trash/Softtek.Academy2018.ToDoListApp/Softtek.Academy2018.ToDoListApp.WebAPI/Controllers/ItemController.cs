using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using Softtek.Academy2018.ToDoListApp.Business.Implementations;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using Softtek.Academy2018.ToDoListApp.WebAPI.Models;

namespace Softtek.Academy2018.ToDoListApp.WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class ItemController : ApiController
    {
        private readonly IItemService _ItemService;
        public ItemController(IItemService userService)
        {
            _ItemService = userService;
        }

        [Route("item")]
        [HttpPost]
        public IHttpActionResult create([FromBody]ItemDTO itemDTO)
        {
            Item item = new Item
            {
                Title = itemDTO.Title,
                Description = itemDTO.Description,
                DueDate = itemDTO.DueDate,
                PriorityId = itemDTO.PriorityId
            };
            int id = _ItemService.Add(item);
            if (id <= 0) return BadRequest("Unable To Create Item");
            var payload = new { ItemId = id };
            return Ok(payload);
        }

        [Route("item/{itemId:int}/tag/{tagId:int}")]
        [HttpPut]
        public IHttpActionResult AddTag([FromUri]int itemId, [FromUri] int tagId)
        {
            bool asignacion = _ItemService.AsignTag(itemId, tagId);
            if (!asignacion)
                return BadRequest("Unable to asign the tag");
            var payload = new
            {
                item = itemId,
                tag = tagId
            };
            return Ok(payload);
        }

        [Route("item/{itemId:int}/status/{statId:int}")]
        [HttpPut]
        public IHttpActionResult AddStatus([FromUri]int itemId, [FromUri] int statId)
        {
            bool asignacion = _ItemService.AsignStat(itemId, statId);
            if (!asignacion)
                return BadRequest("Unable to asign the stat");
            var payload = new
            {
                item = itemId,
                Status = statId
            };
            return Ok(payload);
        }

        [Route("item/{itemId:int}/Duedate")]
        [HttpPut]
        public IHttpActionResult AssignDueDate([FromUri]int itemId, [FromBody]DateDto Due)
        {
            Item item = _ItemService.Get(itemId);
            item.DueDate = Due.DueDate;
            if (!_ItemService.Update(item))
                return BadRequest("Unable to assign Due Date");
            var payload = new
            {
                newDueDate = Due.DueDate
            };
            return Ok(payload);
        }

        [Route("item/{itemId:int}/priority/{prio:int}")]
        [HttpPut]
        public IHttpActionResult Assignpriority([FromUri]int itemId, [FromUri]int prio)
        {
            Item item = _ItemService.Get(itemId);
            item.PriorityId = prio;
            if (!_ItemService.Update(item))
                return BadRequest("Unable to assign Priority");
            var payload = new
            {
                newPriority = prio
            };
            return Ok(payload);
        }

        [Route("items/status/{statId:int}")]
        [HttpGet]
        public IHttpActionResult GetByStatus([FromUri] int statId)
        {
            ICollection<Item> resultado = _ItemService.GetByStatus(statId);

            if (resultado == null)
                return BadRequest("No items match the search parameter");
            if (resultado.Count == 0)
                return BadRequest("No items match the search parameter");
            ICollection<ItemDTO> salida = new List<ItemDTO>();
            foreach (Item item in resultado)
            {
                salida.Add(new ItemDTO
                {
                    Title = item.Title,
                    Description = item.Description,
                    DueDate = item.DueDate,
                    PriorityId = item.PriorityId
                });
            }

            var payload = new
            {
                resultados = salida
            };
            return Ok(payload);
        }

        [Route("items/status/all")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ICollection<Item> result = _ItemService.GetAll();
            if (result == null)  return BadRequest("No items match the search parameter");
            if (result.Count == 0) return BadRequest("No items match the search parameter");

            ICollection<ItemDTO> itemDTOList = new List<ItemDTO>();

            foreach (Item item in result)
            {
                itemDTOList.Add(new ItemDTO
                {
                    Title = item.Title,
                    Description = item.Description,
                    DueDate = item.DueDate,
                    PriorityId = item.PriorityId
                });
            }

            var payload = new
            {
                resultados = itemDTOList
            };
            return Ok(payload);
        }

        [Route("items/Id/{Id:int}")]
        [HttpGet]
        public IHttpActionResult GetById([FromUri] int Id)
        {
            Item resultado = _ItemService.Get(Id);
            if (resultado == null)
                return BadRequest("No items match the search parameter");
            ItemDTO salida = new ItemDTO();
            salida = new ItemDTO
            {
                Title = resultado.Title,
                Description = resultado.Description,
                DueDate = resultado.DueDate,
                PriorityId = resultado.PriorityId
            };
            var payload = new
            {
                resultado = salida
            };
            return Ok(payload);
        }

        [Route("items/title")]
        [HttpGet]
        public IHttpActionResult GetByTittle([FromBody] NameDTO tittle)
        {
            ICollection<Item> resultado = _ItemService.GetByTittle(tittle.Title);

            if (resultado == null)
                return BadRequest("No items match the search parameter");
            if (resultado.Count == 0)
                return BadRequest("No items match the search parameter");
            ICollection<ItemDTO> salida = new List<ItemDTO>();
            foreach (Item item in resultado)
            {
                salida.Add(new ItemDTO
                {
                    Title = item.Title,
                    Description = item.Description,
                    DueDate = item.DueDate,
                    PriorityId = item.PriorityId
                });
            }

            var payload = new
            {
                resultados = salida
            };
            return Ok(payload);
        }

        [Route("item/{itemId:int}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int itemId)
        {
            if (!_ItemService.Delete(itemId))
                return BadRequest("Unable to delete subject");

            var payload = new
            {
                ItemId = itemId,
                message = "Target (soft)Deleted"

            };
            return Ok(payload);
        }


    }

}
