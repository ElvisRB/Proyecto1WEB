using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto1WEB2.Models
{
    public class RecommendationDb : DbContext
    {
        public RecommendationDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Recommendation> Recommendations { get; set; }
    }
}