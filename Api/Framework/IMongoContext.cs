﻿using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Framework
{
    public interface IMongoContext
    {
        //string TestRead(string thing);
        //bool AddEntry(Entry entry);
        //Entry GetEntry(string id);
        //bool DropEntries();

        Onus FindLastOnus(string id);
        bool SaveEarning(Earning earning);
        Earning GetEarning(DateTime date);
        Decimal Total(Sum sum);

        Analytic TotalByOnus(Analytic analytics);

        bool InitializeItems();
        IEnumerable<Item> GetItems();
        bool SaveItems(IEnumerable<Item> items);
        bool AddItem(Item item);
        bool DeleteItem(Item item);

        //IEnumerable<LineItem> InitializeLineItem(LineItem start);

        //LineItem FindLastLineItem(LineItem start);
        //test change



    }


}
