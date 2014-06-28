using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rest.Model.Concrete;
using Rest.Model.Entities;
using Rest.Model.Abstract;

namespace Rest.WebUI.Controllers.API
{
    public class UserServiceController : ApiController
    {
        // TODO: Implement Ninject resolver
        IUserRepository repo;

        public UserServiceController(IUserRepository repo)
        {
            this.repo = repo;
        }

        // GET api/<controller>
        public IEnumerable<User> GetAll()
        {
            return repo.GetAll();
        }

        public User GetById(int id)
        {
            return repo.Find(id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            repo.RemoveUserById(id);
        }

        [HttpPost]
        public void InsertOrUpdate(User user)
        {
            repo.InsertOrUpdate(user);
        }
    }
}