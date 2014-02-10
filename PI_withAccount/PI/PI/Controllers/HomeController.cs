using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Factory;
using LogicLibrary;
using LogicModelLibrary;

namespace PI.Controllers
{
    public class HomeController : AbstractController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View((LogicLibrary.RealEstateLogic)RealEstateLogicFactory.GetInstance());
        }

        

        public ActionResult Search( int id  = 1, int ajax= 0  )
        {
            if (ajax == 1) return PageAjax(id);
            id--;
            if (id < 0)
                return RedirectToRoute("notFound");

            IEnumerable<RealEstate> filtro = RealEstateLogicFactory.GetInstance().GetAll();
            SearchClass auxEstate = new SearchClass(filtro);

            UpdateModel(auxEstate);
            Info info = new Info(auxEstate.filter(), id, Info.SEARCH);
            
            return View("../Destination/Index", info);
        }

        public ActionResult PageAjax(int id = 1)
        {
            id--;
            IEnumerable<RealEstate> filtro = RealEstateLogicFactory.GetInstance().GetAll();
            SearchClass auxEstate = new SearchClass(filtro);
            UpdateModel(auxEstate);
            Info info = new Info(auxEstate.filter(), id, Info.SEARCH);
            return PartialView("../Destination/PartialView", info);
        } 

    }
}
