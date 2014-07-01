using Rest.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Model.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();

        User Find(int id);

        bool RemoveUserById(int id);

        bool Insert(User user);
        
        void Update(User user);
    }
}
