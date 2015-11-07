using Api.Framework;
using Api.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    [EnableCors(origins: "http://insight.org", headers: "*", methods: "*")]
    [RoutePrefix("api/analytics")]
    public class AnalyticsController : ApiController
    {
        private IMongoContext _mongoContext;

        public AnalyticsController(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        [Route("onus")]
        public Analytic SumByOnus(Analytic analytics)
        {
            var sums = _mongoContext.TotalByOnus(analytics);
            var items = _mongoContext.GetItems();

            var dictionary = new Dictionary<string, decimal>();

            foreach(var sum in sums.SumByOnus)
            {
                var match = items.FirstOrDefault(a => a.Id == sum.Key);
                dictionary.Add(match.Name, sum.Value);
            }

            analytics.SumByOnus = dictionary;

            return analytics;
        }
    }
}
