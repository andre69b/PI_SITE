using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factory;
using LogicLibrary;

namespace PI.Controllers
{
    public class AbstractController : Controller
    {
        protected IRealEstateLogic rl;


        public AbstractController()
        {
            rl = RealEstateLogicFactory.GetInstance();
        }
    }
}
