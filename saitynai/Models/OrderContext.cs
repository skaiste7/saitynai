using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saitynai.Models
{
    public class OrderContext:DbContext
    {
        internal object Items;
        internal object Users;

        public OrderContext(DbContextOptions<OrderContext>options):base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public object Item { get; internal set; }
        public object User { get; internal set; }
    }
}
