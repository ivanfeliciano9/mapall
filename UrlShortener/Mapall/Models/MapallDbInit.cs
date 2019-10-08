using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapall.Models
{
    public class MapallDbInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<MapallDBContext>
    {
        protected override void Seed(MapallDBContext context)
        {
            var list = new List<UrlModel>
            {
                new UrlModel
                {
                    Id = 1,
                    Url ="https://www.mapall.com/website-terms/",
                    Urlshortener ="https://map.in/2345dD"
                }
            };
            list.ForEach(s => context.Urls.Add(s));
            context.SaveChanges();
        }

        public MapallDbInit()
        {
            MapallDBContext context = new MapallDBContext();

            context.Database.CreateIfNotExists();
        }


    }
}