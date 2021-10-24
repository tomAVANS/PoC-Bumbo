using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BumboPoC.Domain
{
    public class TimeEntryRepositorySql:ITimeEntryRepository
    {
        private readonly BumboContext ctx;

        public TimeEntryRepositorySql(BumboContext context)
        {
            ctx = context;
        }
        
        public bool Delete(int Id)
        {

            var toRemove = ctx.TimeEntries.Find(Id);
            if (toRemove != null)
            {
                ctx.TimeEntries.Remove(toRemove);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public TimeEntry Update(TimeEntry entry)
        {
            ctx.Attach(entry);
            ctx.TimeEntries.Update(entry);
            ctx.SaveChanges();
            return entry;
        }
    }
}