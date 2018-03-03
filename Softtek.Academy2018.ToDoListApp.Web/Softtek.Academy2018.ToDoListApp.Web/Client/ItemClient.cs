//using Newtonsoft.Json;
//using Softtek.Academy2018.ToDoListApp.Web.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Web;



//It Kinda Worked but ran out of time :(



//namespace Softtek.Academy2018.ToDoListApp.Web.Client
//{
//    public class ItemClient
//    {
//        private readonly Uri uri = new Uri("http://localhost:2048/api/");
//        private readonly MediaTypeWithQualityHeaderValue mediaType = new MediaTypeWithQualityHeaderValue("application/json");


//        public async Task<ICollection<Item>> GetAll()
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = uri;
//                client.DefaultRequestHeaders.Accept.Clear();
//                client.DefaultRequestHeaders.Accept.Add(mediaType);


//                var response = await client.GetAsync("items/status/all/");

//                string content = await response.Content.ReadAsStringAsync();

//                if (!response.IsSuccessStatusCode)
//                {
//                    return null;
//                }

//                var users = JsonConvert.DeserializeObject<ICollection<Item>>(content);

//                return users;
//            }
//        }


//        public async Task<Item> GetById(int id)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = uri;
//                client.DefaultRequestHeaders.Accept.Clear();
//                client.DefaultRequestHeaders.Accept.Add(mediaType);

//                var response = await client.GetAsync("user/" + id);

//                string content = await response.Content.ReadAsStringAsync();
//                if (!response.IsSuccessStatusCode)
//                {
//                    return null;
//                }

//                var user = JsonConvert.DeserializeObject<Item>(content);

//                return user;
//            }
//        }
//    }
//}
