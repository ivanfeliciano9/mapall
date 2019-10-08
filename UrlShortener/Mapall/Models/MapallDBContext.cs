using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mapall.Models
{
    public class MapallDBContext : DbContext
    {
        public MapallDBContext() : base("conMapall") { }

        public DbSet<UrlModel> Urls { get; set; }
    }
}