using Microsoft.AspNetCore.Mvc;

namespace Notebook.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}