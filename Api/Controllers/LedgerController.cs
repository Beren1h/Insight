using Api.Framework;
using Api.Models;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    //[EnableCors(origins: "http://insight.org", headers: "Allow-Control-Allow-Origin", methods: "*")]
    [EnableCors(origins: "http://insight.org", headers: "*", methods: "*")]
    [RoutePrefix("api/ledger")]
    public class LedgerController : ApiController
    {
        private IMongoContext _mongoContext;
        
        public LedgerController(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        [HttpPost]
        [Route("items/delete")]
        public bool DeleteItem(Item item)
        {
            return _mongoContext.DeleteItem(item);
        }

        [HttpPost]
        [Route("items/save")]
        public bool SaveItems(IEnumerable<Item> items)
        //public IEnumerable<Item> UpdateItem(IEnumerable<Item> items)
        //public Simple UpdateItem(Simple simples)
        {

            return _mongoContext.SaveItems(items);
        }

        [HttpPost]
        [Route("items/add")]
        public bool AddItem(Item item)
        {
            return _mongoContext.AddItem(item);
        }

        //[HttpPost]
        //[Route("items/update")]
        //public Item UpdateItem(Item item)
        //{
        //    return item;
        //}

        [HttpGet]
        [Route("items/get")]
        public IEnumerable<Item> GetItems()
        {
            return _mongoContext.GetItems();
        }

        [HttpGet]
        [Route("items/init")]
        public bool InitializeItems()
        {
            return _mongoContext.InitializeItems();
        }

                
        [HttpPost]
        [Route("see")]
        public Entry See()
        {
            var item1 = new LineItem
            {
                Date = new DateTime(2014, 08, 01),
                Amount = 112.10m,
                Tag = 1,
                Memo = "test memo 1",
            };

            var item2 = new LineItem
            {
                Date = new DateTime(2014, 08, 10),
                Amount = 179.34m,
                Tag = 1,
                Memo = "test memo 2",
            };

            var entry = new Entry
            {
                Date = new DateTime(2014, 07, 22),
                Amount = 2210.56m,
                LineItems = new List<LineItem> { item1, item2 }
            };

            return entry;
        }

        [HttpPost]
        [Route("send")]
        public Entry Send(Entry entry)
        {
            return entry;
        }

        [HttpGet]
        [Route("get/{id}")]
        public Entry GetEntry(string id)
        {
            //ControllerContext.HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "insight.org");
            


            var entry = _mongoContext.GetEntry(id);

            return entry;
        }

        [HttpGet]
        [Route("drop")]
        public bool Clear()
        {
            return _mongoContext.DropEntries();
        }

        [HttpPost]
        [Route("add")]
        public bool AddTestEntry()
        {
            var item1 = new LineItem
            {
                Date = new DateTime(2014, 08, 01),
                Amount = 112.10m,
                Tag = 1,
                Memo = "test memo 1",
            };

            var item2 = new LineItem
            {
                Date = new DateTime(2014, 08, 10),
                Amount = 179.34m,
                Tag = 1,
                Memo = "test memo 2",
            };

            var entry = new Entry
            {
                Date = new DateTime(2014, 07, 22),
                Amount = 2210.56m,
                LineItems = new List<LineItem> { item1, item2 }
            };
                        
            return _mongoContext.AddEntry(entry);

        }


        //[HttpGet]
        //[Route("get/{name}")]
        //public IEnumerable<string> Entry(string name)
        //{
        //    var item = _mongoContext.TestRead(name);

        //    return new List<string> { item };
        //}
    }
}

