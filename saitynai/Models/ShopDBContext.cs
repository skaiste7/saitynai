using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saitynai.Models
{
    public class ShopDBContext:DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
