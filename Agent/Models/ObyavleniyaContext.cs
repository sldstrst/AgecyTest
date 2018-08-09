using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Agent.Models
{
    public class ObyavleniyaContext : DbContext
    {
        public ObyavleniyaContext() :
            base("Personliche")
        { }
        public DbSet<Obyavleniya> Obyavleniyas { get; set; }
    }
    
}