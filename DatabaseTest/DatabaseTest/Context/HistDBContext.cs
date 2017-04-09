using DatabaseTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatabaseTest.Context
{
    public class HistDBContext : DbContext
    {
        public DbSet<HistoricalPlaces> HistoricalTable {get;set; }

    }
}