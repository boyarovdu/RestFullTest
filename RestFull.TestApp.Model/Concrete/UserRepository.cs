using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rest.Model.Abstract;
using Rest.Model.Entities;
using System.Data;

namespace Rest.Model.Concrete
{
    public class UserRepository : IUserRepository
    {
        DatabaseContext context;

        public UserRepository()
        {
            context = new DatabaseContext();
        }

        public IQueryable<User> GetAll()
        {
            return context.Users;
        }

        public Entities.User Find(int id)
        {
            return context.Users.Find(id);
        }

        public bool RemoveUserById(int id)
        {
            var requestedUser = context.Users.Find(id);

            if (requestedUser != null)
            {
                context.Users.Remove(requestedUser);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        //public void InsertOrUpdate(User user)
        //{
        //    if (user.Id == default(int))
        //    {
        //        context.Users.Add(user);
        //    }
        //    else
        //    {
        //        context.Entry(user).State = EntityState.Modified;
        //    }

        //    context.SaveChanges();
        //}

        public bool Insert(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
