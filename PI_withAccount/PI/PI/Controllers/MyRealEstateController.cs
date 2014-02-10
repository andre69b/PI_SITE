using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicModelLibrary;

namespace PI.Controllers
{
    public class MyRealEstateController : AbstractController
    {

        [Authorize]
        public ActionResult Page(int id = 1, int ajax= 0 )
        {
            if (ajax == 1) return PageAjax(id);
            id--;
            if (id < 0)
                return RedirectToRoute("notFound");

            Info info = new Info(rl.GeTByUserName(User.Identity.Name), id, Info.DEFAULT);
            return View("../Destination/Index", info);
        }
        [Authorize]
        public ActionResult PageAjax(int id = 1)
        {
            id--;
            Info info = new Info(rl.GeTByUserName(User.Identity.Name), id, Info.DEFAULT);
            return PartialView("../Destination/PartialView", info);
        } 
    }
}
