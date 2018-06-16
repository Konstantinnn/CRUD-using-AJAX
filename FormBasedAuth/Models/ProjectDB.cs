using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FormBasedAuth.Models
{
    public class ProjectDB : DbContext
    {
        public DbSet<Cars> Cars { get; set; }
    }
    public class ProjectDB1 : DbContext
    {
        public DbSet<Cars> Cars { get; set; }
    }
}