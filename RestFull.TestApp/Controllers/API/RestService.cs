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
        public IEnumerable<User> GetAllUsers()
        {
            return repo.GetAll();
        }

        // GET api/<controller>/{id}
        public User GetUserById(int id)
        {
            User user = repo.Find(id);

            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return user;
        }

        // DELETE api/<controller>
        [HttpDelete]
        public HttpResponseMessage DeleteUser(int id)
        {
            if (repo.RemoveUserById(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, User);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(user);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/<controller>
        [HttpPut]
        public HttpResponseMessage UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repo.Update(user);
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}