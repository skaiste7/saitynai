using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saitynai.Models
{
    public class WorkerContext:DbContext
    {
        internal object Items;
        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
        {
        }
        public DbSet<Worker> Workers { get; set; }
        public object Item { get; internal set; }
    }
}
