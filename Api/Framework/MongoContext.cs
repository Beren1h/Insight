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

            var earningsTotal = earnings.Where(e => e.Date.CompareTo(sum.End) < 0).Sum(e => e.Amount);
            var onusesTotal = earnings.SelectMany(e => e.Onuses).Where(o => o.Date.CompareTo(sum.End) < 0).Sum(o => o.Amount);

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
            var item1 = new Item
            {
                Name = "home insurance",
                Frequency = 1,
                Amount = -75.33m,
                Day = 1
            };

            var item2 = new Item
            {
                Name = "music lessons",
                Frequency = 1,
                Amount = -100m,
                Day = 1
            };

            var item3 = new Item
            {
                Name = "mortgage",
                Frequency = 1,
                Amount = -669.02m,
                Day = 2
            };

            var item4 = new Item {
                Name = "credt 1121",
                Frequency = 1,
                Amount = -100m,
                Day = 4
            };

            var item5 = new Item
            {
                Name = "water",
                Frequency = 3,
                Amount = -153.08m,
                Day = 10
            };

            var item6 = new Item
            {
                Name = "power",
                Frequency = 1,
                Amount = -200m,
                Day = 12
            };

            var item7 = new Item
            {
                Name = "credit 1398",
                Frequency = 1,
                Amount = -150m,
                Day = 15
            };

            var item8 = new Item
            {
                Name = "car payment",
                Frequency = 1,
                Amount = -400m,
                Day = 15
            };

            var item9 = new Item
            {
                Name = "cable",
                Frequency = 1,
                Amount = -226.25m,
                Day = 16
            };

            var item10 = new Item
            {
                Name = "car insurance",
                Frequency = 1,
                Amount = -130.39m,
                Day = 20
            };

            var item11 = new Item
            {
                Name = "wireless",
                Frequency = 1,
                Amount = -156.79m,
                Day = 20
            };

            var item12 = new Item
            {
                Name = "quicken fee",
                Frequency = 1,
                Amount = -5.95m,
                Day = 28
            };

            var item13 = new Item
            {
                Name = "student loan",
                Frequency = 1,
                Amount = -110.67m,
                Day = 28
            };

            var item14 = new Item{
                Name = "paycheck",
                Frequency = 2,
                Amount = 2298.59m,
                Day = 0
            };

            var item15 = new Item
            {
                Name = "gas",
                Frequency = 0,
                Amount = -40m,
                Day = 0
            };

            var item16 = new Item
            {
                Name = "arlene",
                Frequency = 0,
                Amount = -700m,
                Day = 0
            };

            var item17 = new Item
            {
                Name = "default",
                Frequency = -1,
                Amount = 0m,
                Day = -1
            };

            var items = new List<Item> { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17 };
            var collection = _database.GetCollection("items");

            try
            {
                collection.Drop();
                collection.InsertBatch<Item>(items);
            }
            catch
            {
                return false;
            }

            return true;

        }

    }
}