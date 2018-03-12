using Softtek.Academy2018.ToDoListApp.Web.Context;
using Softtek.Academy2018.ToDoListApp.Web.Models;
using Softtek.Academy2018.ToDoListApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using Softtek.Academy2018.ToDoListApp.Web.Client;

namespace Softtek.Academy2018.ToDoListApp.Web.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoListContext _context;
        //public ItemClient ItemClient = new ItemClient();

        public ItemsController()
        {
            _context = new ToDoListContext();
        }

        // Tried generating generic class for HTTPClient but it didin't work and i ran out of time 
        public ActionResult Index()
        {
            var Items = _context.Items.ToList();
            ViewData["Header"] = "List of Items";
            ViewData["EmptyList"] = "You don't have any items boi !";

            List<Item> itemList = new List<Item>();
            itemList = _context.Items.ToList();
            ViewData["ItemList"] = itemList;
            return View(Items);
        }

        public ActionResult New()
        {
            var viewModel = new ItemFormViewModel();

            viewModel.Status = _context.Status.ToList();
            viewModel.Tags = _context.Tag.ToList();

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var Item = _context.Items.Where(x => x.Id == id).FirstOrDefault();

            if (Item == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ItemFormViewModel(Item);

            viewModel.Status = _context.Status.ToList();
            viewModel.Tags = _context.Tag.ToList();

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Save(Item item)
        {
            using (var client = new HttpClient())
            {
                Uri uri = new Uri("http://localhost:2048/api/");
                client.BaseAddress = uri;

                if (!ModelState.IsValid)
                {
                    var viewModel = new ItemFormViewModel(item)
                    {
                        Status = _context.Status.ToList(),
                        Tags = _context.Tag.ToList()
                    };

                    return View("New", viewModel);
                }

                var itemInDb = _context.Items.Where(x => x.Id == item.Id).FirstOrDefault();

                if (itemInDb == null)
                {
                    item.CreatedDate = DateTime.Now;
                    _context.Items.Add(item);
                }
                else
                {
                    itemInDb.Id = item.Id;
                    itemInDb.Title = item.Title;
                    itemInDb.Description = item.Description;
                    itemInDb.DueDate = item.DueDate;
                    itemInDb.IsArchived = item.IsArchived;
                    itemInDb.StatusId = item.StatusId;
                    itemInDb.PriorityId = item.PriorityId;
                    itemInDb.ModifiedDate = DateTime.Now;
                }

                var postTask = client.PostAsJsonAsync<Item>("item", item);
                postTask.Wait();

                // _context.SaveChanges(); 

                return RedirectToAction("Index", "Items");
            }
        }

        public ActionResult Details(int id)
        {
            //var itemInDb = _context.Items.Include(c => c.Status).Where(x => x.Id == id).FirstOrDefault();

            var itemInDb = _context.Items.Where(x => x.Id == id).FirstOrDefault();

            if (itemInDb == null)
            {
                return HttpNotFound();
            }

            return View(itemInDb);

        }


        [Route("Items/delete/{id}")]
        public ActionResult Delete(int id)
        {
            var itemInDb = _context.Items.SingleOrDefault(x => x.Id == id);

            if (itemInDb == null)
            {
                return HttpNotFound();
            }

            _context.Items.Remove(itemInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Items");
        }


    }
}