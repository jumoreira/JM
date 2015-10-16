using JM.Examples.MVC.Models;
using System.Web.Mvc;

namespace JM.Examples.MVC.Controllers
{
    public class ExamplesController : Controller
    {
        public ActionResult Index()
        {
            var model = new Exemplo() { PropertyString = "Texto" };
            return View(model);
        }
    }
}