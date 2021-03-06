﻿using Rest.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Model.Concrete
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            :base("TestDbConnection")
        {
#if DEBUG
            Database.SetInitializer(new DbInitializers.TestInitializer());
            Database.Initialize(false);
#endif  
        }

        public DbSet<User> Users { get; set; }
    }
}
