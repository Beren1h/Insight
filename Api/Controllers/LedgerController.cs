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
    [RoutePrefix("api/ledger")]
    public class LedgerController : ApiController
    {
        private IMongoContext _mongoContext;
        private ILedgerHelper _helper;
        
        public LedgerController(IMongoContext mongoContext, ILedgerHelper helper)
        {
            _mongoContext = mongoContext;
            _helper = helper;
        }

        [HttpPost]
        [Route("sum")]
        public Decimal Sum(Sum sum)
        {
            return _mongoContext.Total(sum);
        }

        [HttpPost]
        [Route("create")]
        public Earning Create(Earning earning)
        {
            earning.Onuses = _helper.GetOnusesPerEarning(earning.Date, earning.Next);
            return earning;
        }

        [HttpPost]
        [Route("edit")]
        public Earning Edit(Earning earning)
        {
            return _mongoContext.GetEarning(earning.Date);
        }

        [HttpPost]
        [Route("save")]
        public bool Save(Earning earning)
        {
            return _mongoContext.SaveEarning(earning);
        }

    }
}

