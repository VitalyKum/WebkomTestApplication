using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webkom.Models;

namespace Webkom.Data
{
    public class WebkomContext : DbContext
    {
        public WebkomContext(DbContextOptions<WebkomContext> options) : base(options)
        {        
        }
        public DbSet<Switch> Switches { get; set; }
    }
}
