using Rest.Model.Abstract;
using System.Web.Mvc;
using Rest.Model.Entities;
using System.Web.Mvc.Ajax;

namespace Rest.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository repo;

        public HomeController(IUserRepository repo)
        {
            this.repo = repo;
        }

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }
    }
}
