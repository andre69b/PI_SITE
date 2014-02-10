using System.Collections.Generic;
using System.Web.Mvc;
using LogicModelLibrary;


namespace PI.Controllers
{
    public class ContactController : AbstractController
    {

        List<Contact> conList = new List<Contact>();
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult AddNewContact()
        {
           Contact contact = new Contact();

           if (TryUpdateModel(contact))
           {
               conList.Add(contact);
               return RedirectToAction("Index");
            }
            return Index(); 
        }
    }
}
