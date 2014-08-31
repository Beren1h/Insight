using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Onus
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ItemId { get; set; }
        
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
        public bool Cleared { get; set; }
        public string Memo { get; set; }

    }
}