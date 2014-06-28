#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Rest.Model.Concrete;
using Rest.Model.Entities;

namespace Rest.Model.DbInitializers
{
    class TestInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Users.Add(new User { Name = "Alex", Age = 20 });
            context.Users.Add(new User { Name = "Tom", Age = 37 });
        }
    }
}
#endif