using Api.Framework;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Api.Models
{
    //[ModelBinder(typeof(Test))]
    public class Item
    {
        public Item()
        {
            //BsonClassMap.RegisterClassMap<Item>(map =>
            //{
            //    map.AutoMap();
            //    map.SetIgnoreExtraElements(true);
            //    map.IdMemberMap.SetRepresentation(BsonType.ObjectId).SetIdGenerator(StringObjectIdGenerator.Instance);
            //});
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //public ObjectId _id { get; set; }
        //public string Stringy { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }
        public Decimal Amount { get; set; }
        public int Day { get; set; }
        public string Memo { get; set; }
        public IEnumerable<int> Tags { get; set; }
        public IEnumerable<Item> Items { get; set; }

    }
}