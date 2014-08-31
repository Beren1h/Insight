using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Framework
{
    public interface ILedgerHelper
    {
        IEnumerable<Onus> GetOnusesPerEarning(DateTime start, DateTime end);

        //IEnumerable<LineItem> GetItemsPerPay(LineItem start, IEnumerable<Item> items, IDictionary<string, DateTime?> lasts);
    }
}
