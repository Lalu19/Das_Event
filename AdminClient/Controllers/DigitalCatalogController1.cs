using Microsoft.AspNetCore.Mvc;

namespace AdminClient.Controllers
{
    public class DigitalCatalogController1 : Controller
    {
        public IActionResult CreateDigitalCatalog()
        {
            return View();
        }
        public IActionResult ViewDigitalCatalog()
        {
            return View();
        }
        public IActionResult EditDigitalCatalog(int digitalCatalogId)
        {
            ViewBag.digitalCatalogId = digitalCatalogId;
            return View();
        }
    }
}
