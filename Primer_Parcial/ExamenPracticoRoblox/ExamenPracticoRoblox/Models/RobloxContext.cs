using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamenPracticoRoblox.Models
{
    public class RobloxContext : DbContext
    {
        public RobloxContext() : base("name=RobloxContext")
        {
        }
        public DbSet<Avatar> Avatares { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}