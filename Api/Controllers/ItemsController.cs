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
    [EnableCors(origins: "http://insight.org", headers: "*", methods: "*")]
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        private IMongoContext _mongoContext;
        
        public ItemsController(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        [HttpPost]
        [Route("delete")]
        public bool DeleteItem(Item item)
        {
            return _mongoContext.DeleteItem(item);
        }

        [HttpPost]
        [Route("save")]
        public bool SaveItems(IEnumerable<Item> items)
        {
            return _mongoContext.SaveItems(items);
        }

        [HttpPost]
        [Route("add")]
        public bool AddItem(Item item)
        {
            return _mongoContext.AddItem(item);
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Item> GetItems()
        {
            return _mongoContext.GetItems();
        }

        [HttpGet]
        [Route("init")]
        public bool InitializeItems()
        {
            return _mongoContext.InitializeItems();
        }    
    }
}