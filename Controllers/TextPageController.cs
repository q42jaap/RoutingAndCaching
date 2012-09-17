using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication5.Controllers
{
  public class TextPageController : Controller
  {
    [OutputCache(Duration = 15)]
    public ActionResult Index(string pageid)
    {
      return View((object)pageid);
    }
  }
}
