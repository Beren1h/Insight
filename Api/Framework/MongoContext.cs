using Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Api.Framework
{
    public class MongoContext : IMongoContext
    {
      
        private MongoDatabase _database;
        private const string DATABASE = "insight";
        private const string ITEMS_COLLECTION = "items";
        private const string EARNING_COLLECTION = "earnings";
        private const string BALANCE_COLLECTION = "balance";

        public MongoContext()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings[DATABASE].ConnectionString);
            var server = client.GetServer();

            _database = server.GetDatabase(DATABASE);
        }

        public Decimal Total(Sum sum)
        {
            var collection = _database.GetCollection<Earning>(EARNING_COLLECTION);

            var earnings = collection.FindAllAs<Earning>();

            var earningsTotal = earnings.Where(e => e.Date.CompareTo(sum.End) <= 0).Sum(e => e.Amount);
            var onusesTotal = earnings.SelectMany(e => e.Onuses).Where(o => o.Date.CompareTo(sum.End) <= 0).Sum(o => o.Amount);

            if (sum.includeOnlyCleared)
            {
                var unclearedTotal = earnings.SelectMany(e => e.Onuses).Where(o => o.Date.CompareTo(sum.End) <= 0 && !o.Cleared).Sum(o => o.Amount);
                onusesTotal -= unclearedTotal;
            }

            Decimal balance = 0;

            if (sum.IncludeBalance)
            {
                var balanceCollection = _database.GetCollection(BALANCE_COLLECTION);
               
                balance = Decimal.Parse(balanceCollection.FindOne().Elements.FirstOrDefault(a => a.Name == "Amount").Value.ToString());
            }



            return earningsTotal + onusesTotal + balance;
        }


        public bool SaveEarning(Earning earning)
        {
            var earnings = _database.GetCollection<Item>(EARNING_COLLECTION);

            try
            {
                earnings.Save(earning);
            }
            catch
            {
                return false;
            }

            return true;
        }


        public Earning GetEarning(DateTime date)
        {
            var collection = _database.GetCollection<Earning>(EARNING_COLLECTION);

            var query = Query.EQ("Date", date);

            var earning = collection.FindOneAs<Earning>(query);

            return earning;
        }

        public Onus FindLastOnus(string id)
        {
            var collection = _database.GetCollection<Earning>(EARNING_COLLECTION);

            var query = Query.ElemMatch("Onuses", Query.EQ("ItemId", ObjectId.Parse(id)));
            
            var earnings = collection.FindAs<Earning>(query);

            Onus max = new Onus { Date = new DateTime(2000,01,01) };

            foreach (var earning in earnings)
            {
                foreach (var onus in earning.Onuses)
                {
                    if (onus.ItemId == id)
                    {
                        if (DateTime.Compare(onus.Date, max.Date) > 0)
                        {
                            max = onus;
                        }
                        
                    }
                }
            }

            return max.Date.Year == 2000 ? null : max;
        }

        public bool DeleteItem(Item item)
        {
            var collection = _database.GetCollection<Item>(ITEMS_COLLECTION);

            try
            {
                collection.Remove(Query.EQ("_id", ObjectId.Parse(item.Id)));
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool AddItem(Item item)
        {
            var collection = _database.GetCollection<Item>(ITEMS_COLLECTION);

            try
            {
                collection.Insert(item);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool SaveItems(IEnumerable<Item> items)
        {
            var collection = _database.GetCollection<Item>(ITEMS_COLLECTION);

            try
            {
                foreach (var item in items)
                {
                    collection.Save(item);
                }
                
            }
            catch
            {
                return false;
            }
            
            return true;
        }

        public IEnumerable<Item> GetItems()
        {
            var collection = _database.GetCollection<Item>(ITEMS_COLLECTION);
            
            return collection.FindAllAs<Item>().SetSortOrder(SortBy.Ascending("Name"));
        }

        public bool InitializeItems()
        {
            return true;
        }

    }
}