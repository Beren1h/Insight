using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Framework
{
    public interface IMongoContext
    {
        string TestRead(string thing);
        bool AddEntry(Entry entry);
        Entry GetEntry(string id);
        bool DropEntries();


        bool InitializeItems();
        IEnumerable<Item> GetItems();
        bool SaveItems(IEnumerable<Item> items);



    }


}
