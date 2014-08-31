using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Framework
{
    public class LedgerHelper : ILedgerHelper
    {
        private IMongoContext _mongoContext;

        public LedgerHelper(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public IEnumerable<Onus> GetOnusesPerEarning(DateTime thisEarningDate, DateTime nextEarningDate)
        {
            var onuses = new List<Onus>();
            var now = DateTime.Now;
            var items = _mongoContext.GetItems();

            foreach (var item in items)
            {
                if (item.Day == 0)
                {
                    onuses.Add(new Onus
                    {
                        Date = thisEarningDate,
                        Amount = item.Amount,
                        ItemId = item.Id
                    });
                }
                else if (item.Day > 0)
                {
                    var workingDate = new DateTime(now.Year, now.Month, item.Day);

                    var last = _mongoContext.FindLastOnus(item.Id);

                    if (last != null)
                    {
                        switch (item.Frequency)
                        {
                            case 1:
                                workingDate = last.Date.AddMonths(1);
                                break;
                            case 2:
                                workingDate = last.Date.AddDays(14);
                                break;
                            case 3:
                                workingDate = last.Date.AddMonths(2);
                                break;
                            case 4:
                                workingDate = last.Date.AddMonths(6);
                                break;
                            case 5:
                                workingDate = last.Date.AddYears(1);
                                break;
                        }
                    }
                    else
                    {
                        switch (item.Frequency)
                        {
                            case 1:
                                workingDate = new DateTime(now.Year, now.Month, item.Day);
                                if (DateTime.Compare(workingDate, now) < 0)
                                {
                                    workingDate = workingDate.AddMonths(1);
                                }
                                break;
                            case 2:
                                workingDate = new DateTime(2014, 9, 5);
                                break;
                            case 3:
                                workingDate = new DateTime(2014, 9, 10);
                                break;
                            case 4:
                                workingDate = new DateTime(2015, 6, 5);
                                break;
                            case 5:
                                workingDate = new DateTime(2014, 8, 28);
                                break;
                        }
                    }

                    if (workingDate >= thisEarningDate && workingDate < nextEarningDate)
                    {
                        onuses.Add(new Onus
                        {
                            Date = workingDate,
                            Amount = item.Amount,
                            ItemId = item.Id
                        });
                    }
                }

            }

            return onuses;
        }
    }
}