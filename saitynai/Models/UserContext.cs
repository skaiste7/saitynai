using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saitynai.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
