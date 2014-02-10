using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Factory;
using LogicLibrary;
using LogicModelLibrary;

namespace PI.Controllers
{
    public class NewRealEstateController : AbstractController
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Index(RealEstate e)
        {           
            string[] photos = new string[Request.Files.Count];
            for (int i = 0; i < Request.Files.Count; ++i)
            {  
                HttpPostedFileBase hpf = Request.Files[i] as HttpPostedFileBase;
                if (hpf != null && !hpf.FileName.Equals(""))
                {
                    photos[i] = hpf.FileName;
                    string save = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", Path.GetFileName(hpf.FileName));
                    hpf.SaveAs(save);
                }
            }
            e.Username = User.Identity.Name;
            e.Photos = new RealEstate.Album() { Highlight = 0, Photos = photos };
            e._Appreciations= new RealEstate.Appreciations();
            e._Appreciations._Appreciations=new List<RealEstate.Appreciation>();
            e._AvailabilityOfTheProperty = new RealEstate.AvailabilityOfTheProperty();
           

            return Redirect("Destination/" + rl.AddRealEstate(e).id);
        }

    }
}
