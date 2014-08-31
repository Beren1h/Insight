using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Api
{
    public class MongoContext
    {
        private readonly MongoServer _server;
        private readonly MongoDatabase _database;
        private readonly string _connection = ConfigurationManager.ConnectionStrings["rs"].ConnectionString;
        private const string DATABASE = "insight";

        public MongoContext()
        {
            var client = new MongoClient(_connection);
            _server = client.GetServer();
            _database = _server.GetDatabase(DATABASE);
        }

        //public MongoDatabase Database { get { return _database; } }

        public string TestRead()
        {
            var collection = _database.GetCollection("test");
            var x = collection.FindOne();
            return "fail";
            //primaryPreferred
        }

        //public MongoCollection<IStorageType> GetCollection(string name)
        //{
        //    return _database.GetCollection<IStorageType>(name);
        //}

        //public MongoGridFSFileInfo GridFSUpload(MemoryStream ms)
        //{
        //    return _database.GridFS.Upload(ms, new Guid().ToString());
        //}

        //public void GridFSDelete(BsonValue id)
        //{
        //    _database.GridFS.DeleteById(id);
        //}
    }
}
